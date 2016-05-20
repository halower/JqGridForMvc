/****************************************************
** 作者： Halower (QQ:121625933)
** 创始时间：2015-02-01
** 描述：jqGrid扩展表格配置信息
*****************************************************/

using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace HalowerHub.JqGrid
{
    public class GridConfiguration
    {
        #region 构造函数

        public GridConfiguration(params GridColumn[] gridColumns)
        {
            ColSPanConfiguation = new ColSPanConfiguation();
            GridOperation = new GridOperation();
            var columns = new List<IGridColumn>();
            columns.AddRange(gridColumns);
            GridColumns = columns;
        }

        #endregion

        #region 字段

        private string _dataType;
        private string _mType;
        private string _pagerId;
        private int[] _rowList;
        private int? _rowNum;
        private bool? _viewRecords;

        #endregion

        #region 属性

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("datatype")]
        public string DataType
        {
            get { return _dataType ?? "json"; }
            set { _dataType = value; }
        }

        [JsonProperty("colNames")]
        public string[] ColNames
        {
            get { return GridColumns.ToList().Select(c => c.DisplayName).ToArray(); }
        }

        [JsonProperty("colModel")]
        public List<IGridColumn> GridColumns { get; set; }

        [JsonProperty("rowNum")]
        public int RowNum
        {
            get { return _rowNum ?? 10; }
            set { _rowNum = value; }
        }

        [JsonProperty("rowList")]
        public int[] RowList
        {
            get { return _rowList ?? new[] {10, 20, 30}; }
            set { _rowList = value; }
        }

        [JsonProperty("pager")]
        public string PagerId
        {
            get { return !string.IsNullOrEmpty(_pagerId) ? "#" + _pagerId : null; }
            set { _pagerId = value; }
        }

        [JsonProperty("sortname")]
        public string SortName { get; set; }

        [JsonProperty("mtype")]
        public string MTyope
        {
            get { return _mType ?? "post"; }
            set { _mType = value; }
        }

        /// <summary>
        ///     是否在浏览导航栏显示记录总数
        /// </summary>
        [JsonProperty("viewrecords")]
        public bool ViewRecords
        {
            get { return _viewRecords ?? true; }
            set { _viewRecords = value; }
        }

        [JsonIgnore]
        public ColSPanConfiguation ColSPanConfiguation { get; set; }


        /// <summary>
        ///     从服务器读取XML或JSON数据时初始的排序类型
        /// </summary>
        [JsonProperty("sortorder")]
        public string Sortorder { get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("direction")]
        public string Direction { get; set; }


        [JsonProperty("loadtext")]
        public string LoadText { get; set; }


        [JsonProperty("pginput")]
        public bool PgInput { get; set; }

        [JsonProperty("postData")]
        public Dictionary<string, string> PostData { get; set; }

        [JsonProperty("autowidth")]
        public bool AutoWidth { get; set; }


        [JsonProperty("autoencode")]
        public bool? AutoEencode { get; set; }

        [JsonProperty("emptyrecords")]
        public string EmptyRecords { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("multiselect")]
        public bool Multiselect { get; set; }

        [JsonIgnore]
        public GridOperation GridOperation { get; set; }

        [JsonIgnore]
        public bool MultiSearch { get; set; }

        [JsonProperty("gridComplete")]
        public string GridComplete { get; set; }
        #region 子表格

        [JsonProperty("subGrid")]
        public bool? SubGrid { get; set; }

        [JsonProperty("subGridModel")]
        public SubGridTable[] SubGridModel { get; set; }

        [JsonProperty("subGridType")]
        public object SubGridType { get; set; }

        [JsonProperty("subGridUrl")]
        public string SubGridUrl { get; set; }

        [JsonIgnore]
        public bool GroupHeaders { get; set; }

        [JsonIgnore]
        public string GridKey { get; set; }

        [JsonProperty("subGridRowExpanded")]
        public string SubGridRowExpanded { get; set; }

        [JsonIgnore]
        public bool PerClearCache { get; set; }

        [JsonProperty("treeGrid")]
        public bool TreeGrid { get;  set; }

        [JsonProperty("treeGridModel")]
        public string TreeGridModel { get;  set; }

        public string ExpandColumn { get; internal set; }

        [JsonProperty("treeIcons")]
        public string TreeIcons { get; internal set; }

        [JsonProperty("tree_root_level")]
        public string TreeRootLevel { get; internal set; }

        [JsonProperty("editurl")]
        public string EditUrl { get; internal set; }

        [JsonProperty("onSelectRow")]
        public string OnSelectRow { get; internal set; }
        #endregion
    }
    #endregion
}