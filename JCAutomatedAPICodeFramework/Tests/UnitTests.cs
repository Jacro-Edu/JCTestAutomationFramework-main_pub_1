using AutoFixture;
using JCAutomatedAPICodeFramework.Models.Request;
using JCAutomatedAPICodeFramework.Models.Response;
using JCAutomatedAPICodeFramework.Tests.TestData;
using JCAutomatedAPICodeFramework.Utility;
using NUnit.Framework;
using RestSharp;
using System.Net;

namespace JCAutomatedAPICodeFramework.Tests
{
    public class UnitTests : TestBaseClass
    {
        private readonly string? ApiKey = TestContext.Parameters["ApiKey"];
        private readonly string? ApiToken = TestContext.Parameters["ApiToken"];
        private RestResponse? response;
        private APIClient? api;

        [TestCase]
        public async Task GetAllTheBoardsForMember()
        {
            api = new(ApiKey, ApiToken);
            string memberId = "jamestrelloford1";
            string description = "member";
            response = await api.GetBoardsForMember(memberId);
            HttpStatusCode statusCode = response.StatusCode;
            ValidateResponseCode(statusCode, "Getting all the boards for a member", 200);
            /*Validate board list is not empty & validate board with specific name is found in the board list*/
            ListType = "board";
            List<GetBoardsThatMemberBelongsToResponse> boards = HandleContent.GetContent<List<GetBoardsThatMemberBelongsToResponse>>(response);
            Assertions.AssertListNotEmpty(boards, ListType, description, memberId);
            string nameOrIdToFind = "JC Automation Test Frame Board";
            bool boardExists = boards.Any(board => board.Name == $"{nameOrIdToFind}");
            Assertions.AssertItemExists(boardExists, ListType, nameOrIdToFind);
        }
        [TestCase]
        public async Task GetAllCardsOnABoard()
        {
            api = new(ApiKey, ApiToken);
            string boardId = "8yiu87iygcuiuhib43a6lkjjhb878ygyug24d5e38";
            string description = "boardId";
            response = await api.GetCardsOnABoard(boardId);
            HttpStatusCode statusCode = response.StatusCode;
            ValidateResponseCode(statusCode, "Getting cards on a board", 200);
            /*Validate card list is not empty, validate card with specific name is found in the board list & validate card with specific ID is found in the list */
            ListType = "card";
            List<GetAllCardsOnABoardResponse> cards = HandleContent.GetContent<List<GetAllCardsOnABoardResponse>>(response);
            Assertions.AssertListNotEmpty(cards, "card", description, boardId);
            string cardNameToFind = "GitHub- read me/wiki";
            bool cardWithNameExists = cards.Any(card => card.Name == $"{cardNameToFind}");
            Assertions.AssertItemExists(cardWithNameExists, ListType, cardNameToFind);
            string cardIdToFind = "98uhujisa23diiygyu624d5eba";
            bool cardWithIdExists = cards.Any(card => card.Id == $"{cardIdToFind}");
            Assertions.AssertItemExists(cardWithIdExists, ListType, cardIdToFind);
        }
        [TestCase]
        public async Task GetASingleBoard()
        {
            api = new(ApiKey, ApiToken);
            response = await api.GetSingleBoard("oi4jigowLGDFERE33b6e2b43a624d5e380000");
            HttpStatusCode statusCode = response.StatusCode;
            ValidateResponseCode(statusCode, "Getting a single board", 200);
            ListType = "board";
            string nameToFind = "JC Automation Test Frame Board";
            GetABoardResponse board = HandleContent.GetContent<GetABoardResponse>(response);
            bool boardExists = board.Name == $"{nameToFind}";
            Assertions.AssertItemExists(boardExists, ListType, nameToFind);
        }
        [TestCase]
        public async Task CreateABoard()
        {
            api = new(ApiKey, ApiToken);
            CreateABoardRequest createBoardPayload = JsonPayLoadFactory.CreateRandomABoardPayload();
            response = await api.CreateABoard(createBoardPayload);
            HttpStatusCode statusCodeCreate = response.StatusCode;
            ValidateResponseCode(statusCodeCreate, "Creating a board", 200);
            CreateABoardResponse createBoardResponse = HandleContent.GetContent<CreateABoardResponse>(response);
            CreateABoardAssignBoardResponseValues(createBoardResponse);
            /*Validate board has been created by searching for it using GetSingleBoard(CreatedBoardId) & Validate it is removed by verifying GetSingleBoard response code is 404 */
            response = await api.GetSingleBoard(CreatedBoardId);
            HttpStatusCode statusCodeGetBoard = response.StatusCode;
            ValidateResponseCode(statusCodeGetBoard, "Getting the newly created board", 200);
        }
        [TestCase]
        public async Task UpdateABoard()
        {
            api = new(ApiKey, ApiToken);
            UpdateABoardRequest updateBoardPayload = JsonPayLoadFactory.UpdateABoardPayload();
            response = await api.UpdateABoard(updateBoardPayload, CreatedBoardId);
            HttpStatusCode statusCode = response.StatusCode;
            ValidateResponseCode(statusCode, "Updating the board", 200);
            UpdateABoardResponse updateABoardResponse = HandleContent.GetContent<UpdateABoardResponse>(response);
            string? updatedBoardName = updateABoardResponse.Name;

            response = await api.GetSingleBoard(CreatedBoardId);
            HttpStatusCode statusCodeGetBoard = response.StatusCode;
            ValidateResponseCode(statusCodeGetBoard, "Get the newly updated board", 200);
            GetABoardResponse board = HandleContent.GetContent<GetABoardResponse>(response);
            ListType = "board";
            bool boardExists = board.Name == $"{updatedBoardName}";
            Assertions.AssertItemExists(boardExists, ListType, updatedBoardName);
        }
        [TestCase]
        public async Task CreateAListAndAddACard()
        {
            //CreateAList & attach to a newly created board from [Setup], then validate list created using GetAList
            api = new(ApiKey, ApiToken);
            Fixture fixture = new();
            string newListName = "List: " + fixture.Create<string>();
            Console.WriteLine("List name: " + newListName);
            Console.WriteLine("Board ID to create new List within: " + CreatedBoardId);
            response = await api.CreateANewList(newListName, CreatedBoardId);
            HttpStatusCode statusCodeCreateList = response.StatusCode;
            ValidateResponseCode(statusCodeCreateList, "Creating a new list", 200);
            CreateAListResponse createAListResponse = HandleContent.GetContent<CreateAListResponse>(response);
            string createdListId = createAListResponse.Id;
            response = await api.GetAList(createdListId);
            HttpStatusCode statusCodeGetList = response.StatusCode;
            ValidateResponseCode(statusCodeGetList, "Getting a created list", 200);

            //CreateACard within newly created list
            CreateACardRequest createACardPayload = JsonPayLoadFactory.CreateACardPayload();
            response = await api.CreateNewCard(createACardPayload, createdListId);
            HttpStatusCode statusCodeCreateCard = response.StatusCode;
            ValidateResponseCode(statusCodeCreateCard, "Creating a card within the newly created list", 200);
            CreateACardResponse createACardResponse = HandleContent.GetContent<CreateACardResponse>(response);
            string? createdCardId = createACardResponse.Id;
            response = await api.GetACard(createdCardId);
            HttpStatusCode statusCodeGetCard = response.StatusCode;
            ValidateResponseCode(statusCodeGetCard, "Getting a created card from the newly created list", 200);
        }

