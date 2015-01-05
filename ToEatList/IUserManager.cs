namespace Tangor.ToEatList
{
    public interface IUserManager
    {
        bool Authorize(string userName, string pass);

        IUserInfo CurrentUserInfo { get; }
    }
}