using Web.Common.Interfaces.Model;

namespace Web.Common.Models
{
    /// <summary>
    /// Column information model interface <see cref="IColumnModel"/>
    /// </summary>
    public class ColumnModel :IColumnModel
    {
        /// <summary>
        /// Column value
        /// </summary>
        public int ColumnValue { get; set; }
    }
}
