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
        public List<MySection> sections = new List<MySection>();
      
        public void AddSection()
        { 
            MySection qsection1 = new MySection
            {
                JobNumber = "41586003-001",
                SectionNumber = "2",
                JobName = "Texas Instruments Lewisville",
                Location = "C1",
                CCStatus = "green",
                ArrivalTime = new DateTime(2018, 10, 28, 10, 1, 32, DateTimeKind.Local),
                CCSheet = new CheckSheet
                {
                    Question1Result = true,
                    Question2Result = true,
                    Question3Result = false,
                    CheckSheetResult = false,
                    Impact = "Low",
                    Q3Issue = "symmetry barrier",
                    SolutionUpdates = "breaker rework ETA 2hrs"

                }
            };
            MySection qsection2 = new MySection
            {
                JobNumber = "40838431-001",
                SectionNumber = "1",
                JobName = "ETHICON",
                Location = "A1",
                CCStatus = "Yellow",
                ArrivalTime = new DateTime(2018, 10, 29, 13, 30, 52),
                CCSheet = new CheckSheet
                {
                    Question1Result = true,
                    Question2Result = true,
                    Question3Result = false,
                    CheckSheetResult = false,
                    Impact = "High",
                    Q3Issue = "Missing Kit cart",
                    SolutionUpdates = "parts shortage 10pm"

                }
            };
            MySection qsection3 = new MySection
            {
                JobNumber = "40009165-001",
                SectionNumber = "4",
                JobName = "BASF SUB C",
                Location = "C3",
                CCStatus = "green",
                ArrivalTime = new DateTime(2018, 10, 29, 7, 30, 56),
                CCSheet = new CheckSheet
                {
                    Question1Result = true,
                    Question2Result = true,
                    Question3Result = true,
                    CheckSheetResult = true,
                    Impact = "Low",
                    SolutionUpdates = "Good"

                }
            };
            MySection qsection4 = new MySection
            {
                JobNumber = "41385019-003",
                SectionNumber = "2",
                JobName = "Warner Bros Tour Center",
                Location = "B2",
                CCStatus = "Low",
                ArrivalTime = new DateTime(2018, 10, 28, 8, 30, 52),
                CCSheet = new CheckSheet
                {
                    Question1Result = true,
                    Question2Result = true,
                    Question3Result = true,
                    CheckSheetResult = true,
                    Impact = "Low",
                    SolutionUpdates = "Good"

                }
            };
            MySection qsection5 = new MySection
            {
                JobNumber = "41385019-003",
                SectionNumber = "2",
                JobName = "Warner Bros Tour Center",
                Location = "B2",
                CCStatus = "Low",
                ArrivalTime = new DateTime(2018, 10, 28, 8, 30, 52),
                CCSheet = new CheckSheet
                {
                    Question1Result = true,
                    Question2Result = true,
                    Question3Result = true,
                    CheckSheetResult = true,
                    Impact = "Low",
                    SolutionUpdates = "Good"

                }
            };
            MySection qsection6 = new MySection
            {
                JobNumber = "41385019-003",
                SectionNumber = "2",
                JobName = "Warner Bros Tour Center",
                Location = "B2",
                CCStatus = "green",
                ArrivalTime = new DateTime(2018, 10, 28, 8, 30, 52),
                CCSheet = new CheckSheet
                {
                    Question1Result = true,
                    Question2Result = true,
                    Question3Result = true,
                    CheckSheetResult = true,
                    Impact = "Low",
                    SolutionUpdates = "Good"

                }
            };
            MySection qsection7 = new MySection
            {
                JobNumber = "41385019-003",
                SectionNumber = "2",
                JobName = "Warner Bros Tour Center",
                Location = "B2",
                CCStatus = "green",
                ArrivalTime = new DateTime(2018, 10, 28, 8, 30, 52),
                CCSheet = new CheckSheet
                {
                    Question1Result = true,
                    Question2Result = true,
                    Question3Result = true,
                    CheckSheetResult = true,
                    Impact = "Low",
                    SolutionUpdates = "Good"

                }
            };
            MySection qsection8 = new MySection
            {
                JobNumber = "41385019-003",
                SectionNumber = "2",
                JobName = "Warner Bros Tour Center",
                Location = "B2",
                CCStatus = "green",
                ArrivalTime = new DateTime(2018, 10, 28, 8, 30, 52),
                CCSheet = new CheckSheet
                {
                    Question1Result = true,
                    Question2Result = true,
                    Question3Result = true,
                    CheckSheetResult = true,
                    Impact = "Low",
                    SolutionUpdates = "Good"

                }
            };
            MySection qsection9 = new MySection
            {
                JobNumber = "41385019-003",
                SectionNumber = "2",
                JobName = "Warner Bros Tour Center",
                Location = "B2",
                CCStatus = "green",
                ArrivalTime = new DateTime(2018, 10, 28, 8, 30, 52),
                CCSheet = new CheckSheet
                {
                    Question1Result = true,
                    Question2Result = true,
                    Question3Result = true,
                    CheckSheetResult = true,
                    Impact = "Low",
                    SolutionUpdates = "Good"

                }
            };
            MySection qsection10 = new MySection
            {
                JobNumber = "41385019-003",
                SectionNumber = "2",
                JobName = "Warner Bros Tour Center",
                Location = "B2",
                CCStatus = "green",
                ArrivalTime = new DateTime(2018, 10, 28, 8, 30, 52),
                CCSheet = new CheckSheet
                {
                    Question1Result = true,
                    Question2Result = true,
                    Question3Result = true,
                    CheckSheetResult = true,
                    Impact = "Low",
                    SolutionUpdates = "Good"

                }
            };
            MySection qsection11 = new MySection
            {
                JobNumber = "41385019-003",
                SectionNumber = "2",
                JobName = "Warner Bros Tour Center",
                Location = "B2",
                CCStatus = "green",
                ArrivalTime = new DateTime(2018, 10, 28, 8, 30, 52),
                CCSheet = new CheckSheet
                {
                    Question1Result = true,
                    Question2Result = true,
                    Question3Result = true,
                    CheckSheetResult = true,
                    Impact = "Low",
                    SolutionUpdates = "Good"

                }
            };

            MySection qsection12 = new MySection
            {
                JobNumber = "41385019-003",
                SectionNumber = "2",
                JobName = "Warner Bros Tour Center",
                Location = "B2",
                CCStatus = "green",
                ArrivalTime = new DateTime(2018, 10, 28, 8, 30, 52),
                CCSheet = new CheckSheet
                {
                    Question1Result = true,
                    Question2Result = true,
                    Question3Result = true,
                    CheckSheetResult = true,
                    Impact = "Low",
                    SolutionUpdates = "Good"

                }
            };

            sections.Add(qsection1);
            sections.Add(qsection2);
            sections.Add(qsection3);
            sections.Add(qsection4);
            sections.Add(qsection5);
            sections.Add(qsection6);
            sections.Add(qsection7);
            sections.Add(qsection8);
            sections.Add(qsection9);
            sections.Add(qsection10);
            sections.Add(qsection11);
            sections.Add(qsection12);









        }


    }
}
