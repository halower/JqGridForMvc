/****************************************************
** 作者： Halower (QQ:121625933)
** 创始时间：2015-03-21
** 描述：jqGrid查询扩展 
*****************************************************/

using Newtonsoft.Json;

namespace HalowerHub.JqGrid
{
    public static class SerializerToolKit
    {
        public static string IgnoreNullSerialize(this object result)
        {
            return JsonConvert.SerializeObject(result,
                new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});
        }

        public static string ToSerializer(this object result)
        {
            return JsonConvert.SerializeObject(result);
        }
    }
}