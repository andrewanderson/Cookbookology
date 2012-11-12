using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Cookbookology.Formats.MyCookbook.IO;
using Awa.Testing;

namespace Cookbookology.Formats.Test.MyCookbook.IO
{
    [TestClass]
    public class MyCookbookConverterTest
    {
        [TestMethod]
        public void RoundTripConversionTestCommonToMcb()
        {
            // arrange
            var cookbook = new Cookbookology.Domain.Cookbook { Version = "4" };

            cookbook.Recipes.Add
            (
                new Cookbookology.Domain.Recipe
                {
                    AdditionalComments = "These taste great on a cold morning!",
                    Categories = new List<string> { "Breakfast", "French" },
                    CookingTime = "20 min",
                    ImagePath = @"/mnt/sdcard/MyCookBook/images/crepes.png",
                    Ingredients = new List<string> { "1 1/2 c. flour", "2 c. milk", "2 eggs", "1 1/2 tbsp. oil", "1 tbsp. sugar", "Little salt melted" },
                    Instructions = @"Pour the milk into the flour. Stir.
Add the oil, the beaten eggs and the sugar. Stir again.
Let the batter rest for 2 hours. The batter must be fluid. If not, add a little more milk.

Take a frying pan, oil it and pour a small amount of batter and spread it on the bottom. Cook it on one side, then the other.
The ""French Crepes"" must be very thin.
You can put butter or sugar or jelly or melted chocolate on them.",
                    PreparationTime = "10 min",
                    Servings = "10 crepes",
                    SourceUri = "http://test.com",
                    Title = "Crepes",
                }
            );
            
            // act
            var converter = new MyCookbookConverter();
            var mcb = converter.ConvertFromCommon(cookbook);
            var resultCookbook = converter.ConvertToCommon(mcb);

            // assert
            CookbookAssert.AreEqual(cookbook, resultCookbook);
        }
        
        [TestMethod]
        public void RoundTripConversionTestMcbToCommon()
        {
            // arrange
            var mcb = new Cookbookology.Formats.MyCookbook.Cookbook { Version = 4 };

            mcb.Recipes.Add
            (
                new Cookbookology.Formats.MyCookbook.Recipe
                {
                    Comments = "These taste great on a cold morning!",
                    Categories = "Breakfast,French",
                    CookTime = "20 min",
                    ImagePath = @"/mnt/sdcard/MyCookBook/images/crepes.png",
                    Ingredients = (new [] { "1 1/2 c. flour", "2 c. milk", "2 eggs", "1 1/2 tbsp. oil", "1 tbsp. sugar", "Little salt melted" }).Select(i => new Cookbookology.Formats.MyCookbook.Ingredient { NameAndAmount = i }).ToList(),
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
                    PrepTime = "10 min",
                    Quantity = "10 crepes",
                    SourceUri = "http://test.com",
                    Title = "Crepes",
                }
            );

            // act
            var converter = new MyCookbookConverter();
            var cookbook = converter.ConvertToCommon(mcb);
            var resultMcb = converter.ConvertFromCommon(cookbook);

            // assert
            CookbookAssert.AreEqual(mcb, resultMcb);
        }
    }
}
