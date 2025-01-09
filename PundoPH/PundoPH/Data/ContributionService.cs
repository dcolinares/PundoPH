using Microsoft.AspNetCore.SignalR;
using PundoPH.Model;

namespace PundoPH.Data
{
    public class ContributionService
    {
        private readonly AppDbContext _appDbContext;

        public ContributionService(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;   
        }

        public ContributionService() { }

        public async Task<string> Save(Contribution contribution)
        {
            string resutl = "";
            try
            {
                _appDbContext.Contributions.Add(contribution);
                await _appDbContext.SaveChangesAsync();
            } catch (Exception ex) {
                resutl = ex.Message;
            }

            return resutl;
        }

        public async Task<string> Update(Contribution contribution)
        {
            string resutl = "";
            try
            {
                _appDbContext.Contributions.Update(contribution);
                await _appDbContext.SaveChangesAsync();
            } catch (Exception ex)
            {
                resutl = ex.Message;
            }

            return resutl;
        }

        public async Task<string> Delete(int contributionID)
        {
            string resutl = "";
            try
            {
                Contribution = _appDbContext.Contributions.FirstOrDefault(x => x.ContributionID.Equals(contributionID));
                _appDbContext.Contributions.Remove(Contribution);
                await _appDbContext.SaveChangesAsync();
            } catch (Exception ex)
            {
                resutl = ex.Message;
            }

            return resutl;
        }

        public async Task<List<Contribution>> GetContribution()
        {
            var contribution = _appDbContext.Contributions.OrderByDescending(x=>x.ContributionID).ToList();
            return (contribution);
        }

        public async Task Get(int contributionID)
        {
            Contribution = _appDbContext.Contributions.FirstOrDefault(x=>x.ContributionID.Equals(contributionID));
        }

        public Contribution? Contribution { get; set; }
    }
}
