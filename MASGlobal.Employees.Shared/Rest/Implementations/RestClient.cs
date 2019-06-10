﻿using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MASGlobal.Employees.Shared.Rest.Entities;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using RestSharp;
using IRestClient = MASGlobal.Employees.Shared.Rest.Contracts.IRestClient;

namespace MASGlobal.Employees.Shared.Rest.Implementations
{
    public sealed class RestClient : IRestClient
    {
        public async Task<TResult> ExecutePostResultAsync<TResult>(RestClientRequest requestInfo)
        {
            var restClient = GetRestClient(false, requestInfo);
            var request = GetRequest(Method.POST, requestInfo);

            var restResponse =
                await ExecutePostWithResponseOrExceptionRetryPolicyAsync<TResult>(restClient, request, 3, 1)
                    .ConfigureAwait(false);

            if (restResponse.IsSuccessful)
                return JsonConvert.DeserializeObject<TResult>(restResponse.Content);

            throw new Exception(restResponse.Content.Trim('"'));
        }

        public async Task<TResult> ExecuteGetResultAsync<TResult>(RestClientRequest requestInfo)
        {
            var restClient = GetRestClient(false, requestInfo);
            var request = GetRequest(Method.GET, requestInfo);

            var restResponse =
                await ExecuteGetWithResponseOrExceptionRetryPolicyAsync<TResult>(restClient, request, 3, 1)
                    .ConfigureAwait(false);

            if (restResponse.IsSuccessful)
                return JsonConvert.DeserializeObject<TResult>(restResponse.Content);

            throw new Exception(restResponse.Content.Trim('"'));
        }

        private static Task<IRestResponse<TResult>> ExecutePostWithResponseOrExceptionRetryPolicyAsync<TResult>(
            RestSharp.IRestClient restClient,
            IRestRequest request, int maxRetryAttempts, int retryFactor)
        {
            var retryPolicy = DefineRetryPolicy<TResult>(maxRetryAttempts, retryFactor);

            return retryPolicy.ExecuteAsync(() => restClient.ExecutePostTaskAsync<TResult>(request));
        }

        private static Task<IRestResponse<TResult>> ExecuteGetWithResponseOrExceptionRetryPolicyAsync<TResult>(
            RestSharp.IRestClient restClient,
            IRestRequest request, int maxRetryAttempts, int retryFactor)
        {
            var retryPolicy = DefineRetryPolicy<TResult>(maxRetryAttempts, retryFactor);

            return retryPolicy.ExecuteAsync(() => restClient.ExecuteGetTaskAsync<TResult>(request));
        }

        private static AsyncRetryPolicy<IRestResponse<TResult>> DefineRetryPolicy<TResult>(int maxRetryAttempts,
            int retryFactor)
        {
            HttpStatusCode[] httpStatusCodesWorthRetrying =
            {
                HttpStatusCode.RequestTimeout, // 408
                HttpStatusCode.InternalServerError, // 500
                HttpStatusCode.BadGateway, // 502
                HttpStatusCode.ServiceUnavailable, // 503
                HttpStatusCode.GatewayTimeout // 504
            };

            var retryPolicy = Policy
                .Handle<Exception>()
                .OrResult<IRestResponse<TResult>>(restSharpResponse =>
                    httpStatusCodesWorthRetrying.Contains(restSharpResponse.StatusCode))
                .WaitAndRetryAsync(
                    maxRetryAttempts,
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(retryFactor, retryAttempt)),
                    (exception, timeSpan, retryCount, context) => { });

            return retryPolicy;
        }

        private static RestSharp.IRestClient GetRestClient(bool useHttp, RestClientRequest requestInfo)
        {
            var transferProtocol = useHttp ? "http://" : "https://";

            var baseUri = $"{transferProtocol}{requestInfo.BaseUri}";

            return new RestSharp.RestClient(baseUri);
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
    }
}