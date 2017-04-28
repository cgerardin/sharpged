using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SharpGED_lib
{
    [Serializable]
    public class GedFile
    {

        public string hash { get; set; }
        public string originalname { get; set; }
        public int size { get; set; }
        public string title { get; set; }
        public byte[] bytes { get; set; }
        public int pages { get; set; }

        public byte[] Save()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            try
            {
                formatter.Serialize(stream, this);
                stream.Flush();
            }
            finally
            {
                if (stream != null) stream.Close();
            }
            return stream.ToArray();
        }

        public static GedFile Load(MemoryStream stream)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                return (GedFile)formatter.Deserialize(stream);
            }
            catch(SerializationException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return default(GedFile);
            }
            finally
            {
                if (stream != null) stream.Close();
            }
        }

    }
}
