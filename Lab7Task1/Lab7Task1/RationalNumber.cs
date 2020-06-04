using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab7Task1
{
    class RationalNumber : IComparable<RationalNumber>, IEquatable<RationalNumber>
    {
        private long upNumber = 0;
        private long downNumber = 1;

        public RationalNumber(long newUpNumber, long newDownNumber)
        {
            upNumber = newUpNumber;
            downNumber = newDownNumber;
        }
        public RationalNumber(long newUpNumber)
        {
            upNumber = newUpNumber;
            downNumber = 1;
        }

        public RationalNumber(double number)
        {
            RationalNumber rational = new RationalNumber(number.ToString());
            upNumber = rational.upNumber;
            downNumber = rational.downNumber;
        }

        public RationalNumber(string s)
        {
            s += ' ';
            Regex patternInt = new Regex("[\\+\\-]?[0-9]+");
            Regex patternDouble = new Regex("[\\+\\-]?[0-9]+[.,][0-9]+");
            Regex patternRational = new Regex("[\\+\\-]?[0-9]+\\/[0-9]+");

            if (patternInt.IsMatch(s))
            {
                MatchCollection matches = patternInt.Matches(s);

                if (matches.Count == 1)
                {
                    upNumber = Convert.ToInt64(matches[0].Value);
                    downNumber = 1;
                }
            }
            if (patternDouble.IsMatch(s))
            {
                MatchCollection matches = patternDouble.Matches(s);

                if (matches.Count == 1)
                {

                    string stringNumber = matches[0].Value;
                    string stringUpNumber = "";
                    string stringDownNumber = "1";
                    int i = 0;
                    for(; stringNumber[i] != '.' && stringNumber[i] != ','; i++)
                    {
                        stringUpNumber += stringNumber[i];
                    }
                    i++;
                    for(; i < stringNumber.Length; i++)
                    {
                        stringUpNumber += stringNumber[i];
                        stringDownNumber += '0';
                    }

                    upNumber = Convert.ToInt64(stringUpNumber);
                    downNumber = Convert.ToInt64(stringDownNumber);
                }
            }

            if (patternRational.IsMatch(s))
            {
                MatchCollection matches = patternDouble.Matches(s);

                if (matches.Count == 1)
                {

                    string stringNumber = matches[0].Value;
                    string stringUpNumber = "";
                    string stringDownNumber = "";
                    int i = 0;
                    for (; stringNumber[i] != '/'; i++)
                    {
                        stringUpNumber += stringNumber[i];
                    }
                    i++;
                    for (; i < stringNumber.Length; i++)
                    {
                        stringDownNumber += stringNumber[i];
                    }

                    upNumber = Convert.ToInt64(stringUpNumber);
                    downNumber = Convert.ToInt64(stringDownNumber);
                }
            }
        }
        private double ToDouble()
        {

            return upNumber / 1.0 / downNumber;
        }

        public string ToStringRational()
        {
            return upNumber.ToString() + '/' + downNumber.ToString();
        }

        public string ToStringDouble()
        {
            double k = ToDouble();
            return ToDouble().ToString();
        }

        public string ToStringInt()
        {
            return upNumber.ToString();
        }

        public override string ToString()
        {
            return this.ToString();
        }
        public string ToString( string format = "rational")
        {
            if (format  == "ratiaonal") return ToStringRational();
            else
            if (format  == "int") return ToStringInt();
            else
            return ToStringDouble();
            
            
        }

        public int CompareTo(RationalNumber obj)
        {
            if (this.ToDouble() == obj.ToDouble()) return 0;
            return (this.ToDouble() > obj.ToDouble() ? 1 : -1);
        }

        public bool Equals(RationalNumber obj)
        {
            return (this.ToDouble() == obj.ToDouble() ? true : false);
        }

        private static long __gcd(long a, long b)
        {
            while (a != 0 && b != 0)
            {
                if (a >= b) a %= b;
                else
                b %= a;    
            }
            return a + b;
        }
        private static long __lmc(long a, long b)
        {
            return (a * b) / __gcd(a, b);
        }

        public static RationalNumber operator +(RationalNumber left, RationalNumber right)
        {

            long newDownNumber = __lmc(left.downNumber, right.downNumber);
            long newUpNumber = 0;

            newUpNumber += (left.upNumber * (newDownNumber / left.downNumber));
            newUpNumber += (right.upNumber * (newDownNumber / right.downNumber));

            return new RationalNumber(newUpNumber, newDownNumber);
        }


        public static RationalNumber operator -(RationalNumber left, RationalNumber right)
        {
            long newDownNumber = __lmc(left.downNumber, right.downNumber);
            long newUpNumber = 0;

            newUpNumber += (left.upNumber * (newDownNumber / left.downNumber));
            newUpNumber -= (right.upNumber * (newDownNumber / right.downNumber));

            return new RationalNumber(newUpNumber, newDownNumber);
        }

        public static RationalNumber operator *(RationalNumber left, RationalNumber right)
        {
            long newupNumber = left.upNumber * right.upNumber;
            long newdownNumber = left.downNumber * right.downNumber;
            if (newdownNumber < 0)
            {
                newdownNumber *= -1;
                newupNumber *= -1;
            }
            return new RationalNumber(newupNumber, newdownNumber);
        }

        public static RationalNumber operator /(RationalNumber left, RationalNumber right)
        {
            long newupNumber = left.upNumber * right.downNumber;
            long newdownNumber = left.downNumber * right.upNumber;
            if (newdownNumber < 0)
            {
                newdownNumber *= -1;
                newupNumber *= -1;
            }
            return new RationalNumber(newupNumber, newdownNumber);
        }

        public static bool operator <=(RationalNumber left, RationalNumber right)
        {
            return left.CompareTo(right) != 1;
        }

        public static bool operator >=(RationalNumber left, RationalNumber right)
        {
            return left.CompareTo(right) != -1;
        }

        public static bool operator <(RationalNumber left, RationalNumber right)
        {
            return left.CompareTo(right) == -1;
        }

        public static bool operator >(RationalNumber left, RationalNumber right)
        {
            return left.CompareTo(right) == 1;
        }

        public static bool operator ==(RationalNumber left, RationalNumber right)
        {
            return left.CompareTo(right) == 0;
        }

        public static bool operator !=(RationalNumber left, RationalNumber right)
        {
            return left.CompareTo(right) != 0;
        }

        public static RationalNumber operator ++(RationalNumber RationalNumber)
        {
            return (RationalNumber + new RationalNumber(1));
        }

        public static RationalNumber operator --(RationalNumber RationalNumber)
        {
            return (RationalNumber - new RationalNumber(1));
        }

        public static bool operator true(RationalNumber RationalNumber)
        {
            return (RationalNumber.upNumber != 0);
        }

        public static bool operator false(RationalNumber RationalNumber)
        {
            return (RationalNumber.upNumber == 0);
        }

        public static implicit operator RationalNumber(long number)
        {
            return new RationalNumber(number);
        }

        public static implicit operator RationalNumber(double irrational)
        {
            return new RationalNumber(irrational);
        }

        /* operators for `long`*/
        public static RationalNumber operator +(RationalNumber left, long right)
        {
            return (left + new RationalNumber(right));
        }

        public static RationalNumber operator -(RationalNumber left, long right)
        {
            return (left - new RationalNumber(right));
        }

        public static RationalNumber operator *(RationalNumber left, long right)
        {
            return (left * new RationalNumber(right));
        }

        public static RationalNumber operator /(RationalNumber left, long right)
        {
            return (left * new RationalNumber(right));
        }

        public static explicit operator long(RationalNumber RationalNumber)
        {
            return RationalNumber.upNumber / RationalNumber.downNumber;
        }

        /* operators for `double`*/

        public static RationalNumber operator +(RationalNumber left, double right)
        {
            return (left + new RationalNumber(right));
        }

        public static RationalNumber operator -(RationalNumber left, double right)
        {
            return (left - new RationalNumber(right));
        }

        public static RationalNumber operator *(RationalNumber left, double right)
        {
            return (left * new RationalNumber(right));
        }

        public static RationalNumber operator /(RationalNumber left, double right)
        {
            return (left / new RationalNumber(right));
        }

        public static explicit operator double(RationalNumber RationalNumber)
        {
            return (RationalNumber.upNumber + 0.0) / RationalNumber.downNumber;
        }
        public override bool Equals(object obj)
        {
            return CompareTo(obj as RationalNumber) == 0;
        }
        public override int GetHashCode()
        {
            return upNumber.GetHashCode() + downNumber.GetHashCode();
        }
    }
}
