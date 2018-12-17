using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;
using System.Text;
using System.Reflection;
using System.DirectoryServices.AccountManagement;

////////////////////////// Developed by Eddie Kim on 9/15/2018 //////////////////////////
////////////////////////// Updated by Eddie Kim on 9/20/2018 2:56PM //////////////////////////
////////////////////////// Updated by Eddie Kim on 12/17/2018 //////////////////////////
///
public partial class _Default : System.Web.UI.Page
{
    protected DirectorySearcher searchUser = new DirectorySearcher(adConnector.Get_AD_Entry());
    protected DirectorySearcher searchManager = new DirectorySearcher(adConnector.Get_MGR_Entry());
    protected DirectorySearcher searchLDS = new DirectorySearcher(adConnector.Get_LDS_Entry());

    protected void Page_Load(object sender, EventArgs e)
    {        
        
        if (!Page.IsPostBack)
        {
            txtSearch.Text = null;
            txtSearch.Focus();
            ddlOption.SelectedIndex = 0;
            pnlResult.Visible = false;
            lblError.Text = null;
        }
    }

    protected void ddlOption_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtSearch.Text = null;
        pnlResult.Visible = false;
        lblError.Text = null;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
        {
            string controller = context.ConnectedServer;
            if (controller != null)
            {
                LblLogonServer.Text = controller.Replace(".global.baxter.com", "");
            }
            else
            {
                LblLogonServer.Text = "NA";
            }
        }
        using (searchUser)
        {
            try
            {
                searchUser.Filter = "(&(objectCategory=user)(" + ddlOption.SelectedValue.ToString() + "=" + txtSearch.Text.Trim() + "))";
                searchUser.PropertiesToLoad.Add("accountExpires");
                searchUser.PropertiesToLoad.Add("distinguishedName");                
                searchUser.PropertiesToLoad.Add("lastLogon");
                searchUser.PropertiesToLoad.Add("lockoutTime");
                searchUser.PropertiesToLoad.Add("pwdLastSet");
                searchUser.PropertiesToLoad.Add("userAccountControl");
                searchUser.PropertiesToLoad.Add("whenCreated");
                searchUser.PropertiesToLoad.Add("displayName");
                searchUser.PropertiesToLoad.Add("employeeType");
                searchUser.PropertiesToLoad.Add("sAMAccountName");
                searchUser.PropertiesToLoad.Add("employeeNumber");
                searchUser.PropertiesToLoad.Add("mail");
                searchUser.PropertiesToLoad.Add("sn");
                searchUser.PropertiesToLoad.Add("givenName");
                searchUser.PropertiesToLoad.Add("manager");

                foreach (SearchResult result in searchUser.FindAll())
                {
                    if (result != null)
                    {
                        pnlResult.Visible = true;
                        ResultPropertyCollection res = result.Properties;
                                                  
                        if (res["sn"] != null)
                        {
                            lblFirstName.Text = res["sn"][0].ToString();
                        }
                        else
                        {
                            lblFirstName.Text = null;
                        }
                        if (res["givenName"] != null)
                        {
                            lblLastName.Text = res["givenName"][0].ToString();
                        }
                        else
                        {
                            lblLastName.Text = null;
                        }
                        if (res["displayName"] != null)
                        {
                            lblDispName.Text = res["displayName"][0].ToString();
                        }
                        else
                        {
                            lblDispName.Text = null;
                        }
                        if (res["sAMAccountName"] != null)
                        {
                            lblUid.Text = res["sAMAccountName"][0].ToString();
                        }
                        else
                        {
                            lblUid.Text = null;
                        }
                        if (res["employeeNumber"] != null)
                        {
                            lblEmpNum.Text = res["employeeNumber"][0].ToString();
                        }
                        else
                        {
                            lblEmpNum.Text = null;
                        }
                        if (res["mail"] != null)
                        {
                            lblEmail.Text = res["mail"][0].ToString();
                        }
                        else
                        {
                            lblEmail.Text = null;
                        }
                        if (res["manager"] != null)
                        {
                            string strManager = res["manager"][0].ToString();
                            string[] ManagerSplit = new string[6];
                            ManagerSplit = strManager.Split(new char[] { ',' }, 6);
                            string strRts = ManagerSplit[0].Remove(0, 3);

                            using (searchManager)
                            {
                                try
                                {
                                    searchManager.Sort.PropertyName = "cn";
                                    searchManager.Filter = "(cn=" + strRts + ")";
                                    foreach (SearchResult ResultsManager in searchManager.FindAll())
                                    {
                                        ResultPropertyCollection resManager = ResultsManager.Properties;
                                        if (res["displayName"] != null)
                                        {
                                            lblMgr.Text = resManager["displayName"][0].ToString();
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    lblMgr.Text = ex.Message;
                                }
                            }
                        }
                        else
                        {
                            lblMgr.Text = null;
                        }
                        if (res["EmployeeType"] != null)
                        {
                            lblEmpType.Text = res["EmployeeType"][0].ToString();
                            if (res["EmployeeType"][0].ToString().Equals("Contractor"))
                            {
                                long strAccountExpires = (long)res["accountExpires"][0];
                                DateTime dateExpires = DateTime.FromFileTime(strAccountExpires);

                                lblExpires.Text = string.Format("{0:d MMM yyyy}", dateExpires);
                            }
                            else
                            {
                                lblExpires.Text = "Never";
                            }
                        }
                        else
                        {
                            lblEmpType.Text = null;

                        }
                        if (res["whenCreated"] != null)
                        {
                            lblAccountCreated.Text = res["whenCreated"][0].ToString();
                        }
                        else
                        {
                            lblAccountCreated.Text = null;

                        }
                        if (res["pwdLastSet"] != null)
                        {
                            long strPassLast = (long)res["pwdLastSet"][0];
                            DateTime dateLastset = DateTime.FromFileTime(strPassLast);
                            DateTime dateExpires120 = dateLastset.AddDays(120);

                            lblPwdReset.Text = dateLastset.ToString("d MMM yyyy") + " (Expires on " + dateExpires120.ToString("d MMM yyyy") + ")";
                        }
                        else
                        {
                            lblPwdReset.Text = null;
                        }
                        if (res["userAccountControl"] != null)
                        {
                            if (res["userAccountControl"][0].ToString().Equals("514") || res["userAccountControl"][0].ToString().Equals("546"))
                            {
                                lblAccountStatus.Text = "Account Disabled";
                            }
                            else if (res["userAccountControl"][0].ToString().Equals("512"))
                            {
                                lblAccountStatus.Text = "Active";
                            }
                            else if (res["userAccountControl"][0].ToString().Equals("16"))
                            {
                                lblAccountStatus.Text = "LOCKOUT";
                            }
                            else if (res["userAccountControl"][0].ToString().Equals("8388608"))
                            {
                                lblAccountStatus.Text = "PASSWORD EXPIRED";
                            }
                        }
                        else
                        {
                            lblAccountStatus.Text = null;

                        }
                        //Displaing AD Account lockout                        
                        string strDistNameLockOut = res["distinguishedName"][0].ToString();
                        DirectoryEntry ALentry = new DirectoryEntry("LDAP://" + strDistNameLockOut);
                        ALentry.Username = @"global\USRL-AutoRABIT-ADMIN";
                        ALentry.Password = "Auto123!";

                        object ads = ALentry.NativeObject;
                        Type type = ads.GetType();
                        bool isLocked = (bool)type.InvokeMember("IsAccountLocked", BindingFlags.GetProperty, null, ads, null);

                        if ((bool)isLocked == true)
                        {
                            lblLockout.Text = "<font color=red>Locked Out</font>";
                        }
                        else
                        {
                            lblLockout.Text = "<font color=green>Not Locked</font>";
                        }                       
                    }
                    else
                    {
                        pnlResult.Visible = false;                        
                    }
                }
            }
            catch (Exception ex)
            {
                pnlResult.Visible = false;
                lblError.Text = ex.Message;
            }
        }

        using (searchLDS)
        {
            //try
            //{
            //    searchLDS.Filter = "(&(objectCategory=person)(objectClass=user)(cn=kimy6))";
            //    searchLDS.PropertiesToLoad.Add("BAX-hasMail");

            //    foreach (SearchResult resultLDS in searchLDS.FindAll())
            //    {
            //        if (resultLDS != null)
            //        {
            //            pnlResult.Visible = true;
            //            ResultPropertyCollection resLDS = resultLDS.Properties;

            //            if (resLDS["BAX-hasMail"] != null)
            //            {
            //                Response.Write(resLDS["BAX-hasMail"][0].ToString());
            //            }
            //            else
            //            {
            //                //lblFirstName.Text = null;
            //            }
            //        }
            //    }
            //}
            //catch (Exception Ex)
            //{
            //    Response.Write(Ex);
            //}
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtSearch.Text = null;
        ddlOption.SelectedIndex = 0;
        pnlResult.Visible = false;
        lblError.Text = null;
    }
}