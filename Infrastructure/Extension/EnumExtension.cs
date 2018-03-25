using System;

namespace Infrastructure.Extension
{
    /// <summary>
    /// Enumeration extension class used to convert string and integers to corresponding enumerator type value.
    /// Parameters are provide to enforce or ignore string case and to throw exceptions or return a value of zero
    /// if conversion fails. 
    /// </summary>
    public static class EnumExtension
    {


        #region String to Enum
        /// <summary>
        /// Parse method to convert a string to its equivalent enumeration value
        /// </summary>
        /// <typeparam name="T">Enumerator type</typeparam>
        /// <param name="inString">String to convert</param>
        /// <param name="ignoreCase">True to ignore string case rules</param>
        /// <param name="throwException">True to throw an InvalidOperationException exception in conversion fails</param>
        /// <returns>Converted enumerator value or default value</returns>

        /// <returns></returns>
        public static T ParseEnum<T>(string inString, bool ignoreCase = true, bool throwException = true) where T : struct
        {
            return (T)ParseEnum<T>(inString, default(T), ignoreCase, throwException);
        }

        /// <summary>
        /// Parse method to convert a string to its equivalent enumeration value
        /// </summary>
        /// <typeparam name="T">Enumerator type</typeparam>
        /// <param name="inString">String to convert</param>
        /// <param name="defaultValue">Default enumerator value to return if operation fails</param>
        /// <param name="ignoreCase">True to ignore string case rules</param>
        /// <param name="throwException">True to throw an InvalidOperationException exception in conversion fails</param>
        /// <returns>Converted enumerator value or default value</returns>
        /// <exception cref="InvalidOperationException"> Thrown when a method call is invalid for the object's current state</exception>

        public static T ParseEnum<T>(string inString, T defaultValue,
                               bool ignoreCase = true, bool throwException = false) where T : struct
        {
            T returnEnum = defaultValue;

            if (!typeof(T).IsEnum || String.IsNullOrEmpty(inString))
            {
                if (throwException)
                    throw new InvalidOperationException("Invalid Enum Type or Input String 'inString'. " + typeof(T).ToString() + "  must be an Enum");
                else
                {
                    return returnEnum;
                }
            }

            try
            {
                bool success = Enum.TryParse<T>(inString, ignoreCase, out returnEnum);
                if (!success && throwException)
                {
                    throw new InvalidOperationException("Invalid Cast");
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Invalid Cast", ex);
            }

            return returnEnum;
        }
        #endregion

        #region Int to Enum
        /// <summary>
        /// Parse method to convert an integer to its equivalent enumeration value
        /// </summary>
        /// <typeparam name="T">Enumerator type</typeparam>
        /// <param name="input">Integer value to convert</param>
        /// <param name="throwException">True to throw an InvalidOperationException exception in conversion fails</param>
        /// <returns>Converted enumerator value or default value</returns>
        /// <exception cref="InvalidOperationException"> Thrown when a method call is invalid for the object's current state</exception>

        public static T ParseEnum<T>(int input, bool throwException = true) where T : struct
        {
            return (T)ParseEnum<T>(input, default(T), throwException);
        }

        /// <summary>
        /// Parse method to convert an integer to its equivalent enumeration value
        /// </summary>
        /// <typeparam name="T">Enumerator type</typeparam>
        /// <param name="input">Integer value to convert</param>
        /// <param name="defaultValue">Default enumerator value to return if operation fails</param>
        /// <param name="throwException">True to throw an InvalidOperationException exception in conversion fails</param>
        /// <returns>Converted enumerator value or default value</returns>
        /// <exception cref="InvalidOperationException"> Thrown when a method call is invalid for the object's current state</exception>
        public static T ParseEnum<T>(int input, T defaultValue, bool throwException = false) where T : struct
        {
            T returnEnum = defaultValue;
            if (!typeof(T).IsEnum)
            {
                throw new InvalidOperationException("Invalid Enum Type. " + typeof(T).ToString() + "  must be an Enum");
            }
            if (Enum.IsDefined(typeof(T), input))
            {
                returnEnum = (T)Enum.ToObject(typeof(T), input);
            }
            else
            {
                if (throwException)
                {
                    throw new InvalidOperationException("Invalid Cast");
                }
            }

            return returnEnum;

        }
        #endregion

        #region String Extension Methods for Enum Parsing
        /// <summary>
        /// Extension method to convert an string to its equivalent enumeration value
        /// </summary>
        /// <typeparam name="T">Enumerator type</typeparam>
        /// <param name="inString">String to convert</param>
        /// <param name="ignoreCase">True to ignore string case rules</param>
        /// <param name="throwException">True to throw an InvalidOperationException exception in conversion fails</param>
        /// <returns>Converted enumerator value or default value</returns>
        /// <exception cref="InvalidOperationException"> Thrown when a method call is invalid for the object's current state</exception>       

        public static T ToEnum<T>(this string inString, bool ignoreCase = true, bool throwException = true) where T : struct
        {
            return (T)ParseEnum<T>(inString, ignoreCase, throwException);
        }

        /// <summary>
        /// Extension method to convert an string to its equivalent enumeration value
        /// </summary>
        /// <typeparam name="T">Enumerator type</typeparam>
        /// <param name="inString">String to convert</param>
        /// <param name="defaultValue"> Default enumerator value</param>
        /// <param name="ignoreCase">True to ignore string case rules</param>
        /// <param name="throwException">True to throw an InvalidOperationException exception in conversion fails</param>
        /// <returns>Converted enumerator value or default value</returns>
        /// <exception cref="InvalidOperationException"> Thrown when a method call is invalid for the object's current state</exception>
        public static T ToEnum<T>(this string inString, T defaultValue, bool ignoreCase = true, bool throwException = false) where T : struct
        {
            return (T)ParseEnum<T>(inString, defaultValue, ignoreCase, throwException);
        }
        #endregion

        #region Int Extension Methods for Enum Parsing
        /// <summary>
        /// Extension method to convert an integer to its equivalent enumeration value
        /// </summary>
        /// <typeparam name="T">Enumerator type</typeparam>
        /// <param name="input">Integer to convert</param>
        /// <param name="throwException">True to throw an InvalidOperationException exception in conversion fails</param>
        /// <returns>Converted enumerator value or default value</returns>
        /// <exception cref="InvalidOperationException"> Thrown when a method call is invalid for the object's current state</exception>       
        public static T ToEnum<T>(this int input, bool throwException = true) where T : struct
        {
            return (T)ParseEnum<T>(input, default(T), throwException);
        }

        /// <summary>
        /// Extension method to convert an integer to its equivalent enumeration value
        /// </summary>
        /// <typeparam name="T">Enumerator type</typeparam>
        /// <param name="input">Integer to convert</param>
        /// <param name="defaultValue"> Default enumerator value</param>
        /// <param name="throwException">True to throw an InvalidOperationException exception in conversion fails</param>
        /// <returns>Converted enumerator value or default value</returns>
        /// <exception cref="InvalidOperationException"> Thrown when a method call is invalid for the object's current state</exception>       
        public static T ToEnum<T>(this int input, T defaultValue, bool throwException = false) where T : struct
        {
            return (T)ParseEnum<T>(input, defaultValue, throwException);
        }
        #endregion
    }
}
