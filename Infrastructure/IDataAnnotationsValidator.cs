using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Infrastructure
{
    /// <summary>
    /// Data annotations interface
    /// </summary>
    public interface IDataAnnotationsValidator
    {
        /// <summary>
        /// Validates a list of properties
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objList"></param>
        /// <returns></returns>
        IList<Tuple<T, bool, IList<ValidationResult>>> TryValidateObjectList<T>(IEnumerable<T> objList);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="results"></param>
        /// <param name="validationContextItems"></param>
        /// <returns></returns>
        bool TryValidateObject<T>(T obj, List<ValidationResult> results, IDictionary<object, object> validationContextItems = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propInfos"></param>
        /// <param name="results"></param>
        /// <param name="validationContextItems"></param>
        /// <returns></returns>
        bool TryValidateObjectProperites(IList<Tuple<PropertyInfo, object>> propInfos
            , List<ValidationResult> results
            , IDictionary<object, object> validationContextItems = null);

        /// <summary>
        ///Searches for a property name in a list of validation errors.
        /// </summary>
        /// <returns>True if property name found in validation error list</returns>
        /// <remarks> Created 3/25/2017 </remarks>
        bool ValidatePropertyName(IList<ValidationResult> results, string propName);




    }

}
