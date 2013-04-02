namespace OpenTimeTable.Model.Contracts
{
    using System;
    using System.Collections.Generic;

    public class Connection
    {
        public Checkpoint From { get; set; }

        public Checkpoint To { get; set; }

        public TimeSpan Duration { get; set; }

        public Service Service { get; set; }

        public IEnumerable<string> Products { get; set; }

        public int Capacity1st { get; set; }

        public int Capacity2nd { get; set; }
    }
}
