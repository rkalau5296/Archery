namespace Archery
{
    public class ArcherInFile : ArcherBase
    {
        private const string fileName = "point.txt";
        public override event PointAddedDelegate PointAdded;
        
        public ArcherInFile(string name, string surname)
            : base(name, surname)
        {
        }

        public override void AddPoint(float point)
        {
            if (point > 0 && point <= 100)
            {
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(point);
                }
                if (PointAdded != null)
                {
                    PointAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception("Invalid point value");
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
