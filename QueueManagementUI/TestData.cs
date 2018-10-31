using QueueClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QueueManagementUI
{
    public class TestData
    {
        public List<QSection> sections = new List<QSection>();
      
        public void AddSection()
        { 
            QSection qsection1 = new QSection
            {
                JobNumber = "40838431001",
                SectionNumber = "1",
                JobName = "ETHICON",
                Location = "A1",
                CCStatus = "green",
                ArrivalTime = new DateTime(2018, 10, 28, 8, 30, 52, DateTimeKind.Local),
                CCSheet = new CheckSheet
                {
                    Question1Result = true,
                    Question2Result = true,
                    Question3Result = true,
                    CheckSheetResult = true,
                    Impact = false,
                    SolutionUpdates = "You invoke the DateTime structure's implicit default constructor when you wan"

                }
            };
            QSection qsection2 = new QSection
            {
                JobNumber = "40838431001",
                SectionNumber = "1",
                JobName = "ETHICON",
                Location = "A1",
                CCStatus = "green",
                ArrivalTime = new DateTime(2018, 10, 28, 8, 30, 52),
                CCSheet = new CheckSheet
                {
                    Question1Result = true,
                    Question2Result = true,
                    Question3Result = true,
                    CheckSheetResult = true,
                    Impact = false,
                    SolutionUpdates = "Good to Go!"

                }
            };
            QSection qsection3 = new QSection
            {
                JobNumber = "40838431001",
                SectionNumber = "1",
                JobName = "ETHICON",
                Location = "A1",
                CCStatus = "green",
                ArrivalTime = new DateTime(2018, 10, 28, 8, 30, 52),
                CCSheet = new CheckSheet
                {
                    Question1Result = true,
                    Question2Result = true,
                    Question3Result = true,
                    CheckSheetResult = true,
                    Impact = false,
                    SolutionUpdates = "Good to Go!"

                }
            };
            QSection qsection4 = new QSection
            {
                JobNumber = "40838431001",
                SectionNumber = "1",
                JobName = "ETHICON",
                Location = "A1",
                CCStatus = "green",
                ArrivalTime = new DateTime(2018, 10, 28, 8, 30, 52),
                CCSheet = new CheckSheet
                {
                    Question1Result = true,
                    Question2Result = true,
                    Question3Result = true,
                    CheckSheetResult = true,
                    Impact = false,
                    SolutionUpdates = "Good to Go!"

                }
            };

            sections.Add(qsection1);
            sections.Add(qsection2);
            sections.Add(qsection3);
            sections.Add(qsection4);

        }


    }
}
