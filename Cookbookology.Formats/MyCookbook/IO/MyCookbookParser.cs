using Cookbookology.Domain.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;

namespace Cookbookology.Formats.MyCookbook.IO
{
    public class MyCookbookParser : IParser
    {
        const string mcbFileName = "BackupMyCookBook.xml";

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

        // See this link for details on zipping using SharpZipLib:  https://github.com/icsharpcode/SharpZipLib/wiki/Zip-Samples#wiki-anchorCreate
        public void Write(Cookbookology.Domain.Cookbook cookbook, Stream outputStream)
        {
            if (cookbook == null) throw new ArgumentNullException("cookbook");
            if (outputStream == null) throw new ArgumentNullException("outputStream");

            var converter = new MyCookbookConverter();
            var mcb = converter.ConvertFromCommon(cookbook);

            var ms = new MemoryStream();
            var s = new XmlSerializer(typeof(Cookbook));
            s.Serialize(ms, mcb);
            ms.Position = 0; // reset to the start so that we can write the stream

            // Add the cookbook as a single compressed file in a Zip
            using (var zipStream = new ZipOutputStream(outputStream))
            {
                zipStream.SetLevel(3); // compression
                zipStream.UseZip64 = UseZip64.Off; // not compatible with all utilities and OS (WinXp, WinZip8, Java, etc.)

                var entry = new ZipEntry(mcbFileName);
                entry.DateTime = DateTime.Now;

                zipStream.PutNextEntry(entry);
                StreamUtils.Copy(ms, zipStream, new byte[4096]);
                zipStream.CloseEntry();

                zipStream.IsStreamOwner = false; // Don't close the outputStream (parameter)
                zipStream.Close();
            }           
        }
    }
}
