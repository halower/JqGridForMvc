/****************************************************
** 作者： Halower (QQ:121625933)
** 创始时间：2015-03-21
** 描述：jqGrid查询扩展 
*****************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace HalowerHub.JqGrid
{
    public class GridRule
    {
        public string Field { get; set; }
        public string Op { get; set; }
        public string Data { get; set; }
    }

    public class GridFilters
    {
        public string GroupOp { get; set; }
        public List<GridRule> Rules { get; set; }
    }

    public static class GridSearchPredicate
    {
        public static Expression<Func<T, bool>> SingleSearchExpression<T>(string searchField, string searchOper,string searchString) where T : class
        {
            var predicate = PredicateBuilder.True<T>();
            if (string.IsNullOrEmpty(searchField)) return predicate;
            var filed = typeof(T).GetProperty(searchField);
            //Fix下，由于是单个查询条件所有没必要多个ifElse
            switch (searchOper)
            {
                case "eq":
                    predicate =predicate.And(x => filed.GetValue(x, null).ToString() == searchString);
                    break;
                case "bw":
                    predicate=predicate.And(x => filed.GetValue(x, null).ToString().StartsWith(searchString));
                    break;
                case "cn":
                    predicate=predicate.And(x => filed.GetValue(x, null).ToString().Contains(searchString));
                    break;
                case "gt":
                    {
                        if (filed.PropertyType.Name == "DateTime")
                        {
                            predicate = (x => DateTime.Parse(filed.GetValue(x, null).ToString()) > DateTime.Parse(searchString));
                        }
                        else
                        {
                            predicate = (x => decimal.Parse(filed.GetValue(x, null).ToString())  > decimal.Parse(searchString));
                        }
                    }
                   
                    break;
                case "lt":
                    {
                        if (filed.PropertyType.Name == "DateTime")
                        {
                            predicate = (x => DateTime.Parse(filed.GetValue(x, null).ToString()) < DateTime.Parse(searchString));
                        }
                        else
                        {
                            predicate = (x => decimal.Parse(filed.GetValue(x, null).ToString()) <decimal.Parse(searchString));
                        }
                    }
                    break;
                default:
                    break;
            }         
            return predicate;
        }

        public static Expression<Func<T, bool>> MultiSearchExpression<T>(string filtersContent) where T : class
        {
            var predicate = PredicateBuilder.True<T>();
            var filters = JsonConvert.DeserializeObject<GridFilters>(filtersContent);
            predicate = filters.GroupOp == "AND"
                ? filters.Rules.Aggregate(predicate,
                    (current, rule) => current.And(SingleSearchExpression<T>(rule.Field, rule.Op, rule.Data)))
                : filters.Rules.Aggregate(predicate,
                    (current, rule) => current.Or(SingleSearchExpression<T>(rule.Field, rule.Op, rule.Data)));
            return predicate;
        }
    }
}