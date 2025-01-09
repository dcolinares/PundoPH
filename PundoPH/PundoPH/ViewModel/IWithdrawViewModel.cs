using PundoPH.Model;

namespace PundoPH.ViewModel
{
    public interface IWithdrawViewModel
    {
        Task<string> Save(WithdrawModel withdrawModel);
    }
}
