/****************************************************
** 作者： Halower (QQ:121625933)
** 创始时间：2015-02-01
** 描述：jqGrid扩展枚举
*****************************************************/

namespace HalowerHub.JqGrid
{
    public enum ResponseDatas
    {
        /// <summary>
        ///     xml数据
        /// </summary>
        Xml,

        /// <summary>
        ///     xml字符串
        /// </summary>
        Xmlstring,

        /// <summary>
        ///     JSON数据
        /// </summary>
        Json,

        /// <summary>
        ///     JSON字符串
        /// </summary>
        Jsonstring,

        /// <summary>
        ///     客户端数据（数组）
        /// </summary>
        Local,

        /// <summary>
        ///     javascript数据
        /// </summary>
        Javascript,

        /// <summary>
        ///     函数返回数据
        /// </summary>
        Function
    }
}