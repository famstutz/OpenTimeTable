namespace OpenTimeTable.Model.Contracts
{
    using System.Runtime.Serialization;

    [DataContract]
    public class Service
    {
        [DataMember]
        public string Regular { get; set; }

        [DataMember]
        public string Irregular { get; set; }
    }
}
