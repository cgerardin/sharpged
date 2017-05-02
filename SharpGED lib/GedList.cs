using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SharpGED_lib
{
    [Serializable]
    public class GedList<GedFile> : List<GedFile>
    {

        public byte[] bytes { get; set; }

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

        public static GedList<GedFile> Load(MemoryStream stream)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                return (GedList<GedFile>)formatter.Deserialize(stream);
            }
            catch (SerializationException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return default(GedList<GedFile>);
            }
            finally
            {
                if (stream != null) stream.Close();
            }
        }

    }
}
