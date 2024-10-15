namespace AzureFunctionApp.Domain.DTOs;
public class SalesHouseDto
{
    public string Id { get; set; }
    public string ExternalId { get; set; }
    public string Name { get; set; }
    public bool? Inactive { get; set; }
    public int? DefaultFee { get; set; }
}
