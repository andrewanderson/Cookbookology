using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Cookbookology.Domain.MyCookbook
{
    public class Recipe
    {
        public Recipe()
        {
            this.Ingredients = new List<Ingredient>();
        }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("preptime")]
        public string PrepTime { get; set; }

        [XmlElement("cooktime")]
        public string CookTime { get; set; }

        [XmlArrayItem("li", typeof(Ingredient))]
        [XmlArray("ingredient")]
        public List<Ingredient> Ingredients { get; set; }

        [XmlArrayItem("li", typeof(string))]
        [XmlArray("recipetext")]
        public List<string> TextLines { get; set; }

        [XmlElement("url")]
        public string SourceUri { get; set; }

        [XmlElement("imagepath")]
        public string ImagePath { get; set; }

        [XmlElement("quantity")]
        public string Quantity { get; set; }

        [XmlElement("comments")]
        public string Comments { get; set; }

        [XmlElement("category")]
        public string Categories { get; set; }
    }
}
