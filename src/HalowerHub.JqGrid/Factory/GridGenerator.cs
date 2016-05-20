/****************************************************
** 作者： Halower (QQ:121625933)
** 创始时间：2015-02-01
** 描述：jqGrid扩展
**修改时间: 2015-08-22
*****************************************************/

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using RazorEngine.Text;

namespace HalowerHub.JqGrid
{
    public class GridGenerator<T> : IHtmlString
    {
        #region 属性

        private GridConfiguration GridConfiguration { get; }

        #endregion

        #region 构造函数

        public GridGenerator()
        {
            GridConfiguration = new GridConfiguration();
        }

        public GridGenerator(string gridId)
            : this()
        {
            _gridId = gridId;
        }

        public GridGenerator(string gridId, GridConfiguration gridConfiguration)
            : this(gridId)
        {
            GridConfiguration = gridConfiguration;
        }

        #endregion

        #region 字段

        private readonly string _gridId;

        #endregion

        #region 主要方法

        /// <summary>
        ///     启用分页
        /// </summary>
        /// <param name="pagerId">分页控件Id</param>
        /// <param name="hasPager"></param>
        /// <returns></returns>
        public GridGenerator<T> Pager(string pagerId = null, bool hasPager = true)
        {
            if (GridConfiguration.SubGridRowExpanded != null)
                throw new Exception("子表格不需要指定pagerId");
            GridConfiguration.PagerId = hasPager ? pagerId ?? "pagerId" : null;
            return this;
        }

        /// <summary>
        ///     获取数据的地址
        /// </summary>
        /// <param name="postUrl">获取数据的地址</param>
        /// <param name="postData">发送参数数据</param>
        /// <param name="tabKeyName">主键</param>
        /// <returns></returns>
        public GridGenerator<T> Url(string postUrl, Dictionary<string, string> postData = null, string tabKeyName = null)
        {
            GridConfiguration.Url = postUrl;
            if (tabKeyName != null)
            {
                postUrl = tabKeyName == "row_id" ? postUrl + "/" : postUrl + "?" + tabKeyName + "=";
                GridConfiguration.Url = postUrl + $"{"\""}+{"row_id"}&";
            }

