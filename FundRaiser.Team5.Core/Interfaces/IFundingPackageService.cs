using FundRaiser.Team5.Core.Model;
using FundRaiser.Team5.Core.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FundRaiser.Team5.Core.Interfaces
{
    public interface IFundingPackageService
    {
        public Task<Result<OptionFundingPackage>> CreateFundingPackageAsync(OptionFundingPackage optionFundingPackage);

        public Task<Result<List<OptionFundingPackage>>> ReadFundingPackageAsync(); // All??? 

        public Task<Result<List<OptionFundingPackage>>> ReadFundingPackagesByProjectIdAsync(int projectId);

        public Task<Result<OptionFundingPackage>> ReadFundingPackageAsync(int fundingPackageId);

        public Task<Result<List<OptionFundingPackage>>> ReadFundingPackageAsync(OptionFundingPackage optionFundingPackage);

        public Task<Result<OptionFundingPackage>> UpdateFundingPackageAsync(int fundingPackageId, OptionFundingPackage optionFundingPackage);

        public Task<Result<int>> DeleteFundingPackageAsync(int fundingPackageId);

        public Task<Result<OptionFundingPackage>> IncreaseNumberOfAvailablePackagesByFundingPackageIdAsync(int fundingPackageId);

        public Task<Result<OptionFundingPackage>> DecreaseFundingPackageAsync(int fundingPackageId);

    }
}
