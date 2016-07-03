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
using System.IO;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for OrganizerControl1.xaml
    /// </summary>
    public partial class OrganizerControl1 : UserControl
    {

        public OrganizerControl1()
        {
            InitializeComponent();
            MainDirectory.created += OnCreated;
            MainDirectory.deleted += OnDeleted;
            //MainDirectory.FindCatalogs();
            //MainDirectory.StartWatchingForChanges(MainDirectory.directory);            
        }

        public void ClearOrgList()
        {
            OrganizerList.Items.Clear();
        }

        private void AddOrganizerListItem_Click(object sender, RoutedEventArgs e)
        {
            popup.IsOpen = true;
            ListItemHeader.Focus();

            //var itemList = OrganizerList.Items.OfType<OrganizerListItem>().Where(item => item.Header == "naglowek");


            //for(int i=0;i<itemList.Count();i++)
            //{
            //    OrganizerList.Items.Remove(itemList.ElementAt(i));
            //}

            

        }

        public void ScrollContent(object sender,MouseWheelEventArgs e)
        {
            scrolLViewer.ScrollToVerticalOffset(scrolLViewer.VerticalOffset - e.Delta);
        }

        private void ListItemHeader_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && ListItemHeader.Text != null)
            {
                popup.IsOpen = false;
                if (!Directory.Exists(MainDirectory.directory + "\\" + ListItemHeader.Text))
                {
                    Directory.CreateDirectory(MainDirectory.directory + "\\" + ListItemHeader.Text);
                }
                else
                {
                    MessageBoxResult FolderDoesntExistMB = MessageBox.Show( Application.Current.MainWindow ,"Folder already exists","", MessageBoxButton.OK);
                    //if (FolderDoesntExistMB == MessageBoxResult.OK)
                    //{
                    //    MessageBox.
                    //}
                }

                //OrganizerListItem oli = new OrganizerListItem();
                //oli.MouseWheel += ScrollContent;
                //oli.Header = ListItemHeader.Text;
                //OrganizerList.Items.Add(oli);
            }
        }

        private void popup_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void OnCreated(FileSystemEventArgs e)
        {
            if (MainDirectory.IsDirectory(e.FullPath) == true)
            {
                DirectoryInfo DirInfo = new DirectoryInfo(e.FullPath);
                Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.DataBind,
                new Action(() =>
                {
                    //OrganizerListItem OLI = new OrganizerListItem(DirInfo.Name);
                    //OrganizerList.Items.Add(OLI);
                    MainDirectory.FindCatalogs();
                }));


            }
            else if (MainDirectory.IsDirectory(e.FullPath) == false)
            {
                FileInfo fInfo = new FileInfo(e.FullPath);
                Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.DataBind,
                new Action(() =>
                {
                    foreach (var item in OrganizerList.Items.OfType<OrganizerListItem>())
                    {
                        if (item.Header == fInfo.Directory.Name)
                        {
                            item.OrganizerFilesPanel.Children.Add(new DefaultFileIcon(fInfo.Name, fInfo.Extension));
                        }
                    }
                }));
            }

        }
        private void OnDeleted(FileSystemEventArgs e)
        {
            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.DataBind,
                new Action(() =>
                {
                    MainDirectory.FindCatalogs();
                
                }));         
            //if (MainDirectory.IsDirectory(e.FullPath) == true)
            //{
            //    MessageBox.Show("true");
            //    DirectoryInfo DirInfo = new DirectoryInfo(e.FullPath);


            //    Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.DataBind,
            //    new Action(() =>
            //    {
            //        foreach (var item in OrganizerList.Items.OfType<OrganizerListItem>())
            //        {
            //            if (item.Header == DirInfo.Name)
            //            {
            //                OrganizerList.Items.Remove(item);
            //            }
            //        }
            //    }));
            //}
            
        }
    }
}
