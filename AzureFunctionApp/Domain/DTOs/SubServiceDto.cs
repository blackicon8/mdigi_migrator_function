namespace AzureFunctionApp.Domain.DTOs
{
    public class SubServiceDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int DealerId { get; set; }
        public int MediumId { get; set; }
        public int TechnicalCostId { get; set; }
        public string AdvertisingCode { get; set; }
        public bool AllowInvoiceOverride { get; set; }
        public string AgencyId { get; set; }
    }
}
