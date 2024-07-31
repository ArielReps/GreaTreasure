using System.ComponentModel.DataAnnotations;

namespace GreaTreasure.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "שם הספר")]
        public string Title { get; set; } =string.Empty;
        [Display(Name = "תוכן")] public string Description { get; set; } = string.Empty;
        public Shelf shelf { get; set; }
    }
}
