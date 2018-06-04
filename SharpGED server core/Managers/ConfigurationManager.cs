using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace SharpGED_server_core
{

    class ConfigurationManager
    {

        private string configurationFile;
        public bool exist { get; set; }
        public Configuration values { get; set; }

        public ConfigurationManager()
        {
            configurationFile = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\SharpGED\\config.json";
            exist = File.Exists(configurationFile);
        }

        public void Save()
        {
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
                byte[] json = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(values));
                stream.Write(json, 0, json.Length);
                stream.Flush();
            }
            catch (JsonSerializationException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                //@TODO : Throws new ConfigurationManagerException...
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
                FileStream stream = new FileStream(configurationFile, FileMode.Open, FileAccess.Read);
                try
                {
                    string json = new StreamReader(stream).ReadToEnd();
                    values = JsonConvert.DeserializeObject<Configuration>(json);
                }
                catch (JsonSerializationException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    //@TODO : Throws new ConfigurationManagerException...
                    values = default(Configuration);
                }
                finally
                {
                    if (stream != null) stream.Close();
                }
            }
            else
            {
                values = new Configuration();
            }
        }

    }
}
