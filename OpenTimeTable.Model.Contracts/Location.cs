namespace OpenTimeTable.Model.Contracts
{
    using System;

    public class Location
    {
        public Guid Id { get; set; }

        public LocationType Type { get; set; }

        public string Name { get; set; }

        public Coordinates Coordinates { get; set; }

        public double Distance { get; set; }
    }
}
