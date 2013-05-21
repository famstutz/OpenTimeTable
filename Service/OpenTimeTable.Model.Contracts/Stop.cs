namespace OpenTimeTable.Model.Contracts
{
    public class Stop
    {
        public Location Station { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public int Number { get; set; }

        public string Operator { get; set; }

        public string To { get; set; }
    }
}
