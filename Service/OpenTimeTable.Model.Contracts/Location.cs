namespace OpenTimeTable.Model.Contracts
{
    using System.Data.Services.Common;
    using System.Runtime.Serialization;

    [DataContract]
    public class Location
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int? Score { get; set; }

        [DataMember]
        public Coordinates Coordinates { get; set; }

        [DataMember]
        public float? Distance { get; set; }


    }
}
