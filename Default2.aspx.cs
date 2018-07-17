using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    string constring = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(constring))
        {

            using (SqlCommand cmd = new SqlCommand("VAL_DOWNLINE", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PID", 1053);           // sponser id
                cmd.Parameters.AddWithValue("@ID", 1054);                            // node
                cmd.Parameters.Add("@Down", SqlDbType.VarChar, 30);
                cmd.Parameters["@Down"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                string a = cmd.Parameters["@Down"].Value.ToString();

            }

        }
    }
}