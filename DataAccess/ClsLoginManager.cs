using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Laghaee.Common;
using DBController.DataAccessLayer;
using Laghaee.DataAccess;


/// <summary>
/// Summary description for ClsLoginManager
/// </summary>
public class ClsLoginManager
{
    public enum UserType
    {
        Anonymous,
        Admin,
        User
    }
    //Lida
    public enum CurrentPage 
    {
        Letters,
        Agents,
        TradeMark,
        Patent,
        Applicant,
        Design
    }



    //Lida

    public enum AuthenticationResult
    {
        None,
        PasswordChanged,
        PasswordMismatch,
        UserAlraedyExists,
        Failed
    }

    #region "Member variables"

    private const string LoginSession = "Login";
    private static string mstrRedirectAddress = string.Empty;

    #endregion 

    public static string RedirectAddress
    {
        get
        {
            return mstrRedirectAddress;
        }
        set
        {
            mstrRedirectAddress = value;
        }
    }

   
    public static AuthenticationResult ChangePassword(string strOldPassword, 
                                                      string strNewPassword,
                                                      Page currentPage)
    {
        ClsUser currentUser ;
        string strQueryString;
        AuthenticationResult eResult = AuthenticationResult.Failed;

        currentUser = GetLoggedOnUser(currentPage );

        if (currentUser !=null)
        {
            if (strOldPassword != currentUser.Password)
            {
                eResult = AuthenticationResult.PasswordMismatch; 
            }
            else
            {
                strQueryString = "Update [{0}] Set {1} = N'{2}' Where {3} = N'{4}' And {1} = N'{5}'";
                strQueryString = string.Format(strQueryString, 
                                               ClsDBConstants.User_TableName ,
                                               ClsDBConstants.User_Col_Password,
                                               strNewPassword.Replace("'", "''"), 
                                               ClsDBConstants.User_Col_UserName ,
                                               currentUser.Name.Replace("'", "''"),
                                               strOldPassword.Replace("'", "''"));

                ClsDBController.Instance.ExecuteNoneQuery(strQueryString);

                eResult = AuthenticationResult.PasswordChanged;
                
                // Update current user's session.
                currentUser.Password = strNewPassword;
                currentPage.Session[LoginSession] = currentUser;
            }
        }
        return eResult;
    }

    public static UserType GetUserType(Page objCurrentPage)
    {
        ClsUser objUser;

        objUser = objCurrentPage.Session[LoginSession] as ClsUser;

        if (objUser != null)
        {
            if (objUser.IsAdmin)
                return UserType.Admin;
            else
                return UserType.User;
        }
        else
        {
            return UserType.Anonymous;
        }
    }

    public static Boolean GetUserAccessOnPage(Page objCurrentPage)
    {
        ClsUser objUser;
        objUser = objCurrentPage.Session[LoginSession] as ClsUser;
        switch (objCurrentPage.ToString())
        {
            case "ASP.agents_aspx":
               {
                  return  objUser.HasAgentAccess;
                   
               }
           case "ASP.attachment_aspx":
               {
                   return objUser.HasAttachmentAccess;

               }
           case "ASP.applicants_aspx":
                {
                    return objUser.HasApplicantAccess;
                   
                }
            case "ASP.design_aspx":
                {
                   return objUser.HasDesignAccess;
                    
                }
            case "ASP.letters_aspx":
                {
                    return objUser.HasLetterAccess;
                   
                }
            case "ASP.patent_aspx":
                {
                    return objUser.HasPatentAccess;
                   
                }
            case "ASP.trademark_aspx":
                {
                    return objUser.HasTradeMarkAccess;
                   
                }              
            default:
            return false ;
        }
    }
   
    public static  bool IsUserLoggedOn(Page objCurrentPage)
    {
        return (objCurrentPage.Session[LoginSession] != null);
    }

    public static ClsUser GetLoggedOnUser(Page objCurrentPage)
    {
        return objCurrentPage.Session[LoginSession] as ClsUser ;
    }

    public static string GetLoggedOnUserName(Page objCurrentPage)
    {
        ClsUser objUser;

        objUser = objCurrentPage.Session[LoginSession] as ClsUser;
 
        return (objUser  != null ? objUser.Name : string.Empty);
    }

    public static void Logout(Page objCurrentPage)
    {
        objCurrentPage.Session[LoginSession] = null;
    }

    public static Boolean Login(string strUserName, string strPassword, Page objCurrentPage )
    {
        string strQueryString = string.Empty;
        ClsUser objUser = null ;
        System.Data.SqlClient.SqlDataReader objReader=null  ;
        try
        {
            strQueryString = "Select * From [{0}] Where [{1}] = N'{2}' And [{3}] = N'{4}'";

            strQueryString = string.Format(strQueryString, 
                                           ClsDBConstants.User_TableName, 
                                           ClsDBConstants.User_Col_UserName,
                                           strUserName.Replace("'", "''"), 
                                           ClsDBConstants.User_Col_Password,
                                           strPassword.Replace("'", "''"));
            objReader = ClsDBController.Instance.ExecuteReader(strQueryString);

            if (objReader.HasRows)
                objUser = new ClsUser();

            if (objReader.Read())
            {
                objUser.UserID = objReader.GetInt32(0);
                objUser.Name = objReader.GetString(1);
                objUser.Password = objReader.GetString(2);
                objUser.EmailAddress = objReader.GetString(3);
                objUser.IsAdmin = objReader.GetBoolean(4);
                objUser.HasLetterAccess = objReader.GetBoolean(5);
                objUser.HasTradeMarkAccess = objReader.GetBoolean(6);
                objUser.HasPatentAccess = objReader.GetBoolean(7);
                objUser.HasAgentAccess = objReader.GetBoolean(8);
                objUser.HasApplicantAccess = objReader.GetBoolean(9);
                objUser.HasDesignAccess = objReader.GetBoolean(10);
                objUser.FirstName = objReader.GetString(11);
                objUser.LastName = objReader.GetString(12);
                objUser.HasAttachmentAccess = objReader.GetBoolean(13);
            }

            if (objUser != null)
            {
                objCurrentPage.Session[LoginSession] = objUser;
                return true;

            }
            else
            {
                return false;

            }
        }
        finally
        {
            if (objReader != null)
                objReader.Close();
        }
    }
}
