using Albums.Infra.LoginModule;
using Login.Application.DTO.LoginModule;
using MediatR;

namespace Login.Application
{
    public class LoginHandler : IRequestHandler<LoginRequest, Guid?>
    {
        private readonly LoginRepository _repository;

        public LoginHandler(LoginRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid?> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var login = request.Login;
            return await _repository.LoginAsync(login.Email, login.Password);
        }
    }
    public record LoginRequest(LoginDTO Login) : IRequest<Guid?>;
}
