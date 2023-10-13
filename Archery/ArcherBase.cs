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
        public void AddPoint(string point)
        {
            if (float.TryParse(point, out _))
            {
                AddPoint(float.Parse(point.ToString()));
            }
            else
            {
                throw new Exception("String is not float");
            }
        }
        public void AddPoint(char point)
        {
            switch (point)
            {
                case 'A':
                case 'a':
                    this.AddPoint(100);
                    break;
                case 'B':
                case 'b':
                    this.AddPoint(80);
                    break;
                case 'C':
                case 'c':
                    this.AddPoint(60);
                    break;
                case 'D':
                case 'd':
                    this.AddPoint(40);
                    break;
                case 'E':
                case 'e':
                    this.AddPoint(20);
                    break;
                default:
                    throw new Exception("Wrong letter");
            }
        }
        public void AddPoint(long point)
        {
            AddPoint((float)point);
        }
        public abstract Statistics GetStatistics();        
    }
}
