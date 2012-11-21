using Cookbookology.Domain;
using Cookbookology.Formats.MyCookbook.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Cookbookology.Formats.Test.MyCookbook.IO
{
    [TestClass]
    public class MyCookbookParserTest
    {
        private const string InputFileName = @"Test Data\MyCookBookSample.mcb";

        [TestMethod]
        [DeploymentItem(@"Input\MyCookBookSample.mcb", "Test Data")]
        public void ReadTest()
        {
            // arrange
            var parser = new MyCookbookParser();

            Cookbook cb = null;
            bool result = false;

            using (var file = File.Open(InputFileName, FileMode.Open))
            {
                // act
                cb = parser.Read(file);

                file.Close();
            }

            // assert
            Assert.AreEqual(15, cb.Recipes.Count);
        }

        [TestMethod]
        public void WriteTest()
        {
            // arrange
            string fileName = @"MyCookbookParserWriteTest.mcb";
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

            var parser = new MyCookbookParser();
            using (var outputFileStream = File.OpenWrite(fileName))
            {

                // act
                parser.Write(cookbook, outputFileStream);

                // assert
                var fi = new FileInfo(fileName);
                Assert.IsTrue(fi.Exists);
                Assert.IsTrue(fi.Length > 52); // 52 is the length of a ZIP with an empty file
            }
        }
    }
}