        [SetUp]
        public async Task Setup()
        {
            string? currentMethod = TestContext.CurrentContext.Test.MethodName;
            if (currentMethod == nameof(UpdateABoard) || currentMethod == nameof(CreateAListAndAddACard))
            {
                api = new(ApiKey, ApiToken);
                CreateABoardRequest createBoardPayload = JsonPayLoadFactory.CreateRandomABoardPayload();
                response = await api.CreateABoard(createBoardPayload);
                HttpStatusCode statusCodeCreate = response.StatusCode;
                ValidateResponseCode(statusCodeCreate, "[Setup] Creating a new board", 200);
                CreateABoardResponse createBoardResponse = HandleContent.GetContent<CreateABoardResponse>(response);
                CreateABoardAssignBoardResponseValues(createBoardResponse);
                /*Validate board has been created by searching for it using GetSingleBoard(CreatedBoardId)
                Validate it is found by verifying GetSingleBoard response code is 200 */
                response = await api.GetSingleBoard(CreatedBoardId);
                HttpStatusCode statusCodeGetBoard = response.StatusCode;
                ValidateResponseCode(statusCodeGetBoard, "[Setup] Getting newly created board using ID", 200);
            }
        }
        [TearDown]
        public async Task TearDown()
        {
            string? currentMethod = TestContext.CurrentContext.Test.MethodName;
            if (currentMethod == nameof(CreateABoard))
            {
                /*Delete the specific board created from CreateABoard test using CreatedBoardId*/
                response = await api.DeleteABoard(CreatedBoardId);
                HttpStatusCode statusCodeDelete = response.StatusCode;
                int statusCodeAsInt = (int)statusCodeDelete;
                ValidateResponseCode(statusCodeDelete, "[TearDown] Deleting a board", 200);
               /*Validate board has been deleted by searching for it using GetSingleBoard(CreatedBoardId)
                Validate it is removed by verifying GetSingleBoard response code is 404 */
                response = await api.GetSingleBoard(CreatedBoardId);
                HttpStatusCode statusCodeGetBoard = response.StatusCode;
                ValidateResponseCode(statusCodeGetBoard, "[TearDown] Looking for a specific board to verify deletion", 404);
            }
            CreatedBoardId = null;
            CreatedBoardDesc = null;
            CreatedBoardName = null;
        }
    }
}
