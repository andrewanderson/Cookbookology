using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cookbookology.Domain.IO
{
    /// <summary>
    /// Meta information about a recipe book file format.
    /// </summary>
    public interface IFileFormat
    {
        /// <summary>
        /// The human-readable name for the file format.
        /// </summary>
        string DisplayName { get; }

        /// <summary>
        /// The file extensions that are known to be associated with this file format.
        /// </summary>
        List<string> FileExtensions { get; }

        /// <summary>
        /// The location that further information about the file format can be found at.
        /// </summary>
        Uri Uri { get; }

        /// <summary>
        /// An <see cref="IParser"/> that can read/write files of this format.
        /// </summary>
        IParser Parser { get; }
    }
}
