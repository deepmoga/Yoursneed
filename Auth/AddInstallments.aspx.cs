using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;
public partial class Auth_AddInstallments : System.Web.UI.Page
{
    SQLHelper objsql = new SQLHelper();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        using (TransactionScope ts=new TransactionScope ())
        {
            int end = int.Parse(ddlinst.SelectedItem.Value);
            for (int i = 1; i <= end; i++)
            {
                objsql.ExecuteNonQuery("insert into installments(regno,installment,amount,dated) values('" + txtregid.Text + "','1','" + txtamnt.Text + "','" + System.DateTime.Now + "')");
            }
            ts.Complete();
            ts.Dispose();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Successfully ')", true);
        }

    }

    protected void txtregid_TextChanged(object sender, EventArgs e)
    {
        lblname.Text = Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + txtregid.Text + "'"));
        if (lblname.Text == "")
        {
            lblname.Text = "No Data Found";
            btnsubmit.Enabled = false;
        }
        else
        {
            btnsubmit.Enabled = true;
        }
    }
}