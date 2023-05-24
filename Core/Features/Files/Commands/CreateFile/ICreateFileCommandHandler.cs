using System.Threading;
using System.Threading.Tasks;
namespace Core.Features.Files.Commands.CreateFile
{
    public interface ICreateFileCommandHandler
    {
        Task<string> Handle(CreateFileCommand request);
    }
}