using System;
using FundRaiser_Team5.Options;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundRaiser_Team5.Model;

namespace FundRaiser_Team5.Interfaces
{
    public interface IProjectInterface
    {
       Task<Result<List<OptionProject>>> GetProjectsAsync();
       Task<Result<OptionProject>> CreateProjectAsync(OptionProject options);
       Task<Result<OptionProject>> GetProjectByIdAsync(int id);
       Task<Result<int>> DeleteProjectByIdAsync(int id);
    }

    //public interface IProjectService
    //{
    //    public OptionProject CreateProject(OptionProject optionProject);
    //    public List<OptionProject> ReadProject();
    //    public OptionProject ReadProject(int ProjectId);
    //    public List<OptionProject> ReadProject(OptionProject optionProject);
    //    public OptionProject UpdateProject(OptionProject optionProject, int id);
    //    public bool DeleteUser(int id);

    //}
}
