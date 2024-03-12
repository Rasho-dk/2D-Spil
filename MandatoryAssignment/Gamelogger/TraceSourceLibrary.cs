using MandatoryAssignment.Configuration;
using System.Diagnostics;

namespace MandatoryAssignment.Gamelogger
{
    public class TraceSourceLibrary
    {
        /// <summary>
        /// This class is a singleton class, which means that there can only be one instance of the class.
        /// </summary>
        private static TraceSourceLibrary _instance = new TraceSourceLibrary();
        /// <summary>
        /// This object is used to lock the class, so that only one instance of the class can be created at a time.
        /// </summary>
        private static readonly object _lock = new object();

        //private GameConfiguration GameConfiguration { get; set; }

        /// <summary>
        /// This object is used to create a trace source, which is used to log events in the game.
        /// </summary>
        private TraceSource traceSource;

        /// <summary>
        /// This method is used to get the instance of the class.
        /// Using the lock object, we can ensure that only one instance of the class is created at a time.
        /// Which is important to ensure thread safety.
        /// </summary>
        public static TraceSourceLibrary Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new TraceSourceLibrary();
                    }
                    return _instance;
                }
            }
        }
        /// <summary>
        /// This is the constructor of the class, which is private, so that it can only be called from within the class. 
        /// This it is a default constructor, which is used to create a trace source object.
        /// </summary>
        private TraceSourceLibrary()
        {
            traceSource = new TraceSource(GameConfiguration.Instance.WorldName);

            traceSource.Switch = new SourceSwitch(GameConfiguration.Instance.WorldName,
                "All");
            if (GameConfiguration.Instance.LogXML)
            {
                Reload();
                //traceSource.Listeners.Add(new XmlWriterTraceListener(GameConfiguration.Instance.WorldName + "Game.xml"));
                
            }
            if(GameConfiguration.Instance.LogConsole)
            {
                traceSource.Listeners.Add(new ConsoleTraceListener());
            }

        }
        /// <summary>
        /// This method is used to reload the trace source, which is used to log events in the game.
        /// </summary>
        private void Reload()
        {
            //traceSource.Close();
            traceSource = new TraceSource(GameConfiguration.Instance.WorldName, SourceLevels.All);

            traceSource.Switch = new SourceSwitch(GameConfiguration.Instance.WorldName + "switch", SourceLevels.All.ToString());

            if (GameConfiguration.Instance.LogXML)
            {
                string path = LoggingPath.LogPath;
                path = path +  "\\Game.xml";
                //traceSource.Listeners.Add(new XmlWriterTraceListener(new StreamWriter(path,true) { AutoFlush = true }));
                traceSource.Listeners.Add(new XmlWriterTraceListener(new StreamWriter(path) { AutoFlush = true }));
            }
        }
        /// <summary>
        /// This method is used to log events in the game.
        /// </summary> 
        /// <param name="eventType">Let the use choose the type of event to log</param>
        /// <param name="id">The id of the event</param> 
        /// <param name="message">The message to log</param> 
        public static void LogEvent(TraceEventType eventType, int id, string message)
        {
            _instance.traceSource.TraceEvent(eventType, id, message);
        }

        /// <summary>
        /// This method is used to log information in the game.
        /// </summary>
        /// <param name="id">The id of the event</param>
        /// <param name="message">The message to log</param>
        public static void LogInformation(int id, string message)
        {
            _instance.traceSource.TraceEvent(TraceEventType.Information, id, message);
        }
    }

}