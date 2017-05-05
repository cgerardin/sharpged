using System;

namespace SharpGED_lib
{
    [Serializable]
    public class GedFolder : GedItem
    {

        public string title { get; set; }
        public GedList<GedFolder> folders { get; set; }
        public GedList<GedFile> files { get; set; }

    }
}
