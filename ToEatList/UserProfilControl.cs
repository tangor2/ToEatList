using System;
using System.Windows.Forms;

namespace Tangor.ToEatList
{
    public partial class UserProfilControl : UserControl
    {
        public event EventHandler UserLogoff;

        public UserProfilControl()
        {
            InitializeComponent();
        }

        public void InitProfile(IUserInfo userInfo)
        {
            this.lName.Text = string.Format("Hallo {0}!",  userInfo.FullName);
        }

        private void btnLogoff_Click(object sender, EventArgs e)
        {
            if (this.UserLogoff != null)
                this.UserLogoff(this, EventArgs.Empty);
        }
    }
}
