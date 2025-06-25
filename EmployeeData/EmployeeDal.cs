using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmployeeData
{
    public class EmployeeDal
    {
        public void InsertEmployee(EmployeeBL emp)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=CompanyDB;Integrated Security=True;Encrypt=False"))
            {
                SqlCommand cmd=new SqlCommand("InsertEmployeeSai",connection);
                cmd.CommandType=CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
                cmd.Parameters.AddWithValue("@Email", emp.Email);
                cmd.Parameters.AddWithValue("@Mobile", emp.Mobile);
                cmd.Parameters.AddWithValue("@CountryID", emp.CountryID);
                cmd.Parameters.AddWithValue("@StateId", emp.StateID);
                connection.Open();
                cmd.ExecuteNonQuery();
            }

        }
    }
}