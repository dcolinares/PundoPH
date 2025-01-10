using PundoPH.Data;
using PundoPH.Model;

namespace PundoPH.Service
{
    public class Service
    {
        public UserService User { get; set; }
        public ContributionService Contribution { get; set; }
        public WithdrawService Withdraw { get; set; }
        
        public Service(UserService userService, ContributionService contributionService, WithdrawService withdrawService) 
        { 
            User = userService;
            Contribution = contributionService;
            Withdraw = withdrawService;
        }
    }
}
