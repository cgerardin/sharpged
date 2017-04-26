using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Configuration;

namespace SharpGED_server
{
    class DatabaseManager
    {

        private string databaseName;

        public DatabaseManager()
        {
            DatabaseName = ConfigurationManager.AppSettings.Get("Database");
        }

        public void Initialize()
        {
            string baseFolder = ConfigurationManager.AppSettings.Get("BaseFolder");

            Directory.CreateDirectory(baseFolder + "database\\");
            Directory.CreateDirectory(baseFolder + "\\storage");
            SQLiteConnection.CreateFile(baseFolder + "database\\" + DatabaseName + ".sqlite");

            SQLiteConnection db = new SQLiteConnection("Data Source=" + baseFolder + "database\\" + DatabaseName + ".sqlite" + ";Version=3;");

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
            string baseFolder = ConfigurationManager.AppSettings.Get("BaseFolder");
            return new SQLiteConnection("Data Source=" + baseFolder + "database\\" + DatabaseName + ".sqlite" + ";Version=3;");
        }

        public string DatabaseName { get => databaseName; set => databaseName = value; }

    }

}
