using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using UpdateManager.Properties;

namespace UpdateManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ViewModel mainViewModel;

        public MainWindow()
        {
            InitializeComponent();
            mainViewModel = new ViewModel();
            DataContext = mainViewModel;
        }

        private void SaveMqttServer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ConnectMqttServer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NewDeviceMenu_Click(object sender, RoutedEventArgs e)
        {
            NewDeviceWindow newWindow = new NewDeviceWindow();
            newWindow.Show();
            newWindow.Closed += newWindowClosed;
        }

        private void newWindowClosed(object sender, EventArgs e)
        {
            mainViewModel.refreshList();
        }
    }

    public class ViewModel
    {
        public ObservableCollection<string> comboBoxList { get; private set; }

        public ViewModel()
        {
            comboBoxList = new ObservableCollection<string>();
            foreach (string device in Settings.Default.deviceList)
            {
                comboBoxList.Add(device);
            }
        }

        // add a new device to both lists
        public void addDevice(string device)
        {
            this.comboBoxList.Add(device);
            Settings.Default.deviceList.Add(device);
            Settings.Default.Save();
            Settings.Default.Upgrade();
        }

        public bool deleteDevice(string device)
        {
            bool opResult = this.comboBoxList.Remove(device); // try to delete the device
            if (opResult) // if success remove from settings
            {
                Settings.Default.deviceList.Remove(device);
                Settings.Default.Save();
                Settings.Default.Upgrade();
            }
            else return opResult; // if not return false
            return opResult;
        }

        // refresh the list if we're coming back from another window
        public void refreshList()
        {
            this.comboBoxList.Clear();
            foreach (string device in Settings.Default.deviceList)
            {
                comboBoxList.Add(device);
            }
        }
    }
}
