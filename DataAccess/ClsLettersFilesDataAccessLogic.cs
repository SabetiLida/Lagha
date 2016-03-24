using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Laghaee.Common;
using Laghaee.Entity;
using DBController.DataAccessLayer;

namespace Laghaee.DataAccess
{
    public class ClsLettersFilesDataAccessLogic
    {
        public void Insert(ClsLettersFiles objLetterFiles, bool blnCloseConnection,Page objCurrentPage)
        {
            try
            {
                string strQuery;
                SqlParameter[] arrParams;
                SqlParameter objParam;

                strQuery = "INSERT INTO [dbo].[@TableName@]  " +
                   "([@AgentLettersId@],[@LetterFilePath@],[@FileType@],[@FileName@] ) VALUES('@AgentLettersId_Value@',N'@LetterFilePath_Value@',N'@FileType_Value@',N'@FileName_Value@')";

                strQuery = strQuery.Replace("@TableName@", Common.ClsDBConstants.LettersFiles_TableName);
                strQuery = strQuery.Replace("@AgentLettersId@", Common.ClsDBConstants.LettersFiles_Col_AgentLettersId);
                strQuery = strQuery.Replace("@LetterFilePath@", Common.ClsDBConstants.LettersFiles_Col_LetterFilePath);
                strQuery = strQuery.Replace("@FileType@",ClsDBConstants.LettersFiles_Col_FileType);
                strQuery = strQuery.Replace("@FileName@", ClsDBConstants.LettersFiles_Col_FileName);
                strQuery = strQuery.Replace("@AgentLettersId_Value@", objLetterFiles.AgentLettersId.ToString());
                strQuery = strQuery.Replace("@LetterFilePath_Value@", objLetterFiles.LetterFilePath.Replace("'","''"));
                strQuery = strQuery.Replace("@FileType_Value@",objLetterFiles.FileType.Replace("'","''"));
                strQuery = strQuery.Replace("@FileName_Value@", objLetterFiles.FileName.Replace("'","''"));

                ClsDBController.Instance.ExecuteNoneQuery(strQuery);

                arrParams = new SqlParameter[2];

                objParam = new SqlParameter();
                objParam.ParameterName = "@TableName";
                objParam.SqlDbType = SqlDbType.NVarChar;
                objParam.Size = 255;
                objParam.Direction = ParameterDirection.Input;
                objParam.SqlValue = ClsDBConstants.LettersFiles_TableName;
                arrParams[0] = objParam;

                objParam = new SqlParameter();
                objParam.ParameterName = "@ID";
                objParam.SqlDbType = SqlDbType.Int;
                objParam.Direction = ParameterDirection.Output;
                arrParams[1] = objParam;

                ClsDBController.Instance.ExecuteProcedureNonQuery("[dbo].[GetLastTableID]", arrParams);
                ClsLogDataAccessLogic.Insert(ClsLoginManager.GetLoggedOnUser(objCurrentPage).UserID, string.Format("{0:yyyy/MM/dd}", ClsLogDataAccessLogic.GetNowPersianDate()), Convert.ToInt32(ClsLogDataAccessLogic.TransactionType.AttachmentCreated), true);

                objLetterFiles.ID = (int)arrParams[1].Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (blnCloseConnection)
               
                    ClsDBController.Instance.Close();
                }
            }

