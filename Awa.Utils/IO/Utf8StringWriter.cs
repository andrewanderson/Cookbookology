using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awa.Utils.IO
{
    // Taken from: http://stackoverflow.com/questions/1564718/using-stringwriter-for-xml-serialization
    public sealed class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding { get { return Encoding.UTF8; } }
    }

}
