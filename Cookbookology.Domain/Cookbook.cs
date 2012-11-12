using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Cookbookology.Domain
{
    /// <summary>
    /// The common model for a cookbook that the application uses.  Encompasses aspects
    /// of all supported formats.
    /// </summary>
    /// <remarks>
    /// The <see cref="IParser"/> implementations exist to convert to and from this common format
    /// and all other specific application-based formats.
    /// </remarks>
    public class Cookbook
    {
        public Cookbook()
        {
            this.Recipes = new List<Recipe>();
        }

        [XmlAttribute]
        public string Version { get; set; }

        [XmlElement]
        public List<Recipe> Recipes { get; set; }
    }
}
