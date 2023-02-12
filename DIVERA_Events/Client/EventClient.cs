using System.Net.Http;

namespace Client
{
    public sealed class EventClient : api_v2_eventClient
    {
        public EventClient(ClientConfig config) : base(new HttpClient())
        {
            BaseUrl = config.Url;
            APIKey = config.ApiKey;    
        }
    }
}
