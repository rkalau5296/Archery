using MotoAPp.Entities;

namespace MotoAPp.Repositories
{
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class, IEntity
    {
        
    }
}
