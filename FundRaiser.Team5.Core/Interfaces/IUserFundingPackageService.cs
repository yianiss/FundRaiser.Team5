using FundRaiser_Team5.Model;
using FundRaiser_Team5.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FundRaiser_Team5.Services
{
    interface IUserFundingPackageService
    {
        public Task<Result<OptionUserFundingPackage>> CreateUserFundingPackageAsync(OptionUserFundingPackage optionUserFundingPackage);

        public Task<Result<List<OptionUserFundingPackage>>> ReadUserFundingPackageAsync(); // All??? 

        public Task<Result<List<OptionUserFundingPackage>>> ReadUserFundingPackagesByProjectIdAsync(int projectId);  // ???

        public Task<Result<OptionUserFundingPackage>> ReadUserFundingPackageAsync(int userFundingPackageId);

        public Task<Result<List<OptionUserFundingPackage>>> ReadUserFundingPackageAsync(OptionUserFundingPackage optionUserFundingPackage);

        public Task<Result<OptionUserFundingPackage>> UpdateUserFundingPackageAsync(int userFundingPackageId, OptionUserFundingPackage optionUserFundingPackage);

        public Task<Result<int>> DeleteUserFundingPackageAsync(int userFundingPackageId);
    }
}
