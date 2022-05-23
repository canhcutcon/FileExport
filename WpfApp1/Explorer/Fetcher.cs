using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WpfApp1.Files;
using System.Windows;

namespace WpfApp1.Explorer
{
    public static class Fetcher
    {
        public static List<FileModels> GetFiles(string directory)
        {
            List<FileModels> files = new List<FileModels>();

            if (!directory.IsDirectory())
                return files;

            //for expception handling
            string currentFile = "";

            // code for getting all file
            try
            {
                foreach (string file in Directory.GetFiles(directory))
                {
                    currentFile = file;

                    //check if isn't extension
                    if (Path.GetExtension(file) != ".lnk")
                    {
                        FileInfo fInfo = new FileInfo(file);
                        FileModels fileModels = new FileModels()
                        {
                            Name = fInfo.Name,
                            Path = fInfo.FullName,
                            Type = FileType.File
                        };

                        files.Add(fileModels);
                    }
                }

                return files;
            }
            catch(IOException io)
            {
                MessageBox.Show(
                    $"IO Exception getting files in directory: {io.Message}",
                    "Exception getting files in directory");
            }catch(UnauthorizedAccessException noAccess)
            {
                MessageBox.Show(
                    $"No access for a file: {noAccess.Message}",
                    "Exception getting files in directory");
            }catch(Exception e)
            {
                MessageBox.Show(
                    $"Fail to get file in '{directory}' ||" +
                    $"Something to do with '{currentFile}' \n" +
                    $"Exception: {e.Message}", "Error");
            }

            return files;
        }

        public static List<FileModels> GetDirectories(string directory)
        {
            List<FileModels> directories = new List<FileModels>();

            if (!directory.IsDirectory())
                return directories;

            string currentDirectory = "";

            try
            {
                // chech for normal directory
                foreach(string dir in Directory.GetDirectories(directory))
                {
                    currentDirectory = dir;

                    DirectoryInfo dInfo = new DirectoryInfo(dir);
                    FileModels dModels = new FileModels()
                    {
                        Name = dInfo.Name,
                        Path = dInfo.FullName,
                        Type = FileType.Folder
                    };
                    directories.Add(dModels);
                }

                // check for directory shortcut
                foreach(string file in Directory.GetFiles(directory))
                {
                    if(Path.GetExtension(file) == ".lnk")
                    {
                        string realDirPath = ExplorerHelpers.GetShortcutTargetFolder(file);
                        FileInfo dInfo = new FileInfo(realDirPath);
                        FileModels dModels = new FileModels()
                        {
                            Name = dInfo.Name,
                            Path = dInfo.FullName,
                            Type = FileType.Folder
                        };
                        directories.Add(dModels);
                    }
                }

                return directories;
            }
            catch(IOException io)
            {
                MessageBox.Show(
                    $"IO Exception getting folders in directory: {io.Message}",
                    "Exception getting folders in directory");
            }catch(UnauthorizedAccessException noAccess)
            {
                MessageBox.Show(
                    $"No access for a directory: {noAccess.Message}",
                    "Exception getting folders in directory");
            }catch(Exception e)
            {
                MessageBox.Show(
                    $"Failed to get directories in '{directory}' || " +
                    $"Something to do with '{currentDirectory}'\n" +
                    $"Exception: {e.Message}", "Error");
            }

            return directories;
        }

        public static List<FileModels> GetDrivers()
        {
            List<FileModels> drivers = new List<FileModels>();

            try
            {
                foreach(string driver in Directory.GetLogicalDrives())
                {
                    DriveInfo dInfo = new DriveInfo(driver);

                    FileModels dModel = new FileModels()
                    {
                        Name = dInfo.Name,
                        Path = dInfo.Name,
                        Type = FileType.Driver
                    };
                    drivers.Add(dModel);
                }

                return drivers;
            }
            catch(IOException io)
            {
                MessageBox.Show($"IO Exception getting drivers:{io.Message}", "Exception getting driver");
            }catch(UnauthorizedAccessException noAccess)
            {
                MessageBox.Show($"No access for a hard drivers{noAccess.Message}", "");
            }
            return drivers;
        }
    }
}
