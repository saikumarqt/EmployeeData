using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeData
{
    public partial class Employee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CountryBind();
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            CountryBind();

        }

        private static void CountryBind()
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CompanyDB;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT CountryName FROM tblCountrySai", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}