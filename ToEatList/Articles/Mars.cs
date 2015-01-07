namespace Tangor.ToEatList.Articles
{
    public class Mars : IArticle
    {
        public Mars()
        {
            this.Name = "Mars";
            this.Preis = 1.0;
        }

        public string Name { get; private set; }
        public double Preis { get; private set; }

        public string PreisString
        {
            get { return double.IsNaN(this.Preis) ? string.Empty : this.Preis.ToString("C2"); }
        }
    }
}