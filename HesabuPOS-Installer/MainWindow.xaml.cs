using HesabuPOS.MasterData.Models.Data.BaseData;
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

                // BaseData - Article
                ArticleData dummyArticle = new ArticleData();
                dummyArticle.ArticleNumber = "0000000";
                dummyArticle.Price = 1.25;
                dummyArticle.Name = "Dummy Product";
                dummyArticle.ImageURL = "https://bbts1.azureedge.net/images/p/full/2021/09/34c206ee-2145-4b64-a745-8833c925a476.jpg";
                dummyArticle.Description = "Dummy Description";

                var articlesCollection = database.GetCollection<ArticleData>("Articles");
                articlesCollection.InsertOne(dummyArticle);

                //public string ArticleVariantNumber { get; set; }
                //public string ArticleNumber { get; set; }
                //public double ArticleVariantPrice { get; set; }
                //public string ArticleVariantColor { get; set; }
                //public string ArticleVariantSize { get; set; }

                // BaseData - Article Variant
                ArticleVariantData dummyVariant = new ArticleVariantData();
                dummyVariant.ArticleVariantNumber = "0000000123457";
                dummyVariant.ArticleNumber = "0000000";
                dummyVariant.ArticleVariantPrice = 2.00;
                dummyVariant.ArticleVariantColor = "yellow";
                dummyVariant.ArticleVariantSize = "one size";

                var variantsCollection = database.GetCollection<ArticleVariantData>("ArticleVariants");
                variantsCollection.InsertOne(dummyVariant);

                // BaseData - Storage
                StorageData dummyStorage = new StorageData();
                dummyStorage.StorageLocation = "Berlin";
                dummyStorage.StorageName = "Awesome Online Store";
                dummyStorage.StorageID = 0;
                dummyStorage.StorageContactPerson = "Tobias Kattanek";
                dummyStorage.ImageURL = "https://strawberrytours.com/wp-content/uploads/2019/09/Berlin_500x500-2.jpg";

                var storagesCollection = database.GetCollection<StorageData>("Storages");
                storagesCollection.InsertOne(dummyStorage);

                // create RuntimeData Collections

                // RuntimeData - Stock

                //public int StockID { get; set; }
                //public int StorageID { get; set; }
                //public int ArticleVariantNumber { get; set; }
                //public int ProductQuantity { get; set; }

                StockData dummyStock = new StockData();
                dummyStock.StockID = 0;
                dummyStock.StorageID = 0;
                dummyStock.ArticleVariantNumber = dummyVariant.ArticleVariantNumber;
                dummyStock.ElementString = $"(01){dummyVariant.ArticleVariantNumber}(21)123456";
                dummyStock.ProductQuantity = 100;

                var stocksCollection = database.GetCollection<StockData>("Stocks");
                stocksCollection.InsertOne(dummyStock);

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
