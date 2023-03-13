using Microsoft.AspNetCore.Http;

namespace EventSourcing.Library.Metadata;

public class HttpContextMetadataResolver : IMetadataResolver
{
    private IHttpContextAccessor httpContext;

    public HttpContextMetadataResolver(IHttpContextAccessor httpContext)
    {
        this.httpContext = httpContext;
    }

    public IDictionary<string, string> Resolve(object @event)
    {
        if (this.httpContext?.HttpContext == null)
        {
            return new Dictionary<string, string>();
        }

        return new Dictionary<string, string>
            {
                { "IpAddress", this.httpContext.HttpContext.Connection?.RemoteIpAddress?.ToString() },
            };
    }
}