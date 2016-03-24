using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using Laghaee.Entity;
using Laghaee.Common;
using DBController.DataAccessLayer;
using Laghaee.DataAccess;
using System.Web.UI;


namespace Laghaee.DataAccessLayer
{
    /// <summary>
    /// Summary description for ClsTradeMarkDataAccessLogic
    /// </summary>
    public class ClsTradeMarkDataAccessLogic
    {
        public void Insert(ClsTradeMark objTradeMark, bool blnCloseConnection, Page objCurrentPage)
        {
            try
            {
                System.Text.StringBuilder strQuery;
                SqlParameter[] arrParams;
                SqlParameter objParam;

                if (objTradeMark.AppDate == string.Empty)
                {
                    objTradeMark.RenewalDate = string.Empty;
                    objTradeMark.RenewalCount = 0;
                }

                strQuery = new System.Text.StringBuilder(
                   " INSERT INTO [dbo].[TradeMarkApplications]  " +
                   "    (                            [@FillingNo@],               [@Year@],               [@TradeMark@],           [@Picture@],               [@OppositionAganistNo@],               [@AdditionalGoodsClassesNo@],           [@ExtractNumber@], " +
                   "    [@AppNo@],                   [@AppDate@],                 [@RegNo@],              [@RegDate@],             [@RenewalDate@], [@RenewalCount@], " +
                   "    [@Class@],                   [@ApplicantID@],             [@AgentID@],             [@Agent2ID@],             [@Comment@],             [@KCommission@], " +
                   "    [@StatusID@],                [@PowerOfAttorneyNo@],       [@LastDateChecked@]) " +
                   " VALUES " +
                   "    (                             @FillingNo_Value@,          @Year_Value@,          N'@TradeMark_Value@',    N'@Picture_Value@',            N'@OppositionAganistNo_Value@',            N'@AdditionalGoodsClassesNo_Value@',            N'@ExtractNumber_Value@', " +
                   "      N'@AppNo_Value@',              '@AppDate_Value@',            N'@RegNo_Value@',          '@RegDate_Value@',       '@RenewalDate_Value@', @RenewalCount_Value@, " +
                   "    '@Class_Value@',              @ApplicantID_Value@,        @AgentID_Value@,        @Agent2ID_Value@,        N'@Comment_Value@',        N'@KCommission_Value@', " +
                   "     @StatusID_Value@,            @PowerOfAttorneyNo_Value@, '@LastDateChecked_Value@')");

                strQuery = strQuery.Replace("@FillingNo@", ClsDBConstants.TradeMark_Col_FillingNo);
                strQuery = strQuery.Replace("@Year@", ClsDBConstants.TradeMark_Col_Year);
                strQuery = strQuery.Replace("@TradeMark@", ClsDBConstants.TradeMark_Col_TradeMark);
                strQuery = strQuery.Replace("@Picture@", ClsDBConstants.TradeMark_Col_Picture);
                strQuery = strQuery.Replace("@AppNo@", ClsDBConstants.TradeMark_Col_AppNo);
                strQuery = strQuery.Replace("@OppositionAganistNo@", ClsDBConstants.TradeMark_Col_OppositionAgainstNo);
                strQuery = strQuery.Replace("@AdditionalGoodsClassesNo@", ClsDBConstants.TradeMark_Col_AdditionalGoodsClassesNo);
                strQuery = strQuery.Replace("@ExtractNumber@", ClsDBConstants.TradeMark_Col_ExtractNumber);
                strQuery = strQuery.Replace("@AppDate@", ClsDBConstants.TradeMark_Col_AppDate);
                strQuery = strQuery.Replace("@RegNo@", ClsDBConstants.TradeMark_Col_RegNo);
                strQuery = strQuery.Replace("@RegDate@", ClsDBConstants.TradeMark_Col_RegDate);
                strQuery = strQuery.Replace("@RenewalDate@", ClsDBConstants.TradeMark_Col_RenewalDate);
                strQuery = strQuery.Replace("@RenewalCount@", ClsDBConstants.TradeMark_Col_RenewalCount);
                strQuery = strQuery.Replace("@Class@", ClsDBConstants.TradeMark_Col_Class);
                strQuery = strQuery.Replace("@ApplicantID@", ClsDBConstants.TradeMark_Col_ApplicantID);
                strQuery = strQuery.Replace("@AgentID@", ClsDBConstants.TradeMark_Col_AgentID);
                strQuery = strQuery.Replace("@Agent2ID@", ClsDBConstants.TradeMark_Col_Agent2ID);
                strQuery = strQuery.Replace("@Comment@", ClsDBConstants.TradeMark_Col_Comment);
                strQuery = strQuery.Replace("@KCommission@", ClsDBConstants.TradeMark_Col_KCommission);
                strQuery = strQuery.Replace("@StatusID@", ClsDBConstants.TradeMark_Col_StatusID);
                strQuery = strQuery.Replace("@PowerOfAttorneyNo@", ClsDBConstants.TradeMark_Col_PowerOfAttorneyNo);
                strQuery = strQuery.Replace("@LastDateChecked@", ClsDBConstants.TradeMark_Col_LastDateChecked);

                strQuery = strQuery.Replace("@FillingNo_Value@",
                    objTradeMark.FillingNumber.ToString());
                strQuery = strQuery.Replace("@Year_Value@",
                    (objTradeMark.Year != 0) ? objTradeMark.Year.ToString() : "NULL");
                strQuery = strQuery.Replace("@TradeMark_Value@",
                    (objTradeMark.TradeMarkName != string.Empty) ? objTradeMark.TradeMarkName.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@Picture_Value@",
                    (objTradeMark.Picture == null) ? "NULL" :
                    objTradeMark.Picture.Replace("'", "''"));
                strQuery = strQuery.Replace("@AppNo_Value@",
                    (objTradeMark.AppNumber != string.Empty) ? objTradeMark.AppNumber.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@Comment_Value@",
                    (objTradeMark.Comment != string.Empty) ? objTradeMark.Comment.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@KCommission_Value@",
                    (objTradeMark.KCommission != string.Empty) ? objTradeMark.KCommission.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@OppositionAganistNo_Value@",
                   (objTradeMark.OppositionAganistNumber != string.Empty) ? objTradeMark.OppositionAganistNumber.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@AdditionalGoodsClassesNo_Value@",
                   (objTradeMark.AdditionalGoodsClassesNumber != string.Empty) ? objTradeMark.AdditionalGoodsClassesNumber.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@ExtractNumber_Value@",
                   (objTradeMark.ExtractNumber != string.Empty) ? objTradeMark.ExtractNumber.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@AppDate_Value@",
                    (objTradeMark.AppDate != string.Empty) ? objTradeMark.AppDate : "NULL");
                strQuery = strQuery.Replace("@RegNo_Value@",
                    (objTradeMark.RegNumber != string.Empty) ? objTradeMark.RegNumber.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@RegDate_Value@",
                    (objTradeMark.RegDate != string.Empty) ? objTradeMark.RegDate : "NULL");

                strQuery = strQuery.Replace("@RenewalDate_Value@",
                    (objTradeMark.RenewalDate != string.Empty) ? objTradeMark.RenewalDate : "NULL");
                strQuery = strQuery.Replace("@RenewalCount_Value@", objTradeMark.RenewalCount.ToString());

                strQuery = strQuery.Replace("@Class_Value@",
                    (objTradeMark.Classes != null) ? objTradeMark.Classes.ToString() : "NULL");
                strQuery = strQuery.Replace("@ApplicantID_Value@",
                    (objTradeMark.ApplicantID != 0) ? objTradeMark.ApplicantID.ToString() : "NULL");
                strQuery = strQuery.Replace("@AgentID_Value@",
                    (objTradeMark.AgentID != 0) ? objTradeMark.AgentID.ToString() : "NULL");
                strQuery = strQuery.Replace("@Agent2ID_Value@",
                    (objTradeMark.Agent2ID != 0) ? objTradeMark.Agent2ID.ToString() : "NULL");
                strQuery = strQuery.Replace("@StatusID_Value@",
                    (objTradeMark.StatusID != 0) ? objTradeMark.StatusID.ToString() : "NULL");
                strQuery = strQuery.Replace("@PowerOfAttorneyNo_Value@",
                    (objTradeMark.PowerOfAttorney != 0) ? objTradeMark.PowerOfAttorney.ToString() : "NULL");
                strQuery = strQuery.Replace("@LastDateChecked_Value@",
                    (objTradeMark.LastDateChecked != string.Empty) ? objTradeMark.LastDateChecked : "NULL");

                strQuery = strQuery.Replace("N'NULL'", "NULL");
                strQuery = strQuery.Replace("'NULL'", "NULL");
                ClsDBController.Instance.ExecuteNoneQuery(strQuery.ToString());

                arrParams = new SqlParameter[2];

                objParam = new SqlParameter();
                objParam.ParameterName = "@TableName";
                objParam.SqlDbType = SqlDbType.NVarChar;
                objParam.Size = 255;
                objParam.Direction = ParameterDirection.Input;
                objParam.SqlValue = ClsDBConstants.TradeMark_TableName;
                arrParams[0] = objParam;

                objParam = new SqlParameter();
                objParam.ParameterName = "@ID";
                objParam.SqlDbType = SqlDbType.BigInt;
                objParam.Direction = ParameterDirection.Output;
                arrParams[1] = objParam;

                ClsDBController.Instance.ExecuteProcedureNonQuery("[dbo].[GetLastTableID]", arrParams);
                ClsLogDataAccessLogic.Insert(ClsLoginManager.GetLoggedOnUser(objCurrentPage).UserID, string.Format("{0:yyyy/MM/dd}", ClsLogDataAccessLogic.GetNowPersianDate()), Convert.ToInt32(ClsLogDataAccessLogic.TransactionType.TradeMarkCreated), true);

                objTradeMark.ID = (long)arrParams[1].Value;
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

        public void Update(ClsTradeMark objTradeMark, bool blnCloseConnection, Page objCurrentPage)
        {
            try
            {

                if (objTradeMark.AppDate == string.Empty)
                {
                    objTradeMark.RenewalDate = string.Empty;
                    objTradeMark.RenewalCount = 0;
                }

                System.Text.StringBuilder strQuery;

                strQuery = new System.Text.StringBuilder(
                   " Update[dbo].[@TableName@]  " +
                   "    SET    [@FillingNo@] = @FillingNo_Value@                 ,     [@Year@] = @Year_Value@, " +
                   "           [@TradeMark@] = N'@TradeMark_Value@'              ,     [@Picture@] = N'@Picture_Value@', " +
                   "           [@OppositionAganistNo@] = N'@OppositionAganistNo_Value@'              , [@AdditionalGoodsClassesNo@] = N'@AdditionalGoodsClassesNo_Value@',     [@ExtractNumber@] = N'@ExtractNumber_Value@', " +
                   "           [@AppNo@] = N'@AppNo_Value@'                         ,     [@AppDate@] = '@AppDate_Value@', " +
                   "           [@RegNo@] =  N'@RegNo_Value@'                        ,     [@RegDate@] = '@RegDate_Value@',  " +
                   "           [@RenewalDate@] =  '@RenewalDate_Value@'          ,     [@Class@] = '@Class_Value@', " +
                   "           [@RenewalCount@] =  @RenewalCount_Value@          ,     " +
                   "           [@ApplicantID@] = @ApplicantID_Value@             ,     [@AgentID@] = @AgentID_Value@,     [@Agent2ID@] = @Agent2ID_Value@,     [@Comment@] = N'@Comment_Value@',     [@KCommission@] = N'@KCommission_Value@', " +
                   "           [@StatusID@] = @StatusID_Value@                   ,     [@PowerOfAttorneyNo@] = @PowerOfAttorneyNo_Value@,  " +
                   "           [@LastDateChecked@] = '@LastDateChecked_Value@'  Where [@ID@] = @ID_Value@");

                strQuery = strQuery.Replace("@FillingNo@", ClsDBConstants.TradeMark_Col_FillingNo);
                strQuery = strQuery.Replace("@Year@", ClsDBConstants.TradeMark_Col_Year);
                strQuery = strQuery.Replace("@TradeMark@", ClsDBConstants.TradeMark_Col_TradeMark);
                strQuery = strQuery.Replace("@Picture@", ClsDBConstants.TradeMark_Col_Picture);
                strQuery = strQuery.Replace("@AppNo@", ClsDBConstants.TradeMark_Col_AppNo);
                strQuery = strQuery.Replace("@OppositionAganistNo@", ClsDBConstants.TradeMark_Col_OppositionAgainstNo);
                strQuery = strQuery.Replace("@AdditionalGoodsClassesNo@", ClsDBConstants.TradeMark_Col_AdditionalGoodsClassesNo);
                strQuery = strQuery.Replace("@ExtractNumber@", ClsDBConstants.TradeMark_Col_ExtractNumber);
                strQuery = strQuery.Replace("@AppDate@", ClsDBConstants.TradeMark_Col_AppDate);
                strQuery = strQuery.Replace("@RegNo@", ClsDBConstants.TradeMark_Col_RegNo);
                strQuery = strQuery.Replace("@RegDate@", ClsDBConstants.TradeMark_Col_RegDate);
                strQuery = strQuery.Replace("@RenewalDate@", ClsDBConstants.TradeMark_Col_RenewalDate);
                strQuery = strQuery.Replace("@RenewalCount@", ClsDBConstants.TradeMark_Col_RenewalCount);
                strQuery = strQuery.Replace("@Class@", ClsDBConstants.TradeMark_Col_Class);
                strQuery = strQuery.Replace("@ApplicantID@", ClsDBConstants.TradeMark_Col_ApplicantID);
                strQuery = strQuery.Replace("@AgentID@", ClsDBConstants.TradeMark_Col_AgentID);
                strQuery = strQuery.Replace("@Agent2ID@", ClsDBConstants.TradeMark_Col_Agent2ID);
                strQuery = strQuery.Replace("@Comment@", ClsDBConstants.TradeMark_Col_Comment);
                strQuery = strQuery.Replace("@KCommission@", ClsDBConstants.TradeMark_Col_KCommission);
                strQuery = strQuery.Replace("@StatusID@", ClsDBConstants.TradeMark_Col_StatusID);
                strQuery = strQuery.Replace("@PowerOfAttorneyNo@", ClsDBConstants.TradeMark_Col_PowerOfAttorneyNo);
                strQuery = strQuery.Replace("@LastDateChecked@", ClsDBConstants.TradeMark_Col_LastDateChecked);
                strQuery = strQuery.Replace("@ID@", ClsDBConstants.TradeMark_Col_ID);


                strQuery = strQuery.Replace("@FillingNo_Value@",
                    objTradeMark.FillingNumber.ToString());
                strQuery = strQuery.Replace("@Year_Value@",
                    (objTradeMark.Year != 0) ? objTradeMark.Year.ToString() : "NULL");
                strQuery = strQuery.Replace("@TradeMark_Value@",
                    (objTradeMark.TradeMarkName != string.Empty) ? objTradeMark.TradeMarkName.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@Picture_Value@",
                    (objTradeMark.Picture == null) ? "NULL" :
                    objTradeMark.Picture.Replace("'", "''"));
                strQuery = strQuery.Replace("@AppNo_Value@",
                    (objTradeMark.AppNumber != string.Empty) ? objTradeMark.AppNumber.Replace("'", "''") : "NULL");

                strQuery = strQuery.Replace("@OppositionAganistNo_Value@",
                    (objTradeMark.OppositionAganistNumber != string.Empty) ? objTradeMark.OppositionAganistNumber.Replace("'", "''") : "NULL");

                strQuery = strQuery.Replace("@AdditionalGoodsClassesNo_Value@",
                    (objTradeMark.AdditionalGoodsClassesNumber != string.Empty) ? objTradeMark.AdditionalGoodsClassesNumber.Replace("'", "''") : "NULL");

                strQuery = strQuery.Replace("@ExtractNumber_Value@",
                    (objTradeMark.ExtractNumber != string.Empty) ? objTradeMark.ExtractNumber.Replace("'", "''") : "NULL");

                strQuery = strQuery.Replace("@AppDate_Value@",
                    (objTradeMark.AppDate != string.Empty) ? objTradeMark.AppDate : "NULL");
                strQuery = strQuery.Replace("@RegNo_Value@",
                    (objTradeMark.RegNumber != string.Empty) ? objTradeMark.RegNumber.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@RegDate_Value@",
                    (objTradeMark.RegDate != string.Empty) ? objTradeMark.RegDate : "NULL");

                strQuery = strQuery.Replace("@RenewalDate_Value@",
                    (objTradeMark.RenewalDate != string.Empty) ? objTradeMark.RenewalDate : "NULL");
                strQuery = strQuery.Replace("@RenewalCount_Value@", objTradeMark.RenewalCount.ToString());

                strQuery = strQuery.Replace("@Class_Value@",
                    (objTradeMark.Classes != null) ? objTradeMark.Classes.ToString() : "NULL");
                strQuery = strQuery.Replace("@ApplicantID_Value@",
                    (objTradeMark.ApplicantID != 0) ? objTradeMark.ApplicantID.ToString() : "NULL");
                strQuery = strQuery.Replace("@AgentID_Value@",
                    (objTradeMark.AgentID != 0) ? objTradeMark.AgentID.ToString() : "NULL");
                strQuery = strQuery.Replace("@Agent2ID_Value@",
                    (objTradeMark.Agent2ID != 0) ? objTradeMark.Agent2ID.ToString() : "NULL");
                strQuery = strQuery.Replace("@Comment_Value@",
                    (objTradeMark.Comment != string.Empty) ? objTradeMark.Comment.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@KCommission_Value@",
                    (objTradeMark.KCommission != string.Empty) ? objTradeMark.KCommission.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@RegNo_Value@",
                    (objTradeMark.RegNumber != string.Empty) ? objTradeMark.RegNumber.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@StatusID_Value@",
                    (objTradeMark.StatusID != 0) ? objTradeMark.StatusID.ToString() : "NULL");
                strQuery = strQuery.Replace("@PowerOfAttorneyNo_Value@",
                    (objTradeMark.PowerOfAttorney != 0) ? objTradeMark.PowerOfAttorney.ToString() : "NULL");
                strQuery = strQuery.Replace("@LastDateChecked_Value@",
                    (objTradeMark.LastDateChecked != string.Empty) ? objTradeMark.LastDateChecked : "NULL");
                strQuery = strQuery.Replace("@ID_Value@",
                    objTradeMark.ID.ToString());

                strQuery = strQuery.Replace("@TableName@", ClsDBConstants.TradeMark_TableName);

                strQuery = strQuery.Replace("N'NULL'", "NULL");
                strQuery = strQuery.Replace("'NULL'", "NULL");
                ClsDBController.Instance.ExecuteNoneQuery(strQuery.ToString());
                ClsLogDataAccessLogic.Insert(ClsLoginManager.GetLoggedOnUser(objCurrentPage).UserID, string.Format("{0:yyyy/MM/dd}", ClsLogDataAccessLogic.GetNowPersianDate()), Convert.ToInt32(ClsLogDataAccessLogic.TransactionType.TradeMarkUpdated), true);

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

        public void Delete(ClsTradeMark objTradeMark, bool blnCloseConnection, Page objCurrentPage)
        {
            Delete(objTradeMark.ID, blnCloseConnection, objCurrentPage);
        }

        public void Delete(long lTradeMarkID, bool blnCloseConnection, Page objCurrentPage)
        {
            try
            {
                string strQuery;
                strQuery = "Delete From {0} Where [{1}] = {2}";

                strQuery = string.Format(strQuery,
                                         ClsDBConstants.TradeMark_TableName,
                                         ClsDBConstants.TradeMark_Col_ID,
                                         lTradeMarkID);
                ClsDBController.Instance.ExecuteNoneQuery(strQuery);
                ClsLogDataAccessLogic.Insert(ClsLoginManager.GetLoggedOnUser(objCurrentPage).UserID, string.Format("{0:yyyy/MM/dd}", ClsLogDataAccessLogic.GetNowPersianDate()), Convert.ToInt32(ClsLogDataAccessLogic.TransactionType.TradeMarkDeleted), true);

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

        public bool IsRegNoExists(string lRegNo, long lOriginalTradeMarkID)
        {
            DataTable dtResult = null;
            string strQuery;

            try
            {
                strQuery = " Select * From @TableName@ " +
                           " Where (@RegNo@=N'@RegNoValue@') AND (ID <> @lOriginalID@)";
                strQuery = strQuery.Replace("@TableName@", ClsDBConstants.TradeMark_TableName);
                strQuery = strQuery.Replace("@RegNo@", ClsDBConstants.TradeMark_Col_RegNo);
                strQuery = strQuery.Replace("@RegNoValue@", lRegNo.ToString());
                strQuery = strQuery.Replace("@lOriginalID@", lOriginalTradeMarkID.ToString());

                dtResult = ClsDBController.Instance.ExecuteQuery(strQuery);

                return (dtResult.Rows.Count > 0);
            }
            finally
            {
                if (dtResult != null)
                    dtResult.Dispose();
            }
        }

        public bool IsFillingNoExists(long lFillingNo, long lOriginalTradeMarkID)
        {
            DataTable dtResult = null;
            string strQuery;

            try
            {
                strQuery = " Select * From @TableName@ " +
                           " Where (@FillingNo@=@FillingNoValue@) AND (ID <> @lOriginalID@)";
                strQuery = strQuery.Replace("@TableName@", ClsDBConstants.TradeMark_TableName);
                strQuery = strQuery.Replace("@FillingNo@", ClsDBConstants.TradeMark_Col_FillingNo);
                strQuery = strQuery.Replace("@FillingNoValue@", lFillingNo.ToString());
                strQuery = strQuery.Replace("@lOriginalID@", lOriginalTradeMarkID.ToString());

                dtResult = ClsDBController.Instance.ExecuteQuery(strQuery);

                return (dtResult.Rows.Count > 0);
            }
            finally
            {
                if (dtResult != null)
                    dtResult.Dispose();
            }
        }

        public bool IsAppNoExists(string lAppNo, long lOriginalTradeMarkID)
        {
            DataTable dtResult = null;
            string strQuery;

            try
            {
                strQuery = " Select * From @TableName@ " +
                           " Where (@AppNo@=N'@AppNoValue@') AND (ID <> @lOriginalID@)";
                strQuery = strQuery.Replace("@TableName@", ClsDBConstants.TradeMark_TableName);
                strQuery = strQuery.Replace("@AppNo@", ClsDBConstants.TradeMark_Col_AppNo);
                strQuery = strQuery.Replace("@AppNoValue@", lAppNo.ToString());
                strQuery = strQuery.Replace("@lOriginalID@", lOriginalTradeMarkID.ToString());

                dtResult = ClsDBController.Instance.ExecuteQuery(strQuery);

                return (dtResult.Rows.Count > 0);
            }
            finally
            {
                if (dtResult != null)
                    dtResult.Dispose();
            }
        }

        public bool IsOppositionAganistExists(string lOppositionAganistNo, long lOriginalTradeMarkID)
        {
            DataTable dtResult = null;
            string strQuery;

            try
            {
                strQuery = " Select * From @TableName@ " +
                           " Where (@OppositionAgainstNo@=N'@OppositionAgainstNoValue@') AND (ID <> @lOriginalID@)";
                strQuery = strQuery.Replace("@TableName@", ClsDBConstants.TradeMark_TableName);
                strQuery = strQuery.Replace("@OppositionAgainstNo@", ClsDBConstants.TradeMark_Col_OppositionAgainstNo);
                strQuery = strQuery.Replace("@OppositionAgainstNoValue@", lOppositionAganistNo.ToString());
                strQuery = strQuery.Replace("@lOriginalID@", lOriginalTradeMarkID.ToString());

                dtResult = ClsDBController.Instance.ExecuteQuery(strQuery);

                return (dtResult.Rows.Count > 0);
            }
            finally
            {
                if (dtResult != null)
                    dtResult.Dispose();
            }
        }

        public bool IsAdditionalGoodsClassesExists(string lAdditionalGoodsClassesNo, long lOriginalTradeMarkID)
        {
            DataTable dtResult = null;
            string strQuery;

            try
            {
                strQuery = " Select * From @TableName@ " +
                           " Where (@AdditionalGoodsClassesNo@=N'@AdditionalGoodsClassesNoValue@') AND (ID <> @lOriginalID@)";
                strQuery = strQuery.Replace("@TableName@", ClsDBConstants.TradeMark_TableName);
                strQuery = strQuery.Replace("@AdditionalGoodsClassesNo@", ClsDBConstants.TradeMark_Col_AdditionalGoodsClassesNo);
                strQuery = strQuery.Replace("@AdditionalGoodsClassesNoValue@", lAdditionalGoodsClassesNo.ToString());
                strQuery = strQuery.Replace("@lOriginalID@", lOriginalTradeMarkID.ToString());

                dtResult = ClsDBController.Instance.ExecuteQuery(strQuery);

                return (dtResult.Rows.Count > 0);
            }
            finally
            {
                if (dtResult != null)
                    dtResult.Dispose();
            }
        }

        public DataTable GetTradeMarkForPreview(string strSortBy, bool blnSortAscending)
        {
            try
            {
                string strQuery;

                strQuery = "Select * From " + ClsDBConstants.TradeMark_TableName;

                if (strSortBy != string.Empty)
                    strQuery += " Order By " + strSortBy + ((blnSortAscending) ? " Asc" : " Desc") +
                                " , " + ClsDBConstants.TradeMark_Col_FillingNo + " Desc";

                return ClsDBController.Instance.ExecuteQuery(strQuery);
            }
            finally
            {
                ClsDBController.Instance.Close();
            }
        }

        public ClsTradeMark GetTradeMark(long lTradeMarkID)
        {
            SqlDataReader objReader = null;
            try
            {
                string strQuery;
                ClsTradeMark ObjTradeMark = null;

                strQuery = "Select * From {0} Where {1}={2}";

                strQuery = string.Format(strQuery,
                                         ClsDBConstants.TradeMark_TableName,
                                         ClsDBConstants.TradeMark_Col_ID, lTradeMarkID);

                objReader = ClsDBController.Instance.ExecuteReader(strQuery);

                if (objReader.Read())
                {
                    ObjTradeMark = FillTradeMark(objReader);
                }

                return ObjTradeMark;
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

        public List<ClsTradeMark> GetAllTradeMarks(string strSortBy, bool blnSortAscending)
        {
            SqlDataReader objReader = null;
            try
            {
                string strQuery;
                List<ClsTradeMark> colTradeMarks;
                ClsTradeMark objTradeMark;

                strQuery = "Select * From " + ClsDBConstants.TradeMark_TableName;

                if (strSortBy != string.Empty)
                    strQuery += " Order By " + strSortBy + ((blnSortAscending) ? " Asc" : " Desc") +
                                " , " + ClsDBConstants.TradeMark_Col_FillingNo + " Desc";

                objReader = ClsDBController.Instance.ExecuteReader(strQuery);

                colTradeMarks = new List<ClsTradeMark>();

                while (objReader.Read())
                {
                    objTradeMark = FillTradeMark(objReader);
                    colTradeMarks.Add(objTradeMark);
                }
                return colTradeMarks;
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

        private ClsTradeMark FillTradeMark(SqlDataReader objReader)
        {
            ClsTradeMark objTradeMark;

            objTradeMark = new ClsTradeMark();

            objTradeMark.AgentID = (objReader[ClsDBConstants.TradeMark_Col_AgentID] is DBNull) ? 0 :
                (int)objReader[ClsDBConstants.TradeMark_Col_AgentID];
            objTradeMark.Agent2ID = (objReader[ClsDBConstants.TradeMark_Col_Agent2ID] is DBNull) ? 0 :
               (int)objReader[ClsDBConstants.TradeMark_Col_Agent2ID];
            objTradeMark.Comment = (objReader[ClsDBConstants.TradeMark_Col_Comment] is DBNull) ? string.Empty :
               (string)objReader[ClsDBConstants.TradeMark_Col_Comment];
            objTradeMark.KCommission = (objReader[ClsDBConstants.TradeMark_Col_KCommission] is DBNull) ? string.Empty :
               (string)objReader[ClsDBConstants.TradeMark_Col_KCommission];
            objTradeMark.Agent2ID = (objReader[ClsDBConstants.TradeMark_Col_Agent2ID] is DBNull) ? 0 :
               (int)objReader[ClsDBConstants.TradeMark_Col_Agent2ID];
            objTradeMark.AppDate = (objReader[ClsDBConstants.TradeMark_Col_AppDate] is DBNull) ? string.Empty :
                (string)objReader[ClsDBConstants.TradeMark_Col_AppDate];
            objTradeMark.ApplicantID = (objReader[ClsDBConstants.TradeMark_Col_ApplicantID] is DBNull) ? 0 :
                (int)objReader[ClsDBConstants.TradeMark_Col_ApplicantID];
            objTradeMark.AppNumber = (objReader[ClsDBConstants.TradeMark_Col_AppNo] is DBNull) ? string.Empty :
                (string)objReader[ClsDBConstants.TradeMark_Col_AppNo];

            objTradeMark.ExtractNumber = (objReader[ClsDBConstants.TradeMark_Col_ExtractNumber] is DBNull) ? string.Empty :
                (string)objReader[ClsDBConstants.TradeMark_Col_ExtractNumber];

            objTradeMark.OppositionAganistNumber = (objReader[ClsDBConstants.TradeMark_Col_OppositionAgainstNo] is DBNull) ? string.Empty :
                (string)objReader[ClsDBConstants.TradeMark_Col_OppositionAgainstNo];

            objTradeMark.AdditionalGoodsClassesNumber = (objReader[ClsDBConstants.TradeMark_Col_AdditionalGoodsClassesNo] is DBNull) ? string.Empty :
                (string)objReader[ClsDBConstants.TradeMark_Col_AdditionalGoodsClassesNo];

            objTradeMark.Classes = (objReader[ClsDBConstants.TradeMark_Col_Class] is DBNull) ? string.Empty :
                (string)objReader[ClsDBConstants.TradeMark_Col_Class];
            objTradeMark.FillingNumber = (long)objReader[ClsDBConstants.TradeMark_Col_FillingNo];
            objTradeMark.ID = (long)objReader[ClsDBConstants.TradeMark_Col_ID];
            objTradeMark.LastDateChecked = (objReader[ClsDBConstants.TradeMark_Col_LastDateChecked] is DBNull) ? string.Empty :
                (string)objReader[ClsDBConstants.TradeMark_Col_LastDateChecked];
            objTradeMark.Picture = (objReader[ClsDBConstants.TradeMark_Col_Picture] is DBNull) ? string.Empty :
                (string)objReader[ClsDBConstants.TradeMark_Col_Picture];
            objTradeMark.PowerOfAttorney = (objReader[ClsDBConstants.TradeMark_Col_PowerOfAttorneyNo] is DBNull) ? 0 :
                (long)objReader[ClsDBConstants.TradeMark_Col_PowerOfAttorneyNo];
            objTradeMark.RegDate = (objReader[ClsDBConstants.TradeMark_Col_RegDate] is DBNull) ? string.Empty :
                (string)objReader[ClsDBConstants.TradeMark_Col_RegDate];
            objTradeMark.RegNumber = (objReader[ClsDBConstants.TradeMark_Col_RegNo] is DBNull) ? string.Empty :
                (string)objReader[ClsDBConstants.TradeMark_Col_RegNo];
            objTradeMark.RenewalDate = (objReader[ClsDBConstants.TradeMark_Col_RenewalDate] is DBNull) ? string.Empty :
                (string)objReader[ClsDBConstants.TradeMark_Col_RenewalDate];
            objTradeMark.RenewalCount = (int)objReader[ClsDBConstants.TradeMark_Col_RenewalCount];

            objTradeMark.StatusID = (objReader[ClsDBConstants.TradeMark_Col_StatusID] is DBNull) ? 0 :
                (int)objReader[ClsDBConstants.TradeMark_Col_StatusID];
            objTradeMark.TradeMarkName = (objReader[ClsDBConstants.TradeMark_Col_TradeMark] is DBNull) ? string.Empty :
                (string)objReader[ClsDBConstants.TradeMark_Col_TradeMark];
            objTradeMark.Year = (objReader[ClsDBConstants.TradeMark_Col_Year] is DBNull) ? 0 :
                (int)objReader[ClsDBConstants.TradeMark_Col_Year];

            return objTradeMark;
        }

        public DataTable Search(string lAppNo, string lOppositionAgainst,string lAdditionalGoodsClassesNo,
                                string lRegNo,
                                string strTrademark,
                                long lApplicantID,
                                long lAgentID,
                                long lAgent2ID,
                                long lFillingNo, long lStatusID,
                                string strSortBy,
                                bool blnSortAscending)
        {
            return Search(lAppNo, lOppositionAgainst, lAdditionalGoodsClassesNo, lRegNo, strTrademark,
                          lApplicantID, lAgentID, lAgent2ID, lFillingNo, lStatusID,
                          string.Empty, string.Empty, string.Empty,
                          strSortBy, blnSortAscending);
        }

        public DataTable Search(string lAppNo, string lOppositionAgainst,string lAdditionalGoodsClassesNo,
                                string lRegNo,
                                string strTrademark,
                                long lApplicantID,
                                long lAgentID,
                                long lAgent2ID,
                                long lFillingNo, long lStatusID,
                                string strRenewalDateFrom,
                                string strRenewalDateTo,
                                string strNowPersianDate,
                                string strSortBy,
                                bool blnSortAscending)
        {
            string strQuery;
            System.Text.StringBuilder strWhereClause = new System.Text.StringBuilder(string.Empty);
            bool blnConditionAdded = false;

            strWhereClause.Append(" Where (");

            if (!string.IsNullOrEmpty(lAppNo))
            {
                strWhereClause.Append(ClsDBConstants.TradeMark_Col_AppNo + " = N'" + lAppNo.ToString() + "'");
                blnConditionAdded = true;
            }

            if (!string.IsNullOrEmpty(lOppositionAgainst))
            {
                strWhereClause.Append(ClsDBConstants.TradeMark_Col_OppositionAgainstNo + " = N'" + lOppositionAgainst.ToString() + "'");
                blnConditionAdded = true;
            }

            if (!string.IsNullOrEmpty(lAdditionalGoodsClassesNo))
            {
                strWhereClause.Append(ClsDBConstants.TradeMark_Col_AdditionalGoodsClassesNo + " = N'" + lAdditionalGoodsClassesNo.ToString() + "'");
                blnConditionAdded = true;
            }

            if (!string.IsNullOrEmpty(lRegNo))
            {
                if (blnConditionAdded)
                    strWhereClause.Append(") And (");

                strWhereClause.Append(ClsDBConstants.TradeMark_Col_RegNo + " = N'" + lRegNo.ToString() + "'");
                blnConditionAdded = true;
            }

            if (strTrademark != string.Empty)
            {
                if (blnConditionAdded)
                    strWhereClause.Append(") And (");

                strWhereClause.Append(ClsDBConstants.TradeMark_Col_TradeMark + " Like '%" + strTrademark.ToString() + "%'");
                blnConditionAdded = true;
            }

            if (lApplicantID != 0)
            {
                if (blnConditionAdded)
                    strWhereClause.Append(") And (");

                strWhereClause.Append(ClsDBConstants.TradeMark_Col_ApplicantID + " = " + lApplicantID.ToString());
                blnConditionAdded = true;
            }

            if (lStatusID != 0)
            {
                if (blnConditionAdded)
                    strWhereClause.Append(") And (");

                strWhereClause.Append(ClsDBConstants.TradeMark_Col_StatusID + " = " + lStatusID.ToString());
                blnConditionAdded = true;
            }

            if (lAgentID != 0)
            {
                if (blnConditionAdded)
                    strWhereClause.Append(") And (");

                strWhereClause.Append(ClsDBConstants.TradeMark_Col_AgentID + " = " + lAgentID.ToString());
                blnConditionAdded = true;
            }

            if (lAgent2ID != 0)
            {
                if (blnConditionAdded)
                    strWhereClause.Append(") And (");

                strWhereClause.Append(ClsDBConstants.TradeMark_Col_Agent2ID + " = " + lAgent2ID.ToString());
                blnConditionAdded = true;
            }

            if (lFillingNo != 0)
            {
                if (blnConditionAdded)
                    strWhereClause.Append(") And (");

                strWhereClause.Append(ClsDBConstants.TradeMark_Col_FillingNo + " = " + lFillingNo.ToString());
                blnConditionAdded = true;
            }

            if (strRenewalDateFrom != string.Empty && strRenewalDateTo != string.Empty)
            {
                if (blnConditionAdded)
                    strWhereClause.Append(") And (");

                string strGregorianRenewalDateFrom = DateConverter.GetGregorianDate(strRenewalDateFrom);
                string strGregorianRenewalDateTo = DateConverter.GetGregorianDate(strRenewalDateTo);

                strWhereClause.Append(ClsDBConstants.TradeMark_Col_RenewalDate + " >= '" + strGregorianRenewalDateFrom);
                strWhereClause.Append("' AND " + ClsDBConstants.TradeMark_Col_RenewalDate + " <= '" + strGregorianRenewalDateTo + "'");
                //strWhereClause.Append("' AND " + ClsDBConstants.TradeMark_Col_RenewalDate + " < '" + strNowPersianDate + "'" );
                blnConditionAdded = true;
            }
            else if (strRenewalDateFrom != string.Empty)
            {
                if (blnConditionAdded)
                    strWhereClause.Append(") And (");

                string strGregorianRenewalDateFrom = DateConverter.GetGregorianDate(strRenewalDateFrom);


                strWhereClause.Append(ClsDBConstants.TradeMark_Col_RenewalDate + " >= '" + strGregorianRenewalDateFrom);

                blnConditionAdded = true;

            }
            else if (strRenewalDateTo != string.Empty)
            {
                if (blnConditionAdded)
                    strWhereClause.Append(") And (");

                string strGregorianRenewalDateTo = DateConverter.GetGregorianDate(strRenewalDateTo);

                strWhereClause.Append(ClsDBConstants.TradeMark_Col_RenewalDate + " <= '" + strGregorianRenewalDateTo);

                blnConditionAdded = true;

            }

            if (!blnConditionAdded)
            {
                strWhereClause = new System.Text.StringBuilder(string.Empty);
            }
            else
            {
                strWhereClause.Append(")");
            }

            strQuery = " Select * From {0} {1}";

            strQuery = string.Format(strQuery,
                                     ClsDBConstants.TradeMark_TableName,
                                     strWhereClause.ToString());

            if (strSortBy != string.Empty)
                strQuery += " Order By " + strSortBy + ((blnSortAscending) ? " Asc" : " Desc") +
                            " , " + ClsDBConstants.TradeMark_Col_FillingNo + " Desc";

            return ClsDBController.Instance.ExecuteQuery(strQuery);
        }
    }
}
