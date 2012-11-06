using Cookbookology.Domain.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cookbookology.Formats.MyCookbook.IO
{
    public class MyCookbookParser : IParser
    {
        public bool TryRead(System.IO.StreamReader reader, out Cookbookology.Domain.Cookbook cookbook)
        {
            throw new NotImplementedException();
        }

        public void Write(Cookbookology.Domain.Cookbook cookbook, System.IO.StreamWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
