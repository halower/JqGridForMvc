/****************************************************
** 作者： Halower (QQ:121625933)
** 创始时间：2015-1-21
** 描述：jqGrid扩展
*****************************************************/


namespace HalowerHub.JqGrid
{
    public class GridConfigBuilder
    {
        #region 属性

        private GridConfiguration GridConfiguration { get; set; }

        #endregion

        #region 构造函数

        public GridConfigBuilder()
        {
            GridConfiguration = new GridConfiguration();
        }

        private GridConfigBuilder(string gridId) : this()
        {
        }

        public GridConfigBuilder(string gridId, GridConfiguration gridConfiguration) : this(gridId)
        {
            GridConfiguration = gridConfiguration;
        }

        #endregion

        #region 字段

        #endregion
    }
}