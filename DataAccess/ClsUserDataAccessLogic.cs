using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Laghaee.Entity;
using Laghaee.Common;
using DBController.DataAccessLayer;
using Laghaee.DataAccessLayer;


namespace Laghaee.DataAccess
{
    public class ClsUserDataAccessLogic
    {

        public void Insert(ClsUser objUser, bool blnCloseConnection, Page objCurrentPage)
        {
            try
            {
                string strQuery;
                SqlParameter[] arrParams;
                SqlParameter objParam;

                strQuery = "INSERT INTO [dbo].[@TableName@]  " +
                   "([@UserName@],[@Password@],[@EmailAddress@],[@IsAdmin@],[@HasLetterAccess@],[@HasTradeMarkAccess@],[@HasPatentAccess@],[@HasAgentAccess@],[@HasApplicantAccess@],[@HasDesignAccess@],[@FirstName@],[@LastName@],[@HasAttachmentAccess@] ) VALUES(N'@UserName_Value@',N'@Password_Value@',N'@EmailAddress_Value@','@IsAdmin_Value@','@HasLetterAccess_Value@','@HasTradeMarkAccess_Value@','@HasPatentAccess_Value@','@HasAgentAccess_Value@','@HasApplicantAccess_Value@','@HasDesignAccess_Value@',N'@FirstName_Value@',N'@LastName_Value@','@HasAttachmentAccess_Value@')";

                strQuery = strQuery.Replace("@UserName@", ClsDBConstants.User_Col_UserName);
                strQuery = strQuery.Replace("@Password@", ClsDBConstants.User_Col_Password);
                strQuery = strQuery.Replace("@EmailAddress@", ClsDBConstants.User_Col_EmailAddress);
                strQuery = strQuery.Replace("@IsAdmin@", ClsDBConstants.User_Col_Is_Admin);
                strQuery = strQuery.Replace("@HasLetterAccess@", ClsDBConstants.User_Col_HasLetterAccess);
                strQuery = strQuery.Replace("@HasTradeMarkAccess@", ClsDBConstants.User_Col_HasTradeMarkAccess);
                strQuery = strQuery.Replace("@HasPatentAccess@", ClsDBConstants.User_Col_HasPatentAccess);
                strQuery = strQuery.Replace("@HasAgentAccess@", ClsDBConstants.User_Col_HasAgentAccess);
                strQuery = strQuery.Replace("@HasApplicantAccess@", ClsDBConstants.User_Col_HasApplicantAccess);
                strQuery = strQuery.Replace("@HasDesignAccess@", ClsDBConstants.User_Col_HasDesignAccess);
                strQuery = strQuery.Replace("@FirstName@", ClsDBConstants.User_Col_FirstName);
                strQuery = strQuery.Replace("@LastName@", ClsDBConstants.User_Col_LastName);
                strQuery = strQuery.Replace("@HasAttachmentAccess@", ClsDBConstants.User_Col_HasAttachmentAccess);
                strQuery = strQuery.Replace("@TableName@", ClsDBConstants.User_TableName);
                strQuery = strQuery.Replace("@UserName_Value@", objUser.Name.Replace("'", "''"));
                strQuery = strQuery.Replace("@Password_Value@", objUser.Password.Replace("'", "''"));
                strQuery = strQuery.Replace("@EmailAddress_Value@", objUser.EmailAddress.Replace("'", "''"));
                strQuery = strQuery.Replace("@IsAdmin_Value@", objUser.IsAdmin.ToString());
                strQuery = strQuery.Replace("@HasLetterAccess_Value@", objUser.HasLetterAccess.ToString());
                strQuery = strQuery.Replace("@HasTradeMarkAccess_Value@", objUser.HasTradeMarkAccess.ToString());
                strQuery = strQuery.Replace("@HasPatentAccess_Value@", objUser.HasPatentAccess.ToString());
                strQuery = strQuery.Replace("@HasAgentAccess_Value@", objUser.HasAgentAccess.ToString());
                strQuery = strQuery.Replace("@HasApplicantAccess_Value@", objUser.HasApplicantAccess.ToString());
                strQuery = strQuery.Replace("@HasDesignAccess_Value@", objUser.HasDesignAccess.ToString());
                strQuery = strQuery.Replace("@FirstName_Value@", objUser.FirstName.Replace("'", "''"));
                strQuery = strQuery.Replace("@LastName_Value@", objUser.LastName.Replace("'", "''"));
                strQuery = strQuery.Replace("@HasAttachmentAccess_Value@", objUser.HasAttachmentAccess.ToString());

                ClsDBController.Instance.ExecuteNoneQuery(strQuery);

                arrParams = new SqlParameter[2];

                objParam = new SqlParameter();
                objParam.ParameterName = "@TableName";
                objParam.SqlDbType = SqlDbType.NVarChar;
                objParam.Size = 255;
                objParam.Direction = ParameterDirection.Input;
                objParam.SqlValue = ClsDBConstants.User_TableName;
                arrParams[0] = objParam;

                objParam = new SqlParameter();
                objParam.ParameterName = "@ID";
                objParam.SqlDbType = SqlDbType.Int;
                objParam.Direction = ParameterDirection.Output;
                arrParams[1] = objParam;

                ClsDBController.Instance.ExecuteProcedureNonQuery("[dbo].[GetLastTableID]", arrParams);
                ClsLogDataAccessLogic.Insert(ClsLoginManager.GetLoggedOnUser(objCurrentPage).UserID,string.Format("{0:yyyy/MM/dd}", ClsLogDataAccessLogic.GetNowPersianDate()),Convert.ToInt32(ClsLogDataAccessLogic.TransactionType.UserCreated), true);
                objUser.UserID = (int)arrParams[1].Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (blnCloseConnection)
                {
                    ClsDBController.Instance.Close();
                }
            }
        }

        public void Update(ClsUser objUser, bool blnCloseConnection,Page objCurrentPage)
        {
            try
            {
                System.Text.StringBuilder strQuery;
                strQuery = new System.Text.StringBuilder(
                   " Update[dbo].[@TableName@]  " +
                   "    SET    [@UserName@] = N'@UserName_Value@'," +
                   "           [@Password@] = N'@Password_Value@'," +
                   "           [@EmailAddress@] = N'@EmailAddress_Value@'," +
                   "           [@IsAdmin@] =  '@IsAdmin_Value@'," +
                   "           [@HasLetterAccess@] = '@HasLetterAccess_Value@'," +
                   "           [@HasTradeMarkAccess@]='@HasTradeMarkAccess_Value@',"+
                   "           [@HasPatentAccess@]='@HasPatentAccess_Value@',"+
                   "           [@HasAgentAccess@]='@HasAgentAccess_Value@',"+
                   "           [@HasApplicantAccess@]='@HasApplicantAccess_Value@',"+
                   "           [@HasDesignAccess@]='@HasDesignAccess_Value@',"+
                   "           [@FirstName@]=N'@FirstName_Value@',"+
                   "           [@LastName@]=N'@LastName_Value@'," +
                   "           [@HasAttachmentAccess@]='@HasAttachmentAccess_Value@'" +
                   "           Where [@UserID@] = @UserID_Value@");

                strQuery = strQuery.Replace("@UserName@", ClsDBConstants.User_Col_UserName);
                strQuery = strQuery.Replace("@Password@", ClsDBConstants.User_Col_Password);
                strQuery = strQuery.Replace("@EmailAddress@", ClsDBConstants.User_Col_EmailAddress);
                strQuery = strQuery.Replace("@IsAdmin@", ClsDBConstants.User_Col_Is_Admin);
                strQuery = strQuery.Replace("@HasLetterAccess@", ClsDBConstants.User_Col_HasLetterAccess);
                strQuery = strQuery.Replace("@HasTradeMarkAccess@", ClsDBConstants.User_Col_HasTradeMarkAccess);
                strQuery = strQuery.Replace("@HasPatentAccess@", ClsDBConstants.User_Col_HasPatentAccess);
                strQuery = strQuery.Replace("@HasAgentAccess@", ClsDBConstants.User_Col_HasAgentAccess);
                strQuery = strQuery.Replace("@HasApplicantAccess@", ClsDBConstants.User_Col_HasApplicantAccess);
                strQuery = strQuery.Replace("@HasDesignAccess@", ClsDBConstants.User_Col_HasDesignAccess);
                strQuery = strQuery.Replace("@FirstName@", ClsDBConstants.User_Col_FirstName);
                strQuery = strQuery.Replace("@LastName@", ClsDBConstants.User_Col_LastName);
                strQuery = strQuery.Replace("@UserID@", ClsDBConstants.User_Col_ID);
                strQuery = strQuery.Replace("@HasAttachmentAccess@", ClsDBConstants.User_Col_HasAttachmentAccess);
                strQuery = strQuery.Replace("@TableName@", ClsDBConstants.User_TableName);



                strQuery = strQuery.Replace("@UserName_Value@", objUser.Name.Replace("'", "''"));
                strQuery = strQuery.Replace("@Password_Value@", objUser.Password.Replace("'", "''"));
                strQuery = strQuery.Replace("@EmailAddress_Value@", objUser.EmailAddress.Replace("'", "''"));
                strQuery = strQuery.Replace("@IsAdmin_Value@", objUser.IsAdmin.ToString());
                strQuery = strQuery.Replace("@HasLetterAccess_Value@", objUser.HasLetterAccess.ToString());
                strQuery = strQuery.Replace("@HasTradeMarkAccess_Value@", objUser.HasTradeMarkAccess.ToString());
                strQuery = strQuery.Replace("@HasPatentAccess_Value@", objUser.HasPatentAccess.ToString());
                strQuery = strQuery.Replace("@HasAgentAccess_Value@", objUser.HasAgentAccess.ToString());
                strQuery = strQuery.Replace("@HasApplicantAccess_Value@", objUser.HasApplicantAccess.ToString());
                strQuery = strQuery.Replace("@HasDesignAccess_Value@", objUser.HasDesignAccess.ToString());
                strQuery = strQuery.Replace("@FirstName_Value@", objUser.FirstName.Replace("'", "''"));
                strQuery = strQuery.Replace("@LastName_Value@", objUser.LastName.Replace("'", "''"));
                strQuery = strQuery.Replace("@HasAttachmentAccess_Value@", objUser.HasAttachmentAccess.ToString());
                strQuery = strQuery.Replace("@UserID_Value@", objUser.UserID.ToString());

                ClsDBController.Instance.ExecuteNoneQuery(strQuery.ToString());
                ClsLogDataAccessLogic.Insert(ClsLoginManager.GetLoggedOnUser(objCurrentPage).UserID, string.Format("{0:yyyy/MM/dd}", ClsLogDataAccessLogic.GetNowPersianDate()), Convert.ToInt32(ClsLogDataAccessLogic.TransactionType.UserUpdated), true);

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (blnCloseConnection)
                {
                    ClsDBController.Instance.Close();
                }
            }
        }

