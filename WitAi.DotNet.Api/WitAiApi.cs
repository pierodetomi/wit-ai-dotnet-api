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

        private string ApiVersion { get; set; }

        public WitAiApi()
        {
            ApiVersion = "20170307";
        }

        public WitAiApi(string apiVersion)
        {
            ApiVersion = apiVersion;
        }

        public async Task<CreateWitAppResponse> CreateApp(CreateWitAppRequest request)
        {
            CreateWitAppResponse response = null;

            using (HttpClient http = new HttpClient())
            {
                SetupHeaders(http, request.AccessToken);

                string url = $"{BASE_API_URL}/apps?v={ApiVersion}";
                HttpResponseMessage apiResponse = await http.PostAsJsonAsync(url, request);

                response = await GetResponse<CreateWitAppResponse>(apiResponse);
            }

            return response;
        }

        public async Task<DeleteWitAppResponse> DeleteApp(DeleteWitAppRequest request)
        {
            DeleteWitAppResponse response = null;

            using (HttpClient http = new HttpClient())
            {
                SetupHeaders(http, request.AccessToken);

                string url = $"{BASE_API_URL}/apps/{request.AppId}?v={ApiVersion}";
                HttpResponseMessage apiResponse = await http.DeleteAsync(url);

                response = await GetResponse<DeleteWitAppResponse>(apiResponse);
            }

            return response;
        }

        public async Task<AddWitEntityResponse> AddEntity(AddWitEntityRequest request)
        {
            AddWitEntityResponse response = null;

            using (HttpClient http = new HttpClient())
            {
                SetupHeaders(http, request.AccessToken);

                string url = $"{BASE_API_URL}/entities?v={ApiVersion}";
                HttpResponseMessage apiResponse = await http.PostAsJsonAsync(url, request);

                response = await GetResponse<AddWitEntityResponse>(apiResponse);
            }

            return response;
        }

        public async Task<GetWitEntityResponse> GetEntity(GetWitEntityRequest request)
        {
            GetWitEntityResponse response = null;

            using (HttpClient http = new HttpClient())
            {
                SetupHeaders(http, request.AccessToken);

                string url = $"{BASE_API_URL}/entities/{request.EntityNameOrId}?v={ApiVersion}";
                HttpResponseMessage apiResponse = await http.GetAsync(url);

                response = await GetResponse<GetWitEntityResponse>(apiResponse);
            }

            return response;
        }

        public async Task<GetWitEntitiesResponse> GetEntities(GetWitEntitiesRequest request)
        {
            GetWitEntitiesResponse response = null;

            using (HttpClient http = new HttpClient())
            {
                SetupHeaders(http, request.AccessToken);

                string url = $"{BASE_API_URL}/entities?v={ApiVersion}";
                HttpResponseMessage apiResponse = await http.GetAsync(url);

                response = new GetWitEntitiesResponse
                {
                    IsSuccessful = apiResponse.IsSuccessStatusCode,
                    ErrorMessage = !apiResponse.IsSuccessStatusCode
                        ? await apiResponse.Content.ReadAsStringAsync()
                        : null,
                    Entities = apiResponse.IsSuccessStatusCode
                        ? await apiResponse.Content.ReadAsAsync<List<string>>()
                        : null,
                };
            }

            return response;
        }

        public async Task<DeleteWitEntityResponse> DeleteEntity(DeleteWitEntityRequest request)
        {
            DeleteWitEntityResponse response = null;

            using (HttpClient http = new HttpClient())
            {
                SetupHeaders(http, request.AccessToken);

                string url = $"{BASE_API_URL}/entities/{request.EntityNameOrId}?v={ApiVersion}";
                HttpResponseMessage apiResponse = await http.DeleteAsync(url);

                response = await GetResponse<DeleteWitEntityResponse>(apiResponse);
            }

            return response;
        }

        public async Task<TrainWitAppResponse> Train(TrainWitAppRequest request)
        {
            TrainWitAppResponse response = null;

            using (HttpClient http = new HttpClient())
            {
                SetupHeaders(http, request.AccessToken);

                string url = $"{BASE_API_URL}/samples?v={ApiVersion}";
                HttpResponseMessage apiResponse = await http.PostAsJsonAsync(url, request.Samples);

                response = await GetResponse<TrainWitAppResponse>(apiResponse);
            }

            return response;
        }

        public async Task<ParseWitMessageResponse> ParseMessage(ParseWitMessageRequest request)
        {
            ParseWitMessageResponse response = null;

            using (HttpClient http = new HttpClient())
            {
                SetupHeaders(http, request.AccessToken);

                string query = Uri.EscapeDataString(request.Message);
                string url = $"{BASE_API_URL}/message?v={ApiVersion}&q={query}";
                HttpResponseMessage apiResponse = await http.GetAsync(url);

                response = await GetResponse<ParseWitMessageResponse>(apiResponse);
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