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
        public MainWindow()
        {
            InitializeComponent();

            //load dummy data
            TestData testdata = new TestData();
            testdata.AddSection();
            sectioninqueue = testdata.sections;

            //
            SectionInQueueDataGrid.ItemsSource = sectioninqueue.OrderBy(x => x.ArrivalTime).ToList();
            failedsections = sectioninqueue.Where(x => x.CCSheet.CheckSheetResult == false).ToList();
            FlaggedSectionDataGrid.ItemsSource = failedsections.OrderBy(x => x.ArrivalTime).ToList();
            wipsizeTB.Text = sectioninqueue.Count.ToString();

            ccfailureTB.Text = sectioninqueue.Where(x => x.CCSheet.CheckSheetResult == false).LongCount().ToString();
            long averagewaitTime = Convert.ToInt64(sectioninqueue.Average(x => x.WaitTime.Ticks));
            var avgwt = new TimeSpan(averagewaitTime);
            avgwtTB.Text = $"{avgwt.Days} d  {avgwt.Hours} h";

        }
        private void UpdateBindings()
        {
            SectionInQueueDataGrid.ItemsSource = sectioninqueue;
            FlaggedSectionDataGrid.ItemsSource = sectioninqueue.Where(x => x.CCSheet.CheckSheetResult == false).ToList();

        }
        private void FIFOSortButton_Click(object sender, RoutedEventArgs e)
        {
            SectionInQueueDataGrid.ItemsSource = sectioninqueue.OrderByDescending(x => x.CCSheet.Impact).ThenBy(x => x.ArrivalTime).ToList();
            //UpdateBindings();
        }

        private void ArriveButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Clikced");
            //UpdateBindings();
        }
    }
}
