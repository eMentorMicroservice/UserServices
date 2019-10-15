using static eMentor.Common.Utils.UtilEnum;

namespace eMentor.DBContext.Services
{
    public interface IJwtHandler
    {
        string Create(string id, int expireToken, UserRole role);
    }
}
