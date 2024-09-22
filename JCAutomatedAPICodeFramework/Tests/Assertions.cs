using NUnit.Framework;

namespace JCAutomatedAPICodeFramework.Tests
{
    public static class Assertions
    {
        public static void AssertListNotEmpty<T>(this List<T> list, string listType, string description, string id)
        {
            Console.WriteLine($">>>>>>>>>>> Asserting that list of type '{listType}' is not empty");
            try
            {
                Assert.That(list, Is.Not.Empty);
                Console.WriteLine($"  :: Assertion PASSED: '{listType}' list is not empty for {description}: '{id}'.");
                Console.WriteLine($">>>>>>>>>>> End of assertion");
            }
            catch (AssertionException exception)
            {
                Console.WriteLine($"  :: Assertion FAILED: '{listType}' list is empty for {description}: '{id}'. {exception.Message}");
                throw;
            }
        }
        public static void AssertItemExists(bool itemExists, string listType, string nameOrIdToFind)
        {
            Console.WriteLine($">>>>>>>>>>> Asserting that a '{listType}' with a name/ID of '{nameOrIdToFind}' is amongst the list of {listType}(s)");
            try
            {
                Assert.That(itemExists, Is.True);
                Console.WriteLine($"  :: Assertion PASSED: a '{listType}' with a name/ID of '{nameOrIdToFind}' is amongst the list of {listType}(s)");
                Console.WriteLine($">>>>>>>>>>> End of assertion");

            }
            catch (AssertionException exception)
            {
                Console.WriteLine($"  :: Assertion FAILED: a '{listType}' with a name of '{nameOrIdToFind}' is NOT amongst the list of {listType}(s). {exception.Message}");
                throw;
            }
        }
    }
}
