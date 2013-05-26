namespace OpenTimeTable.Service.Host
{
    using System;
    using System.Net;
    using System.Text;

    public static class WebRequestHelper
    {
        public static WebRequest CreateLocationsRequest(
            string query, string x = null, string y = null, string type = null)
        {
            var stringBuilder = new StringBuilder("http://transport.opendata.ch/v1/locations?");

            stringBuilder.AppendParameter("query", query);
            stringBuilder.AppendParameter("x", x);
            stringBuilder.AppendParameter("y", y);
            stringBuilder.AppendParameter("type", type);
            stringBuilder.Cleanup();

            return WebRequest.Create(stringBuilder.ToString());
        }

        public static WebRequest CreateConnectionsRequest(
            string from,
            string to,
            string[] via = null,
            DateTime? dateTime = null,
            bool? isArrivalTime = null,
            string[] transportations = null,
            bool? isDirect = null,
            bool? hasSleeper = null,
            bool? hasCouchette = null,
            bool? hasBike = null)
        {
            var stringBuilder = new StringBuilder("http://transport.opendata.ch/v1/connections?");

            stringBuilder.AppendParameter("from", from);
            stringBuilder.AppendParameter("to", to);
            stringBuilder.AppendParameter("via", via);
            stringBuilder.AppendParameter("date", dateTime, "{0:yyyy-MM-dd}");
            stringBuilder.AppendParameter("time", dateTime, "{0:HH:mm}");
            stringBuilder.AppendParameter("isArrivalTime", isArrivalTime);
            stringBuilder.AppendParameter("transportations", transportations);
            stringBuilder.AppendParameter("direct", isDirect);
            stringBuilder.AppendParameter("sleeper", hasSleeper);
            stringBuilder.AppendParameter("couchette", hasCouchette);
            stringBuilder.AppendParameter("bike", hasBike);
            stringBuilder.Cleanup();

            return WebRequest.Create(stringBuilder.ToString());
        }

        private static void AppendParameter(this StringBuilder stringBuilder, string name, bool? parameter)
        {
            if (parameter.HasValue)
            {
                var p = parameter.Value ? 1 : 0;

                stringBuilder.AppendFormat("{0}={1}&", name, p);
            }
        }

        private static void AppendParameter(this StringBuilder stringBuilder, string name, int? parameter)
        {
            if (parameter.HasValue)
            {
                stringBuilder.AppendFormat("{0}={1}&", name, parameter);
            }
        }

        private static void AppendParameter(this StringBuilder stringBuilder, string name, DateTime? parameter, string formatString)
        {
            if (parameter.HasValue)
            {
                stringBuilder.AppendFormat("{0}={1}&", name, string.Format(formatString, parameter));
            }
        }

        private static void AppendParameter(this StringBuilder stringBuilder, string name, string[] parameter)
        {
            if (parameter != null)
            {
                foreach (var p in parameter)
                {
                    stringBuilder.AppendFormat("{0}[]={1}&", name, parameter);
                }
            }
        }

        private static void AppendParameter(this StringBuilder stringBuilder, string name, string parameter)
        {
            if (!string.IsNullOrWhiteSpace(parameter))
            {
                stringBuilder.AppendFormat("{0}={1}&", name, parameter);
            }

        }

        private static void Cleanup(this StringBuilder stringBuilder)
        {
           // remove last "&" char
            stringBuilder.Remove(stringBuilder.Length - 1, 1);
        }
    }
}