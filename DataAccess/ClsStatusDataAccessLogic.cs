using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;

using Laghaee.Entity;
using Laghaee.Common;
using DBController.DataAccessLayer;

namespace Laghaee.DataAccessLayer
{
    /// <summary>
    /// Summary description for StatusDataAccessLogic
    /// </summary>
    public class ClsStatusDataAccessLogic
    {
        /*  Unnecessary methods.
        public void Insert(ClsStatus objStatus)
        {
            try
            {
                string strQuery;
                SqlParameter[] arrParams;
                SqlParameter objParam;

                strQuery = "INSERT INTO [dbo].[@TableName@]  " +
                   "([@StatusName@] ) VALUES(N'@StatusName_Value@')";

                strQuery = strQuery.Replace("@StatusName@", ClsDBConstants.Status_Col_StatusName);
                strQuery = strQuery.Replace("@TableName@", ClsDBConstants.Status_TableName);
                strQuery = strQuery.Replace("@StatusName_Value@", objStatus.StatusName);

                ClsDBController.Instance.ExecuteNoneQuery(strQuery);

                arrParams = new SqlParameter[2];

                objParam = new SqlParameter();
                objParam.ParameterName = "@TableName";
                objParam.SqlDbType = SqlDbType.NVarChar;
                objParam.Size = 255;
                objParam.Direction = ParameterDirection.Input;
                objParam.SqlValue = ClsDBConstants.Status_TableName;
                arrParams[0] = objParam;

                objParam = new SqlParameter();
                objParam.ParameterName = "@ID";
                objParam.SqlDbType = SqlDbType.BigInt;
                objParam.Direction = ParameterDirection.Output;
                arrParams[1] = objParam;

                ClsDBController.Instance.ExecuteProcedureNonQuery("[dbo].[GetLastTableID]", arrParams);

                objStatus.ID = (long)arrParams[1].Value;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public void Update(ClsStatus objStatus)
        {
            try
            {
                string strQuery;

                strQuery = "Update [dbo].[@TableName@] Set [@StatusName@]  = N'@StatusName_Value@' Where @StatusID@ = @StatusID_Value@";

                strQuery = strQuery.Replace("@StatusName@", ClsDBConstants.Status_Col_StatusName);
                strQuery = strQuery.Replace("@TableName@", ClsDBConstants.Status_TableName);
                strQuery = strQuery.Replace("@StatusID@", ClsDBConstants.Status_Col_ID);
                strQuery = strQuery.Replace("@StatusName_Value@", objStatus.StatusName);
                strQuery = strQuery.Replace("@StatusID_Value@", objStatus.ID.ToString());

                ClsDBController.Instance.ExecuteNoneQuery(strQuery);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public void Delete(ClsStatus objStatus)
        {
            try
            {
                string strQuery;
                strQuery = "Delete From [dbo].[@TableName@] Where @StatusID@ = @StatusID_Value@";

                strQuery = strQuery.Replace("@TableName@", ClsDBConstants.Status_TableName);
                strQuery = strQuery.Replace("@StatusID@", ClsDBConstants.Status_Col_ID);
                strQuery = strQuery.Replace("@StatusID_Value@", objStatus.ID.ToString());

                ClsDBController.Instance.ExecuteNoneQuery(strQuery);
            }
            catch (Exception Ex)
            {
                throw (Ex);
            }
        }
        */

        public ClsStatus GetStatus(long lStatusID)
        {
            string strQuery;
            DataTable dtResult;
            ClsStatus objStatus = null;

            strQuery = "Select * From {0} Where {1}={2}";

            strQuery = string.Format(strQuery,
                                     ClsDBConstants.Status_TableName,
                                     ClsDBConstants.Status_Col_ID,
                                     lStatusID);

            dtResult = ClsDBController.Instance.ExecuteQuery(strQuery);

            if (dtResult != null && dtResult.Rows.Count > 0)
            {
                objStatus = new ClsStatus();

                objStatus.ID = (int)dtResult.Rows[0][ClsDBConstants.Status_Col_ID];
                objStatus.StatusName = (string)dtResult.Rows[0][ClsDBConstants.Status_Col_StatusName];

            }

            return objStatus;
        }

        public List<ClsStatus> GetAllStatuss()
        {
            SqlDataReader objReader = null;
            try
            {
                string strQuery;
                List<ClsStatus> colStatuss;
                ClsStatus objStatus;

                strQuery = "Select * From " + ClsDBConstants.Status_TableName +
                           " ORDER BY " + ClsDBConstants.Status_Col_StatusName ;      

                objReader = ClsDBController.Instance.ExecuteReader(strQuery);

                colStatuss = new List<ClsStatus>();

                while (objReader.Read())
                {
                    objStatus = new ClsStatus();

                    objStatus.ID = (int)objReader[ClsDBConstants.Status_Col_ID];
                    objStatus.StatusName = (string)objReader[ClsDBConstants.Status_Col_StatusName];

                    colStatuss.Add(objStatus);
                }
                return colStatuss;
            }
            finally
            {
                if (objReader != null)
                {
                    objReader.Close();
                    objReader.Dispose();
                }
            }
        }
    }
}
