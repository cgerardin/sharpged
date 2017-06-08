using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SharpGED_server.Managers
{

    class ConfigurationManager
    {

        private string configurationFile;
        public bool exist { get; set; }
        public Configuration values { get; set; }

        public ConfigurationManager()
        {
            configurationFile = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\SharpGED\\config.dat";
            exist = File.Exists(configurationFile);
        }

        public void Save()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            if (exist)
            {
                File.Delete(configurationFile);
            }
            else
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\SharpGED");
            }
            FileStream stream = new FileStream(configurationFile, FileMode.Create, FileAccess.Write);
            try
            {
                formatter.Serialize(stream, values);
                stream.Flush();
            }
            catch (SerializationException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (stream != null) stream.Close();
            }
            return;
        }

        public void Load()
        {
            if (exist)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(configurationFile, FileMode.Open, FileAccess.Read);
                try
                {
                    values = (Configuration)formatter.Deserialize(stream);
                }
                catch (SerializationException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    values = default(Configuration);
                }
                finally
                {
                    if (stream != null) stream.Close();
                }
            }
            else
            {
                values = new Configuration()
                {
                    listenIP = "localhost",
                    listenPort = 9090,
                    baseFolder = "C:\\SharpGED\\",
                    database = "Base par défaut"
                };
            }
        }

    }
}
