namespace OpenTimeTable.Service.Host
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Newtonsoft.Json.Linq;

    using OpenTimeTable.Model.Contracts;

    public class ConnectionService : IConnectionService
    {
        public IEnumerable<Connection> Get(
            string from,
            string to,
            string[] via,
            DateTime? dateTime,
            bool? isArrivalTime,
            string[] transportations,
            bool? isDirect,
            bool? hasSleeper,
            bool? hasCouchette,
            bool? hasBike)
        {
            var webRequest = WebRequestHelper.CreateConnectionsRequest(
                from,
                to,
                via,
                dateTime,
                isArrivalTime,
                transportations,
                isDirect,
                hasSleeper,
                hasCouchette,
                hasBike);
            var response = webRequest.GetResponse();
            var json = JsonHelper.ParseStream(response.GetResponseStream());

            if (this.HasConnections(json))
            {
                return this.ParseConnections(json);
            }

            return Enumerable.Empty<Connection>();
        }

        private bool HasConnections(JToken stationsToken)
        {
            if (stationsToken["connections"].HasValues)
            {
                return true;
            }

            return false;
        }

        private IEnumerable<Connection> ParseConnections(JToken stationsToken)
        {
            var connections = (JArray)stationsToken["connections"];

            foreach (var connection in connections)
            {
                yield return connection.ToObject<Connection>();
            }
        }
    }
}
