using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI;

using Laghaee.Entity;
using Laghaee.Common;
using DBController.DataAccessLayer;
using Laghaee.DataAccess;

namespace Laghaee.DataAccessLayer
{
/// <summary>
/// Summary description for AgentDataAccessLogic
/// </summary>
    public class ClsAgentDataAccessLogic
    {
        public void Insert(ClsAgent objAgent, bool blnCloseConnection,Page objCurrentPage)
        {
            try
            {
                string strQuery;
                SqlParameter[] arrParams;
                SqlParameter objParam;

                strQuery = "INSERT INTO [dbo].[@TableName@]  " +
                   "([@AgentName@] ) VALUES(N'@AgentName_Value@')";

                strQuery = strQuery.Replace("@AgentName@", ClsDBConstants.Agent_Col_AgentName);
                strQuery = strQuery.Replace("@TableName@", ClsDBConstants.Agent_TableName);
                strQuery = strQuery.Replace("@AgentName_Value@", objAgent.AgentName.Replace("'", "''"));

                ClsDBController.Instance.ExecuteNoneQuery(strQuery);

                arrParams = new SqlParameter[2];

                objParam = new SqlParameter();
                objParam.ParameterName = "@TableName";
                objParam.SqlDbType = SqlDbType.NVarChar;
                objParam.Size = 255;
                objParam.Direction = ParameterDirection.Input;
                objParam.SqlValue = ClsDBConstants.Agent_TableName;
                arrParams[0] = objParam;

                objParam = new SqlParameter();
                objParam.ParameterName = "@ID";
                objParam.SqlDbType = SqlDbType.BigInt;
                objParam.Direction = ParameterDirection.Output;
                arrParams[1] = objParam;

                ClsDBController.Instance.ExecuteProcedureNonQuery("[dbo].[GetLastTableID]", arrParams);
                ClsLogDataAccessLogic.Insert(ClsLoginManager.GetLoggedOnUser(objCurrentPage).UserID, string.Format("{0:yyyy/MM/dd}", ClsLogDataAccessLogic.GetNowPersianDate()), Convert.ToInt32(ClsLogDataAccessLogic.TransactionType.AgentCreated), true);


                objAgent.ID = (long)arrParams[1].Value;
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

        public void Update(ClsAgent objAgent, bool blnCloseConnection,Page objCurrentPage)
        {
            try
            {
                string strQuery;

                strQuery = "Update [dbo].[@TableName@] Set [@AgentName@]  = N'@AgentName_Value@' Where @AgentID@ = @AgentID_Value@";

                strQuery = strQuery.Replace("@AgentName@", ClsDBConstants.Agent_Col_AgentName);
                strQuery = strQuery.Replace("@TableName@", ClsDBConstants.Agent_TableName);
                strQuery = strQuery.Replace("@AgentID@", ClsDBConstants.Agent_Col_ID);
                strQuery = strQuery.Replace("@AgentName_Value@", objAgent.AgentName.Replace("'", "''"));
                strQuery = strQuery.Replace("@AgentID_Value@", objAgent.ID.ToString());

                ClsDBController.Instance.ExecuteNoneQuery(strQuery);
                ClsLogDataAccessLogic.Insert(ClsLoginManager.GetLoggedOnUser(objCurrentPage).UserID, string.Format("{0:yyyy/MM/dd}", ClsLogDataAccessLogic.GetNowPersianDate()), Convert.ToInt32(ClsLogDataAccessLogic.TransactionType.AgentUpdated), true);

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

        public void Delete(ClsAgent objAgent, bool blnCloseConnection,Page objCurrentPage)
        {
            Delete(objAgent.ID, blnCloseConnection,objCurrentPage);
            
        }

        public void Delete(long lAgentId, bool blnCloseConnection,Page objCurrentPage)
        {
            try
            {
                string strQuery;

                strQuery = "Delete From [dbo].[@TableName@] Where @AgentID@ = @AgentID_Value@";

                strQuery = strQuery.Replace("@TableName@", ClsDBConstants.Agent_TableName);
                strQuery = strQuery.Replace("@AgentID@", ClsDBConstants.Agent_Col_ID);
                strQuery = strQuery.Replace("@AgentID_Value@", lAgentId.ToString());

                ClsDBController.Instance.ExecuteNoneQuery(strQuery);
                ClsLogDataAccessLogic.Insert(ClsLoginManager.GetLoggedOnUser(objCurrentPage).UserID, string.Format("{0:yyyy/MM/dd}", ClsLogDataAccessLogic.GetNowPersianDate()), Convert.ToInt32(ClsLogDataAccessLogic.TransactionType.AgentDeleted), true);

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

        public ClsAgent GetAgent(long lAgentID)
        {
            try
            {
                string strQuery;
                DataTable dtResult;
                ClsAgent objAgent = null;

                strQuery = "Select * From {0} Where {1}={2}";

                strQuery = string.Format(strQuery,
                                         ClsDBConstants.Agent_TableName,
                                         ClsDBConstants.Agent_Col_ID,
                                         lAgentID);

                dtResult = ClsDBController.Instance.ExecuteQuery(strQuery);

                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    objAgent = new ClsAgent();

                    objAgent.ID = (int)dtResult.Rows[0][ClsDBConstants.Agent_Col_ID];
                    objAgent.AgentName = (string)dtResult.Rows[0][ClsDBConstants.Agent_Col_AgentName];

                }

                return objAgent;
            }
            finally
            {
                ClsDBController.Instance.Close();
            }
        }

        public DataTable GetAgentsForPreview()
        {
            try
            {
                string strQuery;

                strQuery = " Select * From " + ClsDBConstants.Agent_TableName +
                           " ORDER BY " + ClsDBConstants.Agent_Col_AgentName ;

                return ClsDBController.Instance.ExecuteQuery(strQuery);
            }
            finally
            {
                ClsDBController.Instance.Close();
            }
        }

        public List<ClsAgent> GetAllAgents()
        {
            SqlDataReader objReader = null ;
            try
            {
                string strQuery;
                List<ClsAgent> colAgents;
                ClsAgent objAgent;

                strQuery = " Select * From " + ClsDBConstants.Agent_TableName +
                           " ORDER BY " + ClsDBConstants.Agent_Col_AgentName;

                objReader = ClsDBController.Instance.ExecuteReader(strQuery);

                colAgents = new List<ClsAgent>();

                while (objReader.Read())
                {
                    objAgent = new ClsAgent();

                    objAgent.ID = (int)objReader[ClsDBConstants.Agent_Col_ID];
                    objAgent.AgentName =(string) objReader[ClsDBConstants.Agent_Col_AgentName];

                    colAgents.Add(objAgent);
                }
                return colAgents;
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

        public bool IsAgentNameExists(string strAgentName , long lOriginalAgentID)
        {
            DataTable dtResult = null;
            string strQuery;

            try
            {
                strQuery = " Select * From @TableName@ " +
                           " Where (@AgentName@=N'@AgentNameValue@') AND (ID <> @lOriginalID@)";
                strQuery = strQuery.Replace("@TableName@", ClsDBConstants.Agent_TableName);
                strQuery = strQuery.Replace("@AgentName@", ClsDBConstants.Agent_Col_AgentName );
                strQuery = strQuery.Replace("@AgentNameValue@", strAgentName.Replace("'", "''"));
                strQuery = strQuery.Replace("@lOriginalID@", lOriginalAgentID.ToString());

                dtResult = ClsDBController.Instance.ExecuteQuery(strQuery);

                return (dtResult.Rows.Count > 0);
            }
            finally
            {
                if (dtResult != null)
                    dtResult.Dispose();
            }
        }

     
    }
}
