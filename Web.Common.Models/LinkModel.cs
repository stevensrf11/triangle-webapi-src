using Web.Common.Interfaces.Model;

namespace Web.Common.Models
{
    /// <summary>
    /// Link information model class <see cref="ILinkModel"/>
    /// </summary>
    public class LinkModel : ILinkModel
    {
        /// <summary>
        /// Relative resource information
        /// </summary>
        public string Rel { get; set; }
        /// <summary>
        /// URL address
        /// </summary>
        public string Href { get; set; }
        /// <summary>
        /// Type of method (Get, Put, Delete,...)
        /// </summary>
        public string Method { get; set; }
    }
}
