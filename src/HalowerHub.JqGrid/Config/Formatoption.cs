using Newtonsoft.Json;

namespace HalowerHub.JqGrid
{
    public class Formatoption
    {
        /// <summary>
        /// 千分位分隔符 [currency,integer,number]
        /// </summary>
        [JsonProperty("thousandsSeparator")]
        public string ThousandsSeparator { get; set; }
        /// <summary>
        /// 默认值 [integer,number]
        /// </summary>
        [JsonProperty("defaulValue")]
        public string DefaulValue { get; set; }
        /// <summary>
        /// 小数分隔符 [currency,number]
        /// </summary>
        [JsonProperty("decimalSeparator")]
        public string DecimalSeparator { get; set; }
        /// <summary>
        /// 小数保留位数 [currency,number]
        /// </summary>
        [JsonProperty("decimalPlaces")]
        public string DecimalPlaces { get; set; }
        /// <summary>
        /// 前缀 currency
        /// </summary>
        [JsonProperty("prefix")]
        public string Prefix { get; set; }
        /// <summary>
        /// 后缀
        /// </summary>
        [JsonProperty("suffix")]
        public string Suffix { get; set; }
        /// <summary>
        /// 本来格式 [date]
        /// </summary>
        [JsonProperty("srcformat")]
        public string Srcformat { get; set; }
        /// <summary>
        /// 新格式 [date]
        /// </summary>
        [JsonProperty("newformat")]
        public string Newformat { get; set; }
        /// <summary>
        /// 在当前cell中加入link的url [showlink]
        /// </summary>
        [JsonProperty("baseLinkUrl")]
        public string BaseLinkUrl { get; set; }

        /// <summary>
        /// /在baseLinkUrl后加入额外的参数，如&name=aaaa [showlink]
        /// </summary>
        [JsonProperty("addParam")]
        public string addParam { get; set; }
        /// <summary>
        /// 默认会在baseLinkUrl后加入,如”.action?id=1″[showlink]
        /// </summary>
        [JsonProperty("idName")]
        public string IdName { get; set; }

        /// <summary>
        ///  默认为true此时的checkbox不能编辑 [checkbox]
        /// </summary>
        [JsonProperty("disabled ")]
        public bool Disabled { get; set; }
    }
}