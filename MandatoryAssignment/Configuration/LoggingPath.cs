using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryAssignment.Configuration
{
    public static class LoggingPath
    {
        /*
         * This class is used to get the path for the log file and the configuration file.
         */
        private const string? _filePath = "Confiq2D_Spil";
        public static string? Path { get; set; } = Environment.GetEnvironmentVariable(_filePath);

        private const string? _logPath = "LogPath2DSpil";
        public static string? LogPath { get; set; } = Environment.GetEnvironmentVariable(_logPath);

    }
}
