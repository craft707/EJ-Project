using System.ComponentModel.DataAnnotations;

namespace API
{
    public class User
    {
        private static int _uniqueId = 0;

        public User() { }

        public User(string login, string password)
        {
            ArgumentNullException.ThrowIfNull(login);
            ArgumentNullException.ThrowIfNull(password);

            Login = login;
            Password = password;
        }

        public static User Register(string login, string password)
        {
            User user = new User(login, password);
            user.Id = Interlocked.Increment(ref _uniqueId);
            return user;
        }

        public int Id { get; set; }

        [Required]
        public string Login { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        public void ChangePassword(string newPassword)
        {
            Password = newPassword;
        }
    }
}
