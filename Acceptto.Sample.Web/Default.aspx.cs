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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            bool yourOwnAuthMechanism = true; // Replace this with your own authentication mechanism

            if (yourOwnAuthMechanism) // If your authentication succeed now you can autenticate with Acceptto
            {
                // Checkout this guide in order to create your own Application Integration on Acceptto Dashboard:
                // https://acceptto.com/docs/general_api
                // Then owerwrite this uid and secret in AppSettings with your own application uid and secret.
                string uid = ConfigurationManager.AppSettings.Get("uid").ToString();
                string secret = ConfigurationManager.AppSettings.Get("secret").ToString();
                string callbackurl = ConfigurationManager.AppSettings.Get("callbackurl").ToString();
                IMFAProvider mfaProvider = new AccepttoMFAProvider(uid, secret);
                if (!mfaProvider.IsUserValid(txtEmail.Text))
                {
                    this.ClientAlert("Invalid email address, your email address should be the same email you registered with on Acceptto mobile app.");
                    return;
                }

                string channel = mfaProvider.Authenticate("Acceptto CSharp client wishes to authenticate!", txtEmail.Text, 120, "Login");
                Session["channel"] = channel;
                Session["email"] = txtEmail.Text;
                Response.Redirect(String.Format("https://mfa.acceptto.com/mfa/index?channel={0}&callback_url={1}", channel, callbackurl));
            }
            else
            {
                this.ClientAlert("Invalid Username and Password.");
            }
        }

        private void ClientAlert(string text)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "guardFailure", "alert( '" + text + "' );", true);
        }
    }
}