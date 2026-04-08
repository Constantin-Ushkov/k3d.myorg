
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
            return GetDay(DayData.GetDayOfYear(Year, month, dayOfMonth));
        }

        public static YearData? LoadFromFolder(ILogger logger, string baseFolder, int year)
        {
            var path = Path.Combine(baseFolder, year.ToString());

            if (!Directory.Exists(path))
            {
                logger.Warning("Failed to load year data. Year folder {0} does not exist.", path);
                return null;
            }

            path = Path.Combine(path, "days");

            if (!Directory.Exists(path))
            {
                logger.Warning("Failed to load year data. Days folder {0} does not exist.", path);
                return null;
            }

            var days = new DayData[366];

            foreach (var file in Directory.GetFiles(path, "*.*"))
            {
                var dayData = DayData.LoadFromFile(logger, file, year);

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
    }
}
