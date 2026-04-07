using K3d.MyOrg.Application.Interface.Spendings.UseCases;

namespace K3d.MyOrg.Application.Interface.Spendings
{
    public interface ISpendingsUseCaseFactory
    {
        IGetOverviewReportUseCase CreateGetOverviewReportUseCase();
    }
}
