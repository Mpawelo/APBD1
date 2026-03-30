namespace APBD1.Domain.Equipment
{
    public class Projector : Equipment
    {
        public string Resolution { get; private set; }
        public int Lumens { get; private set; }

        public Projector(string name, string resolution, int lumens) : base(name)
        {
            Resolution = resolution;
            Lumens = lumens;
        }
    }
}