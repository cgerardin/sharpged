using System;

namespace SharpGED_lib_core
{
    [Serializable]
    public class RemoteGedFile : GedFile
    {

        public long folderId { get; set; }
        public byte[] bytes { get; set; }

    }
}
