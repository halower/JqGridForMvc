/****************************************************
** 作者： Halower (QQ:121625933)
** 创始时间：2015-02-01
** 描述：jqGrid扩展单元列属性
*****************************************************/

using Newtonsoft.Json;

namespace HalowerHub.JqGrid
{
    [JsonObject]
    public class GridCell
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("cell")]
        public string[] Cell { get; set; }
    }
}