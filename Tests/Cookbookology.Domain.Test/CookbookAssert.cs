using Awa.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cookbookology.Formats.Test
{
    public static class CookbookAssert
    {
        public static void AreEqual(Cookbookology.Domain.Cookbook expected, Cookbookology.Domain.Cookbook actual)
        {
            Assert.AreEqual(expected.Version, actual.Version);
            Assert.AreEqual(expected.Recipes.Count, actual.Recipes.Count);

            for (int i = 0; i < expected.Recipes.Count; i++)
            {
                var expectedRecipe = expected.Recipes[i];
                var actualRecipe = actual.Recipes[i];

                Assert.AreEqual(expectedRecipe.AdditionalComments, actualRecipe.AdditionalComments);
                EnumerableAssert.AreEqual(expectedRecipe.Categories, actualRecipe.Categories);
                Assert.AreEqual(expectedRecipe.CookingTime, actualRecipe.CookingTime);
                Assert.AreEqual(expectedRecipe.ImagePath, actualRecipe.ImagePath);
                EnumerableAssert.AreEqual(expectedRecipe.Ingredients, actualRecipe.Ingredients);
                Assert.AreEqual(expectedRecipe.Instructions, actualRecipe.Instructions);
                Assert.AreEqual(expectedRecipe.PreparationTime, actualRecipe.PreparationTime);
                Assert.AreEqual(expectedRecipe.Servings, actualRecipe.Servings);
                Assert.AreEqual(expectedRecipe.SourceUri, actualRecipe.SourceUri);
                Assert.AreEqual(expectedRecipe.Title, actualRecipe.Title);
            }
        }

        public static void AreEqual(Cookbookology.Formats.MyCookbook.Cookbook expected, Cookbookology.Formats.MyCookbook.Cookbook actual)
        {
            Assert.AreEqual(expected.Version, actual.Version);
            Assert.AreEqual(expected.Recipes.Count, actual.Recipes.Count);

            for (int i = 0; i < expected.Recipes.Count; i++)
            {
                var expectedRecipe = expected.Recipes[i];
                var actualRecipe = actual.Recipes[i];

                Assert.AreEqual(expectedRecipe.Comments, actualRecipe.Comments);
                Assert.AreEqual(expectedRecipe.Categories, actualRecipe.Categories);
                Assert.AreEqual(expectedRecipe.CookTime, actualRecipe.CookTime);
                Assert.AreEqual(expectedRecipe.ImagePath, actualRecipe.ImagePath);
                EnumerableAssert.AreEqual(expectedRecipe.Ingredients.Select(x => x.NameAndAmount), actualRecipe.Ingredients.Select(x => x.NameAndAmount));
                EnumerableAssert.AreEqual(expectedRecipe.TextLines, actualRecipe.TextLines);
                Assert.AreEqual(expectedRecipe.PrepTime, actualRecipe.PrepTime);
                Assert.AreEqual(expectedRecipe.Quantity, actualRecipe.Quantity);
                Assert.AreEqual(expectedRecipe.SourceUri, actualRecipe.SourceUri);
                Assert.AreEqual(expectedRecipe.Title, actualRecipe.Title);
            }
        }

    }
}
