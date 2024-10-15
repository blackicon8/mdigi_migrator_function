using AzureFunctionApp.Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureFunctionApp.Domain.Resources;
public class Campaign : EntityBase
{
    [Column(TypeName = "nvarchar(256)")]
    public string CustomId { get; set; }
    [Column(TypeName = "nvarchar(256)")]
    public string Name { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    [Column(TypeName = "nvarchar(256)")]
    public string Planner { get; set; }
    public double? Budget { get; set; }
    [Column(TypeName = "nvarchar(256)")]
    public string BudgetType { get; set; }
    [Column(TypeName = "nvarchar(256)")]
    public string State { get; set; }
    public int Version { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? ArchivedAt { get; set; }

    // Navigation properties
    public string BrandId { get; set; }
    public Brand Brand { get; set; }
    public IEnumerable<AdRun> AdRuns { get; set; }
    public IEnumerable<Service> Services { get; set; }
    public IEnumerable<Job> Jobs { get; set; }
}
