namespace Tangor.ToEatList.Articles
{
    public interface IArticle
    {
        string Name { get; }

        double Preis { get; }

        string PreisString { get; }
    }
}