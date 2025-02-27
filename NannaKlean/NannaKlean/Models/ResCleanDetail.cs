using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using System.ComponentModel;

namespace NannaKlean.Models
{
    public class ResCleanDetail
    {
        public int Id { get; set; }
        [DisplayName("Approximate Square Feet")]
        public int? squareFeet { get; set; }
        [DisplayName("Number of Living rooms")]
        public int numLivingRooms { get; set; }
        [DisplayName("Number of Bedrooms")]
        public int numBedrooms { get; set; }
        [DisplayName("Number of Bathrooms")]
        public int numBathRooms { get; set; }
        public DateTime? createTime { get; set; }

        public int contactId { get; set; }

        public ICollection<MiscItem>? miscItems { get; }

    }
}
