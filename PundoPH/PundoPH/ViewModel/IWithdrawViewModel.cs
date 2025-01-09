using PundoPH.Model;

namespace PundoPH.ViewModel
{
    public interface IWithdrawViewModel
    {
        Task<string> Save(WithdrawModel withdrawModel);
        Task<List<WithdrawModel>> Get();
        Task<List<WithdrawsWithUserModel>> GetWithdrawWithUserl();
    }
}
