using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using Dapper;
using System.Data.SqlClient;

namespace WebApi.Repository
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        IConfiguration _configuration;

        public EmployeeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection() =>
                    _configuration.GetConnectionString("ProductContext");

        public int Add(Employee employee)
        {
            int count = 0;
            using (var con = new SqlConnection(GetConnection()))
            {
                try
                {
                    con.Open();
                    var query = "Insert into Employees(FirstName,LastName,Age,Status) Values(@FirstName,@LastName,@Age,@Status)";
                    count = con.Execute(query, employee);
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
                    var query = "Delete from Employees where Id=@Id";
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
            }
            return count;
        }

        public int Edit(Employee employee, int id)
        {
            employee.Id = id;
            int count = 0;
            employee.ModifiedDate = DateTime.Now;
            using (var con = new SqlConnection(GetConnection()))
            {
                try
                {
                    con.Open();
                    var query = "Update Employees Set FirstName=@FirstName,LastName=@LastName,Age=@Age,Status=@Status,ModifiedDate=@ModifiedDate where Id=@Id";
                    count = con.Execute(query, employee);
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

        public Employee Get(int id)
        {
            var employee = new Employee();
            using (var con = new SqlConnection(GetConnection()))
            {
                try
                {
                    con.Open();
                    var query = "Select * from Employees where Id=@Id";
                    employee = con.QueryFirstOrDefault<Employee>(query, new { Id = id });
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
            return employee;
        }

        public List<Employee> GetAll()
        {
            var employees = new List<Employee>();

            using (var con = new SqlConnection(GetConnection()))
            {
                try
                {
                    con.Open();
                    var query = "Select * from Employees";
                    employees = con.Query<Employee>(query).ToList();
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

            return employees;
        }
    }
}
