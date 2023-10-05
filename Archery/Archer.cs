namespace Archery
{
    public class Archer
    {
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public Archer(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }
    }
}
