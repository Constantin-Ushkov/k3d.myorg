using K3d.MyOrg.Core.Logging;

namespace K3d.MyOrg.DataAccess.Cache
{
    internal class DataCache(ILogger logger, string baseFolder) : IDataCache
    {
        private readonly ILogger _logger = logger
            ?? throw new ArgumentNullException(nameof(logger));

        private readonly string _baseFolder = baseFolder;
        private readonly Dictionary<int, YearData> _yearsCache = [];

        public IYearData? GetYear(int year)
        {
            if (_yearsCache.TryGetValue(year, out var yearData))
            {
                _logger.Debug("Year {0} found in cache.", year);
                return yearData;
            }

            _logger.Debug("Year {0} not found in cache.", year);
            return null;
        }

        public void Load(string folder)
        {
            LoadYear(DateTime.Now.Year);
        }

        private void LoadYear(int year)
        {
            if (_yearsCache.ContainsKey(year))
            {
                _logger.Debug("Year {0} is already loaded in cache.", year);
                return;
            }

            var yearData = YearData.LoadFromFolder(_logger, _baseFolder, year);

            if (yearData != null)
            {
                _yearsCache[year] = yearData;
            }
        }
    }
}
