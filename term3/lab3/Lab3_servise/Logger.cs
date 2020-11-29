using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework
{
    public static class Logger
    {
        private static NLog.Logger logger = LogManager.GetCurrentClassLogger();

        public static void Log(string message)
        {
            logger.Debug(message);
        }

    }
}
