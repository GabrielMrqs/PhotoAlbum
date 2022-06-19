using Albums.Domain;
using Albums.Infra.LoginModule;
using Login.Application.DTO.UserModule;
using MediatR;
using Shared.Infra;

namespace Login.Application
{
    public class AddUserHandler : IRequestHandler<AddUserRequest>
    {
        private readonly BaseRepository<User> _userRepository;
        private readonly LoginRepository _loginRepository;

        public AddUserHandler(BaseRepository<User> userRepository, LoginRepository loginRepository)
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

            var user = new User
            {
                Username = userRequest.Username,
                Login = new(userRequest.Email, userRequest.Password)
            };
            await _userRepository.InsertAsync(user);
            return Unit.Value;
        }
    }
    public record AddUserRequest(UserDTO User) : IRequest;
}
