using Albums.Infra.LoginModule;
using Logins.Application.DTO.LoginModule;
using MediatR;
using Shared.Infra;
using System.Security.Claims;

namespace Logins.Application
{
    public class LoginHandler : IRequestHandler<LoginRequest, string>
    {
        private readonly LoginRepository _loginRepository;

        public LoginHandler(LoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<string> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var login = request.Login;

            var userId = await _loginRepository.LoginAsync(login.Email, login.Password);

            var expireDate = DateTime.UtcNow.AddDays(1);

            var claims = new Claim[]
            {
                new ("userId", $"{userId}")
            };

            var token = JWTManager.CreateToken(claims, expireDate);
            
            return token;
        }
    }
    public record LoginRequest(LoginDTO Login) : IRequest<string>;
}
