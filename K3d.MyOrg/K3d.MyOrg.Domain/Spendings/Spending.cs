
namespace K3d.MyOrg.Domain.Spendings
{
    public class Spending
    {
        public string? Name { get; set; }
        public int Amount { get; set; }
        public string? Category { get; set; }
        public DateTime Date { get; set; }
        public string[] Tags { get; set; } = Array.Empty<string>();
    }
}
