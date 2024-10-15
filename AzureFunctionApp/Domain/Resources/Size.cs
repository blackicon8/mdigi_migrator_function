using AzureFunctionApp.Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureFunctionApp.Domain.Resources;
public class Size : EntityBase
{
    public Size()
    {
        Id = Guid.NewGuid().ToString();
    }

    [Column(TypeName = "nvarchar(256)")]
    public string SizeId { get; set; }
    [Column(TypeName = "nvarchar(256)")]
    public string Name { get; set; }
    public bool IsCustom { get; set; }

    [Column(TypeName = "nvarchar(256)")]
    public string FormatId { get; set; }

    // Navigation properties
    public string AdRunId { get; set; }
    public AdRun AdRun { get; set; }
}
