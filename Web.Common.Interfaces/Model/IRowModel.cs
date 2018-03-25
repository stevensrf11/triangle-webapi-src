namespace Web.Common.Interfaces.Model
{
    /// <summary>
    /// Row information model interface <see cref="IWebCommonModel"/>
    /// </summary>
    public interface IRowModel : IWebCommonModel
    {
        /// <summary>
        /// Row value
        /// </summary>
        string RowValue { get; set; }
    }
}
