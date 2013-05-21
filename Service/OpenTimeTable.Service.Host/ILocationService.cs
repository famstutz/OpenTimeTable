namespace OpenTimeTable.Service.Host
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.ServiceModel.Web;

    using OpenTimeTable.Model.Contracts;

    [ServiceContract]
    public interface ILocationService
    {
        [WebGet(
            UriTemplate =
                "Get?query={query}"
                + "&x={x}"
                + "&y={y}"
                + "&type={type}")]
        IEnumerable<Location> Get(
            string query,
            string x,
            string y, 
            string type);
    }
}