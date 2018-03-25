using System.Collections.Generic;
using Infrastructure.Enums;

namespace Infrastructure
{
    /// <summary>
    /// Operation result base interface
    /// </summary>
    public interface IResultBase
    {
        /// <summary>
        /// Result of operation
        /// True if operation was successful
        /// </summary>
        bool ResultSuccess { get; set; }

        /// <summary>
        /// Indication if ersult contains error
        /// True if errors contains 
        /// </summary>
        bool HasErrors { get; set; }

        /// <summary>
        /// List of errors
        /// </summary>
        IList<string> Errors { get; set; }


        /// <summary>
        /// Type of result operation <see cref="ResultOperationEnums"/>
        /// </summary>
        ResultOperationEnums ResultOperation { get; set; }

        /// <summary>
        /// Result content object
        /// </summary>
        dynamic ResultContent { get; set; }
    }

}
