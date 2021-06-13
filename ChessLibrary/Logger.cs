using System;
using System.Collections.Generic;

namespace ChessLibrary
{
    public class Logger
    {
        public List<string> logList = new List<string>();
        /// <summary>
        /// make log of the event
        /// </summary>
        /// <param name="info">string to log</param>
        public void MakeLog(string info)
        {
         logList.Add(info);   
        }
    }
}