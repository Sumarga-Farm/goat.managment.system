using CSharpFunctionalExtensions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using GoatFarm.Management.API.IdentityManagement.Models.Command;
using GoatFarm.Management.API.IdentityManagement.Models.Response;
using GoatFarm.Management.Domain.IdentityManagement;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GoatFarm.Management.API.IdentityManagement
{
    public class AccessTokenService : IAccessTokenService
    {
        private readonly IUserRepository userService;
        private readonly AccessTokenOptions accessTokenOptions;

        public AccessTokenService(
            IUserRepository userService,
            IOptions<AccessTokenOptions> accessTokenOptions)
        {
            this.userService = userService;
            this.accessTokenOptions = accessTokenOptions.Value;
        }
        public async Task<AccessTokenResponse> Login(LoginWithClientCredentialCommand loginWithClientCredentialCommand)
        {
            Maybe<User> maybeUser = await userService.GetUserAsync(loginWithClientCredentialCommand.UserName, loginWithClientCredentialCommand.Password);
            if (maybeUser.HasNoValue)
            {
                throw new InvalidCredentialException("Invalid credentials");
            }
            return GenerateAccessTokenWithUser(maybeUser.Value);
        }

        private AccessTokenResponse GenerateAccessTokenWithUser(User user)
        {
            ClaimsIdentity identity = BuildIdentityWith(user);
            SecurityTokenDescriptor tokenDescriptor = BuildSecurityTokenDescriptor(identity);
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            return MapToAccessTokenResponse(tokenHandler, securityToken);
        }

        private static AccessTokenResponse MapToAccessTokenResponse(JwtSecurityTokenHandler tokenHandler, SecurityToken securityToken) => new AccessTokenResponse
        {

            access_token = tokenHandler.WriteToken(securityToken),
            expires_in = (int)(securityToken.ValidTo - securityToken.ValidFrom).TotalSeconds,
            token_type = "bearer"
        };

        private SecurityTokenDescriptor BuildSecurityTokenDescriptor(ClaimsIdentity identity)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(accessTokenOptions.SecretKey));
            return new SecurityTokenDescriptor
            {
                Subject = identity,
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature),
                Expires = DateTime.UtcNow.AddHours(accessTokenOptions.ExpiresInHours),
                Issuer = accessTokenOptions.Issuer,
                Audience = accessTokenOptions.Audience
            };
        }

        private ClaimsIdentity BuildIdentityWith(User user)
        {
            ClaimsIdentity identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimConstants.TenantId, user.TenantId.ToString()),
                new Claim(ClaimConstants.FarmId, user.FarmId.ToString())
            });
            return identity;
        }
    }
}
