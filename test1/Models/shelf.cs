using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test1.Models
{
    public class shelf
    {
            //{
            //    Books = new List<Book>();
            //}
        [Key]
        public int id { get; set; }

        [Display(Name = "גובה")]
        public int height { get; set; }

        [Display(Name = "ספרייה"), NotMapped]
        public int Library_id { get; set; }

        public Library? Library { get; set; }

        public List<Book> Books { get; set; }

        //פונקציה להוספת ספר למדף
        public void AddBook(int id)
        {
            Book sf = new Book
            {
                id = id,
                shelf = this
            };
            Books.Add(sf);
        }

    }
}
