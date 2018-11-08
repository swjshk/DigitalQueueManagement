using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using QueueClass;

namespace QueueManagementUI
{
    /// <summary>
    /// Interaction logic for SectionInfoWindow.xaml
    /// </summary>
    public partial class SectionInfoWindow : Window
    {
        public MySection currentsection = new MySection();
        public event EventHandler<MySection> AddSectionEvent;//public event
        public event EventHandler<MySection> UpdateSectionEvent;//public event
       

        public SectionInfoWindow()
        {
            InitializeComponent();
            //this.Resources.Add(currentsection, currentsection);
        }


        //Event
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            currentsection.JobNumber = jobnumberTB.Text;
            currentsection.SectionNumber = sectionnumberTB.Text;
            currentsection.JobName = jobnameTB.Text;
            currentsection.Location = queuelocTB.Text;
            if (q1resultCB.Text == "Yes" && q2resultCB.Text == "Yes" && q3resultCB.Text == "Yes")
            {
                currentsection.CCSheet.CheckSheetResult = "Pass";
            }
            else
            {
                currentsection.CCSheet.CheckSheetResult = "Fail";
            }

            currentsection.CCSheet.Impact = impactCB.Text;
            currentsection.CCSheet.Question1Result = q1resultCB.Text;
            currentsection.CCSheet.Q1Issue = q1issueCB.Text;
            currentsection.CCSheet.Question2Result = q2resultCB.Text;
            currentsection.CCSheet.Q2Issue = q2issueCB.Text;
            currentsection.CCSheet.Question3Result = q3resultCB.Text;
            currentsection.CCSheet.Q3Issue = q3issueCB.Text;


            currentsection.CCSheet.SolutionUpdates = solutionupdatesTB.Text;
            currentsection.Comment = commentTB.Text;
         

            AddSectionEvent?.Invoke(this, currentsection);
            this.Close();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            currentsection.JobNumber = jobnumberTB.Text;
            currentsection.SectionNumber = sectionnumberTB.Text;
            currentsection.JobName = jobnameTB.Text;
            currentsection.ArrivalTime = Convert.ToDateTime(arrivaltimeTB.Text);
            currentsection.Location = queuelocTB.Text;
            if (q1resultCB.Text == "Yes" && q2resultCB.Text == "Yes" && q3resultCB.Text == "Yes")
            {
                currentsection.CCSheet.CheckSheetResult = "Pass";
            }
            else
            {
                currentsection.CCSheet.CheckSheetResult = "Fail";
            }

            currentsection.CCSheet.Impact = impactCB.Text;
            currentsection.CCSheet.Question1Result = q1resultCB.Text;
            currentsection.CCSheet.Q1Issue = q1issueCB.Text;
            currentsection.CCSheet.Question2Result = q2resultCB.Text;
            currentsection.CCSheet.Q2Issue = q2issueCB.Text;
            currentsection.CCSheet.Question3Result = q3resultCB.Text;
            currentsection.CCSheet.Q3Issue = q3issueCB.Text;


            currentsection.CCSheet.SolutionUpdates = solutionupdatesTB.Text;
            currentsection.Comment = commentTB.Text;


            UpdateSectionEvent?.Invoke(this, currentsection);
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
 
            this.Close();
        }
    }
}
