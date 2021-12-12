namespace OOD.StackOverflow
{
    public class Account
    {
        public long Id { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int Reputation { get; set; }

        public bool ResetPassword(string newPassword) 
        {
            Password = newPassword;

            return true;
        }
    }
}
