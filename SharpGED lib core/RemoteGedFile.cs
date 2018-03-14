using System;

namespace SharpGED_lib
{
    [Serializable]
    public class RemoteGedFile : GedFile
    {

        public long folderId { get; set; }
        public byte[] bytes { get; set; }

    }
}
