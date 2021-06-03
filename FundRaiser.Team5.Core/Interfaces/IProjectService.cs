using FundRaiser.Team5.Core.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
using FundRaiser.Team5.Core.Entities;
using FundRaiser.Team5.Core.Model;

namespace FundRaiser.Team5.Core.Interfaces
{
    public interface IProjectService
    {
       Task<Result<List<Project>>> GetProjectsAsync();

       Task<Result<Project>> CreateProjectAsync(OptionProject options);

       Task<Result<Project>> GetProjectByIdAsync(int id);

       Task<Result<int>> DeleteProjectByIdAsync(int id);
    }
}
