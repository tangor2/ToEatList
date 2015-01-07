namespace Tangor.ToEatList.Articles
{
    public class ColaZero : IArticle
    {
        public ColaZero()
        {
            this.Name = "Cola Zero";
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