using Newtonsoft.Json;

namespace Shared.Mapping
{
    public static class BaseMapping
    {
        public static string ObjectToJson(this object model)
        {
            return JsonConvert.SerializeObject(model);
        }
    }
}
