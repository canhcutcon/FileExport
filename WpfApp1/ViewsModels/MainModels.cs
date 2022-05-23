using System.Collections.ObjectModel;
using WpfApp1.Explorer;
using WpfApp1.Files;

namespace WpfApp1.ViewsModels
{
    public class MainModels
    {
        public ObservableCollection<FileModels> FileIteams { get; set; }

        public MainModels()
        {
            FileIteams = new ObservableCollection<FileModels>();
        }

        public void TryNavigationToPath(string path)
        {
            // is a driver
            if(path == string.Empty)
            {
                foreach(FileModels file in Fetcher.GetDrivers())
                {
                    addFile(file);
                }
            }

            // chekc file
            else if(path.IsFile())
            {

            }

            else if(path.IsDirectory())
            {
                foreach(FileModels directory in Fetcher.GetDirectories(path))
                {
                    addFile(directory);
                }

                foreach(FileModels file in Fetcher.GetFiles(path))
                {
                    addFile(file);
                }
            }
        }

        public void addFile(FileModels fileModels)
        {
            FileIteams.Add(fileModels);
        }  
    }
}
