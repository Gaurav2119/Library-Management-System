using System.ComponentModel.DataAnnotations;

namespace lms.Models
{
    public class book
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public double Rating { get; set; } = 0;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public Boolean IsAvailable { get; set; } = true;
        public string Description { get; set; } = string.Empty;
        public int lentByUser { get; set; }
        public int currentlyBorrowedByUser { get; set; }
    }
}
