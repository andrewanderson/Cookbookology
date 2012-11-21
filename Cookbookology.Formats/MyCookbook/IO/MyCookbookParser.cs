using Cookbookology.Domain.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using ICSharpCode.SharpZipLib.Zip;

namespace Cookbookology.Formats.MyCookbook.IO
{
    public class MyCookbookParser : IParser
    {
        public Cookbookology.Domain.Cookbook Read(Stream inputStream)
        {
            if (inputStream == null) throw new ArgumentNullException("inputStream");

            var cookbook = new Cookbookology.Domain.Cookbook();

            using (var zip = new ZipFile(inputStream))
            {
                var decompressed = zip.GetInputStream(0); // Only one file in a MCB zip. 
                                        
                var s = new XmlSerializer(typeof(Cookbook));
                var mcb = (Cookbook) s.Deserialize(decompressed);

                var converter = new MyCookbookConverter();
                cookbook = converter.ConvertToCommon(mcb);
            }

            return cookbook;
        }

        public void Write(Cookbookology.Domain.Cookbook cookbook, Stream outputStream)
        {
            throw new NotImplementedException();
        }
    }
}
