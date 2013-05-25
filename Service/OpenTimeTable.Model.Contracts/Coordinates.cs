namespace OpenTimeTable.Model.Contracts
{
    using System.Runtime.Serialization;

    [DataContract]
    public class Coordinates
    {
        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public float? X { get; set; }

        [DataMember]
        public float? Y { get; set; }
    }
}
