using System;

namespace SharpGED_lib_core
{
    [Serializable]
    public class GedFolder : GedItem
    {

        public long id { get; set; }
        public object idParent { get; set; }
        public string title { get; set; }
        public GedList<GedFolder> folders { get; set; }
        public GedList<GedFile> files { get; set; }

        public GedFolder()
        {
            folders = new GedList<GedFolder>();
            files = new GedList<GedFile>();
        }

        public static void AddChild(GedFolder parent, GedFolder child)
        {

            if (parent.id == (long)child.idParent)
            {
                parent.folders.Add(child);
            }
            else
            {
                foreach (GedFolder subFolder in parent.folders)
                {
                    if (subFolder.id == (long)child.idParent)
                    {
                        subFolder.folders.Add(child);
                    }
                    else if (subFolder.folders.Count > 0)
                    {
                        foreach (GedFolder subSubFolder in subFolder.folders)
                        {
                            AddChild(subSubFolder, child);
                        }
                    }
                }
            }
        }

    }
}
