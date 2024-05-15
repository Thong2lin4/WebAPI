using Microsoft.AspNetCore.Identity;

namespace LAB_LTW_API.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
