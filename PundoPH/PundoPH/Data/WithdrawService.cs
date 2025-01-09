using PundoPH.Model;

namespace PundoPH.Data
{
    public class WithdrawService
    {
        private readonly AppDbContext _appDbContext;
        public WithdrawService(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }

        public WithdrawService() { }

        public async Task<string> Save(WithdrawModel withdrawModel)
        {
            string resutl = "";
            try
            {
                _appDbContext.Withdraws.Add(withdrawModel);
                await _appDbContext.SaveChangesAsync();
            } catch (Exception ex)
            {
                resutl = ex.Message;
            }

            return resutl;
        }
    }
}
