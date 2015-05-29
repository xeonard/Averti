using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvertiFestivalApplication
{
    class Article
    {
        //fields 

        //properties
        public int ArticleID { get; set; }
        public string SoortArticle { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public int KindOfArticleID { get; set; }
         
        public Article ()
        {

        }
        public Article(int kinOfArticleID, int articleID, string name, int stock, double price)
        {
            this.KindOfArticleID = kinOfArticleID;
            this.ArticleID = articleID;
            this.Name = name;
            this.Stock = stock;
            this.Price = price;
           
        }
        public Article(int articleID, string soortArticle, string name, int stock, double price)
        {
            ArticleID = articleID;
            SoortArticle = soortArticle;
            Name = name;
            Stock = stock;
            Price = price;

        }
        public Article(int articleID, string soortArticle)
        {
            ArticleID = articleID;
            SoortArticle = soortArticle;
          
        }


        //methods
        public string GetInfo()
        {
            return "ID: " + ArticleID + " - Sort: " + SoortArticle + " - Name: " + Name + " - Left in stock: " + Stock; 
        }
    }
}
