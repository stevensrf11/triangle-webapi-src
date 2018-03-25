using System.Threading;
using System.Threading.Tasks;
using WebApi.Business.Layer.Interfaces.Models.Triangle;

namespace WebApi.Business.Layer.Interfaces.Processing.Triangle
{
    /// <summary>
    /// Business layer triangle processing operation interface
    /// <see cref="IBLProcessing"/>
    /// </summary>

    public interface IBLTriangleProcessing : IBLProcessing
    {
        /// <summary>
        ///  Retrieves triangle's start up information
        /// </summary>
        /// <param name="taskId">Task identification</param>
        /// <param name="bLTriangleModel">Business layer triangle model that contains  row and columm information </param>
        /// <param name="cancellationToken">Cancellation token to cancel operation</param>
        /// <returns>Business layer result model </returns>
        IBLResultBase TriangleStartUpInfo(long taskId
            , IBLTriangleModel bLTriangleModel
            , CancellationToken? cancellationToken = null);

        /// <summary>
        ///  Asynchronously retrieves triangle's start up information
        /// </summary>
        /// <param name="taskId">Task identification</param>
        /// <param name="bLTriangleModel">Business layer triangle model that contains row and column information </param>
        /// <param name="cancellationToken">Cancellation token to cancel operation</param>
        /// <returns>Business layer result model </returns>
        Task<IBLResultBase> TriangleStartUpInfoAsync(long taskId
            , IBLTriangleModel bLTriangleModel
            , CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Retrieves triangle vertice information
        /// </summary>
        /// <param name="taskId">Task identification</param>
        /// <param name="bLTriangleModel">Business layer triangle model that contains the  row and column information</param>
        /// <param name="cancellationToken">Cancellation token to cancel operation</param>
        /// <returns>Business layer result model that contains if the operation was successful
        /// and the triangle vertice information</returns>

        IBLResultBase TriangleCalculateVerices(long taskId
            , IBLTriangleModel bLTriangleModel
            , CancellationToken? cancellationToken = null);

        /// <summary>
        /// Asynchronously retrieves triangle vertice information
        /// </summary>
        /// <param name="taskId">Task identification</param>
        /// <param name="bLTriangleModel">Business layer triangle model that contains the  row and column information</param>
        /// <param name="cancellationToken">Cancellation token to cancel operation</param>
        /// <returns>Business layer result model that contains if the operation was successful
        /// and the triangle vertice information</returns>
        Task<IBLResultBase> TriangleCalculateVericesAsync(long taskId
            , IBLTriangleModel bLTriangleModel
            , CancellationToken cancellationToken = default(CancellationToken));

    }
}
