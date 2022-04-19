using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HesabuPOS
{
    public class ProductData
    {
        public string? _id { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice { get; set; }

    }

    internal class Program
    {
        static HttpClient client = new HttpClient();

        static void ShowProduct(ProductData product)
        {
            Console.WriteLine($"Name: {product.ProductName}\tPrice: " +
                $"{product.ProductPrice}\tBeschreibung: {product.ProductDescription}");
        }

        static async Task<List<ProductData>> GetProductsAsync(string path)
        {
            List<ProductData> products = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                products = await response.Content.ReadFromJsonAsync<List<ProductData>>();
            }
            return products;
        }

        static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var products = await GetProductsAsync("Products");

                Console.WriteLine("Produkt Stammdaten:");

                foreach(var item in products)
                {
                    Console.WriteLine($"ID: {item.ProductID} Name: {item.ProductName} Beschreibung: {item.ProductDescription} Preis: {item.ProductPrice}");
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}