﻿using System;
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
         
        //constructor
        public Article(int articleID, string soortArticle, string name, int stock)
        {
            ArticleID = articleID;
            SoortArticle = soortArticle;
            Name = name;
            Stock = stock;
        }

        //methods
        public string GetInfo()
        {
            return "ID: " + ArticleID + " - Sort: " + SoortArticle + " - Name: " + Name + " - Left in stock: " + Stock; 
        }
    }
}