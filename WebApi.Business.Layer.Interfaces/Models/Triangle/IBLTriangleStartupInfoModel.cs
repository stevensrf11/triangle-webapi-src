using System.Collections.Generic;

namespace WebApi.Business.Layer.Interfaces.Models.Triangle
{
    /// <summary>
    /// Business layer start up information model interface <see cref="IBLModel"/>
    /// </summary>
    public interface IBLTriangleStartupInfoModel :IBLModel
    {
        /// <summary>
        /// List of row strings
        /// </summary>
        IList<string> Rows { get; }
        /// <summary>
        /// List of column integers
        /// </summary>
        IList<int> Columns { get; }
    }
}
