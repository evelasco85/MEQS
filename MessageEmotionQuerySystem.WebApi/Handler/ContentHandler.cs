using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace MessageEmotionQuerySystem.WebApi.Handler
{
    public class ContentHandler : DelegatingHandler
    {
        StringBuilder _requestContent;

        public StringBuilder RequestContent { get { return this._requestContent; } }

        public ContentHandler()
        {
            this._requestContent = new StringBuilder();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string body = await request.Content.ReadAsStringAsync();

            this._requestContent.Clear();
            this._requestContent.Append(body);

            return base
                .SendAsync(request, cancellationToken)
                .Result;
        }
    }
}