using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ImageManagement
{
    public class ErrorManager
    {
        private static ErrorManager __instance;
        private const string __errorLogPath = "errorLog.txt";

        private ErrorManager()
        {
        }

        public static string ErrorLogFile
        {
            get
            {
                return __errorLogPath;
            }
        }

        public static ErrorManager Instance()
        {
            if (__instance == null)
            {
                __instance = new ErrorManager();
            }

            return __instance;
        }

        public void Publish(string msg)
        {
            using (StreamWriter sw = new StreamWriter(__errorLogPath, true))
            {
                sw.WriteLine(DateTime.Now.ToString());
                sw.WriteLine(msg);
                sw.WriteLine();
                sw.WriteLine();
            }
        }
    }
}
