﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Cookbookology.Formats.MyCookbook
{
    public class Ingredient
    {
        [XmlText()]
        public string NameAndAmount { get; set; }
    }
}
