
namespace K3d.MyOrg.Domain.Spendings
{
    public class SpendingsOverview
    {
        public SpendingsReport? CurrentYearSpendings { get; set; }
        public SpendingsReport? CurrentMonthSpendings { get; set; }
        public SpendingsReport? CurrentWeekSpendings { get; set; }
    }
}
