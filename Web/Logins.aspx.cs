using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Laghaee.Entity;
using Laghaee.DataAccessLayer;
using Laghaee.DataAccess;

public partial class Logins : System.Web.UI.Page
{
    private const string AuthResultSession = "chngpass";

    protected void ctrlLogin_Authenticate(object sender, AuthenticateEventArgs e)
    {
        try
        {
            string redirectAddress = string.Empty;

            if (ClsLoginManager.Login(ctrlLogin.UserName, ctrlLogin.Password, this))
            {
                e.Authenticated = true;

                if (ClsLoginManager.RedirectAddress != string.Empty)
                {
                    redirectAddress = ClsLoginManager.RedirectAddress;
                    ClsLoginManager.RedirectAddress = string.Empty;
                    Response.Redirect(redirectAddress);
                }
            }
            else
            {
                e.Authenticated = false;

            }
        }
        catch(Exception ex)
        {
            ClsCommon.ShowMessage(this, 
                                  MessageType.Error, "An error has been occurred during login process, Please try again.",
                                  ex);
        }
    }

    protected void ctrlChangePassword_ChangingPassword(object sender, LoginCancelEventArgs e)
    {
        try
        {
            ClsLoginManager.AuthenticationResult eResult = ClsLoginManager.AuthenticationResult.None;

            eResult = ClsLoginManager.ChangePassword(ctrlChangePassword.CurrentPassword,
                                                     ctrlChangePassword.NewPassword,
                                                     this);

            Page.Session[AuthResultSession] = eResult;

            if (eResult == ClsLoginManager.AuthenticationResult.PasswordChanged)
                Response.Redirect("Logins.aspx");
            else
            {
                switch (eResult)
                {
                    case ClsLoginManager.AuthenticationResult.PasswordMismatch:
                        ClsCommon.ShowMessage(this, MessageType.Error, "Current password is not match the original password.Please try again!");
                        break;

                    case ClsLoginManager.AuthenticationResult.Failed:
                        ClsCommon.ShowMessage(this, MessageType.Error, "An error has been occurred during changing password.");
                        break;
                }
            }
            
            e.Cancel = !(eResult == ClsLoginManager.AuthenticationResult.PasswordChanged);
            
        }
        catch
        {
            ClsCommon.ShowMessage(this, MessageType.Error, "An error has been occurred during changing password.");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            ClsLoginManager.AuthenticationResult eAuthResult = ClsLoginManager.AuthenticationResult.None;

            if (ClsCommon.AuthenticatePage(this, true))
            {
                object objAuthResult = Session[AuthResultSession];

                if (objAuthResult != null)
                    eAuthResult = (ClsLoginManager.AuthenticationResult)objAuthResult;

                switch (eAuthResult)
                {
                    case ClsLoginManager.AuthenticationResult.PasswordChanged:
                        ClsCommon.ShowMessage(this, MessageType.Info, "Password has been changed successfully.");
                        break;

                    case ClsLoginManager.AuthenticationResult.PasswordMismatch:
                        ClsCommon.ShowMessage(this, MessageType.Error, "Current password is not match the original password.Please try again!");
                        break;

                    case ClsLoginManager.AuthenticationResult.Failed:
                        ClsCommon.ShowMessage(this, MessageType.Error, "An error has been occurred during changing password.");
                        break;
                }
                
                if ((eAuthResult != ClsLoginManager.AuthenticationResult.PasswordChanged ) &&
                    Request.QueryString.Count > 0 && Request.QueryString.Get(AuthResultSession) != null)
                {
                    divChangePassword.Visible = true;
                    divWelcome.Visible = false;
                }
                else
                {
                    Session[AuthResultSession] = ClsLoginManager.AuthenticationResult.None;

                    divChangePassword.Visible = false;
                    divWelcome.Visible = true;
                }
            }
            else
            {
                divWelcome.Visible = false;
                divChangePassword.Visible = false;
            }

            divLogin.Visible = !divWelcome.Visible && !divChangePassword.Visible;

            if (!IsPostBack)
            {
                if (divWelcome.Visible)
                    welcomeMessage.InnerText = "Welcom " + ClsLoginManager.GetLoggedOnUserName(this);
            }
        }
        catch
        {
            ClsCommon.ShowMessage(this, MessageType.Error, "An error has been occurred during loading the login form. Please try again.");
        }
    }

}

