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
        public void TryReadTest()
        {
            // arrange
            var parser = new MyCookbookParser();

            Cookbook cb = null;
            bool result = false;

            using (var file = File.Open(InputFileName, FileMode.Open))
            {
                // act
                result = parser.TryRead(file, out cb);

                file.Close();
            }

            // assert
            Assert.IsTrue(result);
            Assert.AreEqual(15, cb.Recipes.Count);
        }
    }
}
