using System.Data.SQLite;
using System.IO;

namespace SharpGED_server
{
    class DatabaseManager
    {
        private string baseFolder;
        public string name { get; set; }

        public DatabaseManager()
        {
            baseFolder = Program.configuration.values.baseFolder;
            name = Program.configuration.values.database;
        }

        public bool isInitialized()
        {
            if (File.Exists(baseFolder + "database\\" + name + ".sqlite"))
            {
                try
                {
                    using (SQLiteConnection db = Connect())
                    {
                        db.Open();
                        using (SQLiteDataReader rs = new SQLiteCommand("SELECT * FROM files;", db).ExecuteReader()) { }
                        return true;
                    }
                }
                catch (SQLiteException)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void Initialize()
        {
            Initialize(name);
        }

        public void Initialize(string databaseName)
        {
            string sql;
            name = databaseName;

            // Crée l'arborescence en la vidant de ses fichiers si elle existe déjà
            if (Directory.Exists(baseFolder + "\\storage\\" + name))
            {
                Directory.Delete(baseFolder + "\\storage\\" + name, true);
            }
            Directory.CreateDirectory(baseFolder + "\\database");
            Directory.CreateDirectory(baseFolder + "\\storage\\" + name);

            // Crée la base si elle n'existe pas, la vide sinon
            string databaseFullPath = baseFolder + "database\\" + databaseName + ".sqlite";
            if (!File.Exists(databaseFullPath))
            {
                SQLiteConnection.CreateFile(databaseFullPath);
            }
            else
            {
                using (SQLiteConnection db = Connect())
                {
                    db.Open();

                    sql = "DROP TABLE IF EXISTS 'files'; DROP TABLE IF EXISTS 'folders'; DROP TABLE IF EXISTS 'types';";
                    new SQLiteCommand(sql, db).ExecuteNonQuery();
                }
            }

            using (SQLiteConnection db = Connect())
            {
                db.Open();

                // Structure

                sql = "CREATE TABLE folders ( " +
                    "idFolder INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "idParentFolder INTEGER REFERENCES folders(idFolder), " +
                    "title TEXT NOT NULL " +
                    ");";
                new SQLiteCommand(sql, db).ExecuteNonQuery();

                sql = "CREATE TABLE types ( " +
                    "idType INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "title STRING  NOT NULL " +
                    ");";

                new SQLiteCommand(sql, db).ExecuteNonQuery();

                sql = "CREATE TABLE files ( " +
                    "idFile INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "idFolder INTEGER NOT NULL REFERENCES folders (idFolder), " +
                    "idType INTEGER NOT NULL REFERENCES types (idType)," +
                    "hash TEXT NOT NULL, " +
                    "originalname TEXT NOT NULL, " +
                    "size INTEGER NOT NULL, " +
                    "title TEXT, " +
                    "pages INTEGER, " +
                    "version INTEGER NOT NULL DEFAULT 1" +
                    ");";
                new SQLiteCommand(sql, db).ExecuteNonQuery();

                // Données

                sql = "INSERT INTO folders (title) VALUES ('" + databaseName + "');";
                new SQLiteCommand(sql, db).ExecuteNonQuery();

                sql = "INSERT INTO types (title) VALUES  ('PDF'), ('Image'), ('Office');";
                new SQLiteCommand(sql, db).ExecuteNonQuery();
            }

            Program.configuration.values.database = databaseName;
            Program.configuration.Save();
        }

        public SQLiteConnection Connect()
        {
            return new SQLiteConnection("Data Source=" + baseFolder + "database\\" + name + ".sqlite" + ";Version=3;");
        }

    }

}
