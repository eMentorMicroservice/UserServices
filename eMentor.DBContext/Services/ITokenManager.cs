using System.Threading.Tasks;

namespace eMentor.DBContext.Services
{
    public interface ITokenManager
    {
        Task Logout();
        Task<bool> IsCurrentActiveToken();
        Task DeactivateCurrentAsync();
        Task<bool> IsActiveAsync(string token);
        Task DeactivateAsync(string token);
    }
}
