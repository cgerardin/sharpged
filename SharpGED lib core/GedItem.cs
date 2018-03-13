using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SharpGED_lib_core
{
    [Serializable]
    public class GedItem
    {

        public byte[] Save()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            try
            {
                formatter.Serialize(stream, this);
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
            return stream.ToArray();
        }

        public static GedItem Load(MemoryStream stream)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                return (GedItem)formatter.Deserialize(stream);
            }
            catch (SerializationException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return default(GedItem);
            }
            finally
            {
                if (stream != null) stream.Close();
            }
        }

    }
}
