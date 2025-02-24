using System.ComponentModel.DataAnnotations.Schema;

namespace NannaKlean.Models
{
    public class MiscItem
    {
        public int Id { get; set; }

        public Boolean requested { get; set; }

        public int ResCleanDetailId { get; set; }
        public int MiscItemTypeId { get; set; }

        public MiscItemType? MiscItemType { get; set; }
    }
}
