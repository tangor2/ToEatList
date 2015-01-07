using System;
using System.Collections.Generic;
using Tangor.ToEatList.Articles;

namespace Tangor.ToEatList
{
    public delegate void UserLoginEventHandler(string loginName, string loginPass);

    public interface IMainForm
    {
        event UserLoginEventHandler UserLogin;
        event EventHandler UserLogoff;

        event EventHandler MainFormClosed;

        void LoadProfile(IUserInfo userInfo);
        void LoadLoginForm();

        void LoadArticles(List<IArticle> articles);
    }
}