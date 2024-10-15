namespace Domain
{
    public class ApiData
    {
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string SalesHouse { get; set; }
        public string Site { get; set; }
        public string Placement { get; set; }
        public string Format { get; set; }
        public string Size { get; set; }
        public string PricingType { get; set; }
        public int Units { get; set; }
        public decimal EstimatedAV { get; set; }
        public int EstimatedCT { get; set; }
        public decimal? EstimatedCTR { get; set; }
        public decimal? EstimatedLead { get; set; }
        public decimal ClientPrice { get; set; }
        public string Discipline { get; set; }
        public string RowId { get; set; }
    }
}
