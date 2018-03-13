using System;

namespace SharpGED_server_core
{
    [Serializable]
    class Configuration
    {

        public string listenIP { get; set; }
        public int listenPort { get; set; }
        public string baseFolder { get; set; }
        public string database { get; set; }

    }
}
