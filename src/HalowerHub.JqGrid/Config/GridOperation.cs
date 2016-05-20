/****************************************************
** 作者： Halower (QQ:121625933)
** 创始时间：2015-02-01
** 描述：jqGrid扩展单元格操作配置类
*****************************************************/

using System.Diagnostics;
using Newtonsoft.Json;

namespace HalowerHub.JqGrid
{ 
    public class GridOperation
    {
        [JsonProperty("edit")]
        public bool Edit { get; set; }

        [JsonProperty("edittext")]
        public string EditText { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("editicon")]
        public string Editicon { get; set; } = "ui-icon ui-icon-pencil";

        [JsonProperty("add")]
        public bool Add { get; set; }

        [JsonProperty("addtext")]
        public string AddText { get; set; }

        /// <summary>
        /// Delicon
        /// </summary>
        [JsonProperty("addicon")]
        public string Addicon { get; set; } = "ui-icon ui-icon-plus";

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("del")]
        public bool Delete { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("deltext")]
        public string DeleteText { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("delicon")]
        public string Delicon { get; set; } = "ui-pg-button ui-corner-all";

        [JsonProperty("search")]
        public bool Search { get; set; }

        [JsonProperty("searchtext")]
        public string SearchText { get; set; }

        [JsonProperty("searchicon")]
        public string SearchIcon { get; set; } = "ui-icon ui-icon-search";

        [JsonProperty("refresh")]
        public bool Refresh { get; set; }

        [JsonProperty("refreshText")]
        public string RefreshText { get; set; }

        [JsonProperty("refreshicon ")]
        public string Refreshicon { get; set; } = "ui-icon ui-icon-refresh";
    }

}