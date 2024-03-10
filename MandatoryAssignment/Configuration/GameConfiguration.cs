using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MandatoryAssignment.Configuration
{
    public class GameConfiguration
    {
        #region Singleton
        /// <summary>
        /// Her laves en singleton af GameConfiguration.
        /// Det er nyttigt, da vi kun skal bruge en instans af klassen, og vi kan derfor sikre os, at der kun er en instans
        /// </summary>

        private static GameConfiguration _instance = new GameConfiguration();
        public static GameConfiguration Instance
        {
            get
            {
                return _instance;
            }
        }

        #endregion End Singleton


        #region Properties to configure the game
        public string GameName { get; set; }
        public string Password { get; set; }
        public SourceLevels SourceLevels { get; set; }
        public string LogFilePath { get; set; }

        #endregion End Properties to configure the game


    }
}
