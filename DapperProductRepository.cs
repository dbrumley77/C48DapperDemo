using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C48DapperDEmo
{
    internal class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;
        public DapperProductRepository(IDbConnection connection)
        {
                _connection = connection;
        }
        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO products (Name, Price, CategoryID) VALUES (@name, @price, @categoryID;",
                new {name = name, price = price, categoryID = categoryID});
        }

        public void DeleteProduct(int id)
        {
           _connection.Execute("DELETE FROM sales WHERE ProductID = @id", new { id = id });
           _connection.Execute("DELETE FROM reviews WHERE ProductID = @id", new { id = id });
           _connection.Execute("DELETE FROM products WHERE ProductID = @id", new { id = id });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products;");
        }

        public Product GetProduct(int id)
        {
            return _connection.QuerySingle<Product>("SELECT * FROM products WHERE productID = @id;", new {id = id});
        }

        public void UpdateProduct(Product product)
        {
            _connection.Execute("UPDATE products SET name = @name," +
                " Price = @price, " +
                "CategoryID = @categoryID, " +
                "OnSale = @onsale, " +
                "StockLevel = @stockLevel " +
                "WHERE ProductID = @id;",
                new 
                { 
                  id = product.ProductID, 
                  name = product.Name, 
                  price = product.Price, 
                  categoryID = product.CategoryID, 
                  onSale = product.OnSale, 
                  stockLevel = product.StockLevel, 
                }); 


                
        }
    }




}
