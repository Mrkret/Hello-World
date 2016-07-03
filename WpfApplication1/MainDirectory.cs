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
        public static Action<FileSystemEventArgs> created;
        public static Action<FileSystemEventArgs> deleted;
        public static Action<RenamedEventArgs> renamed;
        public static string directory = Environment.CurrentDirectory + "\\MainDirectory\\";
        public static FileSystemWatcher watcher;
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
            watcher = new FileSystemWatcher(dir);
            watcher.IncludeSubdirectories = true;
            watcher.NotifyFilter = NotifyFilters.LastWrite | 
                                   NotifyFilters.CreationTime |
                                   NotifyFilters.Size | 
                                   NotifyFilters.Attributes | 
                                   NotifyFilters.DirectoryName | 
                                   NotifyFilters.FileName | 
                                   NotifyFilters.LastAccess | 
                                   NotifyFilters.Security;
            
            //watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnCreated);
            watcher.Deleted += new FileSystemEventHandler(OnDeleted);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);
            watcher.EnableRaisingEvents = true;
        }
        private static void OnChanged(object source, FileSystemEventArgs e)
        {

            if (WindowContentManagement.ccContent is OrganizerControl1)
                
                FindCatalogs();
        }
        private static void OnCreated(object source, FileSystemEventArgs e)
        {
            var handler = created;
            if(handler!=null)
            {
                created(e);
            }

            //if(IsDirectory(e.FullPath)==true)
            //{
            //    DirectoryInfo DirInfo = new DirectoryInfo(e.FullPath); 

            //}       
        }
        private static void OnDeleted(object source, FileSystemEventArgs e)
        {
            var handler = deleted;
            if (handler != null)
            {
                deleted(e);
            }
        }
        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            var handler = renamed;
            if (handler != null)
            {
                renamed(e);
            }
        }

        public static void FindCatalogs()
        {
            string[] Folders;          
            //DirectoryInfo Dir = new DirectoryInfo(directory);
            Folders = Directory.GetFileSystemEntries(directory);
            OrganizerControl1 OrgControl = new OrganizerControl1();
            
            for(int i=0; i < Folders.Length; i++)
            {
                string FolderDir = Folders[i];

                DirectoryInfo dInfo = new DirectoryInfo(Folders[i]);
               
                OrganizerListItem OLI = new OrganizerListItem(FindFiles(FolderDir), dInfo.Name);
                
                OrgControl.OrganizerList.Items.Add(OLI);                
            }

                WindowContentManagement.ccContent = OrgControl;
            
        }
        public static FileObj[] FindFiles(string FolderDir)
        {
            string[] files = Directory.GetFileSystemEntries(FolderDir);
            
            FileObj[] FolderFiles;

            FolderFiles = new FileObj[files.Count()];


            for(int i=0; i < files.Count(); i++)
            {
                FolderFiles[i] = new FileObj(files[i]);  
            }

            return FolderFiles;
        }
        public static bool? IsDirectory(string path)
        {
            if (Directory.Exists(path))
                return true; // is a directory 
            else
            if (File.Exists(path)) return false; // is a file 
            else
                return null; // is a nothing 
        }
    }
}