            if (postData == null)
            {
                postData = new Dictionary<string, string>();
            }
            postData.Add("displayFileds", string.Join(",", GridConfiguration.GridColumns.Select(c => c.Field).Where(f => !string.IsNullOrEmpty(f))));
            if (string.IsNullOrEmpty(GridConfiguration.GridKey))
                throw new Exception("请指定表格标识列");
            postData.Add("gridkey", GridConfiguration.GridKey);
            GridConfiguration.PostData = postData;
            return this;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="postUrl">获取数据的地址</param>
        /// <param name="tabKname">主表主键</param>
        /// <param name="postData">发送参数数据</param>
        /// <param name="passPTabKey">是否传入父表主键参数</param>
        /// <returns></returns>
        public GridGenerator<T> Url(string postUrl, bool passPTabKey, string tabKname, Dictionary<string, string> postData = null)
        {
            return passPTabKey ? Url(postUrl, postData, tabKname ?? "row_id") : Url(postUrl, postData);
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="postUrl">获取数据的地址</param>
        /// <param name="passPTabKey">是否传入父表主键参数</param>
        public GridGenerator<T> Url(string postUrl, bool passPTabKey)
        {
            return Url(postUrl, passPTabKey, null);
        }


        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="editUrl">提交数据的地址</param>
        public GridGenerator<T> EditUrl(string editUrl)
        {
            GridConfiguration.EditUrl = editUrl;
            return this;
        }

        /// <summary>
        ///     表格名称
        /// </summary>
        /// <param name="caption">表格名称</param>
        /// <returns></returns>
        public GridGenerator<T> Caption(string caption)
        {
            GridConfiguration.Caption = caption;
            return this;
        }

        /// <summary>
        ///     一个下拉选择框，用来改变显示记录数，当选择时会覆盖rowNum参数传递到后台
        /// </summary>
        /// <param name="rowslist">显示记录数</param>
        /// <returns></returns>
        public GridGenerator<T> RowList(params int[] rowslist)
        {
            GridConfiguration.RowList = rowslist;
            return this;
        }

        /// <summary>
        ///     默认的排序列。可以是列名称或者是一个数字，这个参数会被提交到后台
        /// </summary>
        /// <param name="sortName">排序列</param>
        /// <returns></returns>
        public GridGenerator<T> SortName(string sortName)
        {
            GridConfiguration.SortName = sortName;
            return this;
        }

        /// <summary>
        ///     表格中的书写方向
        /// </summary>
        /// <param name="direction">书写方向</param>
        /// <returns></returns>
        public GridGenerator<T> Direction(Driections direction)
        {
            GridConfiguration.Direction = direction.ToString().ToLower();
            return this;
        }

        /// <summary>
        ///     从服务器读取XML或JSON数据时初始的排序类型
        /// </summary>
        /// <param name="sortOrderType">排序类型</param>
        /// <returns></returns>
        public GridGenerator<T> SortOrder(SortOrders sortOrderType = SortOrders.Desc)
        {
            GridConfiguration.Sortorder = sortOrderType.ToString().ToLower();
            return this;
        }

        /// <summary>
        ///     数据请求和排序时显示的文本
        /// </summary>
        /// <param name="loadtext">显示的文本</param>
        /// <returns></returns>
        public GridGenerator<T> LoadText(string loadtext)
        {
            GridConfiguration.LoadText = loadtext;
            return this;
        }

        /// <summary>
        ///     定义导航栏是否有页码输入框
        /// </summary>
        /// <param name="haspginput">是否有页码输入框</param>
        /// <returns></returns>
        public GridGenerator<T> PgInput(bool haspginput = true)
        {
            GridConfiguration.PgInput = haspginput;
            return this;
        }

        /// <summary>
        ///     当设置为true时，表格宽度将自动匹配到父元素的宽度
        /// </summary>
        /// <param name="autowidth">自动匹配</param>
        /// <returns></returns>
        public GridGenerator<T> AutoWidth(bool autowidth = true)
        {
            GridConfiguration.AutoWidth = autowidth;
            return this;
        }


        /// <summary>
        ///     当设置为true时，对来自服务器的数据和提交数据进行encodes编码。如<![CDATA[<将被转换为&lt;]]>
        /// </summary>
        /// <param name="autoEncode">encodes编码</param>
        /// <returns></returns>
        public GridGenerator<T> AutoEencode(bool? autoEncode)
        {
            GridConfiguration.AutoEencode = autoEncode;
            return this;
        }

        /// <summary>
        /// 表格完成事件
        /// </summary>
        /// <param name="gridCompleteFunc"></param>
        /// <returns></returns>
        public GridGenerator<T> GridComplete(string gridCompleteFunc)
        {
            GridConfiguration.GridComplete = "&"+ gridCompleteFunc + "&";
            return this;
        }


        /// <summary>
        /// 行选择事件
        /// </summary>
        /// <param name="onSelectRowFunc"></param>
        /// <returns></returns>
        public GridGenerator<T> OnSelectRow(string onSelectRowFunc)
        {
            GridConfiguration.OnSelectRow = "&" + onSelectRowFunc + "&";
            return this;
        }
        /// <summary>
        ///     定义表格希望获得的数据的类型
        /// </summary>
        /// <param name="dataTypes">数据的类型</param>
        /// <returns></returns>
        public GridGenerator<T> DataType(ResponseDatas dataTypes)
        {
            GridConfiguration.DataType = dataTypes.ToString().ToLower();
            return this;
        }

        /// <summary>
        ///     当返回(或当前)数量为零时显示的信息此项只用当viewrecords 设置为true时才有效。
        /// </summary>
        /// <param name="emptyrecords">数量为零时显示的信息</param>
        /// <returns></returns>
        public GridGenerator<T> EmptyRecords(string emptyrecords)
        {
            GridConfiguration.EmptyRecords = emptyrecords;
            return this;
        }

        /// <summary>
        ///     表格高度。可为数值、百分比或auto
        /// </summary>
        /// <param name="height">高度</param>
        /// <returns></returns>
        public GridGenerator<T> Height(string height)
        {
            GridConfiguration.Height = height;
            return this;
        }

        /// <summary>
        ///     此属性设为true时启用多行选择，出现复选框
        /// </summary>
        /// <param name="multiselect">出现复选框</param>
        /// <returns></returns>
        public GridGenerator<T> Multiselect(bool multiselect = true)
        {
            GridConfiguration.Multiselect = multiselect;
            return this;
        }

        /// <summary>
        ///     子表数据请求Url
        /// </summary>
        /// <param name="url">数据请求Url</param>
        /// <param name="gridKey">gridKey</param>
        /// <returns></returns>
        public GridGenerator<T> SubGridUrl(string url, string gridKey)
        {
            GridConfiguration.SubGrid = true;
            var displayFileds = string.Join(",", GridConfiguration.SubGridModel[0].GridColumns.Select(c => c.Field).Where(f => !string.IsNullOrEmpty(f)));
            if (!url.Contains("?") && !url.EndsWith("\\") && string.IsNullOrEmpty(GridConfiguration.SubGridRowExpanded))
                GridConfiguration.SubGridUrl = url + "?gridKey=" + gridKey + "&displayfileds=" + displayFileds;
            return this;
        }

        /// <summary>
        ///     子表格列配置
        /// </summary>
        /// <param name="gridColumns">有效列</param>
        /// <returns></returns>
        public GridGenerator<T> MainGrid(params IGridColumn[] gridColumns)
        {
            GridConfiguration.GridColumns = gridColumns.ToList();
            return this;
        }
 
        /// <summary>
        ///     子表格列配置
        /// </summary>
        /// <param name="multisearh">开启高级查询</param>
        /// <returns></returns>
        public GridGenerator<T> MultiSearch(bool multisearh = true)
        {
            GridConfiguration.MultiSearch = multisearh;
            return this;
        }


        /// <summary>
        ///     子表格配置
        /// </summary>
        /// <param name="gridColumns">有效列</param>
        /// <returns></returns>
        public GridGenerator<T> SubGrid(params GridColumn[] gridColumns)
        {
            GridConfiguration.SubGridModel = new[] { new SubGridTable(gridColumns) };
            return this;
        }

        /// <summary>
        ///     子表格配置
        /// </summary>
        /// <param name="gridTable">子表格</param>
        /// <param name="hassubPager"></param>
        /// <returns></returns>
        public GridGenerator<T> SubGridAsGrid(GridGenerator<T> gridTable, bool hassubPager = false)
        {
            GridConfiguration.SubGrid = true;
            var sb = new StringBuilder("&function(subgrid_id, row_id){");
            sb.Append("var subgrid_pager_id=subgrid_id + '_pgr';");
            sb.Append("var subgrid_table_id = subgrid_id+'_t';");
            sb.Append($"jQuery('#'+subgrid_id).html(\"<table id='\" + subgrid_table_id + \"'class='scroll'></table>{(hassubPager ? "<div id='\" + subgrid_pager_id + \"'class='scroll'></div>" : "")}\");");
            sb.Append("jQuery('#'+subgrid_table_id).jqGrid(");
            sb.Append(gridTable.GridConfiguration.IgnoreNullSerialize());
            sb.Append(" pager: subgrid_pager_id");
            sb.Append(" });}&");
            GridConfiguration.SubGridRowExpanded = sb.ToString()
                .Replace("\"&", "")
                .Replace("&\"", "")
                .Replace("} pager:", ", pager:");
            return this;
        }

        /// <summary>
        /// 填充表单
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="pTabKeyName">主表key</param>
        /// <returns></returns>
        public GridGenerator<T> SubGridAsForm(string url, string pTabKeyName = null)
        {
            GridConfiguration.SubGrid = true;
            var baseUrl = string.IsNullOrEmpty(pTabKeyName) ? url + "/" : url + "?" + pTabKeyName + "=";
            const string templete = @"&function(subgrid_id, row_id){var subgrid_table_id = subgrid_id+'_t';jQuery.get('@baseUrl'+row_id, function(result) {jQuery('#'+subgrid_id).empty().html(result)});}&";
            GridConfiguration.SubGridRowExpanded =
            templete.Replace("@baseUrl", baseUrl).Replace("\"&", "").Replace("&\"", "");
            return this;
        }


        /// <summary>
        /// 设置表格主键
        /// </summary>
        /// <param name="expandColumn">树形列</param>
        /// <param name="treeIcon">树图标</param>
        /// <returns></returns>
        public GridGenerator<T> AsTreeGrid(string expandColumn,  string treeIcon = "ui-icon-document-b")
        {
            GridConfiguration.TreeGrid = true;
            GridConfiguration.TreeGridModel = "adjacency";
            GridConfiguration.ExpandColumn = expandColumn;
            GridConfiguration.TreeIcons = "&{leaf:'" + treeIcon + "'}&";
            return this;
        }
        /// <summary>
        /// 设置表格主键
        /// </summary>
        /// <param name="gridKey">表格主键</param>
        /// <returns></returns>
        public GridGenerator<T> GridKey(string gridKey)
        {
            GridConfiguration.GridKey = gridKey;
            return this;
        }

        /// <summary>
        /// 清除缓存(建议在开发阶段使用)
        /// </summary>
        /// <returns></returns>
        public GridGenerator<T> PerClearCache()
        {
            GridConfiguration.PerClearCache = true;
            return this;
        }
        /// <summary>
        ///     启用内置操作类型
        /// </summary>
        /// <param name="gridOperatorTypes">内置操作类型</param>
        /// <returns></returns>
        public GridGenerator<T> BuiltInOperation(GridOperators gridOperatorTypes)
        {
            if (gridOperatorTypes.HasFlag(GridOperators.Add))
                GridConfiguration.GridOperation.Add = true;
            if (gridOperatorTypes.HasFlag(GridOperators.Edit))
                GridConfiguration.GridOperation.Edit = true;
            if (gridOperatorTypes.HasFlag(GridOperators.Delete))
                GridConfiguration.GridOperation.Delete = true;
            if (gridOperatorTypes.HasFlag(GridOperators.Search))
                GridConfiguration.GridOperation.Search = true;
            if (gridOperatorTypes.HasFlag(GridOperators.Refresh))
                GridConfiguration.GridOperation.Refresh = true;
            return this;
        }

        /// <summary>
        /// 配置图标及文字
        /// </summary>
        /// <param name="operationIcontext"></param>
        /// <returns></returns>
        public GridGenerator<T> OperationIconText(GridOperation operationIcontext)
        {
            GridConfiguration.GridOperation = operationIcontext;
            return this;
        }

        /// <summary>
        /// 表头
        /// </summary>
        /// <param name="groupHeaders"></param>
        /// <returns></returns>
        public GridGenerator<T> GroupHeaders(params GroupHeader[] groupHeaders)
        {
            GridConfiguration.GroupHeaders = true;
            GridConfiguration.ColSPanConfiguation.UseColSpanStyle = true;
            GridConfiguration.ColSPanConfiguation.GroupHeaders = groupHeaders;
            return this;
        }


        /// <summary>
        ///     表格生成器
        /// </summary>
        /// <returns></returns>
        public string ToHtmlString()
        {
            var cacheValue = GridConfiguration.PerClearCache ? null : CacheHelper.Get("JqGird_Config_" + _gridId);
            if (cacheValue != null)
            {
                return cacheValue.ToString();
            }//              
            string template = @"
              <!--该表格由HalwerHub.JqGrid自动生成,联系QQ:121625933-->
              <table id='@Model.GridId'></table> 
              <div id ='@Model.PagerId'></div >
              <script type='text/javascript'>
                jQuery(function(){
                @Model.TableInitCommand
                @Model.BottomNavBarInitCommand
                @Model.GroupHeaderInitCommand
                @Model.MergerColumnInitCommand
              });   
            </script>";
            var initCommand = new RenderInitCommand();
            initCommand.GridId = _gridId;
            initCommand.GroupHeaderInitCommand= GridConfiguration.GroupHeaders? "jQuery('#" + _gridId + "').jqGrid('setGroupHeaders'," +GridConfiguration.ColSPanConfiguation.IgnoreNullSerialize() + ")": "";
            initCommand.TableInitCommand = "jQuery('#" + _gridId + "').jqGrid("+GridConfiguration.IgnoreNullSerialize()+")";
            initCommand.PagerId = GridConfiguration.PagerId?.Substring(1);
            var colNames = GridConfiguration.GridColumns.Where(col => col.CellAttr != null).ToList();
            if (colNames.Any())
            {
                GridConfiguration.GridComplete = @"&function() {" + colNames.Aggregate("", (current, col) => current + ("Merger(\'" + _gridId + "\', \'" + col.Field + "\');")) + "}&";
                initCommand.MergerColumnInitCommand = "function Merger(gridName, cellName) { var mya = $('#' + gridName + '').getDataIDs(); var length = mya.length;for (var i = 0; i < length; i++){ var before = $('#' + gridName + '').jqGrid('getRowData', mya[i]); var rowSpanTaxCount = 1; for (j = i + 1; j <= length; j++) { var end = $('#' + gridName + '').jqGrid('getRowData', mya[j]); if (before[cellName] == end[cellName]) { rowSpanTaxCount++;$('#' + gridName + '').setCell(mya[j], cellName, '', { display: 'none' }); } else { rowSpanTaxCount = 1; break; }$('td[aria-describedby=' + gridName +'_' + cellName +']', '#' + gridName +'').eq(i).attr('rowspan', rowSpanTaxCount);}}};";
            }
            initCommand.BottomNavBarInitCommand= "$('#" + _gridId + "').jqGrid( 'navGrid' ,  '#"+ initCommand.PagerId + "'," + GridConfiguration.GridOperation.IgnoreNullSerialize() + ",{},{},{},{" + (GridConfiguration.MultiSearch ? "multipleSearch:true" : "") + "},{});";
            var config = new TemplateServiceConfiguration {EncodedStringFactory = new RawStringFactory()};
            var service = RazorEngineService.Create(config);
            var result = service.RunCompile(template,"templateKey", typeof(RenderInitCommand), initCommand);
            CacheHelper.Add("JqGird_Config_" + _gridId, result, 5);
            return result.Replace("\"&", "").Replace("&\"", "").Replace("\\", "");
        }

        #endregion

    }
}


