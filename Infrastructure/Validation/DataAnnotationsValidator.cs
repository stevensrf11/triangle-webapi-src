using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Infrastructure.Validation
{
    /// <summary>
    /// Perform data annotation validation on requested properties 
    /// <see cref="IDataAnnotationsValidator"/>
    /// </summary>
    public class DataAnnotationsValidator : IDataAnnotationsValidator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="results">List of validation results</param>
        /// <param name="validationContextItems"></param>
        /// <returns></returns>
        public bool TryValidate(object obj, ICollection<ValidationResult> results, IDictionary<object, object> validationContextItems = null)
        {
            return Validator.TryValidateObject(obj, new ValidationContext(obj, null, validationContextItems), results, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objList"></param>
        /// <returns></returns>
        public IList<Tuple<T, bool, IList<ValidationResult>>> TryValidateObjectList<T>(IEnumerable<T> objList)
        {
            var retVal = new List<Tuple<T, bool, IList<ValidationResult>>>();
            foreach (var objItem in objList)
            {
                var validationResults = new List<ValidationResult>();
                retVal.Add(new Tuple<T, bool, IList<ValidationResult>>(objItem, TryValidate(objItem, validationResults), validationResults));
            }
            return retVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="results"></param>
        /// <param name="validationContextItems"></param>
        /// <returns></returns>
        public bool TryValidateObject<T>(T obj, List<ValidationResult> results, IDictionary<object, object> validationContextItems = null)
        {
            return TryValidate(obj, results, validationContextItems);

            //         var properties = obj.GetType().GetProperties().Where(prop => prop.CanRead 
            //             && !prop.GetCustomAttributes(typeof(SkipRecursiveValidation), false).Any() 
            //             && prop.GetIndexParameters().Length == 0).ToList();

            //foreach (var property in properties)
            //{
            //	if (property.PropertyType == typeof(string) || property.PropertyType.IsValueType) continue;

            //	var value = obj.GetPropertyValue(property.Name);

            //	if (value == null) continue;

            //	var asEnumerable = value as IEnumerable;
            //	if (asEnumerable != null)
            //	{
            //		foreach (var enumObj in asEnumerable)
            //		{
            //			var nestedResults = new List<ValidationResult>();
            //			if (!TryValidateObjectRecursive(enumObj, nestedResults, validationContextItems))
            //			{
            //				result = false;
            //				foreach (var validationResult in nestedResults)
            //				{
            //					PropertyInfo property1 = property;
            //					results.Add(new ValidationResult(validationResult.ErrorMessage, validationResult.MemberNames.Select(x => property1.Name + '.' + x)));
            //				}
            //			};
            //		}
            //	}
            //	else
            //	{
            //		var nestedResults = new List<ValidationResult>();
            //		if (!TryValidateObjectRecursive(value, nestedResults, validationContextItems))
            //		{
            //			result = false;
            //			foreach (var validationResult in nestedResults)
            //			{
            //				PropertyInfo property1 = property;
            //				results.Add(new ValidationResult(validationResult.ErrorMessage, validationResult.MemberNames.Select(x => property1.Name + '.' + x)));
            //			}
            //		};
            //	}
            //}

            //return result;
        }
        /// <summary>
        ///  Performs validation on Custom and DataAnnotation <see cref=""ValidationAttribute/> given a list of 
        ///  <see cref="PropertyInfo"/>objects, and  corresponding object classes. Only one ValidationResult is recorded
        /// per failed <see cref="PropertyInfo"/>  <see cref=""ValidationAttribute/> validation.
        /// </summary>
        /// <param name="propInfos">List of properly information objects, and corresponding object classes to validation</param>
        /// <param name="results">List of <see cref="ValidationResult"/> objects for failed validations</param>
        /// <param name="validationContextItems">Not used</param>
        /// <returns>True if all property  custom and dataannotation validations were successful</returns>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="TypeLoadException"></exception>
        /// <remarks>
        /// Created 2/26/2017
        /// No exception handling provided in this method.
        /// </remarks>
        public bool TryValidateObjectProperites(IList<Tuple<PropertyInfo, object>> propInfos
            , List<ValidationResult> results
            , IDictionary<object, object> validationContextItems = null)
        {
            foreach (var propInfo in propInfos)
            {
                var attributes = propInfo.Item1.GetCustomAttributes(false).Where(x => x is ValidationAttribute);
                foreach (var validAttrVal2 in from validAttr
                                              in attributes.OfType<ValidationAttribute>()
                                              let vContext = new ValidationContext(propInfo.Item2)
                                              select validAttr.GetValidationResult(propInfo.Item1.GetValue(propInfo.Item2), vContext)
                                              into validAttrVal2
                                              where validAttrVal2 != null
                                              select validAttrVal2)
                {
                    // Validation failed add to ValidationResult list 
                    results.Add(validAttrVal2);
                    // Break attributes for list and process next property
                    break;
                }
            }
            return results.Count == 0;
        }

        /// <summary>
        ///Searches for a property name a list of validation errors.
        /// </summary>
        /// <param name="results">List of validation errors</param>
        /// <param name="propName">PropertyName</param>
        /// <returns>True if property name found in validation error list</returns>
        /// <remarks>
        /// Created 3/25/2017
        /// </remarks>
        public bool ValidatePropertyName(IList<ValidationResult> results, string propName)
        {
            return results.Select(l => l.MemberNames).Any(ll => ll.Any(m => string.Compare(m, propName, StringComparison.OrdinalIgnoreCase) == 0));

        }

        /// <summary>
        /// Verifies is all property values from a given property type are null.
        /// </summary>
        /// <param name="source">Source Type </param>
        /// <param name="propType">Property type</param>
        /// <returns>True if all property values are null</returns>
        /// <remarks>
        /// Created 3/25/2017
        /// </remarks>
        public bool ValidateAllPropertyTypeValuesNull(dynamic source, Type propType)
        {
            PropertyInfo[] properties = source.GetType().GetProperties();
            var proppertiesPropType = properties.Where(x => x.PropertyType == propType);
            return proppertiesPropType.All(prop => prop.GetValue(source) == null);

        }

       
        /// <summary>
        /// Connection time validation rule where all identification must be valid and one date time value must be valid(have a value)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="results"></param>
        /// <param name="propName"></param>
        /// <param name="sourceList"></param>
        /// <param name="propType"></param>
        /// <returns>True if connection id time rule passes</returns>
        public bool ValidateConnectionIdTimeRule<T>(IList<IList<ValidationResult>> results, string propName, IList<T> sourceList, Type propType)
        {
            var validResult = false;
            // All identification valid
            foreach (var r in results)
            {
                validResult = ValidatePropertyName(r, propName);
                if (validResult)
                {
                    break;
                }

            }
            // verify at least one datetime value
            if (!validResult)
            {
                foreach (var r in sourceList)
                {
                    validResult = ValidateAllPropertyTypeValuesNull(r, propType);
                    if (validResult)
                    {
                        break;
                    }
                }
            }
            return !validResult;
        }

    }

}
