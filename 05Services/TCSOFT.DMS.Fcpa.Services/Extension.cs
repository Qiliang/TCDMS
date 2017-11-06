using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TCSOFT.DMS.Fcpa.DTO;
using TCSOFT.DMS.Fcpa.DTO.Fcpa;

namespace TCSOFT.DMS.Fcpa.Services
{
    public static class Extension
    {
        public static string Show(this object me)
        {
            if (me == null) return string.Empty;
            return me.ToString();
        }

        public static int[] ToIntArray(this string s)
        {
            if (string.IsNullOrEmpty(s)) return new int[] { };
            return s.Split(',').Select(p => int.Parse(p)).ToArray();
        }

        public static string[] ToStringArray(this string s)
        {
            if (string.IsNullOrEmpty(s)) return new string[] { };
            return s.Split(',').ToArray();
        }

        public static bool[] ToBoolArray(this string s)
        {
            if (string.IsNullOrEmpty(s)) return new bool[] { };
            return s.Split(',').Select(p => bool.Parse(p)).ToArray();
        }

        public static bool ToBool(this string s)
        {
            bool v;
            if (bool.TryParse(s, out v))
            {
                return v;
            }
            return false;

        }



        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName, bool ascending) where T : class
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

            return source.Provider.CreateQuery<T>(resultExp);
        }



        public static PageableDTO<T> ToPageable<T>(this IQueryable<T> source, QueryDTO q) where T : class
        {
            var total = source.Count();
            return new PageableDTO<T>
            {
                total = total,
                rows = source.OrderBy(q.OrderBy, q.Ascending.Value).Skip(q.Skip).Take(q.rows.Value).ToList(),
            };

        }

        public static void InitQuery(this QueryDTO q, string orderBy, bool ascending)
        {
         
            if (!q.page.HasValue) { q.page = 1; }
            if (!q.rows.HasValue) q.rows = 10;
            if (string.IsNullOrEmpty(q.OrderBy)) q.OrderBy = orderBy;
            if (!q.Ascending.HasValue) q.Ascending = ascending;
            q.Skip = (q.page.Value - 1) * q.rows.Value;

        }

        public static void InitQuery(this QueryDTO q, string orderBy)
        {
            q.InitQuery(orderBy, true);

        }


        

        public static int? TryInt(this string me)
        {
            if (string.IsNullOrEmpty(me)) return null;
            int intValue;
            if (int.TryParse(me, out intValue))
                return intValue;
            else
                return null;

        }

        public static bool? TryBool(this string me)
        {
            if (string.IsNullOrEmpty(me)) return null;
            bool value;
            if (bool.TryParse(me, out value))
                return value;
            else
                return null;

        }       
    }


    public class ExcelView
    {
        public string Header { get; set; }
        public string PropertyName { get; set; }
        public int Width { get; set; }
        public int ForColor { get; set; }
        public int BackgroupColor { get; set; }
    }
}