        public void Update(ClsLettersFiles objlettersFiles, bool blnCloseConnection, Page objCurrentPage)
        {
            try
            {


                System.Text.StringBuilder strQuery;
                strQuery = new System.Text.StringBuilder(
                   " Update[dbo].[@TableName@]  " +
                   "    SET    [@AgentLettersId@] = N'@AgentLettersId_Value@'," +
                   "           [@LetterFilePath@] = N'@LetterFilePath_Value@'," +
                   "           [@FileType@] = '@FileType_Value@',"+
                   "           [@FileName@] = '@FileName_Value@'," + 
                   "           Where [@ID@] = @ID_Value@");


                strQuery = strQuery.Replace("@TableName@", ClsDBConstants.LettersFiles_TableName);
                strQuery = strQuery.Replace("@AgentLettersId@", ClsDBConstants.LettersFiles_Col_AgentLettersId);
                strQuery = strQuery.Replace("@LetterFilePath@", ClsDBConstants.LettersFiles_Col_LetterFilePath);
                strQuery = strQuery.Replace("@FileType@", ClsDBConstants.LettersFiles_Col_FileType);
                strQuery = strQuery.Replace("@FileName@", ClsDBConstants.LettersFiles_Col_FileName);
                strQuery = strQuery.Replace("@ID@", ClsDBConstants.LettersFiles_Col_Id);
                strQuery = strQuery.Replace("@AgentLettersId_Value@",
                    objlettersFiles.AgentLettersId.ToString());
                strQuery = strQuery.Replace("@LetterFilePath_Value@",
                    objlettersFiles.LetterFilePath.Replace("'","''"));
                strQuery = strQuery.Replace("@FileType_Value@",
                    objlettersFiles.FileType.Replace("'","''"));
                strQuery = strQuery.Replace("@ID_Value@",
                   objlettersFiles.ID.ToString());
                strQuery = strQuery.Replace("@FileName_Value@",
                  objlettersFiles.FileName.Replace("'","''"));



                ClsDBController.Instance.ExecuteNoneQuery(strQuery.ToString());
                ClsLogDataAccessLogic.Insert(ClsLoginManager.GetLoggedOnUser(objCurrentPage).UserID, string.Format("{0:yyyy/MM/dd}", ClsLogDataAccessLogic.GetNowPersianDate()), Convert.ToInt32(ClsLogDataAccessLogic.TransactionType.AttachmentUpdated), true);

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

        public void Delete(ClsLettersFiles objLettersFiles, bool blnCloseConnection,Page objCurrentPage)
        {
            Delete(objLettersFiles.ID, blnCloseConnection, objCurrentPage);
        }

        public void Delete(int intLettersFilesID, bool blnCloseConnection, Page objCurrentPage)
        {
            try
            {
                string strQuery;
                strQuery = "Delete From {0} Where [{1}] = {2}";

                strQuery = string.Format(strQuery,
                                         ClsDBConstants.LettersFiles_TableName,
                                         ClsDBConstants.LettersFiles_Col_Id,
                                         intLettersFilesID);
                ClsDBController.Instance.ExecuteNoneQuery(strQuery);
                ClsLogDataAccessLogic.Insert(ClsLoginManager.GetLoggedOnUser(objCurrentPage).UserID, string.Format("{0:yyyy/MM/dd}", ClsLogDataAccessLogic.GetNowPersianDate()), Convert.ToInt32(ClsLogDataAccessLogic.TransactionType.AttachmentDeleted), true);

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
        public DataTable GetAllFiles(int agentLetterId)
        {
            try
            {
                string strQuery;

                strQuery = "SELECT  Agents.AgentName, LettersFiles.* FROM AgentLetters INNER JOIN LettersFiles ON AgentLetters.Id = LettersFiles.AgentLettersId INNER JOIN Agents ON AgentLetters.AgentId = Agents.ID WHERE (LettersFiles.AgentLettersId = {0})";
                strQuery = string.Format(strQuery, agentLetterId);
                return ClsDBController.Instance.ExecuteQuery(strQuery);
            }
            finally
            {
                ClsDBController.Instance.Close();
            }
        }
        public string GetLetterFilePathByLetterId(int letterId)
        {
            try
            {
                string strQuery;

                strQuery = "SELECT LetterFilePath FROM LettersFiles where AgentLettersId={0}";
                strQuery = string.Format(strQuery, letterId);
                return (string)ClsDBController.Instance.ExecuteScalar(strQuery);
            }
            finally
            {
                ClsDBController.Instance.Close();
            }
        }
        public string GetLetterFilePathByAttachmentId(int AttachmentId)
        {
            try
            {
                string strQuery;

                strQuery = "SELECT LetterFilePath FROM LettersFiles where Id={0}";
                strQuery = string.Format(strQuery, AttachmentId);
                return (string)ClsDBController.Instance.ExecuteScalar(strQuery);
            }
            finally
            {
                ClsDBController.Instance.Close();
            }
        }

      
    }
}
