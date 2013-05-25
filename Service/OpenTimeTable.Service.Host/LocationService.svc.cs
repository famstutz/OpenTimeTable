namespace OpenTimeTable.Service.Host
{
    using System.Collections.Generic;
    using System.Linq;

    using Newtonsoft.Json.Linq;

    using OpenTimeTable.Model.Contracts;

    public class LocationService : ILocationService
    {
        public IEnumerable<Location> Get(
            string query, string x, string y, string type)
        {
            var webRequest = WebRequestHelper.CreateLocationsRequest(query, x, y, type);
            var response = webRequest.GetResponse();
            var json = JsonHelper.ParseStream(response.GetResponseStream());

            if (this.HasLocations(json))
            {
                return this.ParseLocations(json);
            }

            return Enumerable.Empty<Location>();
        }

        private bool HasLocations(JToken stationsToken)
        {
            if (stationsToken["stations"].HasValues)
            {
                return true;
            }

            return false;
        }

        private IEnumerable<Location> ParseLocations(JToken stationsToken)
        {
            var stations = (JArray)stationsToken["stations"];

            foreach (var station in stations)
            {
                var coordinate = station["coordinate"];

                yield return new Location
                                   {
                                       Coordinates =
                                           new Coordinates
                                               {
                                                   Type = coordinate.Value<string>("type"),
                                                   X = coordinate.Value<float>("x"),
                                                   Y = coordinate.Value<float>("y"),
                                               },
                                       Distance = station.Value<float?>("distance"),
                                       Id = station.Value<int?>("id"),
                                       Name = station.Value<string>("name"),
                                       Score = station.Value<int?>("score")
                                   };
            }
        }
    }
}