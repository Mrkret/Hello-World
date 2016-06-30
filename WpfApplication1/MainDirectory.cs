using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    static class MainDirectory
    {
        public static string directory = "C:\\Users\\Artur\\Desktop\\MainFolder";
        //public void GetFoldersList(string FolderName)
        //{
        //    string direct = directory;
        //    direct += FolderName;
        //    DirectoryInfo Dir = new DirectoryInfo(direct);
        //    if (Dir.Exists)
        //    {
                
        //    }

        //}
        public static void StartWatchingForChanges(string dir)
        {
            FileSystemWatcher watcher = new FileSystemWatcher(dir);
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.Size;
            watcher.Filter = "*.*";
            watcher.Changed += new FileSystemEventHandler(OnChanged);           
            //watcher.Created += new FileSystemEventHandler(OnChanged);
            //watcher.Deleted += new FileSystemEventHandler(OnChanged);
            //watcher.Renamed += new RenamedEventHandler(OnChanged);            
            watcher.EnableRaisingEvents = true;
        }
        private static void OnChanged(object source, FileSystemEventArgs e) { }
        public static void FindCatalogs()
        {
            string[] Folders;          
            //DirectoryInfo Dir = new DirectoryInfo(directory);
            Folders = Directory.GetFileSystemEntries(directory);
            OrganizerControl1 OrgControl = new OrganizerControl1();
            for(int i=0; i < Folders.Length; i++)
            {
                string FolderDir = directory + "\\" + Folders[i];                               
                OrganizerListItem OLI = new OrganizerListItem(FindFiles(FolderDir), Folders[i]);
                OrgControl.OrganizerList.Items.Add(OLI);                
            }
            if (WindowContentManagement.ccContent is OrganizerControl1)
            {
                WindowContentManagement.ccContent = OrgControl;
            }
        }
        public static FileObj[] FindFiles(string FolderDir)
        {
            string[] files = Directory.GetFileSystemEntries(FolderDir);
            FileObj[] FolderFiles;
            FolderFiles = new FileObj[files.Length];
            for(int i=0; i < files.Length; i++)
            {
                FolderFiles[i].Directory = files[i];     
            }
            return FolderFiles;
        }
    }
}
