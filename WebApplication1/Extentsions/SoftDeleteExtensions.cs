using DoranOfficeBackend.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DoranOfficeBackend.Extentsions
{
    public static class SoftDeleteExtensions
    {
        public static IQueryable<TEntity> WhereNotDeleted<TEntity>(this IQueryable<TEntity> query)
        where TEntity : class, ISoftDelete
        {
            var parameter = Expression.Parameter(typeof(TEntity), "entity");
            var deletedAtProperty = Expression.Property(parameter, "DeletedAt");
            var nullConstant = Expression.Constant(null);
            var isNullExpression = Expression.Equal(deletedAtProperty, nullConstant);
           

            var lambda = Expression.Lambda<Func<TEntity, bool>>(isNullExpression, parameter);
            return query.Where(lambda);
        }

        public static IQueryable<TEntity> WhereDeleted<TEntity>(this IQueryable<TEntity> query)
            where TEntity : class, ISoftDelete
        {
            var parameter = Expression.Parameter(typeof(TEntity), "entity");
            var deletedAtProperty = Expression.Property(parameter, "DeletedAt");
            var nullConstant = Expression.Constant(null);
            var isNotNullExpression = Expression.NotEqual(deletedAtProperty, nullConstant);

            var lambda = Expression.Lambda<Func<TEntity, bool>>(isNotNullExpression, parameter);
            return query.Where(lambda);
        }

        public static IQueryable<TEntity> WithSoftDeleted<TEntity>(this IQueryable<TEntity> query)
            where TEntity : class, ISoftDelete
        {
            return query.IgnoreQueryFilters();
        }

        public static IQueryable<TEntity> IncludeSoftDeleted<TEntity>(this IQueryable<TEntity> query, bool includeSoftDeleted = true)
            where TEntity : class, ISoftDelete
        {
            return includeSoftDeleted ? query : query.WhereNotDeleted();
        }
    }
}
