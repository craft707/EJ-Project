using System.Reflection.Metadata.Ecma335;

namespace API
{
    public class User
    {
        public User(int id, string login, string password)
        {
            Id = id;
            Login = login;
            Password = password;
        }

        public int Id { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }

        public void Change(int? id = null, string? login = null, string? password = null)
        {
            if (id.HasValue)
                Id = id.Value;

            if (login != null)
                Login = login;

            if (password != null)
                Password = password;
        }
    }
}
