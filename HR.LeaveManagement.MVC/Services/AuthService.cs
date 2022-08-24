using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Models.Auth;
using HR.LeaveManagement.MVC.Services.Base;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HR.LeaveManagement.MVC.Services
{
    public class AuthService : BaseHttpService, IAuthService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private JwtSecurityTokenHandler _tokenHandler;

        public AuthService(IClient client, ILocalStorageService localStorage, IHttpContextAccessor httpContextAccessor) : base(localStorage, client)
        {
            _httpContextAccessor = httpContextAccessor;
            _tokenHandler = new JwtSecurityTokenHandler();
        }

        public async Task<bool> Register(RegisterVM registration)
        {
            var registrationRequest = new RegistrationRequest()
            {
                FirstName = registration.FirstName,
                LastName = registration.LastName,
                UserName = registration.UserName,
                Email = registration.Email,
                Password = registration.Password
            };
            var response = await _client.RegisterAsync(registrationRequest);

            if (!string.IsNullOrEmpty(response.UserId.ToString()))
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            try
            {
                var authRequest = new AuthRequest()
                {
                    Email = email,
                    Password = password
                };
                var authResponse = await _client.LoginAsync(authRequest);

                if (authResponse.Token != String.Empty)
                {
                    // Get claims from token and build auth user object
                    var tokenContent = _tokenHandler.ReadJwtToken(authResponse.Token);
                    var claims = ParseClaims(tokenContent);
                    var user = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
                    var login = _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user);
                    _localStorage.SetStorageValue("token", authResponse.Token);

                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task Logout()
        {
            _localStorage.ClearStorage(new List<string> { "token" });
            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        private IList<Claim> ParseClaims(JwtSecurityToken tokenContent)
        {
            var claims = tokenContent.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));
            return claims;
        }
    }
}
