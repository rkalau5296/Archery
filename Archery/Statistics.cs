namespace Archery
{
    public class Statistics
    {
        public float Min { get; private set; }
        public float Max { get; private set; }
        public float Average
        {
            get
            {
                return Sum / Count;
            }
        }        
        public float Sum { get; set; }
        public float Count { get; set; }
        public Statistics()
        {
            Count = 0;
            Sum = 0;
            Max = float.MinValue;
            Min = float.MaxValue;
        }
        public void AddPoint(float grade)
        {
            Count++;
            Sum += grade;
            Min = Math.Min(Min, grade);
            Max = Math.Max(Max, grade);
        }
    }
}
