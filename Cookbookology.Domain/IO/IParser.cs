using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Cookbookology.Domain.IO
{
    /// <summary>
    /// A utility class that can read and write a cookbook file.
    /// </summary>
    public interface IParser
    {
        /// <summary>
        /// Open a cookbook from a stream, and convert it to the common format.
        /// </summary>
        /// <returns>True of the file could be properly read in, or false otherwise.</returns>
        bool TryRead(StreamReader reader, out Cookbook cookbook);

        /// <summary>
        /// Save a cookbook to the file format for this class.
        /// </summary>
        void Write(Cookbook cookbook, StreamWriter writer);
    }
}
