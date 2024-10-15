namespace AzureFunctionApp.Services.mDigiApiManager;

public class ApiManagerOptions
{
    public int Limit { get; set; } = 100;
    public string Sort { get; set; } = "desc";
    public string ColumnOrder { get; set; } = "updatedAt";
}
