using Extensions;
using System.Net.Http;
using System.Text;

namespace Client
{
    partial class api_v2_eventClient
    {
        protected string APIKey {get; set;}
        
        void PrepareRequest(HttpClient client, HttpRequestMessage request,StringBuilder urlBuilder)
        {
            if (!APIKey.IsNullOrWhiteSpace())
                urlBuilder.Append("?accesskey=" + APIKey);
        }

    }
}
