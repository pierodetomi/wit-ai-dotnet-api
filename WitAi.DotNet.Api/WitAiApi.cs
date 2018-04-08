using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WitAi.DotNet.Api.Extensions;
using WitAi.DotNet.Api.Models.Request;
using WitAi.DotNet.Api.Models.Response;

namespace WitAi.DotNet.Api
{
    public class WitAiApi
    {
        private const string BASE_API_URL = "https://api.wit.ai";

        private const string DEFAULT_API_VERSION = "20170307";

        private string ApiVersion { get; set; }

        public WitAiApi()
        {
            ApiVersion = DEFAULT_API_VERSION;
        }

        public WitAiApi(string apiVersion)
        {
            if (String.IsNullOrEmpty(apiVersion))
                throw new Exception("apiVersion parameter must be specified");

            ApiVersion = apiVersion;
        }

        public async Task<CreateWitAppResponse> CreateApp(CreateWitAppRequest request)
        {
            string url = $"{BASE_API_URL}/apps?v={ApiVersion}";
            return await Post<CreateWitAppRequest, CreateWitAppResponse>(url, request);
        }

        public async Task<UpdateWitAppResponse> UpdateApp(UpdateWitAppRequest request)
        {
            string url = $"{BASE_API_URL}/apps/{request.AppId}?v={ApiVersion}";
            return await Put<UpdateWitAppRequest, UpdateWitAppResponse>(url, request);
        }

        public async Task<DeleteWitAppResponse> DeleteApp(DeleteWitAppRequest request)
        {
            string url = $"{BASE_API_URL}/apps/{request.AppId}?v={ApiVersion}";
            return await Delete<DeleteWitAppRequest, DeleteWitAppResponse>(url, request);
        }

        public async Task<AddWitEntityResponse> AddEntity(AddWitEntityRequest request)
        {
            string url = $"{BASE_API_URL}/entities?v={ApiVersion}";
            return await Post<AddWitEntityRequest, AddWitEntityResponse>(url, request);
        }

        public async Task<GetWitEntityResponse> GetEntity(GetWitEntityRequest request)
        {
            string url = $"{BASE_API_URL}/entities/{request.EntityNameOrId}?v={ApiVersion}";
            return await Get<GetWitEntityRequest, GetWitEntityResponse>(url, request);
        }

        public async Task<GetWitEntitiesResponse> GetEntities(GetWitEntitiesRequest request)
        {
            string url = $"{BASE_API_URL}/entities?v={ApiVersion}";
            return await Get(url, request, async apiResponse =>
            {
                return new GetWitEntitiesResponse
                {
                    IsSuccessful = apiResponse.IsSuccessStatusCode,
                    ErrorMessage = !apiResponse.IsSuccessStatusCode
                        ? await apiResponse.Content.ReadAsStringAsync()
                        : null,
                    Entities = apiResponse.IsSuccessStatusCode
                        ? await apiResponse.Content.ReadAsAsync<List<string>>()
                        : null,
                };
            });
        }

        public async Task<DeleteWitEntityResponse> DeleteEntity(DeleteWitEntityRequest request)
        {
            string url = $"{BASE_API_URL}/entities/{request.EntityNameOrId}?v={ApiVersion}";
            return await Delete<DeleteWitEntityRequest, DeleteWitEntityResponse>(url, request);
        }

        public async Task<TrainWitAppResponse> Train(TrainWitAppRequest request)
        {
            string url = $"{BASE_API_URL}/samples?v={ApiVersion}";
            return await Post<TrainWitAppRequest, TrainWitAppResponse>(url, request, request.Samples);
        }

        public async Task<ParseWitMessageResponse> ParseMessage(ParseWitMessageRequest request)
        {
            string query = Uri.EscapeDataString(request.Message);
            string url = $"{BASE_API_URL}/message?v={ApiVersion}&q={query}";

            return await Get(url, request, async (apiResponse) =>
            {
                ParseWitMessageResponse response = await apiResponse.Content.ReadAsAsync<ParseWitMessageResponse>();
                response.IsSuccessful = apiResponse.IsSuccessStatusCode;

                if (!response.IsSuccessful)
                    response.ErrorMessage = await apiResponse.Content.ReadAsStringAsync();

                return response;
            });
        }

        private async Task<TResponse> Get<TRequest, TResponse>(string url, TRequest request, Func<HttpResponseMessage, Task<TResponse>> customGetResponse = null)
            where TRequest : BaseWitRequest
            where TResponse : BaseWitResponse, new()
        {
            TResponse response = default(TResponse);

            using (HttpClient http = new HttpClient())
            {
                SetupHeaders(http, request.AccessToken);

                HttpResponseMessage apiResponse = await http.GetAsync(url);

                response = customGetResponse == null
                    ? await GetResponse<TResponse>(apiResponse)
                    : await customGetResponse(apiResponse);
            }

            return response;
        }

        private async Task<TResponse> Post<TRequest, TResponse>(string url, TRequest request)
            where TRequest : BaseWitRequest
            where TResponse : BaseWitResponse, new()
        {
            return await Post<TRequest, TResponse>(url, request, request);
        }

        private async Task<TResponse> Post<TRequest, TResponse>(string url, TRequest request, object body)
            where TRequest : BaseWitRequest
            where TResponse : BaseWitResponse, new()
        {
            TResponse response = default(TResponse);

            using (HttpClient http = new HttpClient())
            {
                SetupHeaders(http, request.AccessToken);

                HttpResponseMessage apiResponse = await http.PostAsJsonAsync(url, body);

                response = await GetResponse<TResponse>(apiResponse);
            }

            return response;
        }

        private async Task<TResponse> Put<TRequest, TResponse>(string url, TRequest request)
            where TRequest : BaseWitRequest
            where TResponse : BaseWitResponse, new()
        {
            TResponse response = default(TResponse);

            using (HttpClient http = new HttpClient())
            {
                SetupHeaders(http, request.AccessToken);

                HttpResponseMessage apiResponse = await http.PutAsJsonAsync(url, request);

                response = await GetResponse<TResponse>(apiResponse);
            }

            return response;
        }

        private async Task<TResponse> Delete<TRequest, TResponse>(string url, TRequest request)
            where TRequest : BaseWitRequest
            where TResponse : BaseWitResponse, new()
        {
            TResponse response = default(TResponse);

            using (HttpClient http = new HttpClient())
            {
                SetupHeaders(http, request.AccessToken);

                HttpResponseMessage apiResponse = await http.DeleteAsync(url);

                response = await GetResponse<TResponse>(apiResponse);
            }

            return response;
        }

        private void SetupHeaders(HttpClient http, string accessToken)
        {
            if (String.IsNullOrEmpty(accessToken))
                throw new Exception("No access token has been defined for current request");

            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        private async Task<TResponse> GetResponse<TResponse>(HttpResponseMessage apiResponse) where TResponse : BaseWitResponse, new()
        {
            TResponse response = apiResponse.IsSuccessStatusCode
                    ? await apiResponse.Content.ReadAsAsync<TResponse>()
                    : new TResponse { IsSuccessful = false, ErrorMessage = await apiResponse.Content.ReadAsStringAsync() };

            response.IsSuccessful = apiResponse.IsSuccessStatusCode;

            return response;
        }
    }
}