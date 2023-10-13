namespace Archery
{
    public class ArcherInMemory : ArcherBase
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
