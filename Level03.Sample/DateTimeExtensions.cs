using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Level03.Sample
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// To the full taiwan date.
        /// </summary>
        /// <param name="dateTime">The datetime.</param>
        /// <returns>System.String.</returns>
        public static string ToFullTaiwanDate(this DateTime dateTime)
        {
            var taiwanCalendar = new TaiwanCalendar();
            var result = $"民國 {taiwanCalendar.GetYear(dateTime)} 年 {dateTime.Month} 月 {dateTime.Day} 日";
            return result;
        }

        /// <summary>
        /// To the simple taiwan date.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>System.String.</returns>
        public static string ToSimpleTaiwanDate(this DateTime dateTime)
        {
            var taiwanCalendar = new TaiwanCalendar();
            var result = $"{taiwanCalendar.GetYear(dateTime)}/{dateTime.Month}/{dateTime.Day}";
            return result;
        }
    }
}