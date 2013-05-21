namespace OpenTimeTable.Service.Host
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.ServiceModel.Web;

    using OpenTimeTable.Model.Contracts;

    [ServiceContract]
    public interface IConnectionService
    {
        [OperationContract]
        [WebGet(
            UriTemplate =
                "Get?from={from}" 
                + "&to={to}" 
                + "&via={via}" 
                + "&dateTime={dateTime}"
                + "&isArrivalTime={isArrivalTime}"
                + "&transportations={transportations}"
                + "&direct={direct}"
                + "&hasSleeper={hasSleeper}" 
                + "&hasCouchette={hasCouchette}" 
                + "&hasBike={hasBike}")]
        IEnumerable<Connection> Get(
            string from, 
            string to, 
            string[] via,
            DateTime dateTime,
            bool isArrivalTime,
            string[] transportations,
            bool isDirect,
            bool hasSleeper,
            bool hasCouchette,
            bool hasBike);
    }
}
