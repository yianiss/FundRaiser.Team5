using FundRaiser_Team5.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
using FundRaiser_Team5.Entities;
using FundRaiser_Team5.Model;

namespace FundRaiser_Team5.Interfaces
{
    public interface IProjectService
    {
       Task<Result<List<Project>>> GetProjectsAsync();

       Task<Result<Project>> CreateProjectAsync(OptionProject options);

       Task<Result<Project>> GetProjectByIdAsync(int id);

       Task<Result<int>> DeleteProjectByIdAsync(int id);
    }
}
