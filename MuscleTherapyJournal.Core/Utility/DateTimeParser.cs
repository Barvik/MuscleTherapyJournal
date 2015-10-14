using System;

namespace MuscleTherapyJournal.Core.Utility
{
    public static class DateTimeParser
    {
        public static DateTime ParseDateTimeFromDateToString(string fromDate)
        {
            try
            {
                return DateTime.Parse(fromDate);
            }
            catch (Exception)
            {
                return new DateTime(1754, 1, 1, 12, 00, 00);
            }
        }

        public static DateTime ParseDateTimeToDateToString(string fromDate)
        {
            try
            {
                var result =  DateTime.Parse(fromDate);
                result = result.AddDays(1);
                return result;
            }
            catch (Exception)
            {
                return new DateTime(9999, 12, 31, 11, 59, 59);
            }
        }
    }
}

