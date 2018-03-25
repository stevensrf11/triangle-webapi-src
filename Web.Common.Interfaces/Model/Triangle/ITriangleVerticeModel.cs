namespace Web.Common.Interfaces.Model.Triangle
{
    /// <summary>
    /// Triangle vertice model interface <see cref="IWebCommonModel"/>
    /// </summary>
    public interface ITriangleVerticeModel : IWebCommonModel
    {
        /// <summary>
        /// X vertex value
        /// </summary>
        double XValue { get; set; }
        /// <summary>
        /// Y vertex value
        /// </summary>
        double YValue { get; set; }

    }
}
