namespace Tangor.ToEatList
{
    public interface IUser
    {
        string Login { get; }
        bool IsAuthorized(string pass);
    }
}