﻿namespace Kudu.Core.Deployment
{
    public class NullLogger : ILogger
    {
        public static NullLogger Instance = new NullLogger();

        public ILogger Log(string value, LogEntryType type)
        {
            return Instance;
        }
    }
}
