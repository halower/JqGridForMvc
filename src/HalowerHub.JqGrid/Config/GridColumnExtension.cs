/****************************************************
** 作者： Halower (QQ:121625933)
** 创始时间：2015-02-01
** 描述：jqGrid扩展单元列属性
*****************************************************/

using System.Collections.Generic;

namespace HalowerHub.JqGrid
{
    public static class GridColumnExtension
    {
        /// <summary>
        ///     设置列的初始宽度，可用pixels和百分比
        /// </summary>
        /// <param name="width">初始宽度</param>
        /// <returns></returns>
        public static GridColumn Width(this GridColumn col, int width)
        {
            col.Width = width;
            return col;
        }

        /// <summary>
        ///     定义初始化时，列是否隐藏
        /// </summary>
        public static GridColumn Hidden(this GridColumn col, bool hidden = true)
        {
            col.Hidden = hidden;
            return col;
        }

        /// <summary>
        ///     设置字段位置
        /// </summary>
        /// <param name="contentAlign">字段位置</param>
        /// <returns></returns>
        public static GridColumn ContentAlign(this GridColumn col, string contentAlign)
        {
            col.Align = contentAlign;
            return col;
        }

        /// <summary>
        ///     定义字段是否可编辑
        /// </summary>
        public static GridColumn Editable(this GridColumn col, ColumnEdits edittype, string editoptions, EditRules rules = null)
        {
            col.Editable = true;
            col.EditType = edittype.ToString().ToLower();
            col.Editoptions = "&{" + editoptions + "}&";
            col.EditRule = rules;
            return col;
        }
        /// <summary>
        ///   定义编辑规则
        /// </summary>
        /// <param name="col"></param>
        /// <param name="editRules"></param>
        /// <returns></returns>
        public static GridColumn EditRules(this GridColumn col, EditRules editRules)
        {
            col.EditRule = editRules;
            return col;
        }

        /// <summary>
        ///     定义定义字段是否可编辑
        /// </summary>
        public static GridColumn Formatter(this GridColumn col, CellFormatters cellformater,Formatoption formatoption=null)
        {
            col.Formatter ="\""+cellformater.ToString().ToLower()+"\"";
            col.Formatoptions =formatoption;
            return col;
        }


        /// <summary>
        /// 整数格式化器
        /// </summary>
        /// <param name="col"></param>
        /// <param name="thousandsSeparator">千分位分隔符</param>
        /// <param name="defautlValue">在没有数据的情况下的默认值</param>
        /// <returns></returns>
        public static GridColumn IntegerFormatter(this GridColumn col,string thousandsSeparator,string defautlValue=null)
        {
            col.Formatter = "\"" + CellFormatters.Integer.ToString().ToLower() + "\"";
            col.Formatoptions = new Formatoption { ThousandsSeparator = thousandsSeparator, DefaulValue = defautlValue };
            return col;
        }

        /// <summary>
        /// 数字格式化器
        /// </summary>
        /// <param name="col"></param>
        /// <param name="thousandsSeparator">千分位分隔符</param>
        /// <param name="decimalPlaces">小数保留位数</param>
        /// <param name="decimalSeparator">小数分隔符 如”.”</param>
        /// <param name="defautlValue">在没有数据的情况下的默认值</param>
        /// <returns></returns>
        public static GridColumn NumberFormatter(this GridColumn col, string thousandsSeparator,string decimalPlaces=null, string decimalSeparator=null,string defautlValue = null)
        {
            col.Formatter = "\"" + CellFormatters.Number.ToString().ToLower() + "\"";
            col.Formatoptions = new Formatoption { ThousandsSeparator = thousandsSeparator, DefaulValue = defautlValue,DecimalPlaces= decimalPlaces,DecimalSeparator=decimalSeparator };
            return col;
        }

        /// <summary>
        /// 金钱格式化器
        /// </summary>
        /// <param name="col"></param>
        /// <param name="prefix">前缀</param>
        /// <param name="suffix">后缀</param>
        /// <param name="thousandsSeparator">千分位分隔符</param>
        /// <param name="decimalPlaces">小数保留位数</param>
        /// <param name="decimalSeparator">小数分隔符 如”.”</param>
        /// <param name="defautlValue">在没有数据的情况下的默认值</param>
        /// <returns></returns>
        public static GridColumn CurrencyFormatter(this GridColumn col,string prefix="￥", string decimalPlaces = null, string suffix=null, string thousandsSeparator=null, string decimalSeparator = null, string defautlValue = null)
        {
            col.Formatter = "\"" + CellFormatters.Currency.ToString().ToLower() + "\"";
            col.Formatoptions = new Formatoption {Prefix=prefix,Suffix=suffix,ThousandsSeparator = thousandsSeparator, DefaulValue = defautlValue, DecimalPlaces = decimalPlaces, DecimalSeparator = decimalSeparator };
            return col;
        }

        /// <summary>
        /// 时间格式化器
        /// </summary>
        /// <param name="col"></param>
        /// <param name="srcformat">原来的格式</param>
        /// <param name="newformat">新的格式</param>
        /// <returns></returns>
        public static GridColumn DateFormatter(this GridColumn col, string srcformat,string newformat)
        {
            col.Formatter = "\"" + CellFormatters.Date.ToString().ToLower() + "\"";
            col.Formatoptions = new Formatoption { Srcformat = srcformat, Newformat = newformat };
            return col;
        }
        /// <summary>
        /// 链接格式化器
        /// </summary>
        /// <param name="col"></param>
        /// <param name="baseLinkUrl">在当前cell中加入link的url，如”jq/query.action”</param>
        /// <param name="addParam">在baseLinkUrl后加入额外的参数，如”&name=aaaa”</param>
        /// <param name="idName">默认会在baseLinkUrl后加入,如”.action?id=1″。改如果设置idName=”name”,那么”.action?name=1″。其中取值为当前rowid</param>
        /// <returns></returns>
        public static GridColumn LinkFormatter(this GridColumn col, string baseLinkUrl=null, string addParam=null,string idName=null)
        {
            col.Formatter = "\"" + CellFormatters.Showlink.ToString().ToLower() + "\"";
            col.Formatoptions = new Formatoption { BaseLinkUrl = baseLinkUrl, addParam = addParam,IdName= idName };
            return col;
        }

        /// <summary>
        /// 复选框格式化器
        /// </summary>
        /// <param name="col"></param>
        /// <param name="disabled">是否选中</param>
        /// <returns></returns>
        public static GridColumn CheckBoxFormatter(this GridColumn col,bool disabled)
        {
            col.Formatter = "\"" + CellFormatters.Checkbox.ToString().ToLower() + "\"";
            col.Formatoptions = new Formatoption { Disabled = disabled};
            return col;
        }

        /// <summary>
        ///     定义搜索
        /// </summary>
        public static GridColumn Searchable(this GridColumn col, CellTypes filedType = CellTypes.String)
        {
            col.Search = true;
            col.SearchFiledType = filedType;
            col.SearchType ="text";
            return col;
        }

        public static GridColumn SelectSearchable(this GridColumn col, string selectDataUrl)
        {
            col.Search = true;
            col.SearchType ="select";
            col.SelectDataSourceUrl = selectDataUrl;
            return col;
        }


        /// <summary>
        ///     启用排序
        /// </summary>
        /// <param name="columnSorts">排序类型</param>
        /// <returns></returns>
        public static GridColumn Sortable(this GridColumn col, ColumnSorts columnSorts = ColumnSorts.Text)
        {
            col.Sortable = true;
            col.SortType = columnSorts.ToString().ToLower();
            return col;
        }
        /// <summary>
        /// 文字位置
        /// </summary>
        /// <param name="col"></param>
        /// <param name="align"></param>
        /// <returns></returns>
        public static GridColumn TextAlign(this GridColumn col, string align)
        {
            col.Align = align;
            return col;
        }
        /// <summary>
        /// 列合并
        /// </summary>
        /// <param name="col"></param>
        /// <param name="align"></param>
        /// <returns></returns>
        public static GridColumn Merger(this GridColumn col)
        {

            var templete = @"&function(rowId, tv, rawObject, cm, rdata){return 'id=@FiledName'+ rowId;}&";
            col.CellAttr = templete.Replace("@FiledName", "\""+ col.Field+"\"");
            return col;
        }
    }
}
 