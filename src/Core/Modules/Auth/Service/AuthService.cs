using quiz_app_api.src.Core.Database;
using quiz_app_api.src.Core.Database.Model;
using quiz_app_api.src.Core.Modules.Auth.Dto;
using quiz_app_api.src.Core.Modules.User;
using quiz_app_api.src.Core.Ultils;
using quiz_app_api.src.Packages.HttpExceptions;

namespace quiz_app_api.src.Core.Modules.Auth.Service
{
    public class AuthService
    {
        private readonly BCryptService bCryptService;
        private readonly UserRepository userRepository;
        private readonly JwtService jwtService;
        public AuthService(AppDbContext context)
        {
            bCryptService = new BCryptService();
            jwtService = new JwtService();
            userRepository = new UserRepository(context);
        }

        public object Login(LoginDto model)
        {
            var user = userRepository.GetUserByUsername(model.username);

            if (user == null || !bCryptService.Verify(model.password, user.password))
            {
                throw new BadRequestException(AuthEnum.LOGIN_INCORRECT);
            }

            var accessToken = jwtService.GenerateAccessToken(user);

            var refreshToken = jwtService.GenerateRefreshToken(user);

            user.refresh_token = refreshToken;

            userRepository.CreateOrUpdateUser(user);

            return new
            {
                message = AuthEnum.LOGIN_SUCCESS,
                data = new
                {
                    accessToken,
                    refreshToken,
                }
            };
        }
        public object Register(RegisterDto model)
        {
            if (model.password != model.confirm_password)
            {
                throw new BadRequestException(AuthEnum.CONFIRM_PASSWORDS_NOT_MATCH);
            }

            Optional.Of(userRepository.GetUserByUsername(model.username)).ThrowIfPresent(new DuplicateException(AuthEnum.DUPLICATE_EMAIL));
            Optional.Of(userRepository.GetUserByEmail(model.email)).ThrowIfPresent(new DuplicateException(AuthEnum.DUPLICATE_EMAIL));

            string hashedPassword = bCryptService.Hash(model.password);

            var user = new UserModel
            {
                email = model.email,
                password = hashedPassword,
                username = model.username,
            };

            userRepository.CreateOrUpdateUser(user);

            return new
            {
                message = AuthEnum.REGISTER_SUCCESS,
            };
        }

        public object GenerateAccessToken(RefreshTokenDto model)
        {
            var user = userRepository.GetUserByRefreshToken(model.refresh_token);

            if (user != null)
            {
                var TokenPayload = jwtService.Verify(model.refresh_token);

                if (TokenPayload != null)
                {
                    string? id = TokenPayload.Claims.FirstOrDefault(c => c.Type == "id")?.Value;

                    if (id == user.id.ToString())
                    {
                        var accessToken = jwtService.GenerateAccessToken(user);

                        var refreshToken = jwtService.GenerateRefreshToken(user);

                        user.refresh_token = refreshToken;

                        userRepository.CreateOrUpdateUser(user);

                        return new
                        {
                            data = new
                            {
                                accessToken,
                                refreshToken,
                            }
                        };
                    }
                }
            }
            throw new UnAuthorizedException(AuthEnum.INVALID_REFRESH_TOKEN);
        }
    }
}
