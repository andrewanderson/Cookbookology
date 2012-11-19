using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cookbookology.Formats.MyCookbook.IO
{
    /// <summary>
    /// Converts to and from the common format and MyCookbook's proprietary format.
    /// </summary>
    public class MyCookbookConverter
    {
        public Cookbookology.Formats.MyCookbook.Cookbook ConvertFromCommon(Cookbookology.Domain.Cookbook cookbook)
        {
            var mcb = new Cookbookology.Formats.MyCookbook.Cookbook
            {
                Version = int.Parse(cookbook.Version),
            };

            foreach (var recipe in cookbook.Recipes)
            {
                var mcbRecipe = new Cookbookology.Formats.MyCookbook.Recipe()
                {
                    Categories = string.Join(",", recipe.Categories),
                    Comments = recipe.AdditionalComments,
                    CookTime = recipe.CookingTime,
                    ImagePath = recipe.ImagePath,
                    Ingredients = recipe.Ingredients.Select(i => new Ingredient { NameAndAmount = i }).ToList(),
                    PrepTime = recipe.PreparationTime,
                    Quantity = recipe.Servings,
                    SourceUri = recipe.SourceUri,
                    TextLines = new List<string>(recipe.Instructions.Split(new [] { "\r\n", "\r", "\n" }, StringSplitOptions.None)),
                    Title = recipe.Title,
                };

                mcb.Recipes.Add(mcbRecipe);
            }

            return mcb;
        }

        public Cookbookology.Domain.Cookbook ConvertToCommon(Cookbookology.Formats.MyCookbook.Cookbook mcb)
        {
            var cookbook = new Cookbookology.Domain.Cookbook
            {
                Version = mcb.Version.ToString(),
            };

            foreach (var mcbRecipe in mcb.Recipes)
            {
                var recipe = new Cookbookology.Domain.Recipe()
                {
                    Categories = (mcbRecipe.Categories == null) ? new List<string>() : new List<string>(mcbRecipe.Categories.Split(new [] {','})),
                    AdditionalComments = mcbRecipe.Comments,
                    CookingTime = mcbRecipe.CookTime,
                    ImagePath = mcbRecipe.ImagePath,
                    Ingredients = (mcbRecipe.Ingredients == null) ? new List<string>() : mcbRecipe.Ingredients.Select(i =>i.NameAndAmount).ToList(),
                    PreparationTime = mcbRecipe.PrepTime,
                    Servings = mcbRecipe.Quantity,
                    SourceUri = mcbRecipe.SourceUri,
                    Instructions = string.Join("\r\n", mcbRecipe.TextLines),
                    Title = mcbRecipe.Title,
                };

                cookbook.Recipes.Add(recipe);
            }

            return cookbook;
        }

    }
}
