using AzureFunctionApp.Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureFunctionApp.Domain.Resources
{
    public class Client : EntityBase
    {
        [Column(TypeName = "nvarchar(256)")]
        public string Name { get; set; }

        // Navigation properties
        public IEnumerable<Brand> Brands { get; set; }
    }
}
