using FundRaiser.Team5.Core.Model;
using FundRaiser.Team5.Core.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FundRaiser.Team5.Core.Services
{
    public interface IUserFundingPackageService
    {
        public Task<Result<OptionUserFundingPackage>> CreateUserFundingPackageAsync(OptionUserFundingPackage optionUserFundingPackage);
        public Task<Result<List<OptionUserFundingPackage>>> ReadUserFundingPackageAsync();

        public Task<Result<List<OptionUserFundingPackage>>> ReadUserFundingPackagesByProjectIdAsync(int projectId);

        public Task<Result<List<OptionUserFundingPackage>>> ReadUserFundingPackagesByUsertIdAsync(int UserId);
        
        public Task<Result<OptionUserFundingPackage>> ReadUserFundingPackageAsync(int userFundingPackageId);

        public Task<Result<List<OptionUserFundingPackage>>> ReadUserFundingPackageAsync(OptionUserFundingPackage optionUserFundingPackage);

        public Task<Result<OptionUserFundingPackage>> UpdateUserFundingPackageAsync(int userFundingPackageId, OptionUserFundingPackage optionUserFundingPackage);

        public Task<Result<int>> DeleteUserFundingPackageAsync(int userFundingPackageId);

        public Task<Result<int>> GetTotalPriceByProjectId(int projectId);
    }
}
