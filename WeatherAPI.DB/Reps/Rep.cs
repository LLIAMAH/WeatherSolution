using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WeatherAPI.DB.Reps.Interfaces;

namespace WeatherAPI.DB.Reps
{
    public class RepBase<T> : IRepBase<T> where T : class
    {
        protected readonly AppDbCtx _ctx;
        protected readonly DbSet<T> _dbSet;

        public RepBase(AppDbCtx ctx)
        {
            this._ctx = ctx;
            this._dbSet = this._ctx.Set<T>();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>>? filter = null, string? navs = null)
        {
            IQueryable<T> query = this._dbSet;
            if (!string.IsNullOrEmpty(navs))
            {
                query = navs
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Aggregate(query, (current, nav) => current.Include(nav));
            }

            if (filter != null)
                query = query.Where(filter);

            return query;
        }
    }

    public class Rep<T> : RepBase<T>, IRep<T> where T : class
    {
        public Rep(AppDbCtx ctx) : base(ctx) { }

        public void Add(T item)
        {
            this._dbSet.Add(item);
        }

        public void Remove(T item)
        {
            this._dbSet.Remove(item);
        }
    }
}
