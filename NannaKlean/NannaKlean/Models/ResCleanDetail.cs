using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;

namespace NannaKlean.Models
{
    public class ResCleanDetail
    {
        public int Id { get; set; }
        public int squareFeet { get; set; }
        public int numLivingRooms { get; set; }
        public int numBedrooms { get; set; }
        public int numBathRooms { get; set; }
        public DateTime createTime { get; set; }

        public int contactId { get; set; }

        public ICollection<MiscItem>? miscItems { get; }

    }
}
