using System.Collections.Generic;
using WebApi.Business.Layer.Interfaces.Models.Triangle;

namespace WebApi.Business.Layer.Models.Triangle
{
    /// <summary>
    /// Business layer start up information model class <see cref="IBLTriangleStartupInfoModel"/>
    /// </summary>
    public class BLTriangleStartupInfoModel : BLModel
        , IBLTriangleStartupInfoModel
    {
        #region Accessor Properties
        /// <summary>
        /// List of row strings
        /// </summary>
        public IList<string> Rows { get; }

        public IList<int> Columns { get; }
        /// <summary>
        /// List of column integers
        /// </summary>
        #endregion

        #region Constructor

        /// <summary>
        /// Positional constructor
        /// </summary>
        /// <param name="rows">List of row strings</param>
        /// <param name="columns">List of column integers</param>
        public BLTriangleStartupInfoModel(IList<string> rows, IList<int> columns)
        {
            Rows = rows;
            Columns = columns;
        }
        #endregion
    }
}
