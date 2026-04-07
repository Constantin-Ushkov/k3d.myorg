
using K3d.MyOrg.Core.Logging;

namespace K3d.MyOrg.DataAccess.Cache
{
    internal class YearData(ILogger logger, int year, DayData[] days): IYearData
    {
        private readonly ILogger _logger = logger
            ?? throw new ArgumentNullException(nameof(logger));

        private readonly DayData[] _days = days
            ?? throw new ArgumentNullException(nameof(days));

        public int Year { get; } = year;

        public IDayData? GetDay(int dayOfYear)
        {
            if (dayOfYear <= 0 || dayOfYear >= 366)
            {
                _logger.Warning("Invalid day of year {0}. Must be between 1 and 365.", dayOfYear);
                return null;
            }

            return _days[dayOfYear - 1];
        }

        public IDayData? GetDay(int month, int dayOfMonth)
        {
            return GetDay(GetDayOfYear(Year, month, dayOfMonth));
        }

        public static YearData? LoadFromFolder(ILogger logger, string baseFolder, int year)
        {
            var path = Path.Combine(baseFolder, year.ToString());

            if (!Directory.Exists(path))
            {
                logger.Warning("Failed to load year data. Year folder {0} does not exist.", path);
                return null;
            }

            var days = new DayData[366];

            foreach (var file in Directory.GetFiles(path, "*.*"))
            {
                var dayData = DayData.LoadFromFile(logger, file);

                if (dayData != null)
                {
                    if (days[dayData.DayOfYear - 1] != null)
                    {
                        logger.Error("Duplicate day of year {0} in file {1}. Skipping.", dayData.DayOfYear, file);
                        continue;
                    }

                    days[dayData.DayOfYear - 1] = dayData;
                }
            }

            return new YearData(logger, year, days);
        }

        /// <summary>
        /// Returns the day of the year for the given month and day.
        /// </summary>
        /// <param name="month">Month number (1-12)</param>
        /// <param name="day">Day of month (1-31)</param>
        /// <param name="year">Year for leap year calculation</param>
        /// <returns>Day of the year (1-365 or 1-366)</returns>
        private static int GetDayOfYear(int year, int month, int day)
        {
            // Validate month
            if (month < 1 || month > 12)
                throw new ArgumentOutOfRangeException(nameof(month), "Month must be between 1 and 12.");

            // Days in each month (non-leap year by default)
            int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            // Adjust for leap year
            if (DateTime.IsLeapYear(year))
                daysInMonth[1] = 29;

            // Validate day
            if (day < 1 || day > daysInMonth[month - 1])
                throw new ArgumentOutOfRangeException(nameof(day), $"Day must be between 1 and {daysInMonth[month - 1]} for month {month}.");

            // Sum days from previous months
            int dayOfYear = day;
            for (int i = 0; i < month - 1; i++)
            {
                dayOfYear += daysInMonth[i];
            }

            return dayOfYear;
        }
    }
}
