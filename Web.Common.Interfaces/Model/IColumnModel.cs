namespace Web.Common.Interfaces.Model
{
    /// <summary>
    /// Column information model interface <see cref="IWebCommonModel"/>
    /// </summary>
    public interface IColumnModel : IWebCommonModel
    {
        /// <summary>
        /// Column value
        /// </summary>
        int ColumnValue { get; set; }
    }
}
