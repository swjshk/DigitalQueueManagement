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

namespace QueueManagementUI
{
    /// <summary>
    /// Interaction logic for SectionInfoWindow.xaml
    /// </summary>
    public partial class SectionInfoWindow : Window
    {   
        public event EventHandler<string> AddSectionEvent;//public event
        

        public SectionInfoWindow()
        {
            InitializeComponent();
        }


        //Event
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddSectionEvent?.Invoke(this, "okay");
            this.Close();
        }
    }
}
