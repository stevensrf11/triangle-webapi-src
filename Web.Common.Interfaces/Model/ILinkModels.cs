using System.Collections.Generic;

namespace Web.Common.Interfaces.Model
{
    /// <summary>
    /// List of link models <see cref="ILinkModel"/> mnodel interface <see cref="IWebCommonModel"/>
    /// </summary>
    public interface ILinkModels : IWebCommonModel
    {
        /// <summary>
        /// List of LinkModel
        /// </summary>
        IList<ILinkModel> Links { get; set; }
    }
}
