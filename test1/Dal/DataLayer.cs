using Microsoft.EntityFrameworkCore;
using test1.Models;

namespace test1.Dal
{
    //קלאס שמייצג את שכבת הנתונים יורש מקלאס בשם Dbcontext
    public class DataLayer : DbContext
    {
        //קונסטרקטור שמקבל מחרוזת ומעביר אותה לקונסטרקטור של הקלאס האב
        public DataLayer(string connectinString) : base(GetOptions(connectinString))
        {
            //מוודא שאכן נוצר החיבור
            Database.EnsureCreated();

            //להכניס נתונים בפעם הראשונה
            Seed();
        }

        //פונקציה שמכניסה ספרייה ראשונה לדאטה שלא יהיה ריק
        private void Seed()
        {
            if (Libraris.Count() > 0)
            {
                return;
            }

            Library firstLibrary = new Library();
            firstLibrary.genre = "חסידות";
            Libraris.Add(firstLibrary);
            SaveChanges();
        }



        //ליצור טבלה של ספרים לפי הטבלה של הספר שכתבנו בקלאס
        public DbSet<Book> Books { get; set; }

        //ליצור טבלה של מדפים לפי הטבלה של המדף שכתבנו בקלאס
        public DbSet<shelf> shelfs { get; set; }

        //ליצור טבלה של ספריות לפי הטבלה של הספרייה שכתבנו בקלאס
        public DbSet<Library> Libraris { get; set; }

        //פונקציה שמחזירה את אפשרויות ההתחברות למסד הנתונים
        private static DbContextOptions GetOptions(string connectinString)
        {
            return SqlServerDbContextOptionsExtensions
                .UseSqlServer(new DbContextOptionsBuilder(), connectinString)
                .Options;
        }
    }
}

