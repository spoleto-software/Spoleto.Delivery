namespace Spoleto.Delivery.Helpers
{
    public static class DateTimeHelper
    {
        /// <summary>
        /// Calculates the date that will be after a given number of working days, considering weekends and holidays.
        /// </summary>
        public static DateTime? GetDateAfterWorkingDays(DateTime? startDate, int? workingDays, List<DateTime>? holidays = null)
        {
            if (startDate == null)
            {
                return null;
            }

            if (workingDays == null)
            {
                return null;
            }

            // List of weekend days (Saturday and Sunday)
            var weekendDays = new[] { DayOfWeek.Saturday, DayOfWeek.Sunday };

            // Start date
            var currentDate = startDate;

            // Working days counter
            int workingDaysCounter = 0;

            // Loop until the desired number of working days is reached
            while (workingDaysCounter < workingDays)
            {
                currentDate = currentDate.Value.AddDays(1);

                // Check if the current day is a weekend or a holiday
                if (!weekendDays.Contains(currentDate.Value.DayOfWeek) &&
                    (holidays == null || !holidays.Contains(currentDate.Value.Date))) // Check for holidays if provided
                {
                    workingDaysCounter++;
                }
            }

            return currentDate;
        }
    }
}
