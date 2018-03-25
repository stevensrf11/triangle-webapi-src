using System.Collections.Generic;
using WebApi.Data.Layer.Interfaces.Models;
using WebApi.Data.Layer.Interfaces.Models.Triangle;
namespace WebApi.Data.Layer.Models.Triangle
{
    /// <summary>
    /// Data layer triangle start up information model class <see cref="IDLTriangleStartUpInfo"/>
    /// </summary>
    public class DLTriangleStartUpInfoModel: IDLTriangleStartUpInfo
    {
        #region Accessor Properties
        /// <summary>
        /// List of row information
        /// </summary>
        public IList<IDLRowModel> Rows { get; }
        /// <summary>
        /// List of column information
        /// </summary>
        public IList<IDLColumnModel> Columns { get; }
        #endregion

        #region Constructors
        /// <summary>
        /// Positional constructor
        /// </summary>
        /// <param name="rows">List of row information</param>
        /// <param name="columns">List of column information</param>
        public DLTriangleStartUpInfoModel(IList<IDLRowModel> rows
            , IList<IDLColumnModel> columns)
        {
            Rows = rows;
            Columns = columns;
        }
        #endregion
    }
}
