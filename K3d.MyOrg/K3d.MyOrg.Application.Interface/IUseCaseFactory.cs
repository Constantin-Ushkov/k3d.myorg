using K3d.MyOrg.Application.Interface.Spendings;

namespace K3d.MyOrg.Application.Interface
{
    public interface IUseCaseFactory
    {
        ISpendingsUseCaseFactory Spendings { get; }
    }
}
