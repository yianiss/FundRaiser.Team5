using FundRaiser_Team5.Model;
using FundRaiser_Team5.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FundRaiser_Team5.Services
{
    interface IFundingPackageService
    {
        public Task<Result<OptionFundingPackage>> CreateFundingPackageAsync(OptionFundingPackage optionFundingPackage);
        //public Task<Result<List<OptionFundingPackage>>> ReadFundingPackageAsync(); // All??? 
        //public Task<Result<List<OptionFundingPackage>>> ReadFundingPackagesByProjectIdAsync(int projectId);  // ???
        public Task<Result<OptionFundingPackage>> ReadFundingPackageAsync(int fundingPackageId);
        public Task<Result<List<OptionFundingPackage>>> ReadFundingPackageAsync(OptionFundingPackage optionFundingPackage);
        public Task<Result<OptionFundingPackage>> UpdateFundingPackageAsync(int fundingPackageId, OptionFundingPackage optionFundingPackage);
        public Task<Result<int>> DeleteFundingPackageAsync(int fundingPackageId);
    }
}
