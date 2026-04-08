
using K3d.MyOrg.Core.Logging;
using K3d.MyOrg.Domain.Spendings;

namespace K3d.MyOrg.DataAccess.Cache
{
    internal class DayData(ILogger log) : IDayData
    {
        private static readonly Dictionary<string, int> _monthMapping = new()
        {
            { "jan", 1 },
            { "feb", 2 },
            { "mar", 3 },
            { "apr", 4 },
            { "may", 5 },
            { "jun", 6 },
            { "jul", 7 },
            { "aug", 8 },
            { "sep", 9 },
            { "oct", 10 },
            { "nov", 11 },
            { "dec", 12 }
        };

        private static readonly Dictionary<string, int> _dayOfWeekMapping = new()
        {
            { "mon", 1 },
            { "tue", 2 },
            { "wed", 3 },
            { "thu", 4 },
            { "fri", 5 },
            { "sat", 6 },
            { "sun", 7 }
        };

        private readonly ILogger _logger = log
            ?? throw new ArgumentNullException(nameof(log));

        public int DayOfYear { get; private set; }
        public int DayOfMonth { get; private set; }
        public int DayOfWeek { get; private set; }

        public int Month { get; private set; }
        public int Year { get; private set; }

        public IList<Spending> Spendings { get; } = [];

        private void ParseSpendings(string[] lines)
        {
            // we expect something like [spending\21:00] 30  - me\food

            foreach (var line in lines)
            {
                var lowerLine = line.ToLower().Trim();

                if (!lowerLine.StartsWith("[spending"))
                {
                    continue;
                }

                var parts = lowerLine.Split(new[] { ' ', '-', }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length < 3)
                {
                    _logger.Warning("Invalid spending line format: {0}. Expected at least 3 parts.", line);
                    continue;
                }

                if (!uint.TryParse(parts[1], out var amount))
                {
                    _logger.Warning("Invalid spending amount: {0} in line: {1}.", parts[1], line);
                    continue;
                }

                TimeOnly? spendingTime = null;

                if (parts[0].Contains(':')) // we have time
                {
                    if (!TryParseSpendingTime(_logger, parts[0], out var time))
                    {
                        _logger.Warning("Failed to parse spending time in line: {0}. Skipping time.", line);
                    }
                    else
                    {
                        spendingTime = time;
                    }
                }

                var spendingDate = new DateTime(Year, Month, DayOfMonth);

                if (spendingTime.HasValue)
                {
                    spendingDate = spendingDate.Add(spendingTime.Value.ToTimeSpan());
                }

                var spending = new Spending()
                {
                    Amount = amount,
                    Date = spendingDate,
                    Category = parts[2].Trim()
                };

                Spendings.Add(spending);
            }
        }

        public static DayData? LoadFromFile(ILogger logger, string filePath, int year)
        {
            if (!File.Exists(filePath))
            {
                logger.Error("File not found: {0}", filePath);
                return null;
            }

            int month;
            int dayOfYear;
            int dayOfMonth;
            int dayOfWeek;

            if (!TryParseFileName(logger, filePath, out month, out dayOfYear, out dayOfMonth, out dayOfWeek))
            {
                logger.Error("Failed to parse file name: {0}", filePath);
                return null;
            }

            var day = new DayData(logger)
            {
                Year = year,
                Month = month,
                DayOfYear = dayOfYear,
                DayOfMonth = dayOfMonth,
                DayOfWeek = dayOfWeek
            };

            var lines = File.ReadAllLines(filePath);

            if (lines == null || lines.Length == 0)
            {
                logger.Warning("File is empty: {0}", filePath);
                return day;
            }

            day.ParseSpendings(lines);

            return day;
        }

        /// <summary>
        /// Returns the day of the year for the given month and day.
        /// </summary>
        /// <param name="month">Month number (1-12)</param>
        /// <param name="day">Day of month (1-31)</param>
        /// <param name="year">Year for leap year calculation</param>
        /// <returns>Day of the year (1-365 or 1-366)</returns>
        public static int GetDayOfYear(int year, int month, int day)
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

        public static bool TryParseFileName(ILogger logger, string fileName, out int month, out int dayOfYear, out int dayOfMonth, out int dayOfWeek)
        {
            var parts = Path.GetFileNameWithoutExtension(fileName).Split('_');

            month = -1;
            dayOfYear = -1;
            dayOfMonth = -1;
            dayOfWeek = -1;

            if (parts.Length != 5)
            {
                logger.Error("Invalid file name: {0}. Expected to have 5 parts.", fileName);
                return false;
            }

            if (parts[0].ToLower() != "day")
            {
                logger.Error("Invalid file name: {0}. Expected to start with 'day'.", fileName);
                return false;
            }

            // Try parse day of year
            if (!int.TryParse(parts[1], out dayOfYear))
            {
                logger.Error("Invalid day of year in file name: {0}.", fileName);
                return false;
            }

            if (dayOfYear < 1 || dayOfYear > 366)
            {
                logger.Error("Day of year out of range in file name: {0}.", fileName);
                return false;
            }

            // Try to parse month
            if (!TryParseMonth(parts[2], out month))
            {
                logger.Error("Invalid month in file name: {0}.", fileName);
                return false;
            }

            // Try to parse day of day of month
            if (!int.TryParse(parts[3], out dayOfMonth))
            {
                logger.Error("Invalid day of month in file name: {0}.", fileName);
                return false;
            }

            if (dayOfMonth < 1 || dayOfMonth > 31)
            {
                logger.Error("Day of month out of range in file name: {0}.", fileName);
                return false;
            }

            // Try to parse day of week
            if (!TryParseDayOfWeek(parts[4], out dayOfWeek))
            {
                logger.Error("Invalid day of week in file name: {0}.", fileName);
                return false;
            }

            return true;
        }

        public static bool TryParseMonth(string monthStr, out int month)
        {
            return _monthMapping.TryGetValue(monthStr.ToLower(), out month);
        }

        public static bool TryParseDayOfWeek(string dayStr, out int day)
        {
            return _dayOfWeekMapping.TryGetValue(dayStr.ToLower(), out day);
        }

        private static bool TryParseSpendingTime(ILogger logger, string timeStr, out TimeOnly time)
        {
            // we expect something like [spending\21:00]

            time = TimeOnly.MinValue;

            var parts = timeStr.Split([@"\", @"/", "[", "]", ":"], StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 3)
            {
                lock (logger)
                {
                    logger.Warning("Invalid spending time format: {0}. Expected format like [spending\\21:00].", timeStr);
                }

                return false;
            }

            if (!int.TryParse(parts[1], out var hour) || hour < 0 || hour > 23)
            {
                lock (logger)
                {
                    logger.Warning("Invalid hour in spending time: {0}. Hour must be between 0 and 23.", timeStr);
                }

                return false;
            }

            if (!int.TryParse(parts[2], out var minute) || minute < 0 || minute > 59)
            {
                lock (logger)
                {
                    logger.Warning("Invalid minute in spending time: {0}. Minute must be between 0 and 59.", timeStr);
                }

                return false;
            }

            time = TimeOnly.FromTimeSpan(new TimeSpan(hour, minute, 0));
            return true;
        }
    }
}
