namespace BackOfficeUI.Client.Components.Table;

public class TableContext<TItem>
{
    public List<Column<TItem>> Columns { get; set; } = new List<Column<TItem>>();
}