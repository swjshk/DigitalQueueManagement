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


        //button event
        private void FIFOSortButton_Click(object sender, RoutedEventArgs e)
        {
            SectionInQueueDataGrid.ItemsSource = sectioninqueue.OrderByDescending(x => x.CCSheet.Impact).ThenBy(x => x.ArrivalTime).ToList();
            //UpdateBindings();
        }
        private void ArriveButton_Click(object sender, RoutedEventArgs e)
        {
            SectionInfoWindow sectionwindow = new SectionInfoWindow();
            MySection qsection1 = new MySection();
            sectionwindow.Show();

            //WPF
            sectionwindow.arrivaltimeTB.Text = DateTime.Now.ToString();

            //data
            qsection1.ArrivalTime = DateTime.Now;
            

          



            sectionwindow.currentsection = qsection1;
            sectionwindow.AddSectionEvent += Sectionwindow_AddSectionEvent;//subscribe event

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
    }
}
