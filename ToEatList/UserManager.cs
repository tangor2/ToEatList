using System.Collections.Generic;
using System.Linq;

namespace Tangor.ToEatList
{
    public class UserManager: IUserManager
    {
        public IUserInfo CurrentUserInfo { get; private set; }

        private readonly List<IUser> _users;

        public UserManager()
        {
            _users = new List<IUser>
                {
                    new User("Peter Schmidt", "testUser", "testPass"),
                    new User("Roland Mann", "testUser2", "otherPass")
                };
        }

        public bool Authorize(string userName, string pass)
        {
            IUser user = getUser(userName);
            if (user == null)
                return false;

            bool isUserAuthorized = user.IsAuthorized(pass);
            if (isUserAuthorized)
            {
                this.CurrentUserInfo = user as IUserInfo;
            }

            return isUserAuthorized;
        }

        private IUser getUser(string userLogin)
        {
            return _users.FirstOrDefault(user => user.Login == userLogin);
        }
    }
}