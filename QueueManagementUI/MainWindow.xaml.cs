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
      public MainWindow()
        {
            InitializeComponent();

            TestData testdata = new TestData();
            testdata.AddSection();
            List<MySection> sections = testdata.sections;
            SectionInQueueDataGrid.ItemsSource = sections.OrderBy(x => x.ArrivalTime).ToList();
            FlaggedSectionDataGrid.ItemsSource = sections.Where(x => x.CCSheet.CheckSheetResult ==false).ToList();
            

            
        }


    }
}
