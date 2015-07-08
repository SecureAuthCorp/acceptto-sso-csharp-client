using Acceptto.MFA.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Acceptto.Sample.Web
{
    public partial class Callback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["channel"] == null || Session["email"] == null)
            {
                lblStatus.Text = "Your Session is expired!";
                return;
            }

            string uid = ConfigurationManager.AppSettings.Get("uid").ToString();
            string secret = ConfigurationManager.AppSettings.Get("secret").ToString();
            string callbackurl = ConfigurationManager.AppSettings.Get("callbackurl").ToString();
            IMFAProvider mfaProvider = new AccepttoMFAProvider(uid, secret);
            string status = mfaProvider.Check(Session["channel"].ToString(), Session["email"].ToString());
            lblStatus.Text = status;
            if (status == "approved")
            {
                // You can sign in the user here
            }
            else
            {
                // You should sign out the user status is "rejected" or "expired"
            }
        }
    }
}