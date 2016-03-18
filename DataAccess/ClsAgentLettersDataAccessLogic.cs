using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Text;
using System.Data.SqlClient;
using Laghaee.Entity;
using Laghaee.Common;
using DBController.DataAccessLayer;
using System.Web.UI;
using Laghaee.DataAccess;

namespace Laghaee.DataAccess
{
  public class ClsAgentLettersDataAccessLogic
    {
        public void Insert(ClsAgentLetters objAgentLetters, bool blnCloseConnection,Page objCurrentPage)
        {
            try
            {
                string strQuery;
                SqlParameter[] arrParams;
                SqlParameter objParam;

                strQuery = "INSERT INTO [dbo].[@TableName@]  " +
                 "([@LetterContent@],[@AgentId@],[@LetterDate@],[@RegisterDate@],[@LetterName@],[@FilingNo@],[@LetterType@],[@ClientorOffice@])" +

                 " VALUES(N'@LetterContent_Value@','@AgentId_Value@','@LetterDate_Value@','@RegisterDate_Value@',N'@LetterName_Value@','@FilingNo_Value@','@LetterType_Value@','@ClientorOffice_Value@')";

                strQuery = strQuery.Replace("@TableName@", ClsDBConstants.AgentLetters_TableName);
                strQuery = strQuery.Replace("@LetterContent@", ClsDBConstants.AgentLetters_Col_LetterContent);
                strQuery = strQuery.Replace("@AgentId@", ClsDBConstants.AgentLetters_Col_AgentId.Replace("'", "''"));
                strQuery = strQuery.Replace("@LetterDate@", ClsDBConstants.AgentLetters_Col_LetterDate);
                strQuery = strQuery.Replace("@RegisterDate@", ClsDBConstants.AgentLetters_Col_RegisterDate);
                strQuery = strQuery.Replace("@LetterName@", ClsDBConstants.AgentLetters_Col_LetterName);
                strQuery = strQuery.Replace("@FilingNo@", ClsDBConstants.AgentLetters_Col_FilingNo);
                strQuery = strQuery.Replace("@LetterType@", ClsDBConstants.AgentLetters_Col_LetterType);
                strQuery = strQuery.Replace("@ClientorOffice@", ClsDBConstants.AgentLetters_Col_ClientorOffice);

                objAgentLetters.LetterContent = objAgentLetters.LetterContent.Replace("'", "\"");
                strQuery = strQuery.Replace("@LetterContent_Value@",
                    objAgentLetters.LetterContent.ToString());
                strQuery = strQuery.Replace("@AgentId_Value@",
                    objAgentLetters.AgentID.ToString());
                strQuery = strQuery.Replace("@LetterDate_Value@",
                    objAgentLetters.LetterDate.ToString());
                strQuery = strQuery.Replace("@RegisterDate_Value@",
                    objAgentLetters.RegisterDate.ToString());
                strQuery = strQuery.Replace("@LetterName_Value@",
                    objAgentLetters.LetterName.ToString());
                strQuery = strQuery.Replace("@LetterType_Value@",
                   objAgentLetters.LetterType.ToString());
                strQuery = strQuery.Replace("@FilingNo_Value@",
                   objAgentLetters.FilingNo.ToString());
 strQuery = strQuery.Replace("@ClientorOffice_Value@",
                   objAgentLetters.ClientOffice.ToString());


                ClsDBController.Instance.ExecuteNoneQuery(strQuery);

                arrParams = new SqlParameter[2];
                objParam = new SqlParameter();
                objParam.ParameterName = "@TableName";
                objParam.SqlDbType = SqlDbType.NVarChar;
                objParam.Size = 255;
                objParam.Direction = ParameterDirection.Input;
                objParam.SqlValue = ClsDBConstants.AgentLetters_TableName;
                arrParams[0] = objParam;

                objParam = new SqlParameter();
                objParam.ParameterName = "@ID";
                objParam.SqlDbType = SqlDbType.Int;
                objParam.Direction = ParameterDirection.Output;
                arrParams[1] = objParam;

                ClsDBController.Instance.ExecuteProcedureNonQuery("[dbo].[GetLastTableID]", arrParams);
                ClsLogDataAccessLogic.Insert(ClsLoginManager.GetLoggedOnUser(objCurrentPage).UserID, string.Format("{0:yyyy/MM/dd}", ClsLogDataAccessLogic.GetNowPersianDate()), Convert.ToInt32(ClsLogDataAccessLogic.TransactionType.LettersCreated), true);


                objAgentLetters.ID = (int)arrParams[1].Value;
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

        public void Update(ClsAgentLetters objAgentLetters, bool blnCloseConnection,Page objCurrentPage)
        {
            try
            {
               

                System.Text.StringBuilder strQuery;
                strQuery = new System.Text.StringBuilder(
                   " Update[dbo].[@TableName@]  " +
                   "    SET    [@LetterContent@] = N'@LetterContent_Value@'," +
                   "           [@AgentId@] = N'@AgentId_Value@'," +
                   "           [@LetterDate@] = '@LetterDate_Value@'," +
                   "           [@RegisterDate@] =  '@RegisterDate_Value@'," +
                   "           [@LetterName@] = '@LetterName_Value@'," +
                   "           [@FilingNo@]=@FilingNo_Value@,"+
                   "           [@LetterType@]=@LetterType_Value@,"+
                   "           [@ClientorOffice@]='@ClientorOffice_Value@'"+
                   "           Where [@ID@] = @ID_Value@");


                strQuery = strQuery.Replace("@TableName@", ClsDBConstants.AgentLetters_TableName);
                strQuery = strQuery.Replace("@TableName@", ClsDBConstants.AgentLetters_TableName);
                strQuery = strQuery.Replace("@LetterContent@", ClsDBConstants.AgentLetters_Col_LetterContent);
                strQuery = strQuery.Replace("@AgentId@", ClsDBConstants.AgentLetters_Col_AgentId);
                strQuery = strQuery.Replace("@LetterDate@", ClsDBConstants.AgentLetters_Col_LetterDate);
                strQuery = strQuery.Replace("@RegisterDate@", ClsDBConstants.AgentLetters_Col_RegisterDate);
                strQuery = strQuery.Replace("@LetterName@", ClsDBConstants.AgentLetters_Col_LetterName);
                strQuery = strQuery.Replace("@ID@", ClsDBConstants.AgentLetters_Col_Id);
                strQuery = strQuery.Replace("@FilingNo@", ClsDBConstants.AgentLetters_Col_FilingNo);
                strQuery = strQuery.Replace("@LetterType@", ClsDBConstants.AgentLetters_Col_LetterType);
                strQuery = strQuery.Replace("@ClientorOffice@", ClsDBConstants.AgentLetters_Col_ClientorOffice);


                objAgentLetters.LetterContent = objAgentLetters.LetterContent.Replace("'", "\"");
                strQuery = strQuery.Replace("@LetterContent_Value@",
                    objAgentLetters.LetterContent.ToString());
                strQuery = strQuery.Replace("@AgentId_Value@",
                    objAgentLetters.AgentID.ToString());
                strQuery = strQuery.Replace("@LetterDate_Value@",
                    objAgentLetters.LetterDate.ToString());
                strQuery = strQuery.Replace("@RegisterDate_Value@",
                    objAgentLetters.RegisterDate.ToString());
                strQuery = strQuery.Replace("@LetterName_Value@",
                    objAgentLetters.LetterName.ToString());
                strQuery = strQuery.Replace("@ID_Value@",
                   objAgentLetters.ID.ToString());
                strQuery = strQuery.Replace("@FilingNo_Value@",
                   objAgentLetters.FilingNo.ToString());
                strQuery = strQuery.Replace("@LetterType_Value@",
                   objAgentLetters.LetterType.ToString());
                strQuery = strQuery.Replace("@ClientorOffice_Value@",
                   objAgentLetters.ClientOffice.ToString());

                ClsDBController.Instance.ExecuteNoneQuery(strQuery.ToString());
                ClsLogDataAccessLogic.Insert(ClsLoginManager.GetLoggedOnUser(objCurrentPage).UserID, string.Format("{0:yyyy/MM/dd}", ClsLogDataAccessLogic.GetNowPersianDate()), Convert.ToInt32(ClsLogDataAccessLogic.TransactionType.LettersUpdated), true);

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

        public void Delete(ClsAgentLetters objAgentLetters, bool blnCloseConnection,Page objCurrentPage)
        {
            Delete(objAgentLetters.ID, blnCloseConnection,objCurrentPage);
        }

        public void Delete(int intAgentLettersID, bool blnCloseConnection,Page objCurrentPage)
        {
            try
            {
                string strQuery;
                strQuery = "Delete From {0} Where [{1}] = {2}";

                strQuery = string.Format(strQuery,
                                         ClsDBConstants.AgentLetters_TableName,
                                         ClsDBConstants.AgentLetters_Col_Id,
                                         intAgentLettersID);
                ClsDBController.Instance.ExecuteNoneQuery(strQuery);
                ClsLogDataAccessLogic.Insert(ClsLoginManager.GetLoggedOnUser(objCurrentPage).UserID, string.Format("{0:yyyy/MM/dd}", ClsLogDataAccessLogic.GetNowPersianDate()), Convert.ToInt32(ClsLogDataAccessLogic.TransactionType.LettersDeleted), true);

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

      public ClsAgentLetters GetLetter(int iLetterID)
      {
          SqlDataReader objReader = null;
          try
          {
              string strQuery;
              ClsAgentLetters ObjAgentLetters = null;

              strQuery = "Select * From {0} Where {1}={2}";

              strQuery = string.Format(strQuery,
                                       ClsDBConstants.AgentLetters_TableName,
                                       ClsDBConstants.AgentLetters_Col_Id, iLetterID);

              objReader = ClsDBController.Instance.ExecuteReader(strQuery);

              if (objReader.Read())
              {
                  ObjAgentLetters = FillLetter(objReader);
              }

              return ObjAgentLetters;
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
      private ClsAgentLetters FillLetter(SqlDataReader objReader)
      {
          ClsAgentLetters objAgentLetters;
          objAgentLetters = new ClsAgentLetters();

          objAgentLetters.AgentID = 
              (int)objReader[ClsDBConstants.AgentLetters_Col_AgentId];
          objAgentLetters.LetterContent = 
              (string)objReader[ClsDBConstants.AgentLetters_Col_LetterContent];
          objAgentLetters.LetterDate =
              (string)objReader[ClsDBConstants.AgentLetters_Col_LetterDate];
          objAgentLetters.LetterName =
              (string)objReader[ClsDBConstants.AgentLetters_Col_LetterName];
          objAgentLetters.RegisterDate =
              (string)objReader[ClsDBConstants.AgentLetters_Col_RegisterDate];
          objAgentLetters.ID=
             (int)objReader[ClsDBConstants.AgentLetters_Col_Id];
          objAgentLetters.ClientOffice =
             (bool)objReader[ClsDBConstants.AgentLetters_Col_ClientorOffice];


          return objAgentLetters;
      }
      public DataTable GetAllLetters(string strSortBy, bool blnSortAscending)
      {
          try
          {
              string strQuery;

              strQuery = "SELECT  AgentLetters.LetterContent, AgentLetters.LetterDate,AgentLetters.AgentId, AgentLetters.RegisterDate, AgentLetters.LetterName, Agents.AgentName, AgentLetters.Id,AgentLetters.ClientorOffice FROM  AgentLetters INNER JOIN Agents ON AgentLetters.AgentId = Agents.ID";

              if (strSortBy != string.Empty)
                  strQuery += " Order By " +  strSortBy + ((blnSortAscending) ? " Asc" : " Desc") +
                      " , " + ClsDBConstants.AgentLetters_Col_AgentId + " Desc";

              return ClsDBController.Instance.ExecuteQuery(strQuery);
          }
          finally
          {
              ClsDBController.Instance.Close();
          }
      }
      public DataTable GetAllLettersBYFillingNo(string strSortBy, bool blnSortAscending,long lFilingNo)
      {
          try
          {
              string strQuery;

              strQuery = "SELECT  AgentLetters.LetterContent, AgentLetters.LetterDate,AgentLetters.AgentId, AgentLetters.RegisterDate, AgentLetters.LetterName, Agents.AgentName, AgentLetters.Id,AgentLetters.ClientorOffice FROM  AgentLetters INNER JOIN Agents ON AgentLetters.AgentId = Agents.ID where FilingNo={0}";
              strQuery = string.Format(strQuery, lFilingNo);
              if (strSortBy != string.Empty)
                  strQuery += " Order By " + strSortBy + ((blnSortAscending) ? " Asc" : " Desc") +
                      " , " + ClsDBConstants.AgentLetters_Col_AgentId + " Desc";

              return ClsDBController.Instance.ExecuteQuery(strQuery);
          }
          finally
          {
              ClsDBController.Instance.Close();
          }
      }
      public DataTable Search(string strLetterDate,
                            string strTitle,
                            string strAgentID,
                            string strSortBy,
                            bool blnSortAscending)
      {
          string strQuery;
          string strWhereClause = string.Empty;
          bool blnConditionAdded = false;

          strWhereClause = " Where (";

          if (strTitle != string.Empty)
          {
              strWhereClause += ClsDBConstants.AgentLetters_Col_LetterName + " Like '%" + strTitle.Replace("'", "''") + "%'";
              blnConditionAdded = true;
          }
        if (strAgentID!="0")
        {
          if (blnConditionAdded)
          
              {
               strWhereClause += ") And (";
               strWhereClause += ClsDBConstants.AgentLetters_Col_AgentId + " = " + strAgentID.ToString();
              }
              else
              { 
                 strWhereClause += ClsDBConstants.AgentLetters_Col_AgentId + " = " + strAgentID.ToString();
                 blnConditionAdded = true;
              }
       

       }
      if (strLetterDate  != string.Empty)
      {
          if (blnConditionAdded)
          {
              strWhereClause += ") And (";
              strWhereClause += ClsDBConstants.AgentLetters_Col_LetterDate + " = " + "'" + strLetterDate.ToString() + "'";
          }
          else
          {   
              strWhereClause += ClsDBConstants.AgentLetters_Col_LetterDate + " = " +"'"+ strLetterDate.ToString()+"'";
              blnConditionAdded = true;
          }
      }
     
          if (!blnConditionAdded)
          {
              strWhereClause = string.Empty;
          }
          else
          {
              strWhereClause += ")";
          }

          strQuery = "SELECT  AgentLetters.LetterContent, AgentLetters.LetterDate,AgentLetters.AgentId, AgentLetters.RegisterDate, AgentLetters.LetterName, Agents.AgentName, AgentLetters.Id,AgentLetters.ClientorOffice FROM  AgentLetters INNER JOIN Agents ON AgentLetters.AgentId = Agents.ID {0}";
          strQuery = string.Format(strQuery,strWhereClause);

          //strQuery = " Select * From {0} {1}";

         //strQuery = string.Format(strQuery, ClsDBConstants.AgentLetters_TableName, strWhereClause);

          if (strSortBy != string.Empty)
              strQuery += " Order By " + strSortBy + ((blnSortAscending) ? " Asc" : " Desc") +
                          " , " + ClsDBConstants.AgentLetters_Col_AgentId + " Desc";

          return ClsDBController.Instance.ExecuteQuery(strQuery);
      }
      
      public string GetAgentNameByAgentId(int iAgentId)
      {
          string strQuery;
          string strWhereClause = string.Empty;
          strQuery = "SELECT  Agents.AgentName FROM  Agents where Agents.ID = {0}";
          strQuery = string.Format(strQuery, iAgentId);
          return (string)ClsDBController.Instance.ExecuteScalar(strQuery);
      }
      public DataTable GetAllLetterByFilingNoLetterType(long lFilingNo,int iLetterType)
      {
          string strQuery;
          string strWhereClause = string.Empty;
          strQuery = "SELECT LetterContent, AgentId, LetterDate, RegisterDate, LetterName, FilingNo, LetterType,ClientorOffice FROM AgentLetters WHERE (FilingNo = {0}) AND (LetterType = {1})";
          strQuery = string.Format(strQuery, lFilingNo,iLetterType);
          return (DataTable)ClsDBController.Instance.ExecuteQuery (strQuery);
      }

      public DataTable GetFileAttachmentByLetterId(int iLetterId)
      {
          string strQuery;
          string strWhereClause = string.Empty;
          strQuery = "SELECT LettersFiles.FileName FROM LettersFiles INNER JOIN AgentLetters ON LettersFiles.AgentLettersId = AgentLetters.Id  WHERE     (LettersFiles.AgentLettersId ={0})";
          strQuery = string.Format(strQuery, iLetterId);
          return ClsDBController.Instance.ExecuteQuery(strQuery);
      }
    
      public string GetLetterContent(int iLetterId)
      {
          string strQuery;
          string strWhereClause = string.Empty;
          strQuery = "SELECT LetterContent FROM AgentLetters WHERE (Id = {0})";
          strQuery = string.Format(strQuery, iLetterId);
          return (string)ClsDBController.Instance.ExecuteScalar(strQuery);
      }
    }
}