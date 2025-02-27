using System.ComponentModel;

namespace NannaKlean.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        [DisplayName("Phone number")]
        public string? PhoneNumber { get; set; }

        public DateTime? createTime { get; set; }

    }
}
