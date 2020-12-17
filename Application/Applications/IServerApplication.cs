using Core.Applications;
using Core.Commands.Models;
using Domain.Server.Models.Request;
using System.Threading.Tasks;

namespace Application.Applications
{
    public interface IServerApplication : IApplication
    {
        Task<CommandResult> AddServer(AddServerRequestModel model);
        Task<CommandResult> EditServer(EditServerRquestModel model);
        Task<CommandDataResult<string>> ConnectServer(ConnectServerRequestModel model);
    }
}
