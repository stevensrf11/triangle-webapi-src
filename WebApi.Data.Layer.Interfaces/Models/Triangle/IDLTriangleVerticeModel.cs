namespace WebApi.Data.Layer.Interfaces.Models.Triangle
{
    /// <summary>
    /// Data layer triangle vertice model interface <see cref="IDLModel"/>
    /// </summary>
    public interface IDLTriangleVerticeModel : IDLModel
    {
        /// <summary>
        /// X vertex value
        /// </summary>
        double XValue { get;  }
        /// <summary>
        /// Y vertex value
        /// </summary>
        double YValue { get; }
    }
}
