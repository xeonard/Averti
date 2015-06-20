using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvertiFestivalApplication
{
    class Order
    {
        private List<Article> articles;
        private int quantity;
        private int personalId;
        private double cost;

        public List<Article> Articles { get { return articles; } private set { articles = value; } }
        public int Quantity { get { return quantity; } set { quantity = value; } }
        public int PersonID { get { return personalId; } set { personalId = value; } }
        public double Cost { get { return cost; } private set { cost = value; } }


        public Order()
        {
            articles = new List<Article>();
            cost = 0;
        }

        public void AddToOrder(Article art, int quantity)
        {
            foreach (Article a in articles)// check if it's already in the list
            {
                if (art.KindOfArticleID == a.KindOfArticleID)
                {
                    a.Stock += quantity;
                    updateCost();
                    return;
                }
            }

            art.Stock = quantity;
            articles.Add(art);
            updateCost();

        }

        public void updateCost()
        {
            Cost = 0;

            foreach (Article a in articles)
            {
                 cost += (a.Price * a.Stock);
            }
        }
    }
}
