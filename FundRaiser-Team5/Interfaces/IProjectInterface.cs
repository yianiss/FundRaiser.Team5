using System;
using FundRaiser_Team5.Options;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiser_Team5.Interfaces
{
    public interface IProjectInterface
    {

       Task<Result<List<Project>>> GetProjectsAsync();
       Task<Result<Project>> CreateProjectAsync(OptionProject options);
       Task<Result<Project>> GetProjectByIdAsync(int id);
       Task<Result<int>> DeleteProjectByIdAsync(int id);
    }
}
