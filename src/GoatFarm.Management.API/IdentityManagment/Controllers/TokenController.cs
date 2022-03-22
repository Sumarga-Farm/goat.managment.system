using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GoatFarm.Management.API.IdentityManagement.Models.Command;
using GoatFarm.Management.API.IdentityManagement.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoatFarm.Management.API.IdentityManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAccessTokenService accessTokenService;

        public TokenController(IAccessTokenService accessTokenService)
        {
            this.accessTokenService = accessTokenService;
        }
        [Route("LoginWithCredentials")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ResponseCache(NoStore = true)]
        public async Task<AccessTokenResponse> LoginWithCredentials([FromBody] LoginWithClientCredentialCommand loginWithCredentialsCommand)
        {
            return await accessTokenService.Login(loginWithCredentialsCommand);
            
        }
    }
}
