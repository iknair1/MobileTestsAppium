using RestSharp;
using UrlCombineLib;

namespace Zonal.App.Shell.PRTests.Helpers
{
    public class RestHelper
    {     
        private RestClient restClient;
        private RestRequest restRequest;
        private string restClientUrl;

        public RestHelper()
        {               
        }

        public void SetUrl(string baseUrl, string endpoint)
        {
            restClientUrl = UrlCombine.Combine(baseUrl, endpoint);
        }

        public void CreateRequest(Method method)
        {
            restRequest = new RestRequest(method);
            restRequest.AddHeader("Accept", "application/json");
        }

        public IRestResponse ExecuteRequest()
        {
            restClient = new RestClient(restClientUrl);
            return restClient.Execute(restRequest);
        }      

        public void AddBody(object body)
        {
            restRequest.AddJsonBody(body);
        }
    }
}
