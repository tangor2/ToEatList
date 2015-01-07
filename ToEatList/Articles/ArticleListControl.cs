using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Tangor.ToEatList.Articles
{
    public partial class ArticleListControl : UserControl
    {
        public ArticleListControl()
        {
            InitializeComponent();
        }

        public void LoadArticles(List<IArticle> articles)
        {
            foreach (IArticle article in articles)
            {
                ListViewItem item = new ListViewItem();
                item.Text = String.Format("{0}" + Environment.NewLine + "{1}", article.Name, article.PreisString);

                listView1.Items.Add(item);
            }
        }
    }
}
