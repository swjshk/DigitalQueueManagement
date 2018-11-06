using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueClass
{
    public class CheckSheet
    {
        public string Question1Result { get; set; }
        public string Question2Result { get; set; }
        public string Question3Result { get; set; }
        public string CheckSheetResult { get; set; }
        public string Impact { get; set; }
        public string SolutionUpdates { get; set; }
        public string Q1Issue { get; set; }
        public string Q2Issue { get; set; }
        public string Q3Issue { get; set; }
        private string _Issue;

        public string Issue
        {
            get
            {
                _Issue = "";
                if (Question1Result=="No")
                {
                    _Issue += Q1Issue+"; ";
                }
                if (Question2Result == "No")
                {
                    _Issue += Q2Issue + "; ";
                }
                if (Question3Result == "No")
                {
                    _Issue += Q3Issue + "; ";
                }
                return _Issue;
            }

        }




    }
}
