namespace Tangor.ToEatList
{
    public class MainController
    {
        public IMainForm Form { get; private set; }

        public bool IsUserLoggedIn { get; private set; }

        private IUserManager Users { get; set; }

        public MainController(): this(new MainForm())
        {
        }

        internal MainController(IMainForm form)
        {
            this.IsUserLoggedIn = false;

            this.Users = new UserManager();

            this.Form = form;
            this.Form.UserLogin += Form_UserLogin;
            this.Form.UserLogoff += Form_UserLogoff;
            this.Form.MainFormClosed += Form_MainFormClosed;
        }

        private void Form_UserLogoff(object sender, System.EventArgs e)
        {
            this.IsUserLoggedIn = false;

            this.Form.LoadLoginForm();
        }

        private void Form_MainFormClosed(object sender, System.EventArgs e)
        {
            this.Dispose();
        }

        public void Dispose()
        {
            this.Form.UserLogin -= Form_UserLogin;
            this.Form.UserLogoff -= Form_UserLogoff;
            this.Form.MainFormClosed -= Form_MainFormClosed;
        }

        private void Form_UserLogin(string loginName, string loginPass)
        {
            this.Login(loginName, loginPass);
        }

        public void Login(string testuser, string testpass)
        {
            this.IsUserLoggedIn = this.Users.Authorize(testuser, testpass);

            if (this.IsUserLoggedIn)
            {
                this.Form.LoadProfile(this.Users.CurrentUserInfo);
            }
        }
    }
}
