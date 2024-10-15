using AzureFunctionApp.Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureFunctionApp.Domain.Resources;
public class Job : EntityBase
{
    public int JobId { get; set; }
    [Column(TypeName = "nvarchar(256)")]
    public string Name { get; set; }
    [Column(TypeName = "nvarchar(256)")]
    public string Code { get; set; }
    [Column(TypeName = "nvarchar(256)")]
    public string Type { get; set; }
    [Column(TypeName = "nvarchar(256)")]
    public string ChannelId { get; set; }

    // Navigation properties
    public string CampaignId { get; set; }
    public Campaign Campaign { get; set; }
}
