using Core.Applications;
using Core.Commands.Models;
using Domain.Project.Models.Request;
using System.Threading.Tasks;

namespace Application.Applications
{
    public interface IProjectApplication : IApplication
    {
        Task<CommandResult> AddProject(AddProjectRequestModel model);
    }
}
