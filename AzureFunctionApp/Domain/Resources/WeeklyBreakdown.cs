using AzureFunctionApp.Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureFunctionApp.Domain.Resources
{
    public class WeeklyBreakdown : EntityBase
    {
        [Column(TypeName = "nvarchar(256)")]
        public string CustomId { get; set; }

        public int Year { get; set; }
        public int Week { get; set; }
        public int Units { get; set; }
        public double? NetNet { get; set; }

        // Navigation properties
        public string AdRunId { get; set; }
        public AdRun AdRun { get; set; }
    }
}
