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

namespace UpdateManager
{
    /// <summary>
    /// Interaction logic for NewDeviceWindow.xaml
    /// </summary>
    public partial class NewDeviceWindow : Window
    {
        ViewModel windowViewModel;

        public NewDeviceWindow()
        {
            InitializeComponent();
            windowViewModel = new ViewModel();
            DataContext = windowViewModel;
        }

        private void AddDeviceButton_Click(object sender, RoutedEventArgs e)
        {
            if (!newDeviceName.Text.Equals(""))
            {
                windowViewModel.addDevice(newDeviceName.Text);
                MessageBox.Show("New device added!", "Info", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Enter a device name!", "Info", MessageBoxButton.OK,MessageBoxImage.Error);
            }
            this.Close();
        }

        private void DeleteDeviceButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                windowViewModel.deleteDevice(windowViewModel.comboBoxList[deviceComboBox.SelectedIndex]);
                MessageBox.Show("Device deleted!", "Info", MessageBoxButton.OK);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Select a device!", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
