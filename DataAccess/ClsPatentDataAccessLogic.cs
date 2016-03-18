using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web.UI;
using Laghaee.Entity;
using Laghaee.Common;
using DBController.DataAccessLayer;
using Laghaee.DataAccess;

namespace Laghaee.DataAccessLayer
{
    /// <summary>
    /// Summary description for ClsPatentDataAccessLogic
    /// </summary>
    public class ClsPatentDataAccessLogic
    {
        public void Insert(ClsPatent objPatent, bool blnCloseConnection, Page objCurrentPage)
        {
            try
            {
                System.Text.StringBuilder strQuery;
                SqlParameter[] arrParams;
                SqlParameter objParam;

                strQuery = new System.Text.StringBuilder(
                   " INSERT INTO [dbo].[PatentApplications]  " +
                   "    (                            [@FillingNo@],               [@Year@],               [@TradeMark@],   " +
                   "    [@AppNo@],                   [@AppDate@],                 [@RegNo@],               [@AdditionalGoodsClassesNo@],              [@RegDate@],             [@NextAnnuityDate@], " +
                   "    [@NextAnnuityYear@],         [@ApplicantID@],             [@AgentID@],             [@Agent2ID@],             [@Comment@],             [@KCommission@], " +
                   "    [@StatusID@],                [@PowerOfAttorneyNo@],       [@LastDateChecked@]) " +
                   " VALUES " +
                   "    (                             @FillingNo_Value@,          @Year_Value@,          N'@TradeMark_Value@', " +
                   "     N'@AppNo_Value@',            '@AppDate_Value@',          N'@RegNo_Value@',            N'@AdditionalGoodsClassesNo_Value@',          '@RegDate_Value@',       '@NextAnnuityDate_Value@', " +
                   "     @NextAnnuityYear_Value@,     @ApplicantID_Value@,        @AgentID_Value@,        @Agent2ID_Value@,        N'@Comment_Value@',        N'@KCommission_Value@', " +
                   "     @StatusID_Value@,            @PowerOfAttorneyNo_Value@, '@LastDateChecked_Value@')");

                strQuery = strQuery.Replace("@FillingNo@", ClsDBConstants.Patent_Col_FillingNo);
                strQuery = strQuery.Replace("@Year@", ClsDBConstants.Patent_Col_Year);
                strQuery = strQuery.Replace("@TradeMark@", ClsDBConstants.Patent_Col_Title);
                strQuery = strQuery.Replace("@AppNo@", ClsDBConstants.Patent_Col_AppNo);
                strQuery = strQuery.Replace("@AppDate@", ClsDBConstants.Patent_Col_AppDate);
                strQuery = strQuery.Replace("@RegNo@", ClsDBConstants.Patent_Col_RegNo);
                strQuery = strQuery.Replace("@AdditionalGoodsClassesNo@", ClsDBConstants.Patent_Col_AdditionalGoodsClassesNo);
                strQuery = strQuery.Replace("@RegDate@", ClsDBConstants.Patent_Col_RegDate);
                strQuery = strQuery.Replace("@NextAnnuityDate@", ClsDBConstants.Patent_Col_NextAnnuityDate);
                strQuery = strQuery.Replace("@NextAnnuityYear@", ClsDBConstants.Patent_Col_NextAnnuityYear);
                strQuery = strQuery.Replace("@ApplicantID@", ClsDBConstants.Patent_Col_ApplicantID);
                strQuery = strQuery.Replace("@AgentID@", ClsDBConstants.Patent_Col_AgentID);
                strQuery = strQuery.Replace("@Agent2ID@", ClsDBConstants.Patent_Col_Agent2ID);
                strQuery = strQuery.Replace("@Comment@", ClsDBConstants.Patent_Col_Comment);
                strQuery = strQuery.Replace("@KCommission@", ClsDBConstants.Patent_Col_KCommission);
                strQuery = strQuery.Replace("@StatusID@", ClsDBConstants.Patent_Col_StatusID);
                strQuery = strQuery.Replace("@PowerOfAttorneyNo@", ClsDBConstants.Patent_Col_PowerOfAttorneyNo);
                strQuery = strQuery.Replace("@LastDateChecked@", ClsDBConstants.Patent_Col_LastDateChecked);

                strQuery = strQuery.Replace("@FillingNo_Value@",
                    objPatent.FillingNumber.ToString());
                strQuery = strQuery.Replace("@Year_Value@",
                    (objPatent.Year != 0) ? objPatent.Year.ToString() : "NULL");
                strQuery = strQuery.Replace("@TradeMark_Value@",
                    (objPatent.Title != string.Empty) ? objPatent.Title.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@AppNo_Value@",
                    (objPatent.AppNumber != string.Empty) ? objPatent.AppNumber.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@AppDate_Value@",
                    (objPatent.AppDate != string.Empty) ? objPatent.AppDate : "NULL");
                strQuery = strQuery.Replace("@RegNo_Value@",
                    (objPatent.RegNumber != string.Empty) ? objPatent.RegNumber.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@AdditionalGoodsClassesNo_Value@",
                   (objPatent.AdditionalGoodsClassesNumber != string.Empty) ? objPatent.AdditionalGoodsClassesNumber.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@Comment_Value@",
                    (objPatent.Comment != string.Empty) ? objPatent.Comment.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@KCommission_Value@",
                   (objPatent.KCommission != string.Empty) ? objPatent.KCommission.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@RegDate_Value@",
                    (objPatent.RegDate != string.Empty) ? objPatent.RegDate : "NULL");
                strQuery = strQuery.Replace("@NextAnnuityDate_Value@",
                    (objPatent.NextAnnuityDate != string.Empty) ? objPatent.NextAnnuityDate : "NULL");
                strQuery = strQuery.Replace("@NextAnnuityYear_Value@",
                    (objPatent.NextAnnuityYear != 0) ? objPatent.NextAnnuityYear.ToString() : "NULL");
                strQuery = strQuery.Replace("@ApplicantID_Value@",
                    (objPatent.ApplicantID != 0) ? objPatent.ApplicantID.ToString() : "NULL");
                strQuery = strQuery.Replace("@AgentID_Value@",
                    (objPatent.AgentID != 0) ? objPatent.AgentID.ToString() : "NULL");
                strQuery = strQuery.Replace("@Agent2ID_Value@",
                    (objPatent.Agent2ID != 0) ? objPatent.Agent2ID.ToString() : "NULL");
                strQuery = strQuery.Replace("@StatusID_Value@",
                    (objPatent.StatusID != 0) ? objPatent.StatusID.ToString() : "NULL");
                strQuery = strQuery.Replace("@PowerOfAttorneyNo_Value@",
                    (objPatent.PowerOfAttorney != 0) ? objPatent.PowerOfAttorney.ToString() : "NULL");
                strQuery = strQuery.Replace("@LastDateChecked_Value@",
                    (objPatent.LastDateChecked != string.Empty) ? objPatent.LastDateChecked : "NULL");

                strQuery = strQuery.Replace("N'NULL'", "NULL");
                strQuery = strQuery.Replace("'NULL'", "NULL");
                ClsDBController.Instance.ExecuteNoneQuery(strQuery.ToString());

                arrParams = new SqlParameter[2];

                objParam = new SqlParameter();
                objParam.ParameterName = "@TableName";
                objParam.SqlDbType = SqlDbType.NVarChar;
                objParam.Size = 255;
                objParam.Direction = ParameterDirection.Input;
                objParam.SqlValue = ClsDBConstants.Patent_TableName;
                arrParams[0] = objParam;

                objParam = new SqlParameter();
                objParam.ParameterName = "@ID";
                objParam.SqlDbType = SqlDbType.BigInt;
                objParam.Direction = ParameterDirection.Output;
                arrParams[1] = objParam;

                ClsDBController.Instance.ExecuteProcedureNonQuery("[dbo].[GetLastTableID]", arrParams);
                ClsLogDataAccessLogic.Insert(ClsLoginManager.GetLoggedOnUser(objCurrentPage).UserID, string.Format("{0:yyyy/MM/dd}", ClsLogDataAccessLogic.GetNowPersianDate()), Convert.ToInt32(ClsLogDataAccessLogic.TransactionType.PatentCreated), true);

                objPatent.ID = (long)arrParams[1].Value;
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

        public void Update(ClsPatent objPatent, bool blnCloseConnection, Page objCurrentPage)
        {
            try
            {
                System.Text.StringBuilder strQuery;

                strQuery = new System.Text.StringBuilder(
                   " Update[dbo].[@TableName@]  " +
                   "    SET    [@FillingNo@] = @FillingNo_Value@                 ,     [@Year@] = @Year_Value@, " +
                   "           [@TradeMark@] = N'@TradeMark_Value@'              ,     [@AppNo@] = N'@AppNo_Value@',     [@AdditionalGoodsClassesNo@] = N'@AdditionalGoodsClassesNo_Value@', " +
                   "           [@AppDate@] = '@AppDate_Value@'                   ,     [@RegNo@] =  N'@RegNo_Value@', " +
                   "           [@RegDate@] = '@RegDate_Value@'                   ,     [@NextAnnuityDate@] =  '@NextAnnuityDate_Value@', " +
                   "           [@NextAnnuityYear@] = @NextAnnuityYear_Value@     ,     [@ApplicantID@] = @ApplicantID_Value@,  " +
                   "           [@AgentID@] = @AgentID_Value@                     ,     [@Agent2ID@] = @Agent2ID_Value@,     [@Comment@] = N'@Comment_Value@',     [@KCommission@] = N'@KCommission_Value@',     [@StatusID@] = @StatusID_Value@, " +
                   "           [@PowerOfAttorneyNo@] = @PowerOfAttorneyNo_Value@ ,     [@LastDateChecked@] = '@LastDateChecked_Value@' " +
                   "   Where [@ID@] = @ID_Value@");

                strQuery = strQuery.Replace("@FillingNo@", ClsDBConstants.Patent_Col_FillingNo);
                strQuery = strQuery.Replace("@Year@", ClsDBConstants.Patent_Col_Year);
                strQuery = strQuery.Replace("@TradeMark@", ClsDBConstants.Patent_Col_Title);
                strQuery = strQuery.Replace("@AppNo@", ClsDBConstants.Patent_Col_AppNo);
                strQuery = strQuery.Replace("@AdditionalGoodsClassesNo@", ClsDBConstants.Patent_Col_AdditionalGoodsClassesNo);
                strQuery = strQuery.Replace("@AppDate@", ClsDBConstants.Patent_Col_AppDate);
                strQuery = strQuery.Replace("@RegNo@", ClsDBConstants.Patent_Col_RegNo);
                strQuery = strQuery.Replace("@RegDate@", ClsDBConstants.Patent_Col_RegDate);
                strQuery = strQuery.Replace("@NextAnnuityDate@", ClsDBConstants.Patent_Col_NextAnnuityDate);
                strQuery = strQuery.Replace("@NextAnnuityYear@", ClsDBConstants.Patent_Col_NextAnnuityYear);
                strQuery = strQuery.Replace("@ApplicantID@", ClsDBConstants.Patent_Col_ApplicantID);
                strQuery = strQuery.Replace("@AgentID@", ClsDBConstants.Patent_Col_AgentID);
                strQuery = strQuery.Replace("@Agent2ID@", ClsDBConstants.Patent_Col_Agent2ID);
                strQuery = strQuery.Replace("@Comment@", ClsDBConstants.Patent_Col_Comment);
                strQuery = strQuery.Replace("@KCommission@", ClsDBConstants.Patent_Col_KCommission);
                strQuery = strQuery.Replace("@StatusID@", ClsDBConstants.Patent_Col_StatusID);
                strQuery = strQuery.Replace("@PowerOfAttorneyNo@", ClsDBConstants.Patent_Col_PowerOfAttorneyNo);
                strQuery = strQuery.Replace("@LastDateChecked@", ClsDBConstants.Patent_Col_LastDateChecked);
                strQuery = strQuery.Replace("@ID@", ClsDBConstants.Patent_Col_ID);

                strQuery = strQuery.Replace("@FillingNo_Value@",
                    objPatent.FillingNumber.ToString());
                strQuery = strQuery.Replace("@Year_Value@",
                    (objPatent.Year != 0) ? objPatent.Year.ToString() : "NULL");
                strQuery = strQuery.Replace("@TradeMark_Value@",
                    (objPatent.Title != string.Empty) ? objPatent.Title.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@AppNo_Value@",
                    (objPatent.AppNumber != string.Empty) ? objPatent.AppNumber.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@AdditionalGoodsClassesNo_Value@",
                    (objPatent.AdditionalGoodsClassesNumber != string.Empty) ? objPatent.AdditionalGoodsClassesNumber.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@AppDate_Value@",
                    (objPatent.AppDate != string.Empty) ? objPatent.AppDate : "NULL");
                strQuery = strQuery.Replace("@RegNo_Value@",
                    (objPatent.RegNumber != string.Empty) ? objPatent.RegNumber.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@RegDate_Value@",
                    (objPatent.RegDate != string.Empty) ? objPatent.RegDate : "NULL");
                strQuery = strQuery.Replace("@NextAnnuityDate_Value@",
                    (objPatent.NextAnnuityDate != string.Empty) ? objPatent.NextAnnuityDate : "NULL");
                strQuery = strQuery.Replace("@NextAnnuityYear_Value@",
                    (objPatent.NextAnnuityYear != 0) ? objPatent.NextAnnuityYear.ToString() : "NULL");
                strQuery = strQuery.Replace("@ApplicantID_Value@",
                    (objPatent.ApplicantID != 0) ? objPatent.ApplicantID.ToString() : "NULL");
                strQuery = strQuery.Replace("@AgentID_Value@",
                    (objPatent.AgentID != 0) ? objPatent.AgentID.ToString() : "NULL");
                strQuery = strQuery.Replace("@Agent2ID_Value@",
                    (objPatent.Agent2ID != 0) ? objPatent.Agent2ID.ToString() : "NULL");
                strQuery = strQuery.Replace("@Comment_Value@",
                    (objPatent.Comment != string.Empty) ? objPatent.Comment.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@KCommission_Value@",
                    (objPatent.KCommission != string.Empty) ? objPatent.KCommission.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@StatusID_Value@",
                    (objPatent.StatusID != 0) ? objPatent.StatusID.ToString() : "NULL");
                strQuery = strQuery.Replace("@PowerOfAttorneyNo_Value@",
                    (objPatent.PowerOfAttorney != 0) ? objPatent.PowerOfAttorney.ToString() : "NULL");
                strQuery = strQuery.Replace("@LastDateChecked_Value@",
                    (objPatent.LastDateChecked != string.Empty) ? objPatent.LastDateChecked : "NULL");
                strQuery = strQuery.Replace("@ID_Value@", objPatent.ID.ToString());

                strQuery = strQuery.Replace("@TableName@", ClsDBConstants.Patent_TableName);

                strQuery = strQuery.Replace("N'NULL'", "NULL");
                strQuery = strQuery.Replace("'NULL'", "NULL");
                ClsDBController.Instance.ExecuteNoneQuery(strQuery.ToString());
                ClsLogDataAccessLogic.Insert(ClsLoginManager.GetLoggedOnUser(objCurrentPage).UserID, string.Format("{0:yyyy/MM/dd}", ClsLogDataAccessLogic.GetNowPersianDate()), Convert.ToInt32(ClsLogDataAccessLogic.TransactionType.PatentUpdated), true);

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

        public void Delete(ClsPatent objPatent, bool blnCloseConnection, Page objCurrentPage)
        {
            Delete(objPatent.ID, blnCloseConnection, objCurrentPage);
        }

        public void Delete(long lPatentID, bool blnCloseConnection, Page objCurrentPage)
        {
            try
            {
                string strQuery;
                strQuery = "Delete From {0} Where [{1}] = {2}";

                strQuery = string.Format(strQuery,
                                         ClsDBConstants.Patent_TableName,
                                         ClsDBConstants.Patent_Col_ID,
                                         lPatentID);
                ClsDBController.Instance.ExecuteNoneQuery(strQuery);
                ClsLogDataAccessLogic.Insert(ClsLoginManager.GetLoggedOnUser(objCurrentPage).UserID, string.Format("{0:yyyy/MM/dd}", ClsLogDataAccessLogic.GetNowPersianDate()), Convert.ToInt32(ClsLogDataAccessLogic.TransactionType.PatentDeleted), true);

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

        public bool IsFillingNoExists(long lFillingNo, long lOriginalPatentID)
        {
            DataTable dtResult = null;
            string strQuery;

            try
            {
                strQuery = " Select * From @TableName@ " +
                           " Where (@FillingNo@=@FillingNoValue@) AND (ID <> @lOriginalID@)";
                strQuery = strQuery.Replace("@TableName@", ClsDBConstants.Patent_TableName);
                strQuery = strQuery.Replace("@FillingNo@", ClsDBConstants.Patent_Col_FillingNo);
                strQuery = strQuery.Replace("@FillingNoValue@", lFillingNo.ToString());
                strQuery = strQuery.Replace("@lOriginalID@", lOriginalPatentID.ToString());

                dtResult = ClsDBController.Instance.ExecuteQuery(strQuery);

                return (dtResult.Rows.Count > 0);
            }
            finally
            {
                if (dtResult != null)
                    dtResult.Dispose();
            }
        }

        public bool IsRegNoExists(string lRegNo, long lOriginalPatentID)
        {
            DataTable dtResult = null;
            string strQuery;

            try
            {
                strQuery = " Select * From @TableName@ " +
                           " Where (@RegNo@=N'@RegNoValue@') AND (ID <> @lOriginalID@)";
                strQuery = strQuery.Replace("@TableName@", ClsDBConstants.Patent_TableName);
                strQuery = strQuery.Replace("@RegNo@", ClsDBConstants.Patent_Col_RegNo);
                strQuery = strQuery.Replace("@RegNoValue@", lRegNo.ToString());
                strQuery = strQuery.Replace("@lOriginalID@", lOriginalPatentID.ToString());

                dtResult = ClsDBController.Instance.ExecuteQuery(strQuery);

                return (dtResult.Rows.Count > 0);
            }
            finally
            {
                if (dtResult != null)
                    dtResult.Dispose();
            }
        }

        public bool IsAppNoExists(string lAppNo, long lOriginalPatentID)
        {
            DataTable dtResult = null;
            string strQuery;

            try
            {
                strQuery = " Select * From @TableName@ " +
                           " Where (@AppNo@=N'@AppNoValue@') AND (ID <> @lOriginalID@)";
                strQuery = strQuery.Replace("@TableName@", ClsDBConstants.Patent_TableName);
                strQuery = strQuery.Replace("@AppNo@", ClsDBConstants.Patent_Col_AppNo);
                strQuery = strQuery.Replace("@AppNoValue@", lAppNo.ToString());
                strQuery = strQuery.Replace("@lOriginalID@", lOriginalPatentID.ToString());

                dtResult = ClsDBController.Instance.ExecuteQuery(strQuery);

                return (dtResult.Rows.Count > 0);
            }
            finally
            {
                if (dtResult != null)
                    dtResult.Dispose();
            }
        }

        public bool IsAdditionalGoodsClassesExists(string lAdditionalGoodsClassesNo, long lOriginalPatentID)
        {
            DataTable dtResult = null;
            string strQuery;

            try
            {
                strQuery = " Select * From @TableName@ " +
                           " Where (@AdditionalGoodsClassesNo@=N'@AdditionalGoodsClassesNoValue@') AND (ID <> @lOriginalID@)";
                strQuery = strQuery.Replace("@TableName@", ClsDBConstants.Patent_TableName);
                strQuery = strQuery.Replace("@AdditionalGoodsClassesNo@", ClsDBConstants.Patent_Col_AdditionalGoodsClassesNo);
                strQuery = strQuery.Replace("@AdditionalGoodsClassesNoValue@", lAdditionalGoodsClassesNo.ToString());
                strQuery = strQuery.Replace("@lOriginalID@", lOriginalPatentID.ToString());

                dtResult = ClsDBController.Instance.ExecuteQuery(strQuery);

                return (dtResult.Rows.Count > 0);
            }
            finally
            {
                if (dtResult != null)
                    dtResult.Dispose();
            }
        }

        public DataTable GetPatentForPreview(string strSortBy, bool blnSortAscending)
        {
            try
            {
                string strQuery;

                strQuery = "Select * From " + ClsDBConstants.Patent_TableName;

                if (strSortBy != string.Empty)
                    strQuery += " Order By " + strSortBy + ((blnSortAscending) ? " Asc" : " Desc") +
                                " , " + ClsDBConstants.Patent_Col_FillingNo + " Desc";

                return ClsDBController.Instance.ExecuteQuery(strQuery);
            }
            finally
            {
                ClsDBController.Instance.Close();
            }
        }

        public ClsPatent GetPatent(long lPatentID)
        {
            SqlDataReader objReader = null;
            try
            {
                string strQuery;
                ClsPatent ObjPatent = null;

                strQuery = "Select * From {0} Where {1}={2}";

                strQuery = string.Format(strQuery,
                                         ClsDBConstants.Patent_TableName,
                                         ClsDBConstants.Patent_Col_ID,
                                         lPatentID);

                objReader = ClsDBController.Instance.ExecuteReader(strQuery);

                if (objReader.Read())
                {
                    ObjPatent = FillPatent(objReader);
                }

                return ObjPatent;
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

        public List<ClsPatent> GetAllPatents(string strSortBy, bool blnSortAscending)
        {
            SqlDataReader objReader = null;
            try
            {
                string strQuery;
                List<ClsPatent> colPatents;
                ClsPatent objPatent;

                strQuery = "Select * From " + ClsDBConstants.Patent_TableName;

                if (strSortBy != string.Empty)
                    strQuery += " Order By " + strSortBy + ((blnSortAscending) ? " Asc" : " Desc") +
                                " , " + ClsDBConstants.Patent_Col_FillingNo + " Desc";

                objReader = ClsDBController.Instance.ExecuteReader(strQuery);

                colPatents = new List<ClsPatent>();

                while (objReader.Read())
                {
                    objPatent = FillPatent(objReader);
                    colPatents.Add(objPatent);
                }
                return colPatents;
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

        private ClsPatent FillPatent(SqlDataReader objReader)
        {
            ClsPatent objPatent;
            objPatent = new ClsPatent();

            objPatent.AgentID = (objReader[ClsDBConstants.Patent_Col_AgentID] is DBNull) ? 0 :
                (int)objReader[ClsDBConstants.Patent_Col_AgentID];
            objPatent.Agent2ID = (objReader[ClsDBConstants.Patent_Col_Agent2ID] is DBNull) ? 0 :
                (int)objReader[ClsDBConstants.Patent_Col_Agent2ID];
            objPatent.Comment = (objReader[ClsDBConstants.Patent_Col_Comment] is DBNull) ? string.Empty :
               (string)objReader[ClsDBConstants.Patent_Col_Comment];
            objPatent.KCommission = (objReader[ClsDBConstants.Patent_Col_KCommission] is DBNull) ? string.Empty :
               (string)objReader[ClsDBConstants.Patent_Col_KCommission];
            objPatent.AppDate = (objReader[ClsDBConstants.Patent_Col_AppDate] is DBNull) ? string.Empty :
                (string)objReader[ClsDBConstants.Patent_Col_AppDate];
            objPatent.ApplicantID = (objReader[ClsDBConstants.Patent_Col_ApplicantID] is DBNull) ? 0 :
                (int)objReader[ClsDBConstants.Patent_Col_ApplicantID];
            objPatent.AppNumber = (objReader[ClsDBConstants.Patent_Col_AppNo] is DBNull) ? string.Empty :
                (string)objReader[ClsDBConstants.Patent_Col_AppNo];
            objPatent.AdditionalGoodsClassesNumber = (objReader[ClsDBConstants.Patent_Col_AdditionalGoodsClassesNo] is DBNull) ? string.Empty :
                (string)objReader[ClsDBConstants.Patent_Col_AdditionalGoodsClassesNo];
            objPatent.FillingNumber = (long)objReader[ClsDBConstants.Patent_Col_FillingNo];
            objPatent.ID = (long)objReader[ClsDBConstants.Patent_Col_ID];
            objPatent.LastDateChecked = (objReader[ClsDBConstants.Patent_Col_LastDateChecked] is DBNull) ? string.Empty :
                (string)objReader[ClsDBConstants.Patent_Col_LastDateChecked];
            objPatent.NextAnnuityDate = (objReader[ClsDBConstants.Patent_Col_NextAnnuityDate] is DBNull) ? string.Empty :
                (string)objReader[ClsDBConstants.Patent_Col_NextAnnuityDate];
            objPatent.NextAnnuityYear = (objReader[ClsDBConstants.Patent_Col_NextAnnuityYear] is DBNull) ? 0 :
                (int)objReader[ClsDBConstants.Patent_Col_NextAnnuityYear];
            objPatent.PowerOfAttorney = (objReader[ClsDBConstants.Patent_Col_PowerOfAttorneyNo] is DBNull) ? 0 :
                (long)objReader[ClsDBConstants.Patent_Col_PowerOfAttorneyNo];
            objPatent.RegDate = (objReader[ClsDBConstants.Patent_Col_RegDate] is DBNull) ? string.Empty :
                (string)objReader[ClsDBConstants.Patent_Col_RegDate];
            objPatent.RegNumber = (objReader[ClsDBConstants.Patent_Col_RegNo] is DBNull) ? string.Empty :
                (string)objReader[ClsDBConstants.Patent_Col_RegNo];
            objPatent.StatusID = (objReader[ClsDBConstants.Patent_Col_StatusID] is DBNull) ? 0 :
                (int)objReader[ClsDBConstants.Patent_Col_StatusID];
            objPatent.Title = (objReader[ClsDBConstants.Patent_Col_Title] is DBNull) ? string.Empty :
                (string)objReader[ClsDBConstants.Patent_Col_Title];
            objPatent.Year = (objReader[ClsDBConstants.Patent_Col_Year] is DBNull) ? 0 :
                (int)objReader[ClsDBConstants.Patent_Col_Year];

            return objPatent;
        }

        public DataTable Search(string lAppNo,
                                string lRegNo, string lAdditionalGoodsClassesNo,
                                string strTitle,
                                long lApplicantID,
                                long lAgentID,
                                long lAgent2ID,
                                long lFillingNo, long lStatusID,
                                string strSortBy,
                                bool blnSortAscending)
        {
            string strQuery;
            string strWhereClause = string.Empty;
            bool blnConditionAdded = false;

            strWhereClause = " Where (";

            if (!string.IsNullOrEmpty(lAppNo))
            {
                strWhereClause += ClsDBConstants.Patent_Col_AppNo + " = N'" + lAppNo.ToString() + "'";
                blnConditionAdded = true;
            }

            if (!string.IsNullOrEmpty(lRegNo))
            {
                if (blnConditionAdded)
                    strWhereClause += ") And (";

                strWhereClause += ClsDBConstants.Patent_Col_RegNo + " = N'" + lRegNo.ToString() + "'";
                blnConditionAdded = true;
            }

            if (!string.IsNullOrEmpty(lAdditionalGoodsClassesNo))
            {
                strWhereClause += ClsDBConstants.Patent_Col_AdditionalGoodsClassesNo + " = N'" + lAdditionalGoodsClassesNo.ToString() + "'";
                blnConditionAdded = true;
            }

            if (strTitle != string.Empty)
            {
                if (blnConditionAdded)
                    strWhereClause += ") And (";

                strWhereClause += ClsDBConstants.Patent_Col_Title + " Like '%" + strTitle.Replace("'", "''") + "%'";
                blnConditionAdded = true;
            }

            if (lApplicantID != 0)
            {
                if (blnConditionAdded)
                    strWhereClause += ") And (";

                strWhereClause += ClsDBConstants.Patent_Col_ApplicantID + " = " + lApplicantID.ToString();
                blnConditionAdded = true;
            }

            if (lAgentID != 0)
            {
                if (blnConditionAdded)
                    strWhereClause += ") And (";

                strWhereClause += ClsDBConstants.Patent_Col_AgentID + " = " + lAgentID.ToString();
                blnConditionAdded = true;
            }

            if (lAgent2ID != 0)
            {
                if (blnConditionAdded)
                    strWhereClause += ") And (";

                strWhereClause += ClsDBConstants.Patent_Col_Agent2ID + " = " + lAgent2ID.ToString();
                blnConditionAdded = true;
            }

            if (lStatusID != 0)
            {
                if (blnConditionAdded)
                    strWhereClause += ") And (";

                strWhereClause += ClsDBConstants.Patent_Col_StatusID + " = " + lStatusID.ToString();
                blnConditionAdded = true;
            }

            if (lFillingNo != 0)
            {
                if (blnConditionAdded)
                    strWhereClause += ") And (";

                strWhereClause += ClsDBConstants.Patent_Col_FillingNo + " = " + lFillingNo.ToString();
                blnConditionAdded = true;
            }

            if (!blnConditionAdded)
            {
                strWhereClause = string.Empty;
            }
            else
            {
                strWhereClause += ")";
            }

            strQuery = " Select * From {0} {1}";

            strQuery = string.Format(strQuery, ClsDBConstants.Patent_TableName, strWhereClause);

            if (strSortBy != string.Empty)
                strQuery += " Order By " + strSortBy + ((blnSortAscending) ? " Asc" : " Desc") +
                            " , " + ClsDBConstants.Patent_Col_FillingNo + " Desc";

            return ClsDBController.Instance.ExecuteQuery(strQuery);
        }
    }
}
