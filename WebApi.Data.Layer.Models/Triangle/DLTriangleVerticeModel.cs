using WebApi.Data.Layer.Interfaces.Models.Triangle;

namespace WebApi.Data.Layer.Models.Triangle
{
    /// <summary>
    /// Data layer triangle vertice model class<see cref="IDLTriangleVerticeModel"/>
    /// </summary>
    public class DLTriangleVerticeModel : DLModel,
        IDLTriangleVerticeModel
    {
        #region Accessor Properties
        /// <summary>
        /// X vertex value
        /// </summary>
        public double XValue { get; }
        /// <summary>
        /// Y vertex value
        /// </summary>
        public double YValue { get;  }
        #endregion

        #region Constructors
        /// <summary>
        /// Positional constructor
        /// </summary>
        /// <param name="xValue">X vertex value</param>
        /// <param name="yValue">Y vertex value</param>
        public DLTriangleVerticeModel(double xValue, double yValue)
        {
            XValue = xValue;
            YValue = yValue;
        }
        #endregion
    }
}
