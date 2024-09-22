using Newtonsoft.Json;
using RestSharp;

namespace JCAutomatedAPICodeFramework.Utility
{
    public class HandleContent
    {
        public static T GetContent<T>(RestResponse response)
        {
            var content = response.Content;

            if (content != null)
            {
                return JsonConvert.DeserializeObject<T>(content);
            }
            else
            {
                throw new InvalidOperationException("Response content is null.");
            }
        }
    }
}
