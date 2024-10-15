using AzureFunctionApp.Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureFunctionApp.Domain.Resources
{
    public class Brand : EntityBase
    {
        [Column(TypeName = "nvarchar(256)")]
        public string Name { get; set; }

        // Navigation properties
        // [Column(TypeName = "nvarchar(256)")]
        public string ClientId { get; set; }
        public Client Client { get; set; }
        public IEnumerable<Campaign> Campaigns { get; set; }
    }
}
