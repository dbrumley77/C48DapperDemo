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


            DapperDepartmentRepository instance2 = new DapperDepartmentRepository(conn);


            IEnumerable<Department> collection = instance2.GetAllDepartments();

            foreach (Department item in collection)
            {
                Console.WriteLine(item.DepartmentID);
                Console.WriteLine(item.Name);
                Console.WriteLine();
            }

            instance2.InsertDepartment("taco");



            DapperProductRepository instance = new DapperProductRepository(conn);

            Product productToUpdate = instance.GetProduct(64);
            productToUpdate.Name = "Madonna: Updated Album name";
            productToUpdate.Price = 9.99;

            instance.UpdateProduct(productToUpdate);


            IEnumerable<Product> collectionP = instance.GetAllProducts();



            foreach (Product item in collectionP)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Price);
                Console.WriteLine();
            }


        }
    }
}
