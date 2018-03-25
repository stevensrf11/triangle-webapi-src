using System.Collections.Generic;

namespace WebApi.Data.Layer.Interfaces.Models.Triangle
{
    /// <summary>
    /// Data layer triangle start up information model interface <see cref="IDLModel"/>
    /// </summary>

    public interface IDLTriangleStartUpInfo : IDLModel
    {
        /// <summary>
        /// List of row information
        /// </summary>
        IList<IDLRowModel> Rows { get; }
        /// <summary>
        /// List of column information
        /// </summary>
        IList<IDLColumnModel> Columns { get; }

    }
}
