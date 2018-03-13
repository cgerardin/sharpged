using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SharpGED_lib_core
{
    [Serializable]
    public class GedList<T> : List<T> where T : GedItem
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

        public static GedList<T> Load(MemoryStream stream)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                return (GedList<T>)formatter.Deserialize(stream);
            }
            catch (SerializationException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return default(GedList<T>);
            }
            finally
            {
                if (stream != null) stream.Close();
            }
        }

    }
}
