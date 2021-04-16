using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Serialization;

namespace BN_Primitive_Launcher.Classes
{
    [Serializable]
    public class Settings
    {
        public bool savedBoxState = true;

        public bool modsBoxState = true;

        public bool soundBoxState = true;

        public bool fontBoxState = true;

        public bool configBoxState = true;

        public bool templateBoxState = true;

        public bool memorialBoxState = true;

        public bool graveyardBoxState = true;

        public bool backupBoxState = true;

        public bool kenanBoxState = true;

        public string textboxState = "";

        public string gamebuildState = "";
    }
}
