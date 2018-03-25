using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Enums;

namespace Infrastructure
{
    public class ResultBase : IResultBase
    {
        #region Properties
        /// <summary>
        /// Indicates if operation successful
        /// </summary>
        public bool ResultSuccess { get; set; }

        /// <summary>
        /// True if errors contains 
        /// </summary>
        public bool HasErrors
        {
            get { return Errors != null && Errors.Count > 0; }
            set { }
        }
        /// <summary>
        /// Type of result operation <see cref="ResultOperationEnums"/>
        /// </summary>
        /// 
        /// <summary>
        /// List of errors
        /// </summary>
        public IList<string> Errors { get; set; }
        public ResultOperationEnums ResultOperation { get; set; }
        /// <summary>
        /// Result content object
        /// </summary>
        public dynamic ResultContent { get; set; }
        #endregion

        #region Constructor

        public ResultBase(bool resultSuccess, ResultOperationEnums resultOperation, object resultContent, IList<string> errors)
            : this(resultSuccess, resultOperation, resultContent)
        {
            if (errors != null)
                Errors = errors;

        }

        public ResultBase(bool resultSuccess, ResultOperationEnums resultOperation, dynamic resultContent)
        {
            ResultSuccess = resultSuccess;
            ResultOperation = resultOperation;
            ResultContent = resultContent;
        }

        public ResultBase()
        {

        }
        #endregion
    }


}
