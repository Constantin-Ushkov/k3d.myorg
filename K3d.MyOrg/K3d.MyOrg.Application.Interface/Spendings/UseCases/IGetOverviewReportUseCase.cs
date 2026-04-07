using K3d.MyOrg.Domain.Spendings;

namespace K3d.MyOrg.Application.Interface.Spendings.UseCases
{
    public interface IGetOverviewReportUseCase
    {
        SpendingsOverview Execute();
    }
}
