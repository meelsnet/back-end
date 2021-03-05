using System;
using RestSharp;

namespace Media.API.Services
{
    public class ApiRequestService : IApiRequestService
    {
        public T Execute<T>(IRestRequest request, Uri baseUri) where T : new()
        {
            var client = new RestClient
            {
                BaseUrl = baseUri
            };

            var response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                var message = "Error retrieving response. Check inner details for more info.";
                throw new ApplicationException(message, response.ErrorException);
            }

            return response.Data;
        }
    }
}