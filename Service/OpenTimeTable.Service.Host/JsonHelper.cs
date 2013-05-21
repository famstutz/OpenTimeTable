namespace OpenTimeTable.Service.Host
{
    using System.IO;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public static class JsonHelper
    {
        public static JToken ParseStream(Stream stream)
        {
            return JObject.ReadFrom(new JsonTextReader(new StreamReader(stream)));
        }

    }
}