using System;
using System.Windows.Forms;

namespace Tangor.ToEatList
{
    public partial class MainForm : Form, IMainForm
    {
        public event UserLoginEventHandler UserLogin;
        public event EventHandler UserLogoff;
        public event EventHandler MainFormClosed;

        private LoginUserControl _loginUserControl;
        private UserProfilControl _userProfilControl;

        public MainForm()
        {
            InitializeComponent();

            initLoginForm();
        }

        private void onUserLogin(object sender, EventArgs eventArgs)
        {
            if (this.UserLogin != null)
                this.UserLogin(_loginUserControl.UserName, _loginUserControl.Passwort);
        }

        public void LoadProfile(IUserInfo userInfo)
        {
            disposeLoginControl();

            _userProfilControl = new UserProfilControl();
            this.Controls.Add(_userProfilControl);

            _userProfilControl.InitProfile(userInfo);
            _userProfilControl.UserLogoff += onUserLogoff;
        }

        public void LoadLoginForm()
        {
            disposeProfileControl();

           initLoginForm();
        }

        private void initLoginForm()
        {
            _loginUserControl = new LoginUserControl();
            _loginUserControl.UserLogin += onUserLogin;

            this.Controls.Add(_loginUserControl);
        }

        private void onUserLogoff(object sender, EventArgs e)
        {
            if (this.UserLogoff != null)
                this.UserLogoff(this, EventArgs.Empty);
        }

        private void disposeLoginControl()
        {
            _loginUserControl.UserLogin -= onUserLogin;
            this.Controls.Remove(_loginUserControl);
            _loginUserControl = null;
        }

        private void disposeProfileControl()
        {
            _userProfilControl.UserLogoff -= onUserLogoff;
            this.Controls.Remove(_userProfilControl);
            _userProfilControl = null;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            EventHandler handler = MainFormClosed;
            if (handler != null)
                handler(this, EventArgs.Empty);

            if (_loginUserControl != null)
                _loginUserControl.UserLogin -= onUserLogin;
        }
    }
}
