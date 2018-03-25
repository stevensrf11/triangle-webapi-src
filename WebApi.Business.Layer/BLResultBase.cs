using System.Collections.Generic;
using Infrastructure;
using Infrastructure.Enums;
using WebApi.Business.Layer.Interfaces;
using WebApi.Business.Layer.Interfaces.Models.Triangle;

namespace WebApi.Business.Layer
{
    /// <summary>
    /// Business layer result class.
    /// Contains the result of an operation and data information
    /// <see cref="IBLResultBase"/> <seealso cref="ResultBase"/>
    /// </summary>
    public class BLResultBase : ResultBase
       ,IBLResultBase
    {
        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public BLResultBase() 
        {
        }

        /// <summary>
        /// Positional constructor
        /// </summary>
        /// <param name="resultSuccess">True if operation was successful</param>
        /// <param name="resultOperation">Operation type</param>
        /// <param name="resultContent">Data information</param>
        /// <param name="errorList">Error list why an operation failed</param>
        public BLResultBase(bool resultSuccess
            , ResultOperationEnums resultOperation
            , IBLTriangleModel resultContent
            , IList<string> errorList)
           :base(resultSuccess,resultOperation,resultContent, errorList)
        {
        }
        #endregion
    }

}
