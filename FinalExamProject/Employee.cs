using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace FinalExamProject
{
    public class Employee
    {
        // Database Connection String 
        public static string connectionStr = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;";


        public Employee() {
            
        }
        // Retrive all the employee records using disconnected model
        public DataTable getAllEmployees()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionStr);

            // Query to fetch all the employee details from the employee table
            string selectQuery = "Select EmployeeID, FirstName, LastName,Title, City from Employee";


            // Creating a SQL adapter object
            SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, connectionStr);


            // Creating a dataset
            DataSet dataSet = new DataSet();


            // Filling the adapter values
            adapter.Fill(dataSet, "Employee");

            DataTable employees = dataSet.Tables["Employee"];
            return employees;
        }

        // Search employee by searchText
        // This method helps to search name based on FirstName,LastName,FirstName+' '+LastName
        public DataTable searchEmployeeByEmployeeName(string searchText)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionStr);

            // Query to fetch all the employee details from the employee table based on search criteria
            string searchQuery = "SELECT EmployeeID, FirstName, LastName,Title, City from Employee WHERE FirstName LIKE @searchText OR LastName LIKE @searchText OR (FirstName+' '+LastName) LIKE @searchText";

            // Creating a SQL adapter object
            SqlDataAdapter adapter = new SqlDataAdapter(searchQuery, connectionStr);

            // Updating the query with dynamic search value
            adapter.SelectCommand.Parameters.AddWithValue("@searchText", $"%{searchText}%");

            // Creating a dataset
            DataSet dataSet = new DataSet();

            // Filling the adapter values
            adapter.Fill(dataSet, "Employee");

            DataTable employees = dataSet.Tables["Employee"];
            return employees;
        }

    }
}
