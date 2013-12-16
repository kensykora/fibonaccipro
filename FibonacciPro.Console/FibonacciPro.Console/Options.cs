﻿using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciPro.ConsoleApplication
{
    /// <summary>
    /// Options to be passed into the application from the command line
    /// </summary>
    class Options
    {
        [Option('n', "interactive", HelpText = "Enables interactive mode where the user will be prompted for input values.")]
        protected bool InteractiveMode
        {
            get;
            set;
        }

        /// <summary>
        /// Handles special exceptions to override Interactive mode argument.
        /// </summary>
        /// <returns></returns>
        public bool UseInteractiveMode()
        {
            if (InteractiveMode && !string.IsNullOrWhiteSpace(InputFile))
                //Interactive mode was indicated, but an input file was passed
                return false;
            else if (!InteractiveMode && string.IsNullOrWhiteSpace(InputFile))
                //InteractiveMode was not indicated, but no input file was passed
                return true;

            return InteractiveMode;
        }

        [Option('i',"in", HelpText="File path to input file. XML or plain text accepted.")]
        public string InputFile { get; set; }

        public enum FileType { Undefined, PlainText, Xml }

        [Option('o',"out",HelpText="File path to output file. Files ending in .xml will be an XML format.")]
        public string OutputFile { get; set; }

        public FileType OutputFileType
        {
            get;
            set;
        }

        public FileType InputFileType { get; set; }

        public int InputNumber { get; set; }

        [HelpOption]
        public string GetUsage() {
            return HelpText.AutoBuild(this, (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
