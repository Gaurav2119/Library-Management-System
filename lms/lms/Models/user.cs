using System.ComponentModel.DataAnnotations;

namespace lms.Models
{
    public class user
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; } = string.Empty;
        public string username { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public int token { get; set; } = 0;

    }
}
