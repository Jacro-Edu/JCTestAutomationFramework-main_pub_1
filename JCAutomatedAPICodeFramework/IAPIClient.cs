using RestSharp;

namespace JCAutomatedAPICodeFramework
{
    public interface IAPIClient
    {
        Task<RestResponse>GetBoardsForMember(string id);
        Task<RestResponse>GetSingleBoard(string id);
        Task<RestResponse>UpdateABoard<T>(T payload, string id) where T : class;
        Task<RestResponse>CreateABoard<T>(T payload) where T : class;
        Task<RestResponse>DeleteABoard(string id);
        Task<RestResponse>GetCardsOnABoard(string id);
        Task<RestResponse>CreateANewList(string name, string id);
        Task<RestResponse>CreateNewCard<T>(T payload, string id) where T : class;
        Task<RestResponse> GetAList(string id);
        Task<RestResponse> GetACard(string id);
    }
}
