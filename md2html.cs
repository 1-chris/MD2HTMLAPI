using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Markdig;

namespace MD2HTMLAPI.FUNCTION
{
    public class md2html
    {
        private readonly ILogger _logger;

        public md2html(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<md2html>();
        }

        [Function("md2html")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            if (req.Body != null)
                response.WriteString(Markdig.Markdown.ToHtml(req.Body.ToString()));

            return response;
        }
    }
}
