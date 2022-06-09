using Albums.Infra.LoginModule;
using Login.Application.DTO.ClientModule;
using MediatR;
using Shared.Infra;
using Shared.Infra.Email;
using System.Security.Claims;

namespace Login.Application
{
    public class VerifyClientHandler : IRequestHandler<VerifyClientRequest>
    {
        private readonly LoginRepository _repository;

        public VerifyClientHandler(LoginRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(VerifyClientRequest request, CancellationToken cancellationToken)
        {
            var client = request.Client;

            var alreadyExists = await _repository.ExistsEmailAsync(client.Email);
            if (alreadyExists)
                throw new Exception("Client already registred in database");

            var expireDate = DateTime.UtcNow.AddDays(1);
            var claims = new Claim[]
            {
                new Claim("username", client.Username),
                new Claim("email", client.Email),
                new Claim("password", client.Password),
            };
            var jwt = JWTManager.CreateToken(claims, expireDate);
            await EmailManager.SendVerificationEmail(client.Email, client.Username, jwt);
            return Unit.Value;
        }
    }

    public record VerifyClientRequest(ClientDTO Client) : IRequest;
}