using System;

namespace SharpGED_lib
{
    [Serializable]
    public class GedFile : GedItem
    {
        public enum GedFileType : long { Unknown = 0, PDF = 1, Image = 2, Office = 3 };

        public GedFileType type { get; set; }
        public string hash { get; set; }
        public string originalname { get; set; }
        public int size { get; set; }
        public string title { get; set; }
        public int pages { get; set; }
        public int version { get; set; } = 1;

        public string TypeName()
        {
            return TypeName(type);
        }

        public static string TypeName(GedFileType type)
        {
            switch (type)
            {
                case GedFileType.PDF:

                    return "Document PDF";

                case GedFileType.Image:

                    return "Fichier image";

                case GedFileType.Office:

                    return "Document bureautique";

                default:

                    return "Inconnu";
            }
        }

    }
}
