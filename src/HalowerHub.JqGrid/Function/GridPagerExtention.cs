/****************************************************
** 作者： Halower (QQ:121625933)
** 创始时间：2015-02-01
** 描述：jqGrid扩展分页
*****************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;

namespace HalowerHub.JqGrid
{
    public static class GridPagerExtention
    {
        /// <summary>
        ///     接管IList
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="list">数据集</param>
        /// <param name="expression">过滤表达式</param>
        /// <param name="baseContent">控制器对象</param>
        /// <returns></returns>
        public static string Pagination<T>(this IQueryable<T> list, Controller baseContent, Expression<Func<T, bool>> expression = null) where T : class
        {
            var pageParams = RequestHelper.InitRequestParams(baseContent);
            var predicate = PredicateBuilder.True<T>();
            if (expression != null) predicate = predicate.And(expression);
            if (!string.IsNullOrEmpty(pageParams.Filters))
                predicate = GridSearchPredicate.MultiSearchExpression<T>(pageParams.Filters);
            if (string.IsNullOrEmpty(pageParams.Filters) && !string.IsNullOrEmpty(pageParams.SearchField))
                predicate = GridSearchPredicate.SingleSearchExpression<T>(pageParams.SearchField, pageParams.SearchOper,pageParams.SearchString);
            var recordes = list.Where(predicate.Compile())
                    .Skip((pageParams.PageIndex - 1)*pageParams.PageSize)
                    .Take(pageParams.PageSize).ToList();
                   
            recordes.Sort(new GridListSort<T>( string.IsNullOrEmpty(pageParams.SortName) ? pageParams.Gridkey : pageParams.SortName,pageParams.Sord == "desc").Compare);
            var gridCells = recordes.Select(p => new GridCell
            {
                Id = p.GetType().GetProperty(pageParams.Gridkey).GetValue(p, null).ToString(),
                Cell = GetObjectPropertyValues(p, pageParams.Displayfileds.Split(','))
            }).ToList();
            var result =
                new
                {
                    pageParams.PageIndex,
                    records = list.Count(predicate.Compile()),
                    rows = gridCells,
                    total = (Math.Ceiling((double)list.Count() / pageParams.PageSize))
                }.ToSerializer();
            return result;
        }
        /// <summary>
        /// IList 接管
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="baseContent"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static string Pagination<T>(this IEnumerable<T> list, Controller baseContent,
            Expression<Func<T, bool>> expression = null) where T : class
        {
            return Pagination(list.AsQueryable(), baseContent, expression);
        }

        /// <summary>
        /// 推送到子表格
        /// </summary>
        /// <param name="list"></param>
        /// <param name="baseContent"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string PushSubGrid<T>(this IEnumerable<T> list, Controller baseContent) where T : class
        {
            var pageParams = RequestHelper.InitRequestParams(baseContent);
            var gridCells = list.Select(p => new GridCell
            {
                Id = p.GetType().GetProperty(pageParams.Gridkey).GetValue(p, null).ToString(),
                Cell = GetObjectPropertyValues(p, pageParams.Displayfileds.Split(','))
            }).ToList();

            var result = new { rows = gridCells }.ToSerializer();
            return result;
        }

        private static string[] GetObjectPropertyValues<T>(T t, IEnumerable<string> filderSortOrder)
        {
            var type = typeof(T);
            return filderSortOrder.Select(filedName => type.GetProperty(filedName).GetValue(t, null) == null
                ? string.Empty
                : type.GetProperty(filedName).GetValue(t, null).ToString()).ToArray();
        }


        /// <summary>
        /// 构建搜索下拉框
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="keySelector"></param>
        /// <param name="elementSelector"></param>
        /// <returns></returns>
        public static string BuildSelect<T>(this IEnumerable<T> list, Func<T, object> keySelector, Func<T, object> elementSelector) where T : class
        {
            var dic = list.ToDictionary(keySelector, elementSelector);
            var selectBuilder = new StringBuilder("<select>");
            selectBuilder.Append("<option value =''>请选择</option>");
            foreach (var item in dic)
            {
                selectBuilder.AppendFormat("<option value ='{0}'>{1}</option>", item.Key, item.Value);
            }
            selectBuilder.Append("</select>");
            return selectBuilder.ToString();
        }


        /// <summary>
        /// 树表格
        /// </summary>
        /// <param name="list"></param>
        /// <param name="baseContent"></param>
        /// <param name="expression"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string ToTreeGrid<T>(this IEnumerable<T> list, Controller baseContent, Expression<Func<T, bool>> expression = null) where T : JGridTree
        {
            var pageParams = RequestHelper.InitRequestParams(baseContent);
            var predicate = PredicateBuilder.True<T>();
            if (expression != null) predicate = predicate.And(expression);
            if (!string.IsNullOrEmpty(pageParams.Filters))
                predicate = GridSearchPredicate.MultiSearchExpression<T>(pageParams.Filters);
            if (string.IsNullOrEmpty(pageParams.Filters) && !string.IsNullOrEmpty(pageParams.SearchField))
                predicate = GridSearchPredicate.SingleSearchExpression<T>(pageParams.SearchField, pageParams.SearchOper,
                    pageParams.SearchString);
            var recordes =
                list.Where(predicate.Compile())
                    .Skip((pageParams.PageIndex - 1) * pageParams.PageSize)
                    .Take(pageParams.PageSize)
                    .ToList();
            recordes.Sort(
                new GridListSort<T>(
                    string.IsNullOrEmpty(pageParams.SortName) ? pageParams.Gridkey : pageParams.SortName,
                    pageParams.Sord == "desc").Compare);
            var gridCells = recordes.Select(p => new GridCell
            {
                Id = p.GetType().GetProperty(pageParams.Gridkey).GetValue(p, null).ToString(),
                Cell = GetObjectPropertyValues(p,(pageParams.Displayfileds + ",TreeLevel,Parent,IsLeaf,Expanded").Split(','))
            }).ToList();
            var result =
                new
                {
                    pageParams.PageIndex,
                    records = list.Count(predicate.Compile()),
                    rows = gridCells,
                    total = (Math.Ceiling((double)list.Count() / pageParams.PageSize))
                }.ToSerializer();
            return result;
        }
    }
}