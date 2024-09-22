namespace JCAutomatedAPICodeFramework
{
    public class Endpoints
    {
        public static readonly string CreateABoard = "/boards";
        public static readonly string DeleteABoard = "/boards/{id}";
        public static readonly string GetBoardsThatMemberBelongsTo = "/members/{id}/boards";
        public static readonly string GetSpecificBoard = "/boards/{id}";
        public static readonly string UpdateSpecificBoard = "/boards/{id}";
        public static readonly string GetCardsOnABoard = "/boards/{id}/cards";
        public static readonly string CreateNewList = "/lists";
        public static readonly string CreateNewCard = "/cards";
        public static readonly string GetAList = "/lists/{id}";
        public static readonly string GetACard = "/cards/{id}";
    }
}
