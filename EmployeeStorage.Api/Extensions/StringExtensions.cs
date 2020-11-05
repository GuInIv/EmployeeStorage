using System;
using System.Globalization;

namespace EmployeeStorage.Api.Extensions
{
    public static class StringExtensions
    {
        public static bool ToDate(this string value, string[] dateFormat, out DateTime scheduleDate)
        {
            if (DateTime.TryParseExact(value, dateFormat, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out scheduleDate))
            {
                return true;
            }

            return false;
        }
    }
}
