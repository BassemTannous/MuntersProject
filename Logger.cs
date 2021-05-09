using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munters
{
    class Logger
    {
        public static string Log(string stringFormat, params object[] objects)
        {
            return Log(string.Format(stringFormat, objects));
        }
        public static string Log(string message)
        {
            System.Console.Out.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.ff") + ": " + message);
            return DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.ff") + ": " + message;
        }

        public static void WriteToDebug(string line, string filename = "debug")
        {
            //Check if Log directory exists, if not create it.
            if (!Directory.Exists(Repository.LOG))
            {
                Directory.CreateDirectory(Repository.LOG);
            }

            filename = Repository.LOG + filename + DateTime.Now.ToString("YYYMMDD") + ".log";

            using (StreamWriter w = File.AppendText(filename))
            {
                w.WriteLine(line);
                w.Close();
            }
        }

    }

}
