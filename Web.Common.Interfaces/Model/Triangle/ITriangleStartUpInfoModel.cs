using System.Collections.Generic;

namespace Web.Common.Interfaces.Model.Triangle
{
    /// <summary>
    /// Triangle model startup information interface <see cref="ITriangleModel"/>
    /// </summary>
    public interface ITriangleStartUpInfoModel : ITriangleModel
    {
        /// <summary>
        /// List of row model information
        /// </summary>
        IList<IRowModel> Rows { get;  }
        /// <summary>
        /// List cof column model information
        /// </summary>
        IList<IColumnModel> Columns { get;  }

    }
}
