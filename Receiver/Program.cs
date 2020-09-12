﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Receiver
{
    class Program
    {
        private static Timer aTimer;
        static void Main(string[] args)
        {
            aTimer = new System.Timers.Timer();
            aTimer.Interval = 2000;

            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;

            // Have the timer fire repeated events (true is the default)
            aTimer.AutoReset = true;

            // Start the timer
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            ConsoleReader consoleReader = new ConsoleReader();
            DataRecord dataRecord = consoleReader.ReadConsole();
            IAlerter alerter = new EmailAlerter();
            Checker checker = new Checker(alerter);
            checker.Check(dataRecord);
        }
    }
}
