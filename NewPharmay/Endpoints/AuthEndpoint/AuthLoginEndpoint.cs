using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewPharmacy.Data;
using NewPharmacy.Helper.Api;
using NewPharmacy.Services;
using NewPharmacy.Data.Models;
using NewPharmacy.Data.Models.Auth;
using NewPharmacy.Helper;
using System.Threading;
using System.Threading.Tasks;
using static NewPharmacy.Endpoints.Auth.AuthLoginEndpoint;

namespace NewPharmacy.Endpoints.Auth
{
    [Route("auth")]
    public class AuthLoginEndpoint(ApplicationDbContext db, MyAuthService authService) : MyEndpointBaseAsync
        .WithRequest<LoginRequest>
        .WithActionResult<LoginResponse>
    {
        [HttpPost("login")]
        public override async Task<ActionResult<LoginResponse>> HandleAsync(LoginRequest request, CancellationToken cancellationToken = default)
        {
            var loggedInUser = await db.MyAppUsers
         .FirstOrDefaultAsync(u => u.Username == request.Username && u.Password == request.Password, cancellationToken);

            if (loggedInUser == null)
            {
                return Unauthorized(new { Message = "Incorrect username or password" });
            }

            var newAuthToken = await authService.GenerateAuthToken(loggedInUser, cancellationToken);
            var authInfo = authService.GetAuthInfo(newAuthToken);

            return new LoginResponse
            {
                Token = newAuthToken.Value,
                MyAuthInfo = authInfo
            };

        }

        public class LoginRequest
        {
            public required string Username { get; set; }
            public required string Password { get; set; }
        }

        public class LoginResponse
        {
            public required MyAuthInfo? MyAuthInfo { get; set; }
            public string Token { get; internal set; }
        }
    }
}
