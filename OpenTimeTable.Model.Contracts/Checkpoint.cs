namespace OpenTimeTable.Model.Contracts
{
    using System;

    public class Checkpoint
    {
        public Location Station { get; set; }

        public DateTime Arrival { get; set; }

        public DateTime? Departure { get; set; }

        public int Platform { get; set; }

        public Prognosis Prognosis { get; set; }
    }
}
