using System;

namespace SharpGED_lib
{
    [Serializable]
    public class GedFile
    {

        public string hash { get; set; }
        public string originalname { get; set; }
        public int size { get; set; }
        public string title { get; set; }
        public int pages { get; set; }

    }
}
