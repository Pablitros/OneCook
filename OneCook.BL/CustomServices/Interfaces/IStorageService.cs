using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace OneCook.BL.CustomServices.Interfaces
{
    public interface IStorageService
    {
        Task UploadFile(string name, IFormFile file);
    }
}
