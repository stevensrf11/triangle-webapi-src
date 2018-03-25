namespace Web.Common.Interfaces.Model
{
    /// <summary>
    /// Link information model interface <see cref="IWebCommonModel"/>
    /// </summary>
    public interface ILinkModel : IWebCommonModel
    {
        /// <summary>
        /// Relative resource information
        /// </summary>
         string Rel { get; set; }
        /// <summary>
        /// URL address
        /// </summary>
         string Href { get; set; }
        /// <summary>
        /// Type of method (Get, Put, Delete,...)
        /// </summary>
         string Method { get; set; }
    }
}
