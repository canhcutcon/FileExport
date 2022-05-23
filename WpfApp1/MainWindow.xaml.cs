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
using WpfApp1.ViewsModels;
using System.ComponentModel;
using WpfApp1.Files;
using System.Collections.ObjectModel;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public class ListFolder : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _Name;
        public string Name 
        {
            get => _Name;
            set
            {
                _Name = value;
                OnPropertyChanged("Name");

            }
        }
        private string _path;
        public string Path
        {
            get => _path;
            set
            {
                _path = value;
                OnPropertyChanged("Path");

            }
        }
        private bool _Choose;
        public bool Choose
        {
            get => _Choose;
            set
            {
                _Choose = value;
                OnPropertyChanged("Choose");

            }
        }

    }
    public partial class MainWindow : Window , INotifyPropertyChanged
    {
        private string GiangPenguin = "";

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private ObservableCollection<ListFolder> _listFolder;
        public ObservableCollection<ListFolder> listFolder
        {
            get 
            {
                if (_listFolder == null)
                {
                    _listFolder = new ObservableCollection<ListFolder>();                  
                }
                return _listFolder;
            }
            set {
                _listFolder = value;
                OnPropertyChanged("listFolder");
            }
        }
       
        private MainModels Model;
        public MainWindow()
        {
            Model = new MainModels();
          
            if (GiangPenguin.Equals(""))
            {
                Model.TryNavigationToPath(@"E:\EMAGEW");
                foreach (var item in Model.FileIteams)
                {
                    listFolder.Add(new ListFolder { Name = item.Name, Path = item.Path, Choose = item.Choose });
                }
                
            }
            else
            {
                Model.TryNavigationToPath(GiangPenguin);
                foreach (var item in Model.FileIteams)
                {
                    listFolder.Add(new ListFolder { Name = item.Name, Path = item.Path });
                }
                //listFoder = Model.FileIteams;
            }
        }

        #region Events
        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDefault_Click(object sender, RoutedEventArgs e)
        {
            if (GiangPenguin.Equals(""))
            {
                Model.TryNavigationToPath(@"E:\EMAGEW");
                foreach (var item in Model.FileIteams)
                {
                    listFolder.Add(new ListFolder { Name = item.Name, Path = item.Path, Choose = item.Choose });
                }
            }
            else
            {
                Model.TryNavigationToPath(GiangPenguin);
                foreach (var item in Model.FileIteams)
                {
                    listFolder.Add(new ListFolder { Name = item.Name, Path = item.Path, Choose = item.Choose });
                }
                //listFoder = Model.FileIteams;
            }
            //lvInfor.ItemsSource = listFolder;
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPath_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello");
            System.Windows.Forms.FolderBrowserDialog openFileDlg = new System.Windows.Forms.FolderBrowserDialog();
            var result = openFileDlg.ShowDialog();
            if (result.ToString() != string.Empty)
            {
                txtPath.Text = openFileDlg.SelectedPath;
            }
            GiangPenguin = txtPath.Text;
        }
        #endregion

        #region Methods


        #endregion

        private void Chk_Checked(object sender, RoutedEventArgs e)
        {
             var checkbox = (sender) as CheckBox;
            checkbox.IsChecked = false;

        }


        
    }
}
