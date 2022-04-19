using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HesabuPOS_Installer.ViewModels
{
    public class InstallerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _windowTitle = "HesabuPOS-Installer";
        private bool _databaseOnline = false;
        private bool _databaseInitialized = false;

        public bool IsDatabaseInitialized
        {
            get
            {
                return _databaseInitialized;
            }
            set
            {
                if(_databaseInitialized != value)
                {
                    _databaseInitialized = value;
                    OnPropertyChanged(nameof(IsDatabaseInitialized));
                }
            }
        }

        public bool IsDatabaseOnline
        {
            get
            {
                return _databaseOnline;
            }
            set
            {
                if (_databaseOnline != value)
                {
                    _databaseOnline = value;
                    OnPropertyChanged(nameof(IsDatabaseOnline));
                }
            }
        }

        public string WindowTitle
        {
            get
            {
                return _windowTitle;
            }
            set
            {
                if(_windowTitle != value)
                {
                    _windowTitle = value;
                    OnPropertyChanged(nameof(WindowTitle));
                }
            }
        }

        


    }
}
