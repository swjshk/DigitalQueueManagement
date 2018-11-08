using QueueClass;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace QueueManagementUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<MySection> sectioninqueue = new List<MySection>();
        public List<MySection> failedsections = new List<MySection>();
        //public SectionInfoWindow sectionwindow = new SectionInfoWindow();

        public MainWindow()
        {
            InitializeComponent();

            //load initial dummy data 
            TestData testdata = new TestData();
            testdata.AddSection();
            sectioninqueue = testdata.sections;

            //load the data to the datagrid
            UpdateBindings_MainWindow();

            //subscribe event
            //WireUpForm();

        }

        private void UpdateBindings_MainWindow()//update WPF data bindings
        {
            sectioninqueue = sectioninqueue.OrderByDescending(x => x.CCSheet.Impact).ThenBy(x => x.ArrivalTime).ToList(); //sorted by FIFO
            SectionInQueueDataGrid.ItemsSource = sectioninqueue;
            failedsections = sectioninqueue.Where(x => x.CCSheet.CheckSheetResult == "Fail").ToList(); //filter failure section
            FlaggedSectionDataGrid.ItemsSource = failedsections.OrderBy(x => x.ArrivalTime).ToList();//sort by arrival time
            

            //Queue Status
            wipsizeTB.Text = $"{sectioninqueue.Count.ToString()} Sections"; //WIP size
            ccfailureTB.Text = $"{sectioninqueue.Where(x => x.CCSheet.CheckSheetResult == "Fail").LongCount().ToString()} Sections";  //failure section         
            if (sectioninqueue.Capacity == 0)
            {
                avgwtTB.Text = $"0 days  0 hours"; //avg waiting time
            }
            else
            {
                var avgwt = new TimeSpan(Convert.ToInt64(sectioninqueue.Average(x => x.WaitTime.Ticks)));  //avg waiting time
                avgwtTB.Text = $"{avgwt.Days} days  {avgwt.Hours} hours"; //avg waiting time
            }


        }

        //event action
        private void Sectionwindow_AddSectionEvent(object sender, MySection e)
        {         
            sectioninqueue.Add(e);
            UpdateBindings_MainWindow();
        }

        private void Sectionwindow_UpdateSectionEvent(object sender, MySection e)
        {
            
            var selectedItem = SectionInQueueDataGrid.SelectedItem as MySection;
            sectioninqueue.Remove(selectedItem);
            sectioninqueue.Add(e);
            UpdateBindings_MainWindow();
        }

        //button event
        private void FIFOSortButton_Click(object sender, RoutedEventArgs e)
        {
            SectionInQueueDataGrid.ItemsSource = sectioninqueue.OrderByDescending(x => x.CCSheet.Impact).ThenBy(x => x.ArrivalTime).ToList();
            //UpdateBindings();
        }
        private void ArriveButton_Click(object sender, RoutedEventArgs e)
        {
            SectionInfoWindow sectionwindow_add = new SectionInfoWindow();
            MySection qsection1 = new MySection();
            sectionwindow_add.Show();
            sectionwindow_add.UpdateButton.IsEnabled = false;
            sectionwindow_add.UpdateButton.Visibility = Visibility.Hidden;
            //WPF
            sectionwindow_add.arrivaltimeTB.Text = DateTime.Now.ToString();

            //data
            qsection1.ArrivalTime = DateTime.Now;

            sectionwindow_add.currentsection = qsection1;
            sectionwindow_add.AddSectionEvent += Sectionwindow_AddSectionEvent;//subscribe event

            //sectionwindow.ShowDialog();
            //MessageBox.Show("Clikced");
            //UpdateBindings();
        }
        private void LeaveButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = SectionInQueueDataGrid.SelectedItem as MySection;
            if (selectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show( $"Job Information:\r\rQueue Loc: { selectedItem.Location}\rSection {selectedItem.SectionNumber} of {selectedItem.JobNumber}\r" + 
                    $"{selectedItem.JobName}\r\r"+ "Do you want to remove the above section?", "Leaving the queue", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    sectioninqueue.RemoveAt(sectioninqueue.IndexOf(selectedItem));
                    UpdateBindings_MainWindow();
                }
            }
            else
            {
                MessageBox.Show("Please select a section from the right list");
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = SectionInQueueDataGrid.SelectedItem as MySection;
            if (selectedItem != null)
            {
                SectionInfoWindow sectionwindow_update = new SectionInfoWindow();
                sectionwindow_update.Show();
                sectionwindow_update.AddButton.IsEnabled = false;
                sectionwindow_update.AddButton.Visibility = Visibility.Hidden;
                sectionwindow_update.jobnumberTB.IsReadOnly = true;
                sectionwindow_update.sectionnumberTB.IsReadOnly = true;
                sectionwindow_update.jobnameTB.IsReadOnly = true;
                sectionwindow_update.queuelocTB.IsReadOnly = true;
                sectionwindow_update.jobnumberTB.BorderBrush = null;
                sectionwindow_update.sectionnumberTB.BorderBrush = null;
                sectionwindow_update.jobnameTB.BorderBrush = null;
                sectionwindow_update.queuelocTB.BorderBrush = null;

                sectionwindow_update.jobnumberTB.Text = selectedItem.JobNumber;
                sectionwindow_update.sectionnumberTB.Text = selectedItem.SectionNumber;
                sectionwindow_update.jobnameTB.Text = selectedItem.JobName;             
                sectionwindow_update.arrivaltimeTB.Text = selectedItem.ArrivalTime.ToString();
                sectionwindow_update.queuelocTB.Text = selectedItem.Location;
                sectionwindow_update.ccresultTB.Text = selectedItem.CCSheet.CheckSheetResult;
                sectionwindow_update.impactCB.Text = selectedItem.CCSheet.Impact;
                sectionwindow_update.q1resultCB.Text = selectedItem.CCSheet.Question1Result;
                sectionwindow_update.q1issueCB.Text = selectedItem.CCSheet.Q1Issue;
                sectionwindow_update.q2resultCB.Text = selectedItem.CCSheet.Question2Result;
                sectionwindow_update.q2issueCB.Text = selectedItem.CCSheet.Q2Issue;
                sectionwindow_update.q3resultCB.Text = selectedItem.CCSheet.Question3Result;
                sectionwindow_update.q3issueCB.Text = selectedItem.CCSheet.Q3Issue;
                sectionwindow_update.solutionupdatesTB.Text = selectedItem.CCSheet.SolutionUpdates;
                sectionwindow_update.commentTB.Text = selectedItem.Comment;

                sectionwindow_update.UpdateSectionEvent += Sectionwindow_UpdateSectionEvent;//subscribe event

            }
            else
            {
                MessageBox.Show("Please select a section from the right list");
            }
        }
    }
}
