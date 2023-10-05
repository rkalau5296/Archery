namespace Archery
{
    public class ArcherInFile : ArcherBase
    {
        private const string fileName = "point.txt";
        public override event PointAddedDelegate PointAdded;

        private List<float> points = new();
        public ArcherInFile(string name, string surname)
            : base(name, surname)
        {
        }

        public override void AddPoint(float grade)
        {
            if (grade > 0 && grade <= 100)
            {
                using var writer = File.AppendText(fileName);
                if (PointAdded != null)
                {
                    PointAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception("Invalid grade value");
            }
        }
        public override void AddPoint(string point)
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
        public override void AddPoint(char point)
        {
            switch (point)
            {
                case 'A':
                case 'a':
                    this.points.Add(100);
                    break;
                case 'B':
                case 'b':
                    this.points.Add(80);
                    break;
                case 'C':
                case 'c':
                    this.points.Add(60);
                    break;
                case 'D':
                case 'd':
                    this.points.Add(40);
                    break;
                case 'E':
                case 'e':
                    this.points.Add(20);
                    break;
                default:
                    throw new Exception("Wrong letter");
            }
        }
       
        public override void AddPoint(long point)
        {
            AddPoint((float)point);
        }
        public override Statistics GetStatistics()
        {
            Statistics statistics = new();
            if (File.Exists($"{fileName}"))
            {
                using StreamReader reader = File.OpenText($"{fileName}");
                string? line = reader.ReadLine();
                while (line != null)
                {
                    statistics.AddPoint(float.Parse(line));
                    line = reader.ReadLine();
                }
            }
            return statistics;
        }
    }
}
