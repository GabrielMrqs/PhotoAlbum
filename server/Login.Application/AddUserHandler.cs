using Albums.Domain;
using Albums.Infra.LoginModule;
using Albums.Infra.UserModule;
using Logins.Application.DTO.UserModule;
using MediatR;

namespace Logins.Application
{
    public class AddUserHandler : IRequestHandler<AddUserRequest>
    {
        private readonly UserRepository _userRepository;
        private readonly LoginRepository _loginRepository;

        public AddUserHandler(UserRepository userRepository, LoginRepository loginRepository)
        {
            _userRepository = userRepository;
            _loginRepository = loginRepository;
        }

        public async Task<Unit> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            var userRequest = request.User;

            var alreadyExists = await _loginRepository.ExistsEmailAsync(userRequest.Email);
            if (alreadyExists)
                throw new Exception("User already registred in database");

            var user = new User(userRequest.Username);
            await _userRepository.Add(user);

            var login = new Login(userRequest.Email, userRequest.Password, user.Id);
            await _loginRepository.Add(login);

            return Unit.Value;
        }
    }
    public record AddUserRequest(UserDTO User) : IRequest;
}
