using MandatoryAssignment.Interfaces;
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
        /// Her we have a singleton of GameConfiguration.
        /// It is important to have a singleton, because we only need one instance of the class, and we can therefore ensure that there is only one instance
        /// </summary>
        private static GameConfiguration _instance = new GameConfiguration(); //eager loading
        //private static GameConfiguration _instance; // used for Lazy loading

        /// <summary>
        /// This method is used to get the instance of the class.
        /// This object reference is used to get the instance of the class.
        /// This used to call _instance of the class Line 18. 
        /// </summary>
        public static GameConfiguration Instance //for Lazy loading we can add parameter to the method
        {
            get
            {
                //if(_instance == null)
                //{
                //    _instance = new GameConfiguration(); //Lazy loading
                //}
                return _instance;
            }
        }
        #endregion End Singleton

        /// <summary>
        /// Default constructor
        /// This should be private, so that it can only be called from within the class.
        /// </summary>
        private GameConfiguration()
        {
            //Her sættes default værdier for spillet
            //MaxX = 100;
            //MaxY = 100;
            Position = new Position(100, 100);
            WorldName = "DefaultWorld";
            SourceLevels = SourceLevels.All;
            LogFilePath = "TraceGame.xml";

        }


        //private const string _filePath = "Confiq2D_Spil";
        //private string getPath = Environment.GetEnvironmentVariable(_filePath);
        #region Properties to configure the game
        //public int MaxX { get; set; }
        //public int MaxY { get; set; }

        public Position Position { get; set; }
        public string WorldName { get; set; }
        /// <summary>
        /// This property is used to log the XML file for the game if it is true then create Xmlfile .
        /// </summary>
        public bool LogXML { get; set; }
        /// <summary>
        /// This property is used to log the console for the game if it is true then log to the console.
        /// </summary>
        public bool LogConsole { get; set; }
        public SourceLevels SourceLevels { get; set; }
        public string LogFilePath { get; set; }

        #endregion End Properties to configure the game

        /// <summary>
        /// This method is used to get the configuration of the game.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException">Throw exception en case if there is no file found</exception>
        public static GameConfiguration GetConfiguration()
        {
            XmlDocument xd = new XmlDocument();
            if(LoggingPath.Path == null || LoggingPath.Path == string.Empty || !File.Exists(LoggingPath.Path))
            {
                throw new FileNotFoundException("File not found", LoggingPath.Path);
            }
            xd.Load(LoggingPath.Path);

            if(!File.Exists(LoggingPath.Path))
            {
                throw new FileNotFoundException("File not found", LoggingPath.Path);
            }
            XmlNode? xmlNode = xd.DocumentElement.SelectSingleNode("MaxX");

            if (xmlNode != null)
            {
                Instance.Position.Y = int.Parse(xmlNode.InnerText);
            }

            xmlNode = xd.DocumentElement.SelectSingleNode("MaxY");
            if (xmlNode != null)
            {
                Instance.Position.Y = int.Parse(xmlNode.InnerText);
            }
            xmlNode = xd.DocumentElement.SelectSingleNode("WorldName");
            if (xmlNode != null)
            {
                Instance.WorldName = xmlNode.InnerText;
            }
            xmlNode = xd.DocumentElement.SelectSingleNode("SourceLevels");
            if (xmlNode != null)
            {
                Instance.SourceLevels = (SourceLevels)Enum.Parse(typeof(SourceLevels), xmlNode.InnerText);
            }
            return Instance;
        }

    


    }
}
