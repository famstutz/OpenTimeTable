namespace OpenTimeTable.Model.Contracts
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class Checkpoint
    {
        [DataMember]
        public Location Station { get; set; }

        [DataMember]
        public DateTime? Arrival { get; set; }

        [DataMember]
        public DateTime? Departure { get; set; }

        [DataMember]
        public int? Platform { get; set; }

        [DataMember]
        public Prognosis Prognosis { get; set; }
    }
}
