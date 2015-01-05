namespace Tangor.ToEatList
{
    public class User: IUser, IUserInfo
    {
        public string FullName { get; private set; }

        public string Login { get; private set; }
        private string Pass { get; set; }

        internal User(string fullName, string login, string pass)
        {
            this.FullName = fullName;

            this.Login = login;
            this.Pass = pass;
        }

        public bool IsAuthorized(string pass)
        {
            return this.Pass == pass;
        }

        
    }
}