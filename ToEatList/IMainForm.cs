using System;

namespace Tangor.ToEatList
{
    public delegate void UserLoginEventHandler(string loginName, string loginPass);

    public interface IMainForm
    {
        event UserLoginEventHandler UserLogin;
        event EventHandler MainFormClosed;
    }
}