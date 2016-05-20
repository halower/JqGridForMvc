namespace HalowerHub.JqGrid
{
    /// <summary>
    /// 
    /// </summary>
    public class RenderInitCommand
    {
        /// <summary>
        /// 表格Id
        /// </summary>
        public string GridId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TableInitCommand { get; set; }
        /// <summary>
        /// 底部按钮初始化
        /// </summary>
        public string BottomNavBarInitCommand { get; set; }
        /// <summary>
        /// 表头合并初始化
        /// </summary>
        public string GroupHeaderInitCommand { get; set; }
        /// <summary>
        /// 合并行初始化
        /// </summary>
        public string MergerColumnInitCommand { get; set; }

        /// <summary>
        /// 分页Id
        /// </summary>
        public string PagerId { get; set; }
    }
}