using System.Collections.Generic;
using Infrastructure.Enums;

namespace Infrastructure.Interfaces
{
    public interface IResultBase
    {
        /// <summary>
        /// True if operation was successful
        /// </summary>
        bool ResultSuccess { get; set; }

        /// <summary>
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
