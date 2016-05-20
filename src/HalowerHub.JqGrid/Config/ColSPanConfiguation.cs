/****************************************************
** 作者： Halower (QQ:121625933)
** 创始时间：2015-02-01
** 描述：jqGrid扩展
*****************************************************/

using Newtonsoft.Json;

namespace HalowerHub.JqGrid
{
    public class ColSPanConfiguation
    {
        [JsonProperty("useColSpanStyle")]
        public bool UseColSpanStyle
        {
            get; set;
        }

        [JsonProperty("groupHeaders")]
        public GroupHeader[] GroupHeaders { get; set; }
    }
}