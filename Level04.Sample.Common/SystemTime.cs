using System;
using System.Collections.Generic;
using System.Text;

namespace Level04.Sample.Common
{
    public static class SystemTime
    {
        internal static Func<DateTime> SetCurrentTime = () => DateTime.Now;

        internal static Func<DateTime> SetToday = () => DateTime.Today;

        public static DateTime Now => SetCurrentTime();

        public static DateTime Today => SetToday();
    }
}