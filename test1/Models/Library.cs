using System.ComponentModel.DataAnnotations;

namespace test1.Models
{
    public class Library
    {

        public Library()
        {
            shelfs = new List<shelf>();
        }
        [Key]
        public int id { get; set; }

        [Display(Name = "זאנר")]
        public string? genre { get; set; }

        public List<shelf> shelfs { get; set; }


        //פונקציה להוספת מדף ראשון לספרייה
        public void Addshelf(int id)
        {
            shelf sf = new shelf
            {
                id = id,
                Library = this
            };
       
            shelfs.Add(sf);
        }
    }
}
