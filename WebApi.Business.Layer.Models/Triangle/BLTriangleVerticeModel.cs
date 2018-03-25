using WebApi.Business.Layer.Interfaces.Models.Triangle;

namespace WebApi.Business.Layer.Models.Triangle
{
    /// <summary>
    /// Business layer vertice model class <see cref="IBLTriangleVerticeModel"/>
    /// </summary>
    public class BLTriangleVerticeModel : BLModel,
        IBLTriangleVerticeModel
    {
        #region Accessor Properties
        /// <summary>
        /// X vertex
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
        /// <param name="xValue">X vertex</param>
        /// <param name="yValue">Y vertex value</param>
        public BLTriangleVerticeModel(double xValue, double yValue)
        {
            XValue = xValue;
            YValue = yValue;
        }
        #endregion
    }
}
