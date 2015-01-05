using System;
using System.Windows.Forms;

namespace Tangor.ToEatList
{
    public partial class LoginUserControl : UserControl
    {
        public event EventHandler UserLogin;

        public LoginUserControl()
        {
            InitializeComponent();
        }

        public string UserName
        {
            get { return textBox1.Text; }
        }

        public string Passwort
        {
            get { return tbPass.Text; }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (this.UserLogin != null)
                this.UserLogin(this, EventArgs.Empty);
        }
    }
}
