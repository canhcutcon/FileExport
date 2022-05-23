using System;
using System.ComponentModel;
using System.Drawing;

namespace WpfApp1.Files
{
    public class FileModels : INotifyPropertyChanged
    {


        private string _Name;
        public String Name {
            get => _Name;
            set 
            {
                _Name = value;
                OnPropertyChanged("Name");
            } 
        }
        string _Path;
        public String Path
        {
            get => _Path;
            set
            {
                _Path = value;
                OnPropertyChanged("Path");

            }
        }
        private bool _Choose;
        public bool Choose {
            get => _Choose;
            set {
                _Choose = value;
                OnPropertyChanged("Choose");
            }
        }
        private FileType _Type;
        public FileType Type 
        {
            get => _Type;
            set
            {
                _Type = value;
                OnPropertyChanged("Type");
            }
        }

        public bool IsFile => Type == FileType.File;

        public bool IdDriver => Type == FileType.Driver;

        public bool IsFolder => Type == FileType.Folder;

        public bool IsShortcut => Type == FileType.Shortcut;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
