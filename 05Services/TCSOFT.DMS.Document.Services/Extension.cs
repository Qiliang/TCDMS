using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.Document.DTO;

namespace TCSOFT.DMS.Document.Services
{
    public static class Extension
    {

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName, bool ascending) where T : class
        {
            Type type = typeof(T);

            PropertyInfo property = type.GetProperty(propertyName);
            if (property == null)
                throw new ArgumentException("propertyName", "Not Exist");

            ParameterExpression param = Expression.Parameter(type, "p");
            Expression propertyAccessExpression = Expression.MakeMemberAccess(param, property);
            LambdaExpression orderByExpression = Expression.Lambda(propertyAccessExpression, param);

            string methodName = ascending ? "OrderBy" : "OrderByDescending";

            MethodCallExpression resultExp = Expression.Call(typeof(Queryable), methodName, new Type[] { type, property.PropertyType }, source.Expression, Expression.Quote(orderByExpression));

            return source.Provider.CreateQuery<T>(resultExp) as IOrderedQueryable<T>;
        }

        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string propertyName, bool ascending) where T : class
        {
            Type type = typeof(T);

            PropertyInfo property = type.GetProperty(propertyName);
            if (property == null)
                throw new ArgumentException("propertyName", "Not Exist");

            ParameterExpression param = Expression.Parameter(type, "p");
            Expression propertyAccessExpression = Expression.MakeMemberAccess(param, property);
            LambdaExpression orderByExpression = Expression.Lambda(propertyAccessExpression, param);

            string methodName = ascending ? "ThenBy" : "ThenByDescending";

            MethodCallExpression resultExp = Expression.Call(typeof(Queryable), methodName, new Type[] { type, property.PropertyType }, source.Expression, Expression.Quote(orderByExpression));

            return source.Provider.CreateQuery<T>(resultExp) as IOrderedQueryable<T>;
        }

        public static PageableDTO<T> ToPageable<T>(this IQueryable<T> source, QueryDTO q) where T : class
        {
            var total = source.Count();            
            var queryable = source.OrderBy(q.OrderBy, q.Ascending.Value);
            if (!string.IsNullOrEmpty(q.ThenBy))
            {
                queryable.ThenBy(q.ThenBy, q.ThenAscending.Value);
            }
            return new PageableDTO<T>
            {
                total = total,
                rows = queryable.Skip(q.Skip).Take(q.rows.Value).ToList(),
            };

        }

        public static void InitQuery(this QueryDTO q, string orderBy, string thenBy)
        {
            q.InitQuery(orderBy, false, thenBy, false);
        }

        public static void InitQuery(this QueryDTO q, string orderBy, bool ascending)
        {
            q.InitQuery(orderBy, ascending, null, false);
        }

        public static void InitQuery(this QueryDTO q, string orderBy, bool ascending, string thenBy, bool thenAscending)
        {
            if (!q.page.HasValue) { q.page = 1; }
            if (!q.rows.HasValue) q.rows = 10;
            if (string.IsNullOrEmpty(q.OrderBy)) q.OrderBy = orderBy;
            q.ThenBy = thenBy;
            q.ThenAscending = thenAscending;
            if (!q.Ascending.HasValue) q.Ascending = ascending;
            q.Skip = (q.page.Value - 1) * q.rows.Value;

        }

        public static void InitQuery(this QueryDTO q, string orderBy)
        {
            q.InitQuery(orderBy, false);

        }
    }
}
