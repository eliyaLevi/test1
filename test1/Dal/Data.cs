namespace test1.Dal
{
    //מחלקה לניהול הנתונים של הספריות  שלי
    public class Data
    {
        // משתנה סטטי לשמירת מופע יחיד של המחלקה  
        static Data GetData;

        //מחרוזת חיבור לבסיס הנתונים
        string ConnectionString = "server=LAPTOP-GGTATKCJ\\SQLEXPRESS;" +
                                                   "initial catalog= test1 ;" +
                                                   "user id=sa ;" +
                                                   "password=1234 ;" +
                                                   "TrustServerCertificate=Yes";
        //קונסטרקטור פרטי  למניעת יצירת מופעים מחוץ למחלקה
        private Data() 
        {   //יצירת מופע של שכבת הנתונים עם מחרוזת החיבור
            Layer = new DataLayer(ConnectionString);
        }
        //מאפיין סטטי לקבלת שכבת הנתונים
        public static DataLayer Get 
        {
            get 
            {
              if(GetData == null)
                {
                    GetData = new Data();
                }
                    return GetData.Layer;
                    
            } 
        }
        //מאפיין לשמירת שכבת הנתונים
        public DataLayer Layer {  get; set; }
    }
}
