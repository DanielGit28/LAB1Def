using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Aritmeticas
{
    public class Operacion
    {

        public Operacion(string tipoOperacion, double valor1, double valor2, double resultado)
        {
            this.tipoOperacion = tipoOperacion;
            this.valor1 = valor1;
            this.valor2 = valor2;
            this.resultado = resultado;
        }

        public string tipoOperacion { get; set; }
        public double valor1 { get; set; }
        public double valor2 { get; set; }
        public double resultado { get; set; }

    }
    class Program
    {
        
        static HttpClient client = new HttpClient();

        /*
        static void ShowProduct(Product product)
        {
            Console.WriteLine($"Name: {product.Name}\tPrice: " +
                $"{product.Price}\tCategory: {product.Category}");
        }*/
        
        static async Task<Uri> CrearOperacionAsync(Operacion operacion)
        {
            var json = JsonConvert.SerializeObject(operacion);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(
                "api/Values", stringContent);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;

        }
        

        static async Task<string> GetProductAsync(string path)
        {
            string operacion = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                string content;
                //operacion = await response.Content.ReadAsStringAsync<string>();
            }
            return operacion;
        }



        static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:62484/api/Values");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                // Create a new product

                Console.WriteLine("Digite la operación que desea realizar. Suma, Resta, Multiplicacion o Division: ");
                string tipoOp = Console.ReadLine();
                Console.WriteLine("Digite el primer valor: ");
                double valor1 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Digite el segundo valor: ");
                double valor2 = Convert.ToDouble(Console.ReadLine());

                Operacion operacionActual = new Operacion(tipoOp, valor1, valor2, 0);
                //Console.WriteLine(operacionActual.ToString());
                

                var url = await CrearOperacionAsync(operacionActual);
                Console.WriteLine($"Created at {url}");
                
                // Get the product
                //double resultado = await GetProductAsync(url.PathAndQuery);
                //ShowProduct(product);


                /*
                // Update the product
                Console.WriteLine("Updating price...");
                product.Price = 80;
                await UpdateProductAsync(product);

                // Get the updated product
                product = await GetProductAsync(url.PathAndQuery);
                ShowProduct(product);

                // Delete the product
                var statusCode = await DeleteProductAsync(product.Id);
                Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");
                */
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //Console.ReadLine();
        }

    }
}
