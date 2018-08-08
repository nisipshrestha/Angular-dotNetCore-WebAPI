using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace WebApi.Repository
{

    public interface IProductRepository : IGenericRepository<Product>
    {
    }

    public class ProductRepository : IProductRepository
    {
        IConfiguration _configuration;

        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GetConnection() =>
                     _configuration.GetConnectionString("ProductContext");

        public int Add(Product product)
        {
            int count = 0;
            using (var con = new SqlConnection(GetConnection()))
            {
                try
                {
                    con.Open();
                    var query = "INSERT INTO Products(Name, Model, Price) VALUES(@Name, @Model, @Price)";
                    count = con.Execute(query, product);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }

        public int Delete(int id)
        {
            var connectionString = this.GetConnection();
            var count = 0;

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "Delete FROM Products WHERE Id=@Id";
                    count = con.Execute(query, new { Id = id });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return count;
            }
        }

        public int Edit(Product product,int id)
        {
            product.Id = id;
            var count = 0;

            using (var con = new SqlConnection(GetConnection()))
            {
                try
                {
                    con.Open();
                    var query = "UPDATE Products SET Name = @Name, Model = @Model, Price = @Price WHERE Id = @Id";
                    count = con.Execute(query, product);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return count;
            }
        }

        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();

            using (var con = new SqlConnection(GetConnection()))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Products";
                    products = con.Query<Product>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return products;
            }
        }

        public Product Get(int id)
        {
            Product product = new Product();

            using (var con = new SqlConnection(GetConnection()))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Products WHERE Id =@Id";
                    product = con.QueryFirstOrDefault<Product>(query, new { Id = id });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return product;
            }
        }

    }
}
