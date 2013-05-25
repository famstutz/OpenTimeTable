namespace OpenTimeTable.Model.Contracts
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class Connection
    {
        [DataMember]
        public Checkpoint From { get; set; }

        [DataMember]
        public Checkpoint To { get; set; }

        [DataMember]
        public string Duration { get; set; }

        [DataMember]
        public Service Service { get; set; }

        [DataMember]
        public List<string> Products { get; set; }

        [DataMember]
        public int? Capacity1st { get; set; }

        [DataMember]
        public int? Capacity2nd { get; set; }
    }
}
