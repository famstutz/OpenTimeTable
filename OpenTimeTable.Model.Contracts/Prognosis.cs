namespace OpenTimeTable.Model.Contracts
{
    using System;

    public class Prognosis
    {
        public int Platform { get; set; }

        public DateTime Departure { get; set; }

        public DateTime Arrival { get; set; }

        public int Capacity1st { get; set; }

        public int Capacity2nd { get; set; }
    }
}
