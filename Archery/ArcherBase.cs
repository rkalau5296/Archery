namespace Archery
{
    public abstract class ArcherBase : IArcher
    {
        public delegate void PointAddedDelegate(object sender, EventArgs args);

        public abstract event PointAddedDelegate PointAdded;        

        public ArcherBase(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }

        public string Name { get; private set; }
        public string Surname { get; private set; }
        public abstract void AddPoint(float grade);
        public abstract void AddPoint(string grade);
        public abstract void AddPoint(char grade);        
        public abstract void AddPoint(long grade);
        public abstract Statistics GetStatistics();        
    }
}
