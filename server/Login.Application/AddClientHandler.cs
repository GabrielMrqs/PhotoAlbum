using Albums.Domain;
using Albums.Infra.LoginModule;
using Login.Application.DTO.ClientModule;
using MediatR;
using Shared.Infra;

namespace Login.Application
{
    public class AddClientHandler : IRequestHandler<AddClientRequest>
    {
        private readonly BaseRepository<Client> _clientRepository;
        private readonly LoginRepository _loginRepository;

        public AddClientHandler(BaseRepository<Client> clientRepository, LoginRepository loginRepository)
        {
            _clientRepository = clientRepository;
            _loginRepository = loginRepository;
        }

        public async Task<Unit> Handle(AddClientRequest request, CancellationToken cancellationToken)
        {
            var clientRequest = request.Client;

            var alreadyExists = await _loginRepository.ExistsEmailAsync(clientRequest.Email);
            if (alreadyExists)
                throw new Exception("Client already registred in database");

            var client = new Client
            {
                Username = clientRequest.Username,
                Login = new(clientRequest.Email, clientRequest.Password)
            };
            await _clientRepository.InsertAsync(client);
            return Unit.Value;
        }
    }
    public record AddClientRequest(ClientDTO Client) : IRequest;
}
