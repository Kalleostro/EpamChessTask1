using System;
using System.Collections.Generic;

namespace ChessLibrary
{
    public class Logger
    {
        public List<string> logList = new List<string>();
        public void MakeLog(string info)
        {
         logList.Add(info);   
        }
    }
}