﻿using HesabuPOS.MasterData.Models.Data;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows;
using HesabuPOS_Storefront.ViewModels;
using System.Collections.ObjectModel;
using System.Linq;

namespace HesabuPOS_Storefront
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StorefrontViewModel _viewModel;

        HttpClient client = new HttpClient();

        public MainWindow()
        {
            _viewModel = new StorefrontViewModel();
            this.DataContext = _viewModel;

            InitializeComponent();

            InitConnection();

            LoadProducts();

        }

        void InitConnection()
        {
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        async void LoadProducts()
        {
            var result = await GetProductsAsync();
            _viewModel.Products = new ObservableCollection<ProductData>(result);
        }

        async Task<List<ProductData>> GetProductsAsync()
        {
            List<ProductData> products = null;
            HttpResponseMessage response = await client.GetAsync("Products/list");
            if (response.IsSuccessStatusCode)
            {
                products = await response.Content.ReadFromJsonAsync<List<ProductData>>();
            }
            return products;
        }
    }
}