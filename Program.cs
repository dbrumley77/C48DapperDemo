using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace C48DapperDEmo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            var config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();
            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);


            //DapperDepartmentRepository instance = new DapperDepartmentRepository(conn);


            //IEnumerable<Department> collection = instance.GetAllDepartments();

            //foreach (Department item in collection)
            //{
            //    Console.WriteLine(item.DepartmentID);
            //    Console.WriteLine(item.Name);
            //    Console.WriteLine();
            //}

            //instance.InsertDepartment("taco");



            DapperProductRepository instance = new DapperProductRepository(conn);

            Product productToUpdate = instance.GetProduct(64);
            productToUpdate.Name = "Madonna: Updated Album name";
            productToUpdate.Price = 9.99;

            instance.UpdateProduct(productToUpdate);


            IEnumerable<Product> collection = instance.GetAllProducts();
                    
                      
                        
            foreach (Product item in collection)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Price);
                Console.WriteLine();
            }


        }
    }
}
