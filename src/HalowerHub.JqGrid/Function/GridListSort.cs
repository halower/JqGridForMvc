/****************************************************
** 作者： Halower (QQ:121625933)
** 创始时间：2015-02-01
** 描述：jqGrid扩展构造列
*****************************************************/

using System;
using System.Collections.Generic;
using System.Reflection;

namespace HalowerHub.JqGrid
{
    /// <summary>
    ///     IList排序类
    /// </summary>
    public class GridListSort<T>
    {
        private Dictionary<string, Func<PropertyInfo, T, T, int>> dicts = new Dictionary<string, Func<PropertyInfo,T,T, int>>();
        /// <summary>
        ///     构造函数
        /// </summary>
        /// <param name="propertyName">排序字段属性名</param>
        /// <param name="isAsc">true升序 false 降序 不指定则为true</param>
        public GridListSort(string propertyName, bool isAsc)
        {
            PropertyName = propertyName;
            IsAsc = isAsc;
            dicts.Add("Int32", CompareInt);
            dicts.Add("Double", CompareDouble);
            dicts.Add("String", CompareString);
            dicts.Add("DateTime", CompareDateTime);
            dicts.Add("Decimal", CompareDecimal);
        }

        /// <summary>
        ///     构造函数
        /// </summary>
        /// <param name="propertyName">排序字段属性名</param>
        public GridListSort(string propertyName)
        {
            PropertyName = propertyName;
            IsAsc = true;
        }

        private string PropertyName { get; }
        private bool IsAsc { get; }

        #region 比较器
        public int CompareInt(PropertyInfo prop, T x, T y)
        {
            var int1 = 0;
            var int2 = 0;
            if (prop.GetValue(x, null) != null)
            {
                int1 = Convert.ToInt32(prop.GetValue(x, null));
            }
            if (prop.GetValue(y, null) != null)
            {
                int2 = Convert.ToInt32(prop.GetValue(y, null));
            }
            return IsAsc ? int2.CompareTo(int1) : int1.CompareTo(int2);
        }

        public int CompareDouble(PropertyInfo prop, T x, T y)
        {
            double double1 = 0;
            double double2 = 0;
            if (prop.GetValue(x, null) != null)
            {
                double1 = Convert.ToDouble(prop.GetValue(x, null));
            }
            if (prop.GetValue(y, null) != null)
            {
                double2 = Convert.ToDouble(prop.GetValue(y, null));
            }
            return IsAsc ? double2.CompareTo(double1) : double1.CompareTo(double2);
        }

        public int CompareDecimal(PropertyInfo prop, T x, T y)
        {
            decimal decimal1 = 0m;
            decimal decimal2 = 0m;
            if (prop.GetValue(x, null) != null)
            {
                decimal1 = Convert.ToDecimal(prop.GetValue(x, null));
            }
            if (prop.GetValue(y, null) != null)
            {
                decimal2 = Convert.ToDecimal(prop.GetValue(y, null));
            }
            return IsAsc ? decimal2.CompareTo(decimal1) : decimal1.CompareTo(decimal2);
        }

        public int CompareString(PropertyInfo prop, T x, T y)
        {
            var string1 = string.Empty;
            var string2 = string.Empty;
            if (prop.GetValue(x, null) != null)
            {
                string1 = prop.GetValue(x, null).ToString();
            }
            if (prop.GetValue(y, null) != null)
            {
                string2 = prop.GetValue(y, null).ToString();
            }
            return IsAsc ? string.Compare(string2, string1, StringComparison.Ordinal) : string.Compare(string1, string2, StringComparison.Ordinal);
        }

        public int CompareDateTime(PropertyInfo prop, T x, T y)
        {
            var dateTime1 = DateTime.Now;
            var dateTime2 = DateTime.Now;
            if (prop.GetValue(x, null) != null)
            {
                dateTime1 = Convert.ToDateTime(prop.GetValue(x, null));
            }
            if (prop.GetValue(y, null) != null)
            {
                dateTime2 = Convert.ToDateTime(prop.GetValue(y, null));
            }
            return IsAsc ? dateTime2.CompareTo(dateTime1) : dateTime1.CompareTo(dateTime2);
        }
        #endregion
        /// <summary>
        ///     比较大小 返回值 小于零则X小于Y，等于零则X等于Y，大于零则X大于Y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(T x, T y)
        {
            var property = typeof (T).GetProperty(PropertyName);
            var propName = property.PropertyType.Name;
            if (dicts.ContainsKey(propName))
            {
               var action = dicts[propName];
                return action.Invoke(property,x,y);
            }
            return 0;
        }
    }
}