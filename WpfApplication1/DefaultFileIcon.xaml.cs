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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for DefaultFileIcon.xaml
    /// </summary>
    public partial class DefaultFileIcon : UserControl
    {


        public string FileName
        {
            get
            {
                return (string)GetValue(FileNameProperty);
            }
            set
            {
                SetValue(FileNameProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for FileName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FileNameProperty = DependencyProperty.Register("FileName", typeof(string), typeof(DefaultFileIcon));



        public string ImgPath
        {
            get
            {
                return (string)GetValue(ImgPathProperty);
            }
            set
            {
                SetValue(ImgPathProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for ImgPath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImgPathProperty =
            DependencyProperty.Register("ImgPath", typeof(string), typeof(DefaultFileIcon));

        public DefaultFileIcon()
        {
            InitializeComponent();
        }

        public DefaultFileIcon(string Name, string extension) : this()
        {
            FileName = Name;
            if(extension == ".txt")
            {
                ImgPath = "C:\\Users\\Artur\\Desktop\\FileIcon.png";
            }
            else if(extension == ".png" || 
                    extension == ".jpg" || 
                    extension == ".gif" || 
                    extension == ".jpeg"|| 
                    extension == ".bmp" || 
                    extension == ".tga" || 
                    extension == ".dds")
            {
                //ImgPath = "C:\\Users\\Artur\\Desktop\\ImageIcon.png";
                ImgPath = MainDirectory.directory + OrganizerListItem.HeaderProperty.ToString() + "\\" + FileName;
                MessageBox.Show(ImgPath);
            }
        }
    }
}
