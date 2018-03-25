using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApi.Infrastructure.Filters.Attributes
{
    /// <summary>
    /// Derived Attribute <see cref="AuthorizationFilterAttribute"/>that  requires request be sent via https
    /// </summary>
    public class RequireHttpsAttribute : AuthorizationFilterAttribute
    {
        /// <summary>
        ///  Override  process requests authorization method. 
        /// Used to verify request was sent via https
        /// </summary>
        /// <param name="actionContext">The action context, which encapsulates information for using AuthorizationFilterAttribute.</param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden)
                {
                    ReasonPhrase = "HTTPS Required"
                };
            }
            else
            {
                base.OnAuthorization(actionContext);
            }
        }
    }
  
}
