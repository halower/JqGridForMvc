/****************************************************
** 作者： Halower (QQ:121625933)
** 创始时间：2015-03-21
** 描述：jqGrid查询扩展 
*****************************************************/

using System.Web.Mvc;

namespace HalowerHub.JqGrid 
{
    /// <summary>
    ///     Grid 工厂扩展方法。
    /// </summary>
    public static class GridFactoryExtensions
    {
        /// <summary>
        ///    Grid
        /// </summary>
        /// <param name="htmlHelper">Html 助手</param>
        /// <returns>Grid 工厂</returns>
        public static GridFacotory JqGridKit(this HtmlHelper htmlHelper)
        {
            return new GridFacotory(htmlHelper);
        }

        /// <summary>
        ///   Grid
        /// </summary>
        /// <typeparam name="TModel">模型类型</typeparam>
        /// <param name="htmlHelper">Html 助手</param>
        /// <returns>Grid 工厂</returns>
        public static GridFacotory<TModel> JqGridKit<TModel>(this HtmlHelper<TModel> htmlHelper)
        {
            return new GridFacotory<TModel>(htmlHelper);
        }
    }
}