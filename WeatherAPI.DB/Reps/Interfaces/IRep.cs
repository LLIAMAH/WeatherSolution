using System.Linq.Expressions;

namespace WeatherAPI.DB.Reps.Interfaces
{
    public interface IRepBase<T>
    {
        IQueryable<T> Get(Expression<Func<T, bool>>? filter = null, string? navs = null);
    }

    public interface IRep<T> : IRepBase<T>
    {
        void Add(T item);
        void Remove(T item);
    }
}
