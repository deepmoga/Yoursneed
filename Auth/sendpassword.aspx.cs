using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Auth_sendpassword : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void txtpin_TextChanged(object sender, EventArgs e)
    {
        lblname.Text ="Name: "+ Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + txtpin.Text + "'"));
        lblpass.Text ="Pass: "+ Common.Get(objsql.GetSingleValue("select pass from usersnew where regno='" + txtpin.Text + "'"));
        lblmob.Text ="Mobile: "+ Common.Get(objsql.GetSingleValue("select mobile from usersnew where regno='" + txtpin.Text + "'"));
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {

    }
}