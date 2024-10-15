namespace AzureFunctionApp.Domain.Common
{
    public abstract class EntityBase
    {
        // [Column(TypeName = "nvarchar(256)")]
        public string Id { get; set; }
    }
}
