using System.Collections.Generic;
using System.Web;

// ReSharper disable once CheckNamespace
namespace Riganti.Utils.Infrastructure.Logging
{
    public class DefaultWebAdditionalDataProvider : IAdditionalDataProvider
    {
        public void ExtractAdditinalData(IDictionary<string, string> additionalData)
        {
            var context = HttpContext.Current;
            if (context == null)
            {
                return;
            }

            additionalData["IsUserLogged"] = (context.User?.Identity?.IsAuthenticated ?? false).ToString();
            additionalData["LoggedUser"] = context.User?.Identity?.Name ?? "";
            additionalData["RemoteIpAddress"] = context.Request?.UserHostAddress;
            additionalData["RequestUrl"] = context.Request?.Url?.ToString();
            additionalData["RequestHttpMethod"] = context.Request?.HttpMethod;
        }
    }
}