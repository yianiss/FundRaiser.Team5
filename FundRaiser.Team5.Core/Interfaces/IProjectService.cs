using FundRaiser.Team5.Core.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
using FundRaiser.Team5.Core.Entities;
using FundRaiser.Team5.Core.Model;

namespace FundRaiser.Team5.Core.Interfaces
{
    public interface IProjectService
    {
        Task<Result<List<OptionProject>>> GetProjectsAsync();
        Task<Result<OptionProject>> CreateProjectAsync(OptionProject options);
        Task<Result<OptionProject>> GetProjectByIdAsync(int id);
        Task<Result<int>> DeleteProjectByIdAsync(int id);
        Task<Result<OptionProject>> EditProjectAsync(int projectId, OptionProject options);
        Task<Result<OptionProject>> EditProjectAsync(int projectId, decimal options);
        Task<Result<List<OptionProject>>> GetProjectsByCategory(OptionProject optionProject);
        Task<Result<List<OptionProject>>> GetProjectsBySearch(string search);
        Task<Result<List<OptionProject>>> GetActiveProjectsAsync();
        Task<Result<List<OptionProject>>> GetActiveMostFundedProjectsAsync();


    }
}