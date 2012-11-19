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
        public bool TryRead(Stream inputStream, out Cookbookology.Domain.Cookbook cookbook)
        {
            if (inputStream == null) throw new ArgumentNullException("inputStream");

            cookbook = null;

            try
            {
                // skip first two bytes as per http://george.chiramattel.com/blog/2007/09/deflatestream-block-length-does-not-match.html
               // inputStream.ReadByte();
               // inputStream.ReadByte();

                using (var zip = new ZipFile(inputStream))
                {
                    var decompressed = zip.GetInputStream(0); // Only one file in a MCB zip. 
                                        
                    var s = new XmlSerializer(typeof(Cookbook));
                    var mcb = (Cookbook) s.Deserialize(decompressed);

                    var converter = new MyCookbookConverter();
                    cookbook = converter.ConvertToCommon(mcb);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Write(Cookbookology.Domain.Cookbook cookbook, Stream outputStream)
        {
            throw new NotImplementedException();
        }
    }
}
