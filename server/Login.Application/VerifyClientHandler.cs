using Albums.Infra.ClientModule;
using Login.Application.DTO.ClientModule;
using MediatR;
using Shared.Infra;
using Shared.Infra.Email;
using System.Security.Claims;

namespace Login.Application
{
    public class VerifyClientHandler : IRequestHandler<VerifyClientRequest>
    {
        private readonly ClientRepository _repository;

        public VerifyClientHandler(ClientRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(VerifyClientRequest request, CancellationToken cancellationToken)
        {
            var client = request.Client;

            var response = await _repository.GetByEmailAsync(client.Email);
            if (response is not null)
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