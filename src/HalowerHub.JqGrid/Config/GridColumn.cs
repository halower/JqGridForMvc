/****************************************************
** 作者： Halower (QQ:121625933)
** 创始时间：2015-02-01
** 描述：jqGrid扩展单元列属性
*****************************************************/

using Newtonsoft.Json;

namespace HalowerHub.JqGrid
{
    public class GridColumn : IGridColumn
    {
        #region 主要方法

        /// <summary>
        ///     设置字段映射名
        /// </summary>
        /// <param name="field">字段</param>
        /// <param name="name">映射名</param>
        /// <returns></returns>
        public GridColumn(string field, string name)
        {
            Field = field;
            DisplayName = name;
        }

        #endregion 主要方法

        #region 字段

        private string _aligin;
        private string _index;
        private bool? _search;
        private string _fomatter;

        #endregion 字段

        #region 属性

        [JsonProperty("name")]
        public string Field { get; set; }

        [JsonProperty("index")]
        public string Index
        {
            get { return _index ?? Field; }
            set { _index = value; }
        }

        [JsonProperty("width")]
        public int? Width { get; set; }

        [JsonProperty("align")]
        public string Align
        {
            get { return _aligin ?? "left"; }
            set { _aligin = value; }
        }

        [JsonIgnore]
        public string DisplayName { get; set; }

        [JsonProperty("sortable")]
        public bool Sortable { get; set; }

        [JsonProperty("hidden")]
        public bool Hidden { get; set; }

        [JsonProperty("editable")]
        public bool Editable { get; set; }

        [JsonProperty("search")]
        public bool Search
        {
            get { return _search ?? false; }
            set { _search = value; }
        }

        [JsonProperty("stype")]
        public string SearchType { get; set; }

        [JsonProperty("sorttype")]
        public string SortType { get; set; }

        [JsonProperty("edittype")]
        public string EditType { get; set; }

        [JsonProperty("searchoptions")]
        public string Searchoptions
        {
            get
            {
                if (SearchType == "select")
                    return "&{dataUrl:'" + SelectDataSourceUrl + "',sopt:['eq']}&";
                else
                {
                    switch (SearchFiledType)
                    {
                        case CellTypes.String:
                            return "&{sopt:['eq','bw','cn']}&";
                        case CellTypes.Number:
                            return "&{sopt:['eq','lt','gt']}&";
                        case CellTypes.DateTime:
                           return @"&{sopt:['eq','lt','gt'],dataInit: function (elem) {jQuery(elem).datepicker({changeMonth: true,changeYear: true,dateFormat:'yy年mm月dd日'});}}&";
                        default:
                            return "&{sopt:['eq','bw','cn']}&";
                    }
                }
            }
        }

        [JsonProperty("formatter")]
        public string Formatter
        {
            get
            {
                if (!string.IsNullOrEmpty(_fomatter))
                    return "&" + _fomatter + "&";
                return null;
            }
            set { _fomatter = value; }
        }

        [JsonProperty("cellattr")]
        public string CellAttr { get; set; }

        [JsonIgnore]
        public CellTypes SearchFiledType { get; set; }

        [JsonIgnore]
        public string SelectDataSourceUrl { get; internal set; }

        [JsonProperty("formatoptions")]
        public Formatoption Formatoptions { get; internal set; }

        [JsonProperty("editoptions")]
        public string Editoptions { get; internal set; }

        [JsonProperty("editrules")]
        public EditRules EditRule { get; set; }

        #endregion 属性
    }
}