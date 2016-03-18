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
    /// Summary description for ApplicantDataAccessLogic
    /// </summary>
    public class ClsApplicantDataAccessLogic
    {
        public void Insert(ClsApplicants objApplicant, bool blnCloseConnection,Page objCurrentPage)
        {
            try
            {
                string strQuery;
                SqlParameter[] arrParams;
                SqlParameter objParam;

                strQuery = "INSERT INTO [dbo].[@TableName@]  " +
                   "([@ApplicantName@] ) VALUES(N'@ApplicantName_Value@')";

                strQuery = strQuery.Replace("@ApplicantName@", ClsDBConstants.Applicant_Col_ApplicantName);
                strQuery = strQuery.Replace("@TableName@", ClsDBConstants.Applicant_TableName);
                strQuery = strQuery.Replace("@ApplicantName_Value@", objApplicant.ApplicantName.Replace("'", "''"));

                ClsDBController.Instance.ExecuteNoneQuery(strQuery);

                arrParams = new SqlParameter[2];

                objParam = new SqlParameter();
                objParam.ParameterName = "@TableName";
                objParam.SqlDbType = SqlDbType.NVarChar;
                objParam.Size = 255;
                objParam.Direction = ParameterDirection.Input;
                objParam.SqlValue = ClsDBConstants.Applicant_TableName;
                arrParams[0] = objParam;

                objParam = new SqlParameter();
                objParam.ParameterName = "@ID";
                objParam.SqlDbType = SqlDbType.BigInt;
                objParam.Direction = ParameterDirection.Output;
                arrParams[1] = objParam;

                ClsDBController.Instance.ExecuteProcedureNonQuery("[dbo].[GetLastTableID]", arrParams);
                ClsLogDataAccessLogic.Insert(ClsLoginManager.GetLoggedOnUser(objCurrentPage).UserID, string.Format("{0:yyyy/MM/dd}", ClsLogDataAccessLogic.GetNowPersianDate()), Convert.ToInt32(ClsLogDataAccessLogic.TransactionType.ApplicantsCreated), true);


                objApplicant.ID = (long)arrParams[1].Value;
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

        public void Update(ClsApplicants objApplicant, bool blnCloseConnection,Page objCurrentPage)
        {
            try
            {
                string strQuery;

                strQuery = "Update [dbo].[@TableName@] Set [@ApplicantName@]  = N'@ApplicantName_Value@' Where @ApplicantID@ = @ApplicantID_Value@";

                strQuery = strQuery.Replace("@ApplicantName@", ClsDBConstants.Applicant_Col_ApplicantName);
                strQuery = strQuery.Replace("@TableName@", ClsDBConstants.Applicant_TableName);
                strQuery = strQuery.Replace("@ApplicantID@", ClsDBConstants.Applicant_Col_ID);
                strQuery = strQuery.Replace("@ApplicantName_Value@", objApplicant.ApplicantName.Replace("'", "''"));
                strQuery = strQuery.Replace("@ApplicantID_Value@", objApplicant.ID.ToString());

                ClsDBController.Instance.ExecuteNoneQuery(strQuery);
                ClsLogDataAccessLogic.Insert(ClsLoginManager.GetLoggedOnUser(objCurrentPage).UserID, string.Format("{0:yyyy/MM/dd}", ClsLogDataAccessLogic.GetNowPersianDate()), Convert.ToInt32(ClsLogDataAccessLogic.TransactionType.ApplicantsUpdated), true);

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

        public void Delete(long lApplicantID, bool blnCloseConnection,Page objCurrentPage)
        {
            try
            {
                string strQuery;
                strQuery = "Delete From [dbo].[@TableName@] Where @ApplicantID@ = @ApplicantID_Value@";

                strQuery = strQuery.Replace("@TableName@", ClsDBConstants.Applicant_TableName);
                strQuery = strQuery.Replace("@ApplicantID@", ClsDBConstants.Applicant_Col_ID);
                strQuery = strQuery.Replace("@ApplicantID_Value@", lApplicantID.ToString());

                ClsDBController.Instance.ExecuteNoneQuery(strQuery);
                ClsLogDataAccessLogic.Insert(ClsLoginManager.GetLoggedOnUser(objCurrentPage).UserID, string.Format("{0:yyyy/MM/dd}", ClsLogDataAccessLogic.GetNowPersianDate()), Convert.ToInt32(ClsLogDataAccessLogic.TransactionType.ApplicantsDeleted), true);

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

        public void Delete(ClsApplicants objApplicant, bool blnCloseConnection,Page objCurrentPage)
        {
            Delete(objApplicant.ID, blnCloseConnection, objCurrentPage);
        }

        public ClsApplicants GetApplicant(long lApplicantID)
        {
            try
            {
                string strQuery;
                DataTable dtResult;
                ClsApplicants objApplicant = null;

                strQuery = "Select * From {0} Where {1}={2}";

                strQuery = string.Format(strQuery,
                                         ClsDBConstants.Applicant_TableName,
                                         ClsDBConstants.Applicant_Col_ID,
                                         lApplicantID);

                dtResult = ClsDBController.Instance.ExecuteQuery(strQuery);

                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    objApplicant = new ClsApplicants();

                    objApplicant.ID = (int)dtResult.Rows[0][ClsDBConstants.Applicant_Col_ID];
                    objApplicant.ApplicantName = (string)dtResult.Rows[0][ClsDBConstants.Applicant_Col_ApplicantName];

                }

                return objApplicant;
            }
            finally
            {
                ClsDBController.Instance.Close();
            }
        }

        public DataTable GetApplicantsForPreview()
        {
            try
            {
                string strQuery;

                strQuery = " Select * From " + ClsDBConstants.Applicant_TableName +
                           " ORDER BY " + ClsDBConstants.Applicant_Col_ApplicantName ; ;

                return ClsDBController.Instance.ExecuteQuery(strQuery);
            }
            finally
            {
                ClsDBController.Instance.Close();
            }
        }

        public List<ClsApplicants> GetAllApplicants()
        {
            SqlDataReader objReader = null;
            try
            {
                string strQuery;
                List<ClsApplicants> colApplicants;
                ClsApplicants objApplicant;

                strQuery = " Select * From " + ClsDBConstants.Applicant_TableName +
                           " ORDER BY " + ClsDBConstants.Applicant_Col_ApplicantName ;      

                objReader = ClsDBController.Instance.ExecuteReader(strQuery);

                colApplicants = new List<ClsApplicants>();

                while (objReader.Read())
                {
                    objApplicant = new ClsApplicants();

                    objApplicant.ID = (int)objReader[ClsDBConstants.Applicant_Col_ID];
                    objApplicant.ApplicantName = (string)objReader[ClsDBConstants.Applicant_Col_ApplicantName];

                    colApplicants.Add(objApplicant);
                }
                return colApplicants;
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

        public bool IsApplicantNameExists(string strApplicantName, long lOriginalApplicantID)
        {
            DataTable dtResult = null;
            string strQuery;

            try
            {
                strQuery = " Select * From @TableName@ " +
                           " Where (@ApplicantName@=N'@ApplicantNameValue@') AND (ID <> @lOriginalID@)";
                strQuery = strQuery.Replace("@TableName@", ClsDBConstants.Applicant_TableName);
                strQuery = strQuery.Replace("@ApplicantName@", ClsDBConstants.Applicant_Col_ApplicantName);
                strQuery = strQuery.Replace("@ApplicantNameValue@", strApplicantName.Replace("'", "''"));
                strQuery = strQuery.Replace("@lOriginalID@", lOriginalApplicantID.ToString());

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