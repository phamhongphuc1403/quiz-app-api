using quiz_app_api.src.Core.Database;
using quiz_app_api.src.Core.Database.Model;
using quiz_app_api.src.Packages.HttpExceptions;

namespace quiz_app_api.src.Core.Modules.User
{
    public class UserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public UserModel? GetUserByUsername(string username)
        {
            try
            {
                return _context.Users.SingleOrDefault(p => p.username == username);
            }
            catch (Exception ex)
            {
                throw new InternalException(ex.Message);
            }
        }
        public UserModel? GetUserByEmail(string email)
        {
            try
            {
                return _context.Users.SingleOrDefault(p => p.email == email);
            }
            catch (Exception ex)
            {
                throw new InternalException(ex.Message);
            }
        }
        public UserModel? GetUserById(int id)
        {
            try
            {
                return _context.Users.SingleOrDefault(p => p.id == id);
            }
            catch (Exception ex)
            {
                throw new InternalException(ex.Message);
            }
        }
        public UserModel? CreateOrUpdateUser(UserModel user)
        {
            try
            {
                if (user.id == 0)
                {
                    _context.Users.Add(user);
                }
                _context.SaveChanges();

                return user;
            }
            catch (Exception ex)
            {
                throw new InternalException(ex.Message);
            }
        }
        public UserModel? GetUserByRefreshToken(string refreshToken)
        {
            try
            {
                return _context.Users.SingleOrDefault(u => u.refresh_token == refreshToken);
            }
            catch (Exception ex)
            {
                throw new InternalException(ex.Message);
            }
        }
        public List<UserModel> GetAllUsers()
        {
            try
            {
                return _context.Users.ToList();
            }
            catch (Exception ex)
            {
                throw new InternalException(ex.Message);
            }
        }
    }
}