        public void Delete(ClsUser objUser, bool blnCloseConnection, Page objCurrentPage)
        {
            Delete(objUser.UserID, blnCloseConnection,objCurrentPage);

        }

        public void Delete(int iUserId, bool blnCloseConnection, Page objCurrentPage)
        {
            try
            {
                string strQuery;

                strQuery = "Delete From [dbo].[@TableName@] Where @UserID@ = @UserID_Value@";

                strQuery = strQuery.Replace("@TableName@", ClsDBConstants.User_TableName);
                strQuery = strQuery.Replace("@UserID@", ClsDBConstants.User_Col_ID);
                strQuery = strQuery.Replace("@UserID_Value@", iUserId.ToString());

                ClsDBController.Instance.ExecuteNoneQuery(strQuery);
                ClsLogDataAccessLogic.Insert(ClsLoginManager.GetLoggedOnUser(objCurrentPage).UserID, string.Format("{0:yyyy/MM/dd}", ClsLogDataAccessLogic.GetNowPersianDate()), Convert.ToInt32(ClsLogDataAccessLogic.TransactionType.UserDeleted), true);

            }
            catch (Exception Ex)
            {
                throw (Ex);
            }
            finally
            {
                if (blnCloseConnection)
                {
                    ClsDBController.Instance.Close();
                }
            }
        }
        public DataTable GetAllUsers(string strSortBy, bool blnSortAscending)
        {
            try
            {
                string strQuery;

                strQuery = "SELECT * FROM  [User]";

                if (strSortBy != string.Empty)
                    strQuery += " Order By " + strSortBy + ((blnSortAscending) ? " Asc" : " Desc");

                return ClsDBController.Instance.ExecuteQuery(strQuery);
            }
            finally
            {
                ClsDBController.Instance.Close();
            }
        }
        public ClsUser GetUserByUserID(int iUserID)
        {
            SqlDataReader objReader = null;
            try
            {
                string strQuery;
                ClsUser ObjUsers = null;

                strQuery = "Select * From [{0}] Where {1}={2}";

                strQuery = string.Format(strQuery,
                                         ClsDBConstants.User_TableName,
                                         ClsDBConstants.User_Col_ID, iUserID);

                objReader = ClsDBController.Instance.ExecuteReader(strQuery);

                if (objReader.Read())
                {
                    ObjUsers = FillUser(objReader);
                }

                return ObjUsers;
            }
            finally
            {
                if (objReader != null)
                {
                    objReader.Close();
                    objReader.Dispose();
                }

                ClsDBController.Instance.Close();
            }
        }
        private ClsUser FillUser(SqlDataReader objReader)
        {
            ClsUser objUsers;
            objUsers = new ClsUser();

            objUsers.UserID =
                (int)objReader[ClsDBConstants.User_Col_ID ];
            objUsers.FirstName =
                (string)objReader[ClsDBConstants.User_Col_FirstName];
            objUsers.LastName =
                (string)objReader[ClsDBConstants.User_Col_LastName];
            objUsers.Name =
                (string)objReader[ClsDBConstants.User_Col_UserName];
            objUsers.Password =
                (string)objReader[ClsDBConstants.User_Col_Password];
            objUsers.EmailAddress =
                (string)objReader[ClsDBConstants.User_Col_EmailAddress];
            objUsers.IsAdmin =
               (bool)objReader[ClsDBConstants.User_Col_Is_Admin];
            objUsers.HasTradeMarkAccess =
              (bool)objReader[ClsDBConstants.User_Col_HasTradeMarkAccess];
            objUsers.HasPatentAccess =
                          (bool)objReader[ClsDBConstants.User_Col_HasPatentAccess];
            objUsers.HasLetterAccess =
                          (bool)objReader[ClsDBConstants.User_Col_HasLetterAccess];
            objUsers.HasDesignAccess =
                          (bool)objReader[ClsDBConstants.User_Col_HasDesignAccess];
            objUsers.HasApplicantAccess =
                          (bool)objReader[ClsDBConstants.User_Col_HasApplicantAccess];
            objUsers.HasAgentAccess =
                          (bool)objReader[ClsDBConstants.User_Col_HasAgentAccess];
            objUsers.HasAttachmentAccess =
                          (bool)objReader[ClsDBConstants.User_Col_HasAttachmentAccess];
            return objUsers;
        }
    }
}