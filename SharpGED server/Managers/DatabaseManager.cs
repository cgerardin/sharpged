using System.Data.SQLite;
using System.IO;
using System.Configuration;

namespace SharpGED_server
{
    class DatabaseManager
    {
        string baseFolder;
        private string databaseName;

        public DatabaseManager()
        {
            baseFolder = ConfigurationManager.AppSettings.Get("BaseFolder");
            databaseName = ConfigurationManager.AppSettings.Get("Database");
        }

        public bool isInitialized()
        {
            try
            {
                using (SQLiteConnection db = Connect())
                {
                    db.Open();
                    string sql = "SELECT * FROM sqlite_master;";
                    SQLiteDataReader rs = new SQLiteCommand(sql, db).ExecuteReader();
                }
            }
            catch (SQLiteException ex)
            {
                return false;
            }

            return true;
        }

        public void Initialize()
        {
            Directory.CreateDirectory(baseFolder + "database\\");
            Directory.CreateDirectory(baseFolder + "\\storage");
            SQLiteConnection.CreateFile(baseFolder + "database\\" + databaseName + ".sqlite");

            using (SQLiteConnection db = Connect())
            {
                db.Open();
                string sql = "CREATE TABLE files (" +
                    "idFile INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "filename TEXT NOT NULL, " +
                    "originalname TEXT NOT NULL, " +
                    "size INTEGER NOT NULL, " +
                    "title TEXT, pages INTEGER" +
                    ");";

                new SQLiteCommand(sql, db).ExecuteNonQuery();
            }
        }

        public SQLiteConnection Connect()
        {
            return new SQLiteConnection("Data Source=" + baseFolder + "database\\" + databaseName + ".sqlite" + ";Version=3;");
        }

    }

}
