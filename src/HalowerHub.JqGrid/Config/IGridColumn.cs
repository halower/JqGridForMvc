namespace HalowerHub.JqGrid
{
    public interface IGridColumn
    {
        string Field { get; set; }
        string Index { get; set; }
        int? Width { get; set; }
        string Align { get; set; }
        string DisplayName { get; set; }
        bool Sortable { get; set; }
        bool Hidden { get; set; }
        bool Editable { get; set; }
        bool Search { get; set; }
        string SearchType { get; set; }
        string SortType { get; set; }
        string EditType { get; set; }
        string Searchoptions { get; }
        string Formatter { get; set; }
        string CellAttr { get; set; }
        CellTypes SearchFiledType { get; set; }
    }
}