using API;

namespace Anketa.API
{
    public class UserDatabase
    {
        public UserDatabase()
        {
            Fill();
        }

        private List<User> _users = new List<User>();

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            await Task.Yield();
            return _users.AsReadOnly();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            await Task.Yield();
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await Task.Yield();

            _users.Add(user);
            return user;
        }

        public async Task<bool> ChangePasswordAsync(int id, string newPassword)
        {
            await Task.Yield();

            User? user = _users.FirstOrDefault(u => u.Id == id);
            
            if (user == null)
                return false;

            user.ChangePassword(newPassword);
            return true;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            await Task.Yield();

            User? user = _users.FirstOrDefault(u => u.Id == id);

            if (user == null)
                return false;

            _users.Remove(user);
            return true;
        }

        private void Fill()
        {
            _users.Add(User.Register("Petya", "Petya12345"));
            _users.Add(User.Register("Max222", "222MaxNeMax222"));
            _users.Add(User.Register("Byk", "qwerty123456"));
        }
    }
}
