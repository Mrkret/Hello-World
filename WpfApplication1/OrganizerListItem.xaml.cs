using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for OrganizerListItem.xaml
    /// </summary>
    public partial class OrganizerListItem : UserControl, INotifyPropertyChanged
    {
        public static DependencyProperty HeaderProperty = DependencyProperty.Register("Header", typeof(string), typeof(OrganizerListItem));
        public event PropertyChangedEventHandler PropertyChanged;        
        public string Header
        {
            get
            {
                return (string)GetValue(HeaderProperty);
            }
            set
            {
                SetValue(HeaderProperty, value);
            }
        }
        public void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public OrganizerListItem()
        {
            InitializeComponent();

            this.MouseWheel += ScrollContent;
            //DefaultFileIcon icon = new DefaultFileIcon();
            //OrganizerFilesPanel.Children.Add(icon);
        }
        public OrganizerListItem(FileObj[] files, string hheader)
        {
            Header = hheader;
            InitializeComponent();
            foreach(FileObj file in files)
            {
                DefaultFileIcon icon = new DefaultFileIcon(file.Name, file.Extension);
                icon.VerticalAlignment = VerticalAlignment.Stretch;
                icon.HorizontalAlignment = HorizontalAlignment.Stretch;
                
                OrganizerFilesPanel.Children.Add(icon);
            }
        }
        public void ScrollContent(object sender, MouseWheelEventArgs e)
        {
            DependencyObject obj = this;

            do
            {
                obj = VisualTreeHelper.GetParent(obj);
            } while (obj.GetType() != typeof(OrganizerControl1));

            ((OrganizerControl1)obj).scrolLViewer.ScrollToVerticalOffset(((OrganizerControl1)obj).scrolLViewer.VerticalOffset - e.Delta);
            
        }

        private void DeleteFolder_Click(object sender, RoutedEventArgs e)
        {
            
            var result = MessageBox.Show("do you want to delete the folder?", "kek", MessageBoxButton.YesNo);
            if(result == MessageBoxResult.Yes)
            {
                Directory.Delete(MainDirectory.directory + "\\" + Header);
            }
            
        }
    }
}
