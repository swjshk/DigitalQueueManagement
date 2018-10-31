using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueClass
{
    public class MySection
    {
        public string JobNumber { get; set; }
        public string SectionNumber { get; set; }
        public string JobName { get; set; }
        public string Location { get; set; }
        public string CCStatus { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public CheckSheet CCSheet { get; set; }
        public TimeSpan WaitTime //Calculate the WaitTime
        {
            get
            {
                if (DepartureTime == new DateTime(2039, 12, 31, 0, 0, 0))
                {
                    return DateTime.Now.Subtract(ArrivalTime);
                }
                else
                {
                    return DepartureTime.Subtract(ArrivalTime);
                }
            }

        }

        public MySection() //Constructor to intialize the property
        {
            DepartureTime = new DateTime(2039, 12, 31, 0, 0, 0);
            CCSheet = new CheckSheet();
        }
    
    }
}
