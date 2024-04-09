using MandatoryAssignment.Configuration;
using System.Diagnostics;

namespace MandatoryAssignment.Gamelogger
{
    public class TraceSourceLibrary
    {
        #region Singleton
        /// This class is a singleton class, which means that there can only be one instance of the class.
        /// </summary>
        private static TraceSourceLibrary _instance = new TraceSourceLibrary(); //step 1
        /// This object is used to lock the class, so that only one instance of the class can be created at a time. Used for thread safety.
        private static readonly object _lock = new object();


        //private GameConfiguration GameConfiguration { get; set; }

        /// This object is used to create a trace source, which is used to log events in the game.
        private TraceSource traceSource;

        /// <summary>
        /// This method is used to get the instance of the class.
        /// As we can see, the class is a singleton class, which means that there can only be one instance of the class. 
        /// And its lazy loaded, whichh means that the instance is only created when it is needed.
        /// Using the lock object, we can ensure that only one instance of the class is created at a time.
        /// Which is important to ensure thread safety.
        /// </summary>
        public static TraceSourceLibrary Instance //step 2
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new TraceSourceLibrary(); //lazy loading mean that the instance is only created when it is needed
                    }
                    return _instance;
                }
            }
        }
        /// <summary>
        /// This is the constructor of the class, which is private, so that it can only be called from within the class. 
        /// This it is a default constructor, which is used to create a trace source object.
        /// </summary>
        private TraceSourceLibrary()  //step 3
        {

            if (traceSource == null)
            {
                ReloadError();
            }
            if (GameConfiguration.Instance.LogXML)
            {
                Reload();                
            }
            if(GameConfiguration.Instance.LogConsole)
            {
                traceSource.Listeners.Add(new ConsoleTraceListener());
            }

        }
        #endregion End Singleton
        
         
        private void ReloadError()
        {

            traceSource = new TraceSource("Confiq not found Path", SourceLevels.All);
            traceSource.Switch = new SourceSwitch("Erro Confiq", SourceLevels.All.ToString());

            string path = LoggingPath.LogPath;
            path = path + "\\ErrorConfiq.xml";
            traceSource.Listeners.Add(new XmlWriterTraceListener(new StreamWriter(path) { AutoFlush = true }));
            traceSource.Listeners.Add(new ConsoleTraceListener());


        }
        /// <summary>
        /// This method is used to reload the trace source, which is used to log events in the game.
        /// </summary>
        private void Reload()
        {
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
        /// This method is used to different log events in the game.
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