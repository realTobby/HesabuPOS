using HesabuPOS.MasterData.Models.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HesabuPOS_Storefront.ViewModels
{
    public class StorefrontViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _windowTitle = "HesabuPOS-Storefront";

        private ObservableCollection<ProductData> _products;

        public ObservableCollection<ProductData> Products
        {
            get { return _products; }
            set
            {
                if(_products != value)
                {
                    _products = value;
                    OnPropertyChanged(nameof(Products));
                }
            }
        }

        public string WindowTitle
        {
            get { return _windowTitle; }
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
