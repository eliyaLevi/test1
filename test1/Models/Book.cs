using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Reflection.Metadata.BlobBuilder;

namespace test1.Models
{
    public class Book
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "שם הספר")]
        public string NameBook { get; set; }

        [Display(Name = "גובה")]
        public int height { get; set; }

        [Display(Name = "ספרייה"), NotMapped]
        public int shelf_id { get; set; }
        public shelf shelf { get; set; }

    }
}
