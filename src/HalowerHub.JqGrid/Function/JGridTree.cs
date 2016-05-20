using Newtonsoft.Json;

namespace HalowerHub.JqGrid
{
    public class JGridTree
    {
        [JsonProperty("level")]
        public virtual string TreeLevel { get; set; }

        [JsonProperty("isLeaf")]
        public virtual string IsLeaf { get; set; }

        [JsonProperty("parent")]
        public virtual string Parent { get; set; }

        [JsonProperty("expanded")]
        public virtual string Expanded { get; set; }
    }
}