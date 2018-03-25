using WebApi.Data.Layer.Interfaces.Models;

namespace WebApi.Data.Layer.Models.Triangle
{
    /// <summary>
    /// Data layer column model class <see cref="IDLColumnModel"/>
    /// </summary>
    public class DLColumnModel : IDLColumnModel
    {
        #region Accessor Properties
        /// <summary>
        /// Column value
        /// </summary>
        public int Column { get; }
        #endregion

        #region Constructors
        /// <summary>
        /// Positional constructor
        /// </summary>
        /// <param name="column">Column value</param>
        public DLColumnModel(int column)
        {
            Column = column;
        }
        #endregion
    }
}
