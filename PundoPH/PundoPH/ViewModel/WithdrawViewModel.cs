using PundoPH.Data;
using PundoPH.Model;

namespace PundoPH.ViewModel
{
    public class WithdrawViewModel: IWithdrawViewModel
    {
        public List<WithdrawModel> WithdrawModels { get; set; }
        public List<WithdrawsWithUserModel> withdrawsWithUserModels { get; set; }
        public WithdrawModel WithdrawModel { get; set; }

        private readonly WithdrawService _withdrawService;
        public WithdrawViewModel(WithdrawService withdrawService)
        {
            _withdrawService = withdrawService;
        }
        public WithdrawViewModel() { }

        public async Task<string> Save(WithdrawModel withdrawModel)
        {
            string result = await _withdrawService.Save(withdrawModel);
            return result;
        }

        public async Task<List<WithdrawModel>> Get()
        {
            WithdrawModels = await _withdrawService.Get();
            return WithdrawModels;
        }

        public async Task<List<WithdrawsWithUserModel>> GetWithdrawWithUserl()
        {
            withdrawsWithUserModels = await _withdrawService.GetWithdrawWithUser();
            return withdrawsWithUserModels;
        }
    }
}
