using System.ComponentModel.DataAnnotations;

namespace GreaTreasure.Models
{
    public class Shelf
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "שם מדף")]
        public string Name { get; set; }
        [Display(Name ="גובה")]
        public int Height { get; set; }
        public Library library { get; set; } 
        public List<Book> books { get; set; }
        public Shelf(string name , int height, Library library)
        {
            Name = name;
            Height = height;
            this.library = library;
        }
        public Shelf() { }
        
    }
}
