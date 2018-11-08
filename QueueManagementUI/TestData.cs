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
                ArrivalTime = new DateTime(2018, 11, 07, 1, 1, 32, DateTimeKind.Local),
                CCSheet = new CheckSheet
                {
                    Question1Result = "Yes",
                    Question2Result = "Yes",
                    Question3Result = "No",
                    CheckSheetResult = "Fail",
                    Impact = "Low",
                    Q3Issue = "Missing kit cart",
                    SolutionUpdates = "breaker rework ETA 2hrs"

                }
            };
            MySection qsection2 = new MySection
            {
                JobNumber = "40838431-001",
                SectionNumber = "1",
                JobName = "ETHICON",
                Location = "A1",
                ArrivalTime = new DateTime(2018, 11, 07, 2, 30, 52),
                CCSheet = new CheckSheet
                {
                    Question1Result = "Yes",
                    Question2Result = "Yes",
                    Question3Result = "No",
                    CheckSheetResult = "Fail",
                    Impact = "Low",
                    Q3Issue = "Missing kit cart",
                    SolutionUpdates = "team lead to sign off"

                }
            };
            MySection qsection3 = new MySection
            {
                JobNumber = "40009165-001",
                SectionNumber = "4",
                JobName = "BASF SUB C",
                Location = "C3",
                ArrivalTime = new DateTime(2018, 11, 07, 4, 30, 56),
                CCSheet = new CheckSheet
                {
                    Question1Result = "Yes",
                    Question2Result = "Yes",
                    Question3Result = "Yes",
                    CheckSheetResult = "Pass",
                    Impact = "Low",
                    SolutionUpdates = "Good"

                }
            };
            MySection qsection4 = new MySection
            {
                JobNumber = "41385019-003",
                SectionNumber = "1",
                JobName = "Warner Bros Tour Center",
                Location = "B2",
                ArrivalTime = new DateTime(2018, 11, 07, 5, 30, 52),
                CCSheet = new CheckSheet
                {
                    Question1Result = "Yes",
                    Question2Result = "Yes",
                    Question3Result = "Yes",
                    CheckSheetResult = "Pass",
                    Impact = "Low",
                    SolutionUpdates = "Good"

                }
            };
            MySection qsection5 = new MySection
            {
                JobNumber = "41385019-003",
                SectionNumber = "2",
                JobName = "Warner Bros Tour Center",
                Location = "A2",
                ArrivalTime = new DateTime(2018, 11, 07, 6, 30, 52),
                CCSheet = new CheckSheet
                {
                    Question1Result = "Yes",
                    Question2Result = "Yes",
                    Question3Result = "No",
                    CheckSheetResult = "Fail",
                    Impact = "High",
                    Q3Issue = "Missing kit cart",
                    SolutionUpdates = "parts shortage 10pm"

                }
            };
            MySection qsection6 = new MySection
            {
                JobNumber = "41385019-003",
                SectionNumber = "3",
                JobName = "Warner Bros Tour Center",
                Location = "B2",
                ArrivalTime = new DateTime(2018, 11, 06, 6, 30, 52),
                CCSheet = new CheckSheet
                {
                    Question1Result = "Yes",
                    Question2Result = "Yes",
                    Question3Result = "No",
                    CheckSheetResult = "Fail",
                    Impact = "High",
                    Q3Issue = "Missing kit cart",
                    SolutionUpdates = "parts shortage 10pm"

                }
            };
            MySection qsection7 = new MySection
            {
                JobNumber = "41385019-003",
                SectionNumber = "4",
                JobName = "Warner Bros Tour Center",
                Location = "E2",
                ArrivalTime = new DateTime(2018, 11, 06, 6, 30, 52),
                CCSheet = new CheckSheet
                {
                    Question1Result = "Yes",
                    Question2Result = "Yes",
                    Question3Result = "No",
                    CheckSheetResult = "Fail",
                    Impact = "High",
                    Q3Issue = "Missing kit cart",
                    SolutionUpdates = "parts shortage 10pm"


                }
            };
            MySection qsection8 = new MySection
            {
                JobNumber = "40337205-015",
                SectionNumber = "1",
                JobName = "HCA SUNRISE HOSPITAL",
                Location = "D1",
                ArrivalTime = new DateTime(2018, 11, 06, 7, 30, 52),
                CCSheet = new CheckSheet
                {
                    Question1Result = "Yes",
                    Question2Result = "Yes",
                    Question3Result = "No",
                    CheckSheetResult = "Fail",
                    Impact = "High",
                    Q3Issue = "Missing kit cart",
                    SolutionUpdates = "parts shortage 10pm"


                }
            };
            MySection qsection9 = new MySection
            {
                JobNumber = "40337205-015",
                SectionNumber = "2",
                JobName = "HCA SUNRISE HOSPITAL",
                Location = "D2",
                ArrivalTime = new DateTime(2018, 11, 06, 8, 30, 52),
                CCSheet = new CheckSheet
                {
                    Question1Result = "Yes",
                    Question2Result = "Yes",
                    Question3Result = "No",
                    CheckSheetResult = "Fail",
                    Impact = "High",
                    Q3Issue = "Missing kit cart",
                    SolutionUpdates = "parts shortage 10pm"


                }
            };
            //MySection qsection10 = new MySection
            //{
            //    JobNumber = "41385019-003",
            //    SectionNumber = "2",
            //    JobName = "Warner Bros Tour Center",
            //    Location = "B2",
            //    ArrivalTime = new DateTime(2018, 11, 06, 9, 30, 52),
            //    CCSheet = new CheckSheet
            //    {
            //        Question1Result = "Yes",
            //        Question2Result = "Yes",
            //        Question3Result = "No",
            //        CheckSheetResult = "Fail",
            //        Impact = "High",
            //        Q3Issue = "Missing kit cart",
            //        SolutionUpdates = "parts shortage 10pm"


            //    }
            //};
            //MySection qsection11 = new MySection
            //{
            //    JobNumber = "41385019-003",
            //    SectionNumber = "2",
            //    JobName = "Warner Bros Tour Center",
            //    Location = "B2",
            //    ArrivalTime = new DateTime(2018, 11, 06, 12, 30, 52),
            //    CCSheet = new CheckSheet
            //    {
            //        Question1Result = "Yes",
            //        Question2Result = "Yes",
            //        Question3Result = "No",
            //        CheckSheetResult = "Fail",
            //        Impact = "Low",
            //        Q3Issue = "Changes requrie re-work",
            //        SolutionUpdates = "missing cover"


            //    }
            //};

            //MySection qsection12 = new MySection
            //{
            //    JobNumber = "41385019-003",
            //    SectionNumber = "2",
            //    JobName = "Warner Bros Tour Center",
            //    Location = "B2",
            //    ArrivalTime = new DateTime(2018, 11, 05, 12, 30, 52),
            //    CCSheet = new CheckSheet
            //    {
            //        Question1Result = "Yes",
            //        Question2Result = "Yes",
            //        Question3Result = "No",
            //        CheckSheetResult = "Fail",
            //        Impact = "High",
            //        Q3Issue = "Missing kit cart",
            //        SolutionUpdates = "parts shortage 10pm"


            //    }
            //};

            MySection qsection13 = new MySection
            {
                JobNumber = "41496242-033",
                SectionNumber = "1",
                JobName = "FS17007 - First Solar",
                Location = "E1",
                ArrivalTime = new DateTime(2018, 11, 05, 15, 30, 56),
                CCSheet = new CheckSheet
                {
                    Question1Result = "Yes",
                    Question2Result = "Yes",
                    Question3Result = "Yes",
                    CheckSheetResult = "Pass",
                    Impact = "Low",
                    SolutionUpdates = "Good"

                }
            };

            MySection qsection14 = new MySection
            {
                JobNumber = "41496242-033",
                SectionNumber = "2",
                JobName = "FS17007 - First Solar",
                Location = "E2",
                ArrivalTime = new DateTime(2018, 11, 05, 16, 30, 56),
                CCSheet = new CheckSheet
                {
                    Question1Result = "Yes",
                    Question2Result = "Yes",
                    Question3Result = "Yes",
                    CheckSheetResult = "Pass",
                    Impact = "Low",
                    SolutionUpdates = "Good"

                }
            };

            MySection qsection15 = new MySection
            {
                JobNumber = "41496242-033",
                SectionNumber = "3",
                JobName = "FS17007 - First Solar",
                Location = "E3",
                ArrivalTime = new DateTime(2018, 11, 04, 12, 30, 56),
                CCSheet = new CheckSheet
                {
                    Question1Result = "Yes",
                    Question2Result = "Yes",
                    Question3Result = "Yes",
                    CheckSheetResult = "Pass",
                    Impact = "Low",
                    SolutionUpdates = "Good"

                }
            };

            MySection qsection16 = new MySection
            {
                JobNumber = "41397014-001",
                SectionNumber = "4",
                JobName = "ATT Plaza Generator Re-Feed",
                Location = "B1",
                ArrivalTime = new DateTime(2018, 11, 04, 3, 30, 56),
                CCSheet = new CheckSheet
                {
                    Question1Result = "Yes",
                    Question2Result = "Yes",
                    Question3Result = "Yes",
                    CheckSheetResult = "Pass",
                    Impact = "Low",
                    SolutionUpdates = "Good"

                }
            };

            MySection qsection17 = new MySection
            {
                JobNumber = "41397014-001",
                SectionNumber = "2",
                JobName = "ATT Plaza Generator Re-Feed",
                Location = "B2",
                ArrivalTime = new DateTime(2018, 11, 02, 12, 30, 56),
                CCSheet = new CheckSheet
                {
                    Question1Result = "Yes",
                    Question2Result = "Yes",
                    Question3Result = "Yes",
                    CheckSheetResult = "Pass",
                    Impact = "Low",
                    SolutionUpdates = "Good"

                }
            };

            MySection qsection18 = new MySection
            {
                JobNumber = "41407062-001",
                SectionNumber = "3",
                JobName = "SLC-40 Hangar Upgrades",
                Location = "C5",
                ArrivalTime = new DateTime(2018, 11, 06, 14, 30, 56),
                CCSheet = new CheckSheet
                {
                    Question1Result = "Yes",
                    Question2Result = "Yes",
                    Question3Result = "Yes",
                    CheckSheetResult = "Pass",
                    Impact = "Low",
                    SolutionUpdates = "Good"

                }
            };

            MySection qsection19 = new MySection
            {
                JobNumber = "41407062-001",
                SectionNumber = "1",
                JobName = "SLC-40 Hangar Upgrades",
                Location = "C4",
                ArrivalTime = new DateTime(2018, 11, 05, 17, 30, 56),
                CCSheet = new CheckSheet
                {
                    Question1Result = "Yes",
                    Question2Result = "Yes",
                    Question3Result = "Yes",
                    CheckSheetResult = "Pass",
                    Impact = "Low",
                    SolutionUpdates = "Good"

                }
            };

            MySection qsection20 = new MySection
            {
                JobNumber = "39874222-001",
                SectionNumber = "2",
                JobName = "UK Parking Structure #2",
                Location = "A5",
                ArrivalTime = new DateTime(2018, 11, 01, 12, 30, 56),
                CCSheet = new CheckSheet
                {
                    Question1Result = "Yes",
                    Question2Result = "Yes",
                    Question3Result = "Yes",
                    CheckSheetResult = "Pass",
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
            //sections.Add(qsection10);
            //sections.Add(qsection11);
            //sections.Add(qsection12);
            sections.Add(qsection13);
            sections.Add(qsection14);
            sections.Add(qsection15);
            sections.Add(qsection16);
            sections.Add(qsection17);
            sections.Add(qsection18);
            sections.Add(qsection19);
            sections.Add(qsection20);









        }


    }
}
