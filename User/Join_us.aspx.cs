using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;
public partial class User_Join_us : System.Web.UI.Page
{
    public static string pin = "", sponser = "",pintype="", newregno="",pass="",lastdata;
    SQLHelper objsql = new SQLHelper();
    string constring = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
    public static Boolean proposalstatus = false;
    public int lefdirect = 0, rightdirect = 0, left = 0, right = 0;
    Common cm = new Common();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["pin"] != null || Request.QueryString["sponser"] != null)
            {
                pin = Request.QueryString["pin"].ToString();
                sponser = Request.QueryString["sponser"].ToString();
                txtsponserid.Text = sponser;
                lblsponsername.Text = Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + sponser + "'"));
                lblleafnode.Text =lastnode(sponser);
                pintype = Common.Get(objsql.GetSingleValue("select pintype from pins where pin='" + pin + "'"));
                lastdata = lastnode(sponser);
            }
        }
    }

    #region Check Valid Upline
    protected void txtproposerid_TextChanged(object sender, EventArgs e)
    {

        using (SqlConnection con = new SqlConnection(constring))
        {
            using (SqlCommand cmd = new SqlCommand("VAL_DOWNLINE", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PID", txtproposerid.Text.Trim());         // proposer id
                cmd.Parameters.AddWithValue("@ID", txtsponserid.Text.Trim());                             // sponser id
                cmd.Parameters.Add("@Down", SqlDbType.VarChar, 30);
                cmd.Parameters["@Down"].Direction = ParameterDirection.Output;  // outpur parameter
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                string check = cmd.Parameters["@Down"].Value.ToString();
                if (check == "")
                {
                    lblproposername.Text = "Proposer is Not Vaid in up line";
                }
                else
                {
                    lblproposername.Text = Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + txtproposerid.Text + "'"));
                    proposalstatus = true;
                    lblleafnode.Text = lastnode(sponser);
                }
                //  lblFruitName.Text = "Last Node: " + cmd.Parameters["@printvalue"].Value.ToString();
            }
        }
    } 
    #endregion

    protected string lastnode(string sponser)
    {
        using (SqlConnection con = new SqlConnection(constring))
        {
           
                using (SqlCommand cmd = new SqlCommand("LastNode", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", txtsponserid.Text.Trim());           // sponser id
                    cmd.Parameters.AddWithValue("@node", rdonode.SelectedItem.Value);                            // node
                    cmd.Parameters.Add("@printvalue", SqlDbType.VarChar, 30);
                    cmd.Parameters["@printvalue"].Direction = ParameterDirection.Output;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return cmd.Parameters["@printvalue"].Value.ToString();
                   
                }
            
        }
    }

    protected void rdonode_TextChanged(object sender, EventArgs e)
    {
        lblleafnode.Text =lastnode(sponser);
       // lastdata = lastnode(sponser);
    }

    protected void btnjoin_Click(object sender, EventArgs e)
    {
        using (TransactionScope ts=new TransactionScope ())
        {
            try
            {
                if (proposalstatus == true)
                {
                    // insert in usersnew table
                    // sregno= lastnode
                    //spillsregno = sponser
                     newregno = cm.GenerateRegno();
                     pass = cm.Generatepass();
                    objsql.ExecuteNonQuery("insert into usersnew(regno,pass,fname,lname,dob,add1,city,pin,state,country,mobile,nomirel,sregno,node,status,joined,grace,spillsregno,updated,updatepin,pintypeid,aadharcard,proposerregno,relation,Active) values('" + newregno + "','" + pass + "','" + txtname.Text + "','" + txtrelation.Text + "','" + dob() + "','" + txtadd.Text + "','" + txtcity.Text + "','" + txtpincode.Text + "','" + txtstate.Text + "','" + txtcountry.Text + "','" + txtphn.Text + "','" + txtnominee.Text + "','"+ lastnode(sponser) + "','"+rdonode.SelectedItem.Value+"','y','"+DateTime.Now+"','10','"+sponser+"','n','"+pin+"','"+pintype+"','"+txtaadhar.Text+"','"+txtproposerid.Text+"','"+ddlrelation.SelectedItem.Text+"','1')");
                    // joining installment
                    objsql.ExecuteNonQuery("insert into installments(regno,installment,amount,dated,paidby) values('" + newregno + "','1','1000','" + DateTime.Now + "','')");
                    objsql.ExecuteNonQuery("update pins set status='y',subregno='" + newregno+"' where pin='" + pin + "'");
                    #region insert in leg table
                    string countleafnode = Common.Get(objsql.GetSingleValue("select regno from legs where regno='" + newregno + "'"));

                    

                        if (rdonode.SelectedItem.Value == "one")
                        {
                            objsql.ExecuteNonQuery("insert into legs(regno,leftleg,rightleg,leftdirect,rightdirect)values('" + newregno + "','0','0','0','0')");

                        }
                        else
                        {
                            objsql.ExecuteNonQuery("insert into legs(regno,leftleg,rightleg,leftdirect,rightdirect)values('" + newregno + "','0','0','0','0')");


                        }
                    


                    #endregion
                    #region Update Legs
                    DataTable dt = new DataTable();
                    dt = objsql.GetTable("select * from legs where regno='" + txtsponserid.Text + "'");
                    if (dt.Rows.Count > 0)
                    {
                        if (txtsponserid.Text!="")        // direct 
                        {
                            if (rdonode.SelectedItem.Value == "one")
                            {
                                int getdirect = int.Parse(Common.Get(objsql.GetSingleValue("select leftdirect from legs where regno='" + txtsponserid.Text + "'")));
                                
                                    getdirect += 1;
                                    objsql.ExecuteNonQuery("update legs set leftdirect='" + getdirect + "' where regno='" + txtsponserid.Text + "'");
                               

                            }
                            else
                            {
                                rightdirect = int.Parse(Common.Get(objsql.GetSingleValue("select rightdirect from legs where regno='" + txtsponserid.Text + "'")));
                                rightdirect += 1;
                                objsql.ExecuteNonQuery("update legs set rightdirect='" + rightdirect + "' where regno='" + txtsponserid.Text + "'");

                            }
                            using (SqlConnection con = new SqlConnection(constring))
                            {

                                using (SqlCommand cmd = new SqlCommand("EveryNode", con))
                                {
                                    string check = lastdata;
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@id", lblleafnode.Text);           // sponser id
                                    cmd.Parameters.AddWithValue("@node", rdonode.SelectedItem.Value);                            // node
                                    cmd.Parameters.AddWithValue("@checkid", lblleafnode.Text);
                                    cmd.Parameters.Add("@printvalue", SqlDbType.VarChar, 30);
                                    cmd.Parameters["@printvalue"].Direction = ParameterDirection.Output;
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                    string a = cmd.Parameters["@printvalue"].Value.ToString();

                                }

                            }
                        }
                        //else
                        //{
                        //    if (rdonode.SelectedItem.Value == "one")
                        //    {
                        //        left = int.Parse(Common.Get(objsql.GetSingleValue("select leftleg from legs where regno='" + sponser + "'")));
                        //        if (left >= 0)
                        //        {
                        //            left += 1;
                        //            objsql.ExecuteNonQuery("update legs set leftleg='" + left + "' where regno='" + sponser + "'");
                        //        }

                        //    }
                        //    else
                        //    {
                        //        right = int.Parse(Common.Get(objsql.GetSingleValue("select rightleg from legs where regno='" + sponser + "'")));
                        //        right += 1;
                        //        objsql.ExecuteNonQuery("update legs set rightleg='" + right + "' where regno='" + sponser + "'");

                        //    }
                        //}
                    }
                    #endregion
                    //string msz = " Welcome to YNTC.You name "+txtname+", id is "+newregno+" and password is "+pass+".Login to www.yoursneed.com and Thank you for joining us.";
                    //if (txtphn.Text != null)
                    //{
                    //    objsql.SendSMS("", "", txtphn.Text, msz);
                    //}
                }
                ts.Complete();
                ts.Dispose();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Thank You For Registration ')", true);
                Response.Redirect("welcome.aspx?id=" + newregno + "&pass=" + pass+"&name="+txtname.Text);
                
            }
            catch (Exception a)
            {
                
                string msz = a.Message;
                throw;
            }
        }
    }
    protected string dob()
    {
        return ddlmonth.SelectedItem.Text + "/" + ddlday.SelectedItem.Text + "/" + ddlyear.SelectedItem.Text;
    }

    protected void txtsponserid_TextChanged(object sender, EventArgs e)
    {
        lblsponsername.Text = Common.Get(objsql.GetSingleValue("select fname from usersnew where regno='" + txtsponserid.Text + "'"));
        sponser = txtsponserid.Text;
        lastdata = lastnode(sponser);
        lblleafnode.Text = lastnode(sponser);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
    }
    
}