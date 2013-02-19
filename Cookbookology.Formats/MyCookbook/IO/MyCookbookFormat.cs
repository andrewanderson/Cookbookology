using Cookbookology.Domain.IO;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;

namespace Cookbookology.Formats.MyCookbook.IO
{
    [Export(typeof(IFileFormat))]
    public class MyCookbookFormat : IFileFormat
    {
        private readonly MyCookbookParser parser = new MyCookbookParser();

        public string DisplayName
        {
            get { return "MyCookbook"; }
        }

        public List<string> FileExtensions
        {
            get { return new List<string> { ".mcb" }; }
        }

        public Uri Uri
        {
            get { return new Uri(@"http://mycookbook-android.com/site/"); }
        }

        public IParser Parser
        {
            get { return this.parser; }
        }
    }
}
