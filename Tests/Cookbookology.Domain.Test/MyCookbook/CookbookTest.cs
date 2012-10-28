using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using Awa.Utils.IO;
using System.Collections.Generic;
using Cookbookology.Domain.MyCookbook;

namespace Cookbookology.Domain.Test.MyCookbook
{
    /// <summary>
    /// Test the serialization of the <see cref="Cookbook"/> class and related classes.
    /// </summary>
    [TestClass]
    public class CookbookTest
    {
        [TestMethod]
        public void SerializeEmptyCookbook()
        {
            // arrange
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            var s = new XmlSerializer(typeof(Cookbook));
            var cookbook = new Cookbook { Version = 1 };

            // act
            string result = null;
            using (var writer = new Utf8StringWriter())
            {
                s.Serialize(writer, cookbook, ns);
                result = writer.GetStringBuilder().ToString();
            }

            // assert
            Assert.AreEqual(
@"<?xml version=""1.0"" encoding=""utf-8""?>
<cookbook version=""1"" />"
            , result);
        }

        [TestMethod]
        public void SerializeSingleRecipe()
        {
            // arrange
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            var s = new XmlSerializer(typeof(Cookbook));
            var cookbook = new Cookbook { Version = 1 };
            cookbook.Recipes.Add(
                new Recipe
                {
                    Title = "My recipe",
                    PrepTime = "15 min",
                    CookTime = "20 min",
                    Categories = "fish",
                    Quantity = "4",
                    ImagePath = @"/mnt/sdcard/MyCookBook/images/recipe_img.png",
                    SourceUri = @"http://www.recipeurl",
                    Comments = "Your comments",
                    TextLines = new List<string> 
                    {
                        @"Step 1",
                        @"Step 2",
                    },
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient { NameAndAmount = "Ingredient 1" },
                        new Ingredient { NameAndAmount = "Ingredient 2" },
                    }
                }
            );

            // act
            string result = null;
            using (var writer = new Utf8StringWriter())
            {
                s.Serialize(writer, cookbook, ns);
                result = writer.GetStringBuilder().ToString();
            }

            // assert
            Assert.AreEqual(
@"<?xml version=""1.0"" encoding=""utf-8""?>
<cookbook version=""1"">
  <recipe>
    <title>My recipe</title>
    <preptime>15 min</preptime>
    <cooktime>20 min</cooktime>
    <ingredient>
      <li>Ingredient 1</li>
      <li>Ingredient 2</li>
    </ingredient>
    <recipetext>
      <li>Step 1</li>
      <li>Step 2</li>
    </recipetext>
    <url>http://www.recipeurl</url>
    <imagepath>/mnt/sdcard/MyCookBook/images/recipe_img.png</imagepath>
    <quantity>4</quantity>
    <comments>Your comments</comments>
    <category>fish</category>
  </recipe>
</cookbook>"
            , result);
        }

        [TestMethod]
        public void SerializeTwoRecipes()
        {
            // arrange
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            var s = new XmlSerializer(typeof(Cookbook));
            var cookbook = new Cookbook { Version = 1 };
            cookbook.Recipes.Add(
                new Recipe
                {
                    Title = "My recipe",
                    PrepTime = "15 min",
                    CookTime = "20 min",
                    Categories = "fish",
                    Quantity = "4",
                    ImagePath = @"/mnt/sdcard/MyCookBook/images/recipe_img.png",
                    SourceUri = @"http://www.recipeurl",
                    Comments = "Your comments",
                    TextLines = new List<string> 
                    {
                        @"Step 1",
                        @"Step 2",
                    },
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient { NameAndAmount = "Ingredient 1" },
                        new Ingredient { NameAndAmount = "Ingredient 2" },
                    }
                }
            );
            cookbook.Recipes.Add(
                new Recipe
                {
                    Title = "Crepes",
                    PrepTime = "10 min",
                    CookTime = "20 min",
                    Categories = "breakfast",
                    Quantity = string.Empty,
                    ImagePath = @"/mnt/sdcard/MyCookBook/images/crepes.png",
                    SourceUri = string.Empty,
                    Comments = string.Empty,
                    TextLines = new List<string> 
                    {
                        @"Pour the milk into the flour. Stir.",
                        @"Add the oil, the beaten eggs and the sugar. Stir again.",
                        @"Let the batter rest for 2 hours. The batter must be fluid. If not, add a little more milk.",
                        string.Empty,
                        @"Take a frying pan, oil it and pour a small amount of batter and spread it on the bottom. Cook it on one side, then the other.",
                        @"The ""French Crepes"" must be very thin.",
                        @"You can put butter or sugar or jelly or melted chocolate on them.",
                    },
                    Ingredients = new List<Ingredient>
                                {
                                    new Ingredient { NameAndAmount = "1 1/2 c. flour" },
                                    new Ingredient { NameAndAmount = "2 c. milk" },
                                    new Ingredient { NameAndAmount = "2 eggs" },
                                    new Ingredient { NameAndAmount = "1 1/2 tbsp. oil" },
                                    new Ingredient { NameAndAmount = "1 tbsp. sugar" },
                                    new Ingredient { NameAndAmount = "Little salt melted" },
                                }
                }
            );

            // act
            string result = null;
            using (var writer = new Utf8StringWriter())
            {
                s.Serialize(writer, cookbook, ns);
                result = writer.GetStringBuilder().ToString();
            }

            // assert
            Assert.AreEqual(
@"<?xml version=""1.0"" encoding=""utf-8""?>
<cookbook version=""1"">
  <recipe>
    <title>My recipe</title>
    <preptime>15 min</preptime>
    <cooktime>20 min</cooktime>
    <ingredient>
      <li>Ingredient 1</li>
      <li>Ingredient 2</li>
    </ingredient>
    <recipetext>
      <li>Step 1</li>
      <li>Step 2</li>
    </recipetext>
    <url>http://www.recipeurl</url>
    <imagepath>/mnt/sdcard/MyCookBook/images/recipe_img.png</imagepath>
    <quantity>4</quantity>
    <comments>Your comments</comments>
    <category>fish</category>
  </recipe>
  <recipe>
    <title>Crepes</title>
    <preptime>10 min</preptime>
    <cooktime>20 min</cooktime>
    <ingredient>
      <li>1 1/2 c. flour</li>
      <li>2 c. milk</li>
      <li>2 eggs</li>
      <li>1 1/2 tbsp. oil</li>
      <li>1 tbsp. sugar</li>
      <li>Little salt melted</li>
    </ingredient>
    <recipetext>
      <li>Pour the milk into the flour. Stir.</li>
      <li>Add the oil, the beaten eggs and the sugar. Stir again.</li>
      <li>Let the batter rest for 2 hours. The batter must be fluid. If not, add a little more milk.</li>
      <li />
      <li>Take a frying pan, oil it and pour a small amount of batter and spread it on the bottom. Cook it on one side, then the other.</li>
      <li>The ""French Crepes"" must be very thin.</li>
      <li>You can put butter or sugar or jelly or melted chocolate on them.</li>
    </recipetext>
    <url />
    <imagepath>/mnt/sdcard/MyCookBook/images/crepes.png</imagepath>
    <quantity />
    <comments />
    <category>breakfast</category>
  </recipe>
</cookbook>"
            , result);
        }
    }
}
