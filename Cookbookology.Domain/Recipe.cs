using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Cookbookology.Domain
{
    /// <summary>
    /// A single recipe within a <see cref="Cookbook"/>.
    /// </summary>
    public class Recipe
    {
        public Recipe()
        {
            this.Ingredients = new List<string>();
            this.Categories = new List<string>();
        }

        /// <summary>
        /// The name of the recipe.
        /// </summary>
        [XmlElement]
        public string Title { get; set; }

        /// <summary>
        /// The amount of time required to prepare the recipe before it starts to cook.
        /// </summary>
        [XmlElement]
        public string PreparationTime { get; set; }

        /// <summary>
        /// The amount of time required to cook the recipe, excluding preparation.
        /// </summary>
        [XmlElement]
        public string CookingTime { get; set; }

        /// <summary>
        /// The ingredients - and amounts required for each - used in the recipe.
        /// </summary>
        [XmlArray]
        public List<string> Ingredients { get; set; }

        /// <summary>
        /// A freeform text summary of how to prepare the recipe.  Could be a numbered list, paragraphs,
        /// or any other format desired.
        /// </summary>
        [XmlElement]
        public string Instructions { get; set; }

        /// <summary>
        /// A link to where the recipe was originally found, if applicable.
        /// </summary>
        [XmlElement]
        public string SourceUri { get; set; }

        /// <summary>
        /// The relative path to a picture of the finished dish.
        /// </summary>
        [XmlElement]
        public string ImagePath { get; set; }

        /// <summary>
        /// A freeform text description of how many people one batch of the recipe serves.
        /// </summary>
        [XmlElement]
        public string Servings { get; set; }

        /// <summary>
        /// A freeform text section where additional commentary about the recipe may be recorded.
        /// </summary>
        [XmlElement]
        public string AdditionalComments { get; set; }

        /// <summary>
        /// A list of arbitrary categories (e.g. main course, fish, sweet) that this recipe belongs to.
        /// </summary>
        [XmlArray]
        public List<string> Categories { get; set; }
    }
}
