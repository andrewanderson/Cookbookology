using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Cookbookology.Formats.MyCookbook
{
    // Schema found here:  http://mycookbook-android.com/site/my-cookbook-xml-schema/
    [XmlRoot("cookbook")]
    public class Cookbook
    {
        public Cookbook()
        {
            this.Recipes = new List<Recipe>();
        }

        [XmlAttribute("version")]
        public int Version { get; set; }

        [XmlElement("recipe")]
        public List<Recipe> Recipes { get; set; }
    }
}
