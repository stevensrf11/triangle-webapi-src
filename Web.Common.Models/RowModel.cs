using Web.Common.Interfaces.Model;

namespace Web.Common.Models
{
    /// <summary>
    /// Row information model class <see cref="IRowModel"/>
    /// </summary>
    public class RowModel : IRowModel
    {
        /// <summary>
        /// Row value
        /// </summary>
        public string RowValue { get; set; }
    }
}
