/****************************************************
** 作者： Halower (QQ:121625933)
** 创始时间：2015-02-01
** 描述：jqGrid扩展属性
*****************************************************/

using Newtonsoft.Json;

namespace HalowerHub.JqGrid
{
    public class GroupHeader
    {
        public GroupHeader(string startColumnName, int numberOfColumns, string titleTextHtml)
        {
            StartColumnName = startColumnName;
            NumberOfColumns = numberOfColumns;
            TitleText = titleTextHtml;
        }

        [JsonProperty("startColumnName")]
        public string StartColumnName { get; set; }

        [JsonProperty("numberOfColumns")]
        public int NumberOfColumns { get; set; }

        [JsonProperty("titleText")]
        public string TitleText { get; set; }
    }
}