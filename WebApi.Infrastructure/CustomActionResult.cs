using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApi.Infrastructure
{
    /// <summary>
    /// Custom HttpRespone <see cref="IHttpActionResult"/> class  used to return information to client
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CustomActionResult<T> : IHttpActionResult

    {
        #region Fields
        /// <summary>
        /// Status code result
        /// </summary>
        private readonly System.Net.HttpStatusCode _statusCode;
        /// <summary>
        /// Information
        /// </summary>
        readonly T _data;
        #endregion

        #region Constructor
        /// <summary>
        /// Positional Constructor
        /// </summary>
        /// <param name="statusCode"> Status code result of operation</param>
        /// <param name="data"> Information</param>
        public CustomActionResult(System.Net.HttpStatusCode statusCode, T data)
        {
            _statusCode = statusCode;
            _data = data;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {

            return Task.FromResult(CreateResponse(_statusCode, _data));

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public HttpResponseMessage CreateResponse(System.Net.HttpStatusCode statusCode, T data)
        {

            var request = new HttpRequestMessage();
            request.Properties.Add(System.Web.Http.Hosting.HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            var response = request.CreateResponse(statusCode, data);
            return response;

        }
    }

}