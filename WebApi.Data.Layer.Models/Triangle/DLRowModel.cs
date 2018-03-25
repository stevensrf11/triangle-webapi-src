using WebApi.Data.Layer.Interfaces.Models;

namespace WebApi.Data.Layer.Models.Triangle
{
    /// <summary>
    /// Date layer row model class <see cref="IDLRowModel"/>
    /// </summary>
    public class DLRowModel : IDLRowModel
    {
        #region Accessor Properties
        /// <summary>
        /// Row value
        /// </summary>
        public string Row { get; }
        #endregion

        #region Constructor
        /// <summary>
        /// Positional Constructor
        /// </summary>
        /// <param name="row">Row value</param>
        public DLRowModel(string row)
        {
            Row = row;
        }
        #endregion
    }
}
