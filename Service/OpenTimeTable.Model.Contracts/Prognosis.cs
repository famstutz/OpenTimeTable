namespace OpenTimeTable.Model.Contracts
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class Prognosis
    {
        [DataMember]
        public int? Platform { get; set; }

        [DataMember]
        public DateTime? Departure { get; set; }

        [DataMember]
        public DateTime? Arrival { get; set; }

        [DataMember]
        public int Capacity1st { get; set; }

        [DataMember]
        public int Capacity2nd { get; set; }
    }
}
