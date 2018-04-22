﻿using System;
using System.Linq;
using System.IO;

namespace LoggingKata
{
    class Program
    {
        //Why do you think we use ILog?
        static readonly ILog Logger = new TacoLogger();
        const string CsvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            Logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(CsvPath);

            Logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();


            var locations = lines.Select(parser.Parse);
            for ()
            {

            }
            // TODO:  Find the two TacoBells in Alabama that are the furthurest from one another.
            // HINT:  You'll need two nested forloops
        }
    }
}