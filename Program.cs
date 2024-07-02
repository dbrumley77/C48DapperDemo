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


            DapperDepartmentRepository instance = new DapperDepartmentRepository(conn);
            IEnumerable<Department> collection = instance.GetAllDepartments();

            foreach (Department item in collection)
            {
                Console.WriteLine(item.DepartmentID);
                Console.WriteLine(item.Name);
                Console.WriteLine();
            }
        }
    }
}
