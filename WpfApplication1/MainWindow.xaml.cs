using System;
using System.IO;
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
using System.ComponentModel;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        

        Random r = new Random(DateTime.Now.Millisecond);
        


        public MainWindow()
        {

            InitializeComponent();
            MainDirectory.StartWatchingForChanges(MainDirectory.directory);
            MainDirectory.FindCatalogs();
            //WindowContentManagement.ccContent = new OrganizerControl1();            
            //ccContent = new UserControl();
            //System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            //timer.Tick += RandomColor;
            //timer.Interval = TimeSpan.FromMilliseconds(100);
            //timer.Start();

        }

        

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void brTop_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void RandomColor(object sender, EventArgs e)
        {
            RandomColor();
        }
        private void RandomColor()
        {
            kolor.Color = Color.FromArgb((byte)r.Next(255), (byte)r.Next(255), (byte)r.Next(255), (byte)r.Next(255));
            brTop.Background = kolor;
        }

        private SolidColorBrush kolor = new SolidColorBrush();

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        


        private void closeMainWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void topGridLeftButDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            App.Current.Shutdown();
        }


        private void showMusicWindow_Click(object sender, RoutedEventArgs e)
        {
            WindowContentManagement.ccContent = new MusicWindowControl();

            //MusicWindow.Visibility = Visibility.Visible;
            //InternetWindow.Visibility = Visibility.Collapsed;
            //OrganizerWindow.Visibility = Visibility.Collapsed;
        }

        private void showInternetWindow_Click(object sender, RoutedEventArgs e)
        {
            WindowContentManagement.ccContent = new NetWindow();
            //InternetWindow.Visibility = Visibility.Visible;
            //OrganizerWindow.Visibility = Visibility.Collapsed;
            //MusicWindow.Visibility = Visibility.Collapsed;
        }

        private void showOrganizerWindow_click(object sender, RoutedEventArgs e)
        {
            MainDirectory.FindCatalogs();
            //WindowContentManagement.ccContent = new OrganizerControl1();           
            //InternetWindow.Visibility = Visibility.Collapsed;
            //OrganizerWindow.Visibility = Visibility.Visible;
            //MusicWindow.Visibility = Visibility.Collapsed;
        }
        
    }
}
