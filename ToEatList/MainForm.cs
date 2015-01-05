using System;
using System.Windows.Forms;

namespace Tangor.ToEatList
{
    public partial class MainForm : Form, IMainForm
    {
        public event UserLoginEventHandler UserLogin;
        public event EventHandler MainFormClosed;

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            EventHandler handler = MainFormClosed;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
    }
}
