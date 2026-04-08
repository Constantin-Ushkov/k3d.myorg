
namespace K3d.MyOrg.Core.Helpers
{
    public static class DateOnlyHelper
    {
        public static DateOnly GetCurrentDate()
        {
            return DateOnly.FromDateTime(DateTime.Now);
        }

        public static DateOnly GetCurrentWeekStart()
        {
            var now = GetCurrentDate();
            int diff = (7 + (now.DayOfWeek - DayOfWeek.Monday)) % 7;

            return now.AddDays(-diff);
        }

        public static DateOnly GetCurrentMonthStart()
        {
            var now = GetCurrentDate();
            return new DateOnly(now.Year, now.Month, 1);
        }

        public static DateOnly GetCurrentYearStart()
        {
            var now = GetCurrentDate();
            return new DateOnly(now.Year, 1, 1);
        }
    }
}
