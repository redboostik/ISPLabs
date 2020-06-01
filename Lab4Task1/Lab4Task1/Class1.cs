using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Lab4Task1
{
    class Snake
    {
        [DllImport("User32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(Keys vKey);

        private const int halfBlockSize = 10;
        public static bool running = false;
        private int minX, minY, maxX, maxY;
        private List<(int, int)> bodySnake = new List<(int, int)>();
        private int foodX = 0, foodY = 0;
        private int snakeSize;
        private int moveX = 20, moveY;
        private System.Timers.Timer timer;
        private Random rand = new Random();
        public Snake(int x, int y)
        {
            minX = x / 4;
            minY = y / 4;
            maxX = minX + halfBlockSize * 100;
            maxY = minY + halfBlockSize * 60;
            timer = new System.Timers.Timer(150);
            timer.Elapsed += DrawForm;
            timer.AutoReset = true;
            timer.Enabled = true;
            running = true;
            bodySnake.Add((minX + halfBlockSize * 47, minY + halfBlockSize * 31));
            bodySnake.Add((minX + halfBlockSize * 49, minY + halfBlockSize * 31));
            bodySnake.Add((minX + halfBlockSize * 51 , minY + halfBlockSize * 31));
            snakeSize = 3;

        }

        private void SnakeMove()
        {

            if(bodySnake.Count <= snakeSize)bodySnake.Add((bodySnake[snakeSize - 1].Item1 + moveX, bodySnake[snakeSize - 1].Item2 + moveY));
            if(bodySnake[snakeSize - 1].Item1 > maxX - 2 * halfBlockSize || bodySnake[snakeSize - 1].Item1 < minX
               || bodySnake[snakeSize - 1].Item2 > maxY || bodySnake[snakeSize - 1].Item2 < minY)
            {
                timer.Enabled = false;
                running = false;
            }

            for (int i = 0; i < snakeSize; i++) 
                if (bodySnake[snakeSize] == bodySnake[i])
                {
                    timer.Enabled = false;
                    running = false;
                }

            if(bodySnake[snakeSize - 1].Item1 == foodX && bodySnake[snakeSize - 1].Item2 == foodY)
            {
                foodX = 0;
                foodY = 0;
                snakeSize++;
            }else bodySnake.RemoveAt(0);

        }

        private void SpawnFood()
        {
            foodX = rand.Next(0, 49) * 2 * halfBlockSize + halfBlockSize + minX;
            foodY = rand.Next(0, 30) * 2 * halfBlockSize + halfBlockSize + minY;
            for (int i = 0; i < snakeSize; i++) if (bodySnake[i].Item1 == foodX && bodySnake[i].Item2 == foodY) SpawnFood();
        }

        private void ChangeVectorMove()
        {
            if(GetAsyncKeyState(Keys.Left) != 0 && moveX == 0)
            {
                moveX = -20;
                moveY = 0;
            }
            if (GetAsyncKeyState(Keys.Right) != 0 && moveX == 0)
            {
                moveX = 20;
                moveY = 0;
            }
            if (GetAsyncKeyState(Keys.Up) != 0 && moveY == 0)
            {
                moveX = 0;
                moveY = -20;
            }
            if (GetAsyncKeyState(Keys.Down) != 0 && moveY == 0)
            {
                moveX = 0;
                moveY = 20;
            }
        }
        private void DrawForm(Object source, ElapsedEventArgs e)
        {
            if (foodX == 0 && foodY == 0) SpawnFood();
            ChangeVectorMove();
            SnakeMove();

            IntPtr desktopDC = GetDC(IntPtr.Zero);
            Graphics graphics = Graphics.FromHdc(desktopDC);
            graphics.FillRectangle(Brushes.Black, minX - 2 * halfBlockSize, minY - 2 * halfBlockSize, halfBlockSize * 104, halfBlockSize * 64);
            graphics.FillRectangle(Brushes.White, minX, minY, halfBlockSize * 100, halfBlockSize * 60);

            graphics.FillRectangle(Brushes.Yellow, foodX - halfBlockSize, foodY - halfBlockSize, 
                                    2 * halfBlockSize, 2 * halfBlockSize);

            for (int i = 0; i < snakeSize - 1; i++) 
                graphics.FillRectangle(Brushes.Green, bodySnake[i].Item1 - halfBlockSize, bodySnake[i].Item2 - halfBlockSize,
                                       2 * halfBlockSize, 2 * halfBlockSize);

            graphics.FillRectangle(Brushes.Red, bodySnake[snakeSize - 1].Item1 - halfBlockSize, bodySnake[snakeSize - 1].Item2 - halfBlockSize,
                                     2* halfBlockSize, 2 * halfBlockSize);

            graphics.DrawString(snakeSize.ToString(), new Font("Arial", 16), Brushes.Black, new PointF(minX, minY));
            
        }

    }
}