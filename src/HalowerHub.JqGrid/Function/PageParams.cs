/****************************************************
** 作者： Halower (QQ:121625933)
** 创始时间：2015-03-21
** 描述：jqGrid分页参数 
*****************************************************/

using System.Web.Mvc;

namespace HalowerHub.JqGrid
{
    public class PageParams
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Gridkey { get; set; }
        public string SortName { get; set; }
        public string Displayfileds { get; set; }
        public string SearchField { get; set; }
        public string SearchString { get; set; }
        public string SearchOper { get; set; }
        public string Filters { get; set; }
        public string Sord { get; set; }
    }

    public static class RequestHelper
    {
        public static PageParams InitRequestParams(Controller baseContent)
        {
            var pageParams = new PageParams
            {
                PageIndex = int.Parse(baseContent.Request["page"] ?? "0"),
                PageSize = int.Parse(baseContent.Request["rows"] ?? "0"),
                SortName = baseContent.Request["sidx"],
                Displayfileds = baseContent.Request["displayfileds"],
                SearchField = baseContent.Request["searchField"],
                SearchString = baseContent.Request["searchString"],
                SearchOper = baseContent.Request["searchOper"],
                Filters = baseContent.Request["filters"],
                Sord = baseContent.Request["sord"],
                Gridkey = baseContent.Request["gridKey"]
            };
            return pageParams;
        }
    }
}