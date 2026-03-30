namespace APBD1.Domain.Equipment
{
    public class Laptop : Equipment
    {
        public string Processor { get; private set; }
        public int RamInGb { get; private set; }

        public Laptop(string name, string processor, int ramInGb) : base(name)
        {
            Processor = processor;
            RamInGb = ramInGb;
        }
    }
}