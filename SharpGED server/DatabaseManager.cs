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

        public void Initialize()
        {
            Directory.CreateDirectory(baseFolder + "database\\");
            Directory.CreateDirectory(baseFolder + "\\storage");
            SQLiteConnection.CreateFile(baseFolder + "database\\" + databaseName + ".sqlite");

            SQLiteConnection db = new SQLiteConnection("Data Source=" + baseFolder + "database\\" + databaseName + ".sqlite" + ";Version=3;");

            db.Open();
            string sql = "CREATE TABLE files (" +
                "idFile INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "filename TEXT NOT NULL, " +
                "originalFilename TEXT NOT NULL, " +
                "size INTEGER NOT NULL, " +
                "title TEXT, pages INTEGER" +
                ");";

            new SQLiteCommand(sql, db).ExecuteNonQuery();
            db.Close();
        }

        public SQLiteConnection Connect()
        {
            return new SQLiteConnection("Data Source=" + baseFolder + "database\\" + databaseName + ".sqlite" + ";Version=3;");
        }

    }

}
