namespace Woofhub
{
    internal class Usuario
    {
        public int Id
        {
            get => _id;
            set => _id = value;
        }
        public string Username
        {
            get => _username;
            set => _username = value;
        }
        public string password
        {
            get => _password;
            set => _password = value;
        }
        public string email
        {
            get => _email;
            set => _email = value
        }
    }
}
