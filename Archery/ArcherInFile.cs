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
