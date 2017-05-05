using System;

namespace SharpGED_lib
{
    [Serializable]
    public class RemoteGedFile : GedFile
    {
        public byte[] bytes { get; set; }

    }
}
