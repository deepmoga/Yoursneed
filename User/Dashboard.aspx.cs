using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Dashboard : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    public string regno, name, father, date, address, gender, phn, marital;
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }
    protected void bind()
    {
        dt = objsql.GetTable("select * from usersnew where regno='" + Session["user"] + "'");
        if (dt.Rows.Count > 0)
        {
            regno = dt.Rows[0]["regno"].ToString();
            name = dt.Rows[0]["fname"].ToString();
            father= dt.Rows[0]["lname"].ToString();
            date = dt.Rows[0]["joined"].ToString();
            address = dt.Rows[0]["add1"].ToString();
            gender = dt.Rows[0]["sex"].ToString();
            phn = dt.Rows[0]["mobile"].ToString();
            marital = dt.Rows[0]["marital"].ToString();

        }
    }
}