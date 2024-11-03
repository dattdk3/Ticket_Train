using Newtonsoft.Json;

namespace Ticket_Train.Core.Utilities
{
    public class JsonUtil
    {
        public static String SerializeObject(Object t)
        {
            return "";
        }

        public static object DeserializeObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
