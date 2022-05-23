using Shell32;
using System.IO;

namespace WpfApp1.Explorer
{
    public static class ExplorerHelpers
    {
        // check is file 
        public static bool IsFile(this string path)
        {
            return !string.IsNullOrEmpty(path) && File.Exists(path);
        }


        // check is directory
        public static bool IsDirectory(this string path)
        {
            return !string.IsNullOrEmpty(path) && Directory.Exists(path);
        }

        // check driver 
        public static bool IsDriver(this string path)
        {
            return !string.IsNullOrEmpty(path) && Directory.Exists(path);
        }


        //Gets the name of a file within a path
        public static string GetFileName(this string fullpath)
        {
            return Path.GetFileName(fullpath);
        }

        // return directory path of the directory a file is located in 
        //(e.g, C:\f1\fold2\f3\hello.txt, returns C:\f1\fold2\f3)
        public static string GetParentDirectory(this string fullpath)
        {
            return Path.GetFileName(fullpath);
        }


        // check if the path is the shortcut
        public static bool CheckPathIsShortcutFile(string path)
        {
            return File.Exists(GetShortcutTargetFolder(path));
        }

        // get the root path of shortcut
        public static string GetShortcutTargetFolder(string shortcutFileName)
        {
            string pathOnly = Path.GetDirectoryName(shortcutFileName);
            string fileNameOnly = Path.GetFileName(shortcutFileName);

            Shell shell = new Shell();
            Folder folder = shell.NameSpace(pathOnly);
            FolderItem folderItem = folder.ParseName(fileNameOnly);
            if(folderItem != null)
                    {
                ShellLinkObject link = (ShellLinkObject)folderItem.GetLink;
                return link.Path;
            }

            return string.Empty;
        }

    }
}
