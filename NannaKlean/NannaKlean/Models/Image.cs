using System.ComponentModel.DataAnnotations;

namespace NannaKlean.Models
{
    public class Image
    {
        [Key]
        public string name { get; set; }

        public int resCleanDetailId { get; set; }

        public List<IFormFile> photos { get; set; }
    }
}
