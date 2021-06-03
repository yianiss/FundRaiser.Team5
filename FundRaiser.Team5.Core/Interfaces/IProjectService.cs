using FundRaiser_Team5.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
using FundRaiser_Team5.Model;

namespace FundRaiser_Team5.Interfaces
{
    public interface IProjectService
    {
       Task<Result<List<OptionProject>>> GetProjectsAsync();
       Task<Result<OptionProject>> CreateProjectAsync(OptionProject options);
       Task<Result<OptionProject>> GetProjectByIdAsync(int id);
       Task<Result<int>> DeleteProjectByIdAsync(int id);
    }
}
