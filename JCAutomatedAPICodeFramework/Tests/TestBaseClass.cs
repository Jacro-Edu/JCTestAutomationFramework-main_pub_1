using JCAutomatedAPICodeFramework.Models.Response;
using NUnit.Framework;
using System.Net;

namespace JCAutomatedAPICodeFramework.Tests
{
    public class TestBaseClass
    {
        protected string? CreatedBoardId;
        protected string? CreatedBoardName;
        protected string? CreatedBoardDesc;
        protected string? ListType;
        public static void ValidateResponseCode(HttpStatusCode statusCode, string component, int expectedResponseCode)
        {
            Console.WriteLine(">>>>>>>>>>> Validating response code");
            Console.WriteLine("  :: Calling Test Case: " + TestContext.CurrentContext.Test.MethodName);
            Console.WriteLine("  :: Component: " + component);
            Console.WriteLine("  :: Expected response code: " + expectedResponseCode);

            int statusCodeAsInt = (int)statusCode;
            try
            {
                Assert.That(statusCodeAsInt, Is.EqualTo(expectedResponseCode));
                Console.WriteLine($"  :: Assertion PASSED: status code of '{statusCode}' received.");
                Console.WriteLine($"  :: Status code has been validated for API request: '{component}'");
                Console.WriteLine(">>>>>>>>>>> End of response code validation");
            }
            catch (AssertionException exception)
            {
                Console.WriteLine($"  :: Assertion FAILED: status/status code of '{statusCode}' receeived. {exception.Message}");
                throw;
            }
        }
        public void CreateABoardAssignBoardResponseValues(CreateABoardResponse createBoardResponse)
        {
            CreatedBoardId = createBoardResponse.Id;
            CreatedBoardName = createBoardResponse.Name;
            CreatedBoardDesc = createBoardResponse.Desc;
            Console.WriteLine("Created Board ID: " + CreatedBoardId);
            Console.WriteLine("Created Board Name (randomised): " + CreatedBoardId);
            Console.WriteLine("Created Board Description (randomised): " + CreatedBoardDesc);
        }
    }
}
