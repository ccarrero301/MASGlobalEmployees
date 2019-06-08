using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MASGlobal.Employees.Rest.Entities;
using Newtonsoft.Json;
using Polly;
using RestSharp;
using IRestClient = MASGlobal.Employees.Rest.Contracts.IRestClient;

namespace MASGlobal.Employees.Rest.Implementations
{
    internal sealed class RestClient : IRestClient
    {
        public async Task<TResult> ExecutePostResultAsync<TResult>(RestClientRequest requestInfo)
        {
            var restClient = GetRestClient(true, requestInfo);
            var request = GetRequest(Method.POST, requestInfo);

            var restResponse = await ExecutePostWithResponseOrExceptionRetryPolicy<TResult>(restClient, request, 3, 1);

            if (restResponse.IsSuccessful)
                return JsonConvert.DeserializeObject<TResult>(restResponse.Content);

            throw new Exception(GetResponseErrorMessage(restResponse));
        }

        private static async Task<IRestResponse<TResult>> ExecutePostWithResponseOrExceptionRetryPolicy<TResult>(
            RestSharp.IRestClient restClient,
            IRestRequest request, int maxRetryAttempts, int retryFactor)
        {
            HttpStatusCode[] httpStatusCodesWorthRetrying =
            {
                HttpStatusCode.RequestTimeout, // 408
                HttpStatusCode.InternalServerError, // 500
                HttpStatusCode.BadGateway, // 502
                HttpStatusCode.ServiceUnavailable, // 503
                HttpStatusCode.GatewayTimeout // 504
            };

            return await Policy
                .Handle<Exception>()
                .OrResult<IRestResponse<TResult>>(restSharpResponse =>
                    httpStatusCodesWorthRetrying.Contains(restSharpResponse.StatusCode))
                .WaitAndRetryAsync(
                    maxRetryAttempts,
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(retryFactor, retryAttempt)),
                    (exception, timeSpan, retryCount, context) => { })
                .ExecuteAsync(() => restClient.ExecutePostTaskAsync<TResult>(request));
        }

        private static RestSharp.IRestClient GetRestClient(bool useHttp, RestClientRequest requestInfo)
        {
            var transferProtocol = useHttp ? "Http" : "Https";

            return new RestSharp.RestClient($"{transferProtocol}{requestInfo.BaseUri}");
        }

        private static IRestRequest GetRequest(Method method, RestClientRequest requestInfo, int timeout = 3600000)
        {
            var request = new RestRequest(requestInfo.Resource, method);

            AddHeaderParameters(request, requestInfo);
            AddQueryParameters(request, requestInfo);
            AddUriSegments(request, requestInfo);

            if (requestInfo.BodyAsJson != null)
                request.AddParameter("application/json", requestInfo.BodyAsJson, ParameterType.RequestBody);

            request.Timeout = timeout;

            return request;
        }

        private static void AddHeaderParameters(IRestRequest request, RestClientRequest requestInfo)
        {
            if (requestInfo.HeaderParameters == null)
                return;

            foreach (var headerParameter in requestInfo.HeaderParameters)
                request.AddHeader(headerParameter.Key, headerParameter.Value);
        }

        private static void AddQueryParameters(IRestRequest request, RestClientRequest requestInfo)
        {
            if (requestInfo.QueryParameters == null)
                return;

            foreach (var queryParameter in requestInfo.QueryParameters)
                request.AddQueryParameter(queryParameter.Key, queryParameter.Value);
        }

        private static void AddUriSegments(IRestRequest request, RestClientRequest requestInfo)
        {
            if (requestInfo.UriSegments == null)
                return;

            foreach (var uriSegment in requestInfo.UriSegments)
                request.AddUrlSegment(uriSegment.Key, uriSegment.Value);
        }

        private static string GetResponseErrorMessage(IRestResponse restResponse)
        {
            var errorExceptionMessage = restResponse.ErrorException?.Message ?? string.Empty;
            var errorMessage = restResponse.ErrorMessage ?? string.Empty;

            return $"Error Exception Message: {errorExceptionMessage}, " + $"Error Message : {errorMessage}, " +
                   $"Response Status : {restResponse.ResponseStatus}, " +
                   $"Response Status Code: {restResponse.StatusCode}, " +
                   $"Response Status Description: {restResponse.StatusDescription}";
        }
    }
}