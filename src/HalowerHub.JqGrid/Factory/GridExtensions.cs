/****************************************************
** 作者： Halower (QQ:121625933)
** 创始时间：2015-03-21
** 描述：jqGrid查询扩展 
*****************************************************/

namespace HalowerHub.JqGrid
{
    public static class GridExtensions
    {
        public static GridGenerator<TModel> JqGrid<TModel>(this GridFacotory<TModel> factory, string gridId)
        {
            return new GridGenerator<TModel>(gridId);
        }

        public static GridGenerator<TModel> JqGrid<TModel>(this GridFacotory<TModel> factory, string gridId, string gridKey)
        {
            return new GridGenerator<TModel>(gridId, new GridConfiguration {GridKey = gridKey});
        }

        public static GridGenerator<TModel> JqGrid<TModel>(this GridFacotory factory, string gridId,GridConfiguration jqGridConfiguration)
        {
            return new GridGenerator<TModel>(gridId, jqGridConfiguration);
        }
    }
}