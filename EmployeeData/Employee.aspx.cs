using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
            if (!IsPostBack)
            {
                //CountryBind();
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CompanyDB;Integrated Security=True;Encrypt=False");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT CountryID,CountryName FROM tblCountrySai", con);
                SqlDataReader dr = cmd.ExecuteReader();
                ddlCountry.DataSource = dr;
                ddlCountry.DataTextField = "CountryName";
                ddlCountry.DataValueField = "CountryID";
                ddlCountry.DataBind();
                ddlCountry.Items.Insert(0, new ListItem("--Select Country--", "0"));
                con.Close();

                //SqlCommand cm = new SqlCommand("SELECT * FROM tblStateSai", con);
                //con.Open();
                //SqlDataReader dar = cm.ExecuteReader();
                //ddlState.DataSource = dar;
                //ddlState.DataTextField = "StateName";
                //ddlState.DataValueField = "StateId";
                //ddlState.DataBind();
                //ddlState.Items.Insert(0, new ListItem("--Select State--", "0"));
                //con.Close();
            }
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            int countryid=Convert.ToInt32(ddlCountry.SelectedValue);
            BindStatesByCountryID(countryid);
            //CountryBind();
            //SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CompanyDB;Integrated Security=True;Encrypt=False");
            //con.Open();
            //SqlCommand cmd = new SqlCommand("SELECT CountryID,CountryName FROM tblCountrySai", con);
            //SqlDataReader dr = cmd.ExecuteReader();
            //ddlCountry.DataSource = dr;
            //ddlCountry.DataTextField = "CountryName";
            //ddlCountry.DataValueField = "CountryID";
            //ddlCountry.DataBind();
            //ddlCountry.Items.Insert(0, new ListItem("--Select Country--", "0"));
            //con.Close();

            //con.Close();

        }

        private static void CountryBind()
        {
            
        }
        private void BindStatesByCountryID(int countryid)
        {
            //string connstr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CompanyDB;Integrated Security=True;Encrypt=False");
            SqlCommand cmd = new SqlCommand("select stateid,statename from tblStateSai where countryid=@countryid", con);
            cmd.Parameters.AddWithValue("@CountryId", countryid);
            con.Open();
            SqlDataReader dr=cmd.ExecuteReader();
            ddlState.DataSource = dr;
            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "StateId";
            ddlState.DataBind();
            ddlState.Items.Insert(0, new ListItem("--select State--", "0"));
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CompanyDB;Integrated Security=True;Encrypt=False");
          
            //SqlCommand cm = new SqlCommand("SELECT * FROM tblStateSai", con);
            //con.Open();
            //SqlDataReader dar = cm.ExecuteReader();
            //ddlState.DataSource = dar;
            //ddlState.DataTextField = "StateName";
            //ddlState.DataValueField = "StateId";
            //ddlState.DataBind();
            //ddlState.Items.Insert(0, new ListItem("--Select State--", "0"));
            //con.Close();
        }

        protected void ddlCountry_SelectedIndexChanged1(object sender, EventArgs e)
        {
            int countryid = Convert.ToInt32(ddlCountry.SelectedValue);
            BindStatesByCountryID(countryid);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            EmployeeBL emp = new EmployeeBL
            {
                FirstName = txtFirstName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Mobile = txtMobile.Text.Trim(),
                CountryID = Convert.ToInt32(ddlCountry.SelectedValue),
                StateID = Convert.ToInt32(ddlCountry.SelectedValue)
            };
            EmployeeDal dal=new EmployeeDal();
            dal.InsertEmployee(emp);
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=CompanyDB;Integrated Security=True;Encrypt=False");
            SqlDataAdapter da = new SqlDataAdapter("select * from tblEmployeeSai", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            grddata.DataSource = ds;
            grddata.DataBind();


        }
    }
}