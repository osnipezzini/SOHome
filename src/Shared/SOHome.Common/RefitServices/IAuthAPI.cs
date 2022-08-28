using Refit;

using SOHome.Common.DataModels;

using System.Threading.Tasks;

namespace SOHome.Common.RefitServices;

public interface IAuthAPI
{
    [Post("/api/auth")]
    Task<UserDto> Authenticate([Body]LoginModel login);
}
