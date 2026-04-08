
namespace K3d.MyOrg.Domain.Spendings
{
    public class SpendingsReport
    {
        public DateOnly FromDate { get; set; }
        public DateOnly ToDate { get; set; }

        public uint Total { get; set; }
        public Dictionary<string, uint> TotalByCategory { get; set; } = [];

        public List<Spending> Spendings { get; set; } = [];
    }
}
