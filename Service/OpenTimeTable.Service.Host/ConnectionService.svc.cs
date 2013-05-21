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
            DateTime dateTime,
            bool isArrivalTime,
            string[] transportations,
            bool isDirect,
            bool hasSleeper,
            bool hasCouchette,
            bool hasBike)
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
                var from = connection["from"];
                var fromPrognosis = from["prognosis"];
                var fromStation = from["station"];
                var fromStationCoordinates = fromStation["coordinate"];
                var to = connection["to"];
                var toPrognosis = from["prognosis"];
                var toStation = from["station"];
                var toStationCoordinates = fromStation["coordinate"];

                yield return
                    new Connection
                        {
                            From =
                                new Checkpoint
                                    {
                                        Arrival = from.Value<DateTime?>("arrival"),
                                        Departure = from.Value<DateTime?>("departure"),
                                        Platform = from.Value<int>("platform"),
                                        Prognosis =
                                            new Prognosis
                                                {
                                                    Platform = fromPrognosis.Value<int?>("platform"),
                                                    Arrival = fromPrognosis.Value<DateTime?>("arrival"),
                                                    Departure = fromPrognosis.Value<DateTime?>("departure"),
                                                    Capacity1st = fromPrognosis.Value<int>("capacity1st"),
                                                    Capacity2nd = fromPrognosis.Value<int>("capacity2nd")
                                                },
                                        Station =
                                            new Location
                                                {
                                                    Coordinates =
                                                        new Coordinates
                                                            {
                                                                Type = fromStationCoordinates.Value<string>("type"),
                                                                X = fromStationCoordinates.Value<float>("x"),
                                                                Y = fromStationCoordinates.Value<float>(
                                                                        "y"),
                                                            },
                                                    Distance =
                                                        fromStation.Value<float?>(
                                                            "distance"),
                                                    Id = fromStation.Value<int?>("id"),
                                                    Name =
                                                        fromStation.Value<string>("name"),
                                                    Score =
                                                        fromStation.Value<int?>("score")
                                                }
                                    },
                            To =
                                new Checkpoint
                                    {
                                        Arrival = to.Value<DateTime?>("arrival"),
                                        Departure = to.Value<DateTime?>("departure"),
                                        Platform = to.Value<int>("platform"),
                                        Prognosis =
                                            new Prognosis
                                                {
                                                    Platform =
                                                        toPrognosis.Value<int?>(
                                                            "platform"),
                                                    Arrival =
                                                        toPrognosis.Value<DateTime?>(
                                                            "arrival"),
                                                    Departure =
                                                        toPrognosis.Value<DateTime?>(
                                                            "departure"),
                                                    Capacity1st =
                                                        toPrognosis.Value<int>(
                                                            "capacity1st"),
                                                    Capacity2nd =
                                                        toPrognosis.Value<int>(
                                                            "capacity2nd")
                                                },
                                        Station =
                                            new Location
                                                {
                                                    Coordinates =
                                                        new Coordinates
                                                            {
                                                                Type =
                                                                    toStationCoordinates
                                                                    .Value
                                                                    <string>(
                                                                        "type"),
                                                                X =
                                                                    toStationCoordinates
                                                                    .Value
                                                                    <float>(
                                                                        "x"),
                                                                Y =
                                                                    toStationCoordinates
                                                                    .Value
                                                                    <float>(
                                                                        "y"),
                                                            },
                                                    Distance =
                                                        toStation.Value<float?>("distance"),
                                                    Id = toStation.Value<int?>("id"),
                                                    Name = toStation.Value<string>("name"),
                                                    Score = toStation.Value<int?>("score")
                                                }
                                    }
                        };
            }
        }
    }
}
