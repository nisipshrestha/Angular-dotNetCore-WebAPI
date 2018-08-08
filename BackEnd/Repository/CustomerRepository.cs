using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repository
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
    }

    public class CustomerRepository : ICustomerRepository
    {
        IConfiguration _configuration;

        public CustomerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GetConnection() =>
            _configuration.GetConnectionString("ProductContext");

        public int Add(Customer customer)
        {
            int count = 0;
            using (var con = new SqlConnection(GetConnection()))
            {
                try
                {
                    con.Open();
                    var query = "Insert into Customers(FirstName,LastName,Age,Status) Values(@FirstName,@LastName,@Age,@Status)";
                    count = con.Execute(query, customer);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
            return count;
        }

        public int Delete(int id)
        {
            int count = 0;
            using (var con = new SqlConnection(GetConnection()))
            {
                try
                {
                    con.Open();
                    var query = "Delete from Customers where Id=@Id";
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

        public int Edit(Customer customer, int id)
        {
            customer.Id = id;
            int count = 0;
            customer.ModifiedDate = DateTime.Now;

            using (var con = new SqlConnection(GetConnection()))
            {
                try
                {
                    con.Open();
                    var query = "UPDATE Customers SET FirstName=@FirstName,LastName=@LastName,Age=@Age,Status=@Status,ModifiedDate=@ModifiedDate WHERE Id=@Id";
                    con.Execute(query, customer);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return count;
        }

        public List<Customer> GetAll()
        {
            var customers = new List<Customer>();
            using (var con = new SqlConnection(GetConnection()))
            {
                try
                {
                    con.Open();
                    var query = "Select * from Customers";
                    customers = con.Query<Customer>(query).ToList();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return customers;
            }
        }

        public Customer Get(int id)
        {
            var customer = new Customer();
            using (var con = new SqlConnection(GetConnection()))
            {
                try
                {
                    con.Open();
                    var query = "Select * from Customers where Id=@Id";
                    customer = con.Query<Customer>(query, new { Id = id }).FirstOrDefault();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return customer;
            }
        }
    }
}
