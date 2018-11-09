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
        public int highWIPsize = 18;
        public int lowWIPsize = 5;
        public int ccfailureLevel = 6;

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
            sectioninqueue = sectioninqueue.OrderBy(x => x.ArrivalTime).ToList(); //sorted by FIFO
            SectionInQueueDataGrid.ItemsSource = sectioninqueue;
            failedsections = sectioninqueue.Where(x => x.CCSheet.CheckSheetResult == "Fail").ToList(); //filter failure section
            FlaggedSectionDataGrid.ItemsSource = failedsections.OrderBy(x => x.CCSheet.Impact).ThenBy(x => x.ArrivalTime).ToList();//sort by arrival time
            var converter = new System.Windows.Media.BrushConverter();
            var brushgray = converter.ConvertFromString("#FF686868") as Brush;
            var brushgreen = converter.ConvertFromString("#FF3DCD58") as Brush;
            var brushred = converter.ConvertFromString("#FFEF9A9A") as Brush;
            //Queue Status
            int currentQueueSize = sectioninqueue.Count;
            sectQtyTB.Text = currentQueueSize.ToString();
            int ccfailureQty = sectioninqueue.Where(x => x.CCSheet.CheckSheetResult == "Fail").Count();
            failQtyTB.Text = ccfailureQty.ToString();

            if (currentQueueSize >= highWIPsize)
            {
                wipsizeTB.Text = "High WIP";
                wipsizeTB.Foreground = Brushes.Red;
                
            }
            else
            {
                if (currentQueueSize <= lowWIPsize)
                {
                    wipsizeTB.Text = "Low WIP";
                    wipsizeTB.Foreground = Brushes.Blue;
                    
                }
                else
                {
                    wipsizeTB.Text = "Healthy WIP";                   
                    wipsizeTB.Foreground = brushgray;
                    
                }
            }
            

            if (ccfailureQty >= ccfailureLevel)
            {
                ccfailureTB.Foreground = Brushes.Red;
            }
            else
            {
               
                ccfailureTB.Foreground = brushgray;

            }

            ccfailureTB.Text = $"{ccfailureQty.ToString()} Sections";  //failure section         
            

            if (sectioninqueue.Capacity == 0)
            {
                avgwtTB.Text = $"0 days  0 hours"; //avg waiting time
            }
            else
            {
                var avgwt = new TimeSpan(Convert.ToInt64(sectioninqueue.Average(x => x.WaitTime.Ticks)));  //avg waiting time
                avgwtTB.Text = $"{avgwt.Days} days  {avgwt.Hours} hours"; //avg waiting time
            }

            
            if ((currentQueueSize>=highWIPsize || currentQueueSize<=lowWIPsize) && ccfailureQty <= ccfailureLevel)
            {
                actionTB.Text = "Supervisor: WIP size is NOT healthy. Please take actions!";
                actionTB.Foreground = Brushes.Red;
                apptitleTB.Background = brushred;
            }
            if ((currentQueueSize >= highWIPsize || currentQueueSize <= lowWIPsize) && ccfailureQty >= ccfailureLevel)
            {
                actionTB.Text = "Supervisor: WIP size is NOT healthy. There are to many failure sections. Please take actions!";
                actionTB.Foreground = Brushes.Red;
                apptitleTB.Background = brushred;
            }
            if ((currentQueueSize < highWIPsize && currentQueueSize > lowWIPsize) && ccfailureQty >= ccfailureLevel)
            {
                actionTB.Text = "Supervisor: There are to many failure sections. Please take actions!";
                actionTB.Foreground = Brushes.Red;
                apptitleTB.Background = brushred;
            }
            if (currentQueueSize < highWIPsize && currentQueueSize>lowWIPsize && ccfailureQty< ccfailureLevel)
            {
                actionTB.Text = "Queue Status is Good!";
                actionTB.Foreground = brushgreen;
                apptitleTB.Background = brushgreen;

            }
          

        }

        //event action
        private void Sectionwindow_AddSectionEvent(object sender, MySection e)
        {
            sectioninqueue.Add(e);
            this.IsEnabled = true;
            UpdateBindings_MainWindow();
        }

        private void Sectionwindow_UpdateSectionEvent(object sender, MySection e)
        {

            var selectedItem = SectionInQueueDataGrid.SelectedItem as MySection;
            sectioninqueue.Remove(selectedItem);
            sectioninqueue.Add(e);
            UpdateBindings_MainWindow();
        }


        private void ArriveButton_Click(object sender, RoutedEventArgs e)
        {
            SectionInfoWindow sectionwindow_add = new SectionInfoWindow();
            MySection qsection1 = new MySection();

            //this.IsEnabled = false;

            sectionwindow_add.UpdateButton.IsEnabled = false;
            sectionwindow_add.UpdateButton.Visibility = Visibility.Hidden;
            //WPF
            sectionwindow_add.arrivaltimeTB.Text = DateTime.Now.ToString();

            //data
            qsection1.ArrivalTime = DateTime.Now;

            sectionwindow_add.currentsection = qsection1;


            sectionwindow_add.AddSectionEvent += Sectionwindow_AddSectionEvent;//subscribe event
            sectionwindow_add.ShowDialog();
        }
        private void LeaveButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = SectionInQueueDataGrid.SelectedItem as MySection;
            if (selectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show($"Job Information:\r\rQueue Loc: { selectedItem.Location}\rSection {selectedItem.SectionNumber} of {selectedItem.JobNumber}\r" +
                    $"{selectedItem.JobName}\r\r" + "Do you want to remove the above section?", "Leaving the queue", MessageBoxButton.YesNo);

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
            //this.IsEnabled = false;

            var selectedItem = SectionInQueueDataGrid.SelectedItem as MySection;
            if (selectedItem != null)
            {
                SectionInfoWindow sectionwindow_update = new SectionInfoWindow();

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
                //sectionwindow_update.ccresultTB.Text = selectedItem.CCSheet.CheckSheetResult;
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

                sectionwindow_update.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a section from the right list");
            }
        }
    }
}
