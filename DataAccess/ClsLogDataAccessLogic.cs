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

namespace Laghaee.DataAccess
{
    public class ClsLogDataAccessLogic
    {
        public enum TransactionType
        { 
            
             UserCreated = 0,
             UserUpdated = 1,
             UserDeleted = 2,
            AgentCreated=3,
            AgentUpdated=4,
            AgentDeleted = 5,
            ApplicantsCreated=6,
            ApplicantsUpdated = 7,
            ApplicantsDeleted = 8,
            AttachmentCreated=9,
            AttachmentUpdated=10,
            AttachmentDeleted=11,
            DesignCreated=12,
            DesignUpdated=13,
            DesignDeleted=14,
            LettersCreated=15,
            LettersUpdated=16,
            LettersDeleted=17,
            PatentCreated=18,
            PatentUpdated=19,
            PatentDeleted=20,
            TradeMarkCreated=21,
            TradeMarkUpdated=22,
            TradeMarkDeleted=23

        }
        
        public static void Insert(int iUserId, string strDateTime, int iTransacionType, bool blnCloseConnection)
        {
            try
            {
                string strQuery;
                SqlParameter[] arrParams;
                SqlParameter objParam;

                strQuery = "INSERT INTO [dbo].[@TableName@]  " +
                   "([@UserID@],[@DateTime@],[@TransactionType@]) VALUES(@UserID_Value@,N'@DateTime_Value@',@TransactionType_Value@)";

                strQuery = strQuery.Replace("@UserID@", ClsDBConstants.Log_Col_UserID);
                strQuery = strQuery.Replace("@DateTime@", ClsDBConstants.Log_Col_DateTime);
                strQuery = strQuery.Replace("@TransactionType@", ClsDBConstants.Log_Col_TransactionType);
                
                strQuery = strQuery.Replace("@TableName@", ClsDBConstants.Log_TableName);
                strQuery = strQuery.Replace("@UserID_Value@", iUserId.ToString());
                strQuery = strQuery.Replace("@DateTime_Value@", strDateTime.Replace("'", "''"));
                strQuery = strQuery.Replace("@TransactionType_Value@", iTransacionType.ToString());
             
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
        public static string GetNowPersianDate()
        {
            return FarsiLibrary.Utils.PersianDate.Now.ToString("yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture)+"  "+System.DateTime.Now.ToShortTimeString() ;
        }
       

    }
}
