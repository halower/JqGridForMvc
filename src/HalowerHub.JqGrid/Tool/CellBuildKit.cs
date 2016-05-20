using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HalowerHub.JqGrid
{
    /// <summary>
    /// 工具包
    /// </summary>
    public static class CellBuildKit
    {
        /// <summary>
        /// 构建搜索下拉框
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="keySelector"></param>
        /// <param name="elementSelector"></param>
        /// <returns></returns>
        public static string SearchSelect<T>(this IEnumerable<T> list, Func<T, object> keySelector, Func<T, object> elementSelector) where T : class
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
        /// 构建搜索下拉
        /// </summary>
        /// <param name="selectDictionary"></param>
        /// <returns></returns>
        public static string SearchSelect(Dictionary<string,string> selectDictionary)
        {
            var selectBuilder = new StringBuilder("<select>");
            selectBuilder.Append("<option value =''>请选择</option>");
            foreach (var item in selectDictionary)
            {
                selectBuilder.AppendFormat("<option value ='{0}'>{1}</option>", item.Key, item.Value);
            }
            selectBuilder.Append("</select>");
            return selectBuilder.ToString();
        }

        /// <summary>
        ///  构建编辑下拉
        /// </summary>
        /// <param name="selectDictionary"></param>
        /// <returns></returns>
        public static string EditSelect(Dictionary<string, string> selectDictionary)
        {

            var selectBuilder = new StringBuilder("value:'");
            foreach (var item in selectDictionary)
            {
                selectBuilder.Append(item.Key + ":" + item.Value+";");
            }
            selectBuilder.Remove(selectBuilder.Length - 1, 1).Append("'");
             return selectBuilder.ToString();
        }

        /// <summary>
        ///  构建编辑下拉
        /// </summary>
        /// <returns></returns>
        public static string EditCheckbox(string ckv,string unckv)
        {
            return string.Format("value:'{0}:{1}'", ckv, unckv);
        }

        /// <summary>
        /// 构建文本框
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <returns></returns>
        public static string EditTextarea(int rows, int cols)
        {
            return string.Format("rows:'{0}',cols:'{1}'", rows, cols);
        }
    }
}