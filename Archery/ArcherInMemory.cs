namespace Archery
{
    public class ArcherInMemory : ArcheryBase
    {
        public override event PointAddedDelegate PointAdded;
        public ArcherInMemory(string name, string surname) : base(name, surname)
        {

        }        

        private List<float> points = new();
        public override void AddPoint(float point)
        {
            if (point > 0 && point <= 100)
            {
                points.Add(point);
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
            if (float.TryParse(point, out float result))
            {
                AddPoint(float.Parse(point));
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
            var statistics = new Statistics();

            foreach (var point in this.points)
            {
                statistics.AddPoint(point);
            }
            return statistics;
        }
    }
}
