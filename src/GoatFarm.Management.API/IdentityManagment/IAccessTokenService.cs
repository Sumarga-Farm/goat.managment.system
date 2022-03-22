using GoatFarm.Management.API.IdentityManagement.Models.Command;
using GoatFarm.Management.API.IdentityManagement.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoatFarm.Management.API.IdentityManagement
{
    public interface IAccessTokenService
    {
        Task<AccessTokenResponse> Login(LoginWithClientCredentialCommand loginWithClientCredentialCommand);
    }
}
