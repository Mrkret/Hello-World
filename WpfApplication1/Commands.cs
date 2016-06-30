using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;
using System.ComponentModel;

namespace WpfApplication1
{
    public class WindowContentManagement 
    {
        

        static ContentControl cccontent = new ContentControl();
        public static ContentControl ccContent
        {
            get
            {
                return cccontent;
            }
            set
            {
                cccontent = value;
                OnStaticPropertyChanged("ccContent");
            }
        }

        public static event PropertyChangedEventHandler StaticPropertyChanged;
        static void OnStaticPropertyChanged(string propertyName)
        {
            StaticPropertyChanged?.Invoke(typeof(WindowContentManagement), new PropertyChangedEventArgs(propertyName));
        }
    }

}
