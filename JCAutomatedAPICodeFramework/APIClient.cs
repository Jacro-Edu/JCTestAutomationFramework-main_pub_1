using RestSharp;

namespace JCAutomatedAPICodeFramework
{
    public class APIClient : IAPIClient, IDisposable
    {
        readonly RestClient Client;
        const string BaseUrl = "https://api.trello.com/1";
        public APIClient(string apiKey, string apiToken)
        {
            Client = new RestClient(BaseUrl);
            Client.AddDefaultQueryParameter("key", apiKey);
            Client.AddDefaultQueryParameter("token", apiToken);
        }
        public async Task<RestResponse> CreateABoard<T>(T payload) where T : class
        {
            RestRequest request = new(Endpoints.CreateABoard, Method.Post);
            // Log or print the full URL before making the request
            string fullUrl = Client.BuildUri(request).ToString();
            Console.WriteLine($"Full URL: {fullUrl}");
            request.AddBody(payload);
            return await Client.ExecuteAsync<T>(request);
        }
        public async Task<RestResponse> DeleteABoard(string id)
        {
            RestRequest request = new(Endpoints.DeleteABoard, Method.Delete);
            request.AddUrlSegment("id", id);
            return await Client.ExecuteAsync<RestResponse>(request);
        }
        public void Dispose()
        {
            Client?.Dispose();
            GC.SuppressFinalize(this);
        }
        public async Task<RestResponse> GetBoardsForMember(string id)
        {
            RestRequest request = new(Endpoints.GetBoardsThatMemberBelongsTo, Method.Get);
            request.AddUrlSegment("id", id);
            request.AddHeader("Accept", "application/json");
            return await Client.ExecuteAsync<RestResponse>(request);
        }
        public async Task<RestResponse> GetCardsOnABoard(string id)
        {
            RestRequest request = new(Endpoints.GetCardsOnABoard, Method.Get);
            request.AddUrlSegment("id", id);
            request.AddHeader("Accept", "application/json");
            return await Client.ExecuteAsync<RestResponse>(request);
        }
        public async Task<RestResponse> GetSingleBoard(string id)
        {
            RestRequest request = new(Endpoints.GetSpecificBoard, Method.Get);
            request.AddUrlSegment("id", id);
            request.AddHeader("Accept", "application/json");
            return await Client.ExecuteAsync<RestResponse>(request);
        }
        public async Task<RestResponse> UpdateABoard<T>(T payload, string id) where T : class
        {
            RestRequest request = new(Endpoints.UpdateSpecificBoard, Method.Put);
            request.AddUrlSegment("id", id);
            request.AddBody(payload);
            return await Client.ExecuteAsync<T>(request);
        }
        public async Task<RestResponse> CreateANewList(string name, string idBoard)
        {
            RestRequest request = new(Endpoints.CreateNewList, Method.Post);
            request.AddParameter("name", name);
            request.AddParameter("idBoard", idBoard); 
            return await Client.ExecuteAsync<RestResponse>(request);
        }
        public async Task<RestResponse> CreateNewCard<T>(T payload, string idList) where T : class
        {
            RestRequest request = new(Endpoints.CreateNewCard, Method.Post);
            request.AddParameter("idList", idList);
            request.AddBody(payload);
            return await Client.ExecuteAsync<T>(request);
        }
        public async Task<RestResponse> GetAList(string id)
        {
            RestRequest request = new(Endpoints.GetAList, Method.Get);
            request.AddUrlSegment("id", id);
            return await Client.ExecuteAsync<RestResponse>(request);
        }
        public async Task<RestResponse> GetACard(string id)
        {
            RestRequest request = new(Endpoints.GetACard, Method.Get);
            request.AddUrlSegment("id", id);
            return await Client.ExecuteAsync<RestResponse>(request);
        }
    }
}
