/****************************************************
** 作者： Halower (QQ:121625933)
** 创始时间：2015-02-01
** 描述：jqGrid扩展属性
*****************************************************/

using Newtonsoft.Json;

namespace HalowerHub.JqGrid
{
    public class SubGridModel
    {
        [JsonProperty("name")]
        public string[] FiledNames { get; set; }

        [JsonProperty("width")]
        public int[] FiledWidths { get; set; }

        [JsonProperty("align")]
        public string[] FiledAligns { get; set; }

        [JsonProperty("params")]
        public string[] Params { get; set; }
    }
}