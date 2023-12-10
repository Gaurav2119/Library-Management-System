using System.ComponentModel.DataAnnotations;

namespace lms.Models
{
    public class order
    {
        [Key]
        public int Id { get; set; }
        public int bookid { get; set; }
        public int borrowedByUser { get; set; }
        public DateTime borrowedOn { get; set; }
        public DateTime borrowedUntil { get; set; }
        public Boolean is_returned { get; set; } = false;
    }
}