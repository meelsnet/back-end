using System;
using RestSharp;

namespace Media.API.Services
{
    public interface IApiRequestService
    {
        T Execute<T>(IRestRequest request, Uri baseUri) where T : new();
    }
}