using Albums.Infra.LoginModule;
using Login.Application.DTO.UserModule;
using MediatR;
using Shared.Infra;
using Shared.Infra.Email;
using System.Security.Claims;

namespace Login.Application
{
    public class VerifyUserHandler : IRequestHandler<VerifyUserRequest>
    {
        private readonly LoginRepository _repository;

        public VerifyUserHandler(LoginRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(VerifyUserRequest request, CancellationToken cancellationToken)
        {
            var user = request.User;

            var alreadyExists = await _repository.ExistsEmailAsync(user.Email);
            if (alreadyExists)
                throw new Exception("User already registred in database");

            var expireDate = DateTime.UtcNow.AddDays(1);
            var claims = new Claim[]
            {
                new Claim("username", user.Username),
                new Claim("email", user.Email),
                new Claim("password", user.Password),
            };
            var jwt = JWTManager.CreateToken(claims, expireDate);
            await EmailManager.SendVerificationEmail(user.Email, user.Username, jwt);
            return Unit.Value;
        }
    }

    public record VerifyUserRequest(UserDTO User) : IRequest;
}