﻿using HesabuPOS.MasterData.Models.Data.BaseData;
using HesabuPOS.MasterData.Models.Data.RuntimeData;
using HesabuPOS_Installer.ViewModels;
using MongoDB.Driver;
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

namespace HesabuPOS_Installer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public InstallerViewModel InstallerViewModel;

        private MongoClient _mongoClient;


        public MainWindow()
        {
            InstallerViewModel = new InstallerViewModel();
            this.DataContext = InstallerViewModel;

            _mongoClient = new MongoClient("mongodb://localhost:27017");

            InitializeComponent();

            Process();

        }

        private void Process()
        {
            CheckMongoDB();

            if (InstallerViewModel.IsDatabaseOnline == true)
            {
                InitializeDatabase();
            }
            else
            {
                MessageBox.Show("MongoDB isnt currently online...maybe you dont use default settings? TODO FOR DEV: Custom Port or ConnectionString");
            }
        }

        private void InitializeDatabase()
        {
            if(_mongoClient.ListDatabaseNames().ToList().Exists(db => db == "HesabuPOS") == false)
            {
                InstallerViewModel.IsDatabaseInitialized = false;

                var database = _mongoClient.GetDatabase("HesabuPOS");

                // create BaseData Collections

                // BaseData - Product
                var productsCollection = database.GetCollection<ProductData>("Products");
                productsCollection.InsertOne(new ProductData { ProductID = 0, ProductName = "Test Dummy", ProductDescription = "Dummy Description", ProductPrice = 4.20, ImageURL = "https://bbts1.azureedge.net/images/p/full/2021/09/34c206ee-2145-4b64-a745-8833c925a476.jpg" });

                // BaseData - Storage
                var storageCollection = database.GetCollection<StorageData>("Storages");
                storageCollection.InsertOne(new StorageData { StorageID = 0, StorageName = "Dummy Storage", StorageContactPerson = "Person 1", StorageLocation = "Online" });

                // create RuntimeData Collections

                // RuntimeData - Stock
                var stockCollection = database.GetCollection<StockData>("Stocks");
                stockCollection.InsertOne(new StockData { StockID = 0, ProductID = 0, StorageID = 0, ProductQuantity = 99 });

                InstallerViewModel.IsDatabaseInitialized = true;
            }
            else
            {
                InstallerViewModel.IsDatabaseInitialized = true;
            }
            
        }

        private void CheckMongoDB()
        {
            InstallerViewModel.IsDatabaseOnline = ProbeForMongoDbConnection();

        }

        private bool ProbeForMongoDbConnection()
        {
            var probeTask =
                    Task.Run(() =>
                    {
                        var isAlive = false;
                        for (var k = 0; k < 6; k++)
                        {
                            _mongoClient.GetDatabase("admin");
                            var server = _mongoClient.Cluster.Description.Servers.FirstOrDefault();
                            isAlive = (server != null &&
                                   server.HeartbeatException == null &&
                                   server.State == MongoDB.Driver.Core.Servers.ServerState.Connected);
                            if (isAlive)
                            {
                                break;
                            }
                            System.Threading.Thread.Sleep(300);
                        }
                        return isAlive;
                    });
            probeTask.Wait();
            return probeTask.Result;
        }

        private void btn_restart_process_Click(object sender, RoutedEventArgs e)
        {
            InstallerViewModel.IsDatabaseOnline = false;
            InstallerViewModel.IsDatabaseInitialized = false;

            Process();
        }
    }
}
