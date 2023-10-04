using static Archery.ArcheryBase;

namespace Archery
{
    interface IArcher
    {
        string Name { get; }
        string Surname { get; }
        void AddPoint(float point);
        void AddPoint(string point);
        void AddPoint(char point);
        void AddPoint(long point);
        Statistics GetStatistics();

        event PointAddedDelegate PointAdded;
    }
}
