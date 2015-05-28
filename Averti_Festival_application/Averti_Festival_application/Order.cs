using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvertiFestivalApplication
{
    class Order
    {
        private Article article;
        private int quantity;
        private int personalId;

        public Article Article { get { return article; } set { article = value; } }

        public int Quantity { get { return quantity; } set { quantity = value; } }
        public int PersonID { get { return personalId; } set { personalId = value; } }

        public Order()
        {

        }

        public Order( Article article, int quantity)
        {

            this.Article = article;
            this.Quantity = quantity;


        }


            
    }
}
