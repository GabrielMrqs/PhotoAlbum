using Albums.Infra.ClientModule;
using Albums.Domain;
using Login.Application.DTO.ClientModule;
using MediatR;

namespace Login.Application
{
    public class AddClientHandler : IRequestHandler<AddClientRequest>
    {
        private readonly ClientRepository _repository;

        public AddClientHandler(ClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(AddClientRequest request, CancellationToken cancellationToken)
        {
            var clientRequest = request.Client;

            var response = await _repository.GetByEmailAsync(clientRequest.Email);
            if (response is not null)
                throw new Exception("Client already registred in database");

            var client = new Client
            {
                Username = clientRequest.Username,
                Email = clientRequest.Email,
                Password = clientRequest.Password,
            };
            await _repository.InsertAsync(client);
            return Unit.Value;
        }
    }
    public record AddClientRequest(ClientDTO Client) : IRequest;
}
