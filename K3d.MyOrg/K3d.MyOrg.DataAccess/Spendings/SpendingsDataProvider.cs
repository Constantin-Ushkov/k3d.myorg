using K3d.MyOrg.Core.Extensions;
using K3d.MyOrg.Core.Logging;
using K3d.MyOrg.DataAccess.Cache;
using K3d.MyOrg.DataAccess.Interface.Spendings;
using K3d.MyOrg.Domain.Spendings;

namespace K3d.MyOrg.DataAccess.Spendings
{
    internal class SpendingsDataProvider(ILogger logger, IDataCache cache) : ISpendingsDataProvider
    {
        private readonly ILogger _logger = logger
            ?? throw new ArgumentNullException(nameof(logger));

        private readonly IDataCache _cache = cache
            ?? throw new ArgumentNullException(nameof(cache));

        public SpendingsReport? GetSpendingsReport(DateOnly fromDate, DateOnly toDate)
        {
            var year = _cache.GetYear(fromDate.Year);

            if (year == null)
            {
                _logger.Warning($"No data for year {fromDate.Year}");
                return null;
            }

            var report = new SpendingsReport
            {
                FromDate = fromDate,
                ToDate = toDate,
            };

            for (var dayOfYear = fromDate.DayOfYear; dayOfYear <= toDate.DayOfYear; dayOfYear++)
            {
                var day = year.GetDay(dayOfYear);

                if (day == null)
                {
                    _logger.Warning($"No data for day {dayOfYear} of year {fromDate.Year}");
                    continue;
                }

                foreach (var spending in day.Spendings ?? [])
                {
                    if (spending == null)
                    {
                        _logger.Warning($"Null spending for day {dayOfYear} of year {fromDate.Year}");
                        continue;
                    }

                    report.Total += spending.Amount;
                    report.Spendings.Add(spending);

                    UpdateCategory(report, spending);
                }
            }

            return report;
        }

        private static void UpdateCategory(SpendingsReport report, Spending spending)
        {
            // example categories:
            // me
            // me\food
            // me\food\lunch

            var category = spending.Category ?? "no_category";

            if (report.TotalByCategory.TryGetValue(category, out var categoryTotal))
            {
                report.TotalByCategory[category] = categoryTotal + spending.Amount;
            }
            else
            {
                report.TotalByCategory[category] = spending.Amount;
            }

            foreach (var parentCategory in GetParentCategories(category))
            {
                if (report.TotalByCategory.TryGetValue(parentCategory, out var parentCategoryTotal))
                {
                    report.TotalByCategory[parentCategory] = parentCategoryTotal + spending.Amount;
                }
                else
                {
                    report.TotalByCategory[parentCategory] = spending.Amount;
                }
            }
        }

        private static string[] GetParentCategories(string category)
        {
            var parentCategories = new List<string>();
            var categoryParts = category.Replace('/', '\\').Split('\\', StringSplitOptions.RemoveEmptyEntries);

            for (var i = categoryParts.Length - 1; i > 0; i--)
            {
                var parentCategory = string.Join('\\', categoryParts.Take(i));
                parentCategories.Add(parentCategory);
            }

            return [.. parentCategories];
        }
    }
}
