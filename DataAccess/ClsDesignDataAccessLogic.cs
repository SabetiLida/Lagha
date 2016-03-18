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
    /// Summary description for ClsDesignDataAccessLogic
    /// </summary>
    public class ClsDesignDataAccessLogic
    {
        public void Insert(ClsDesign objDesign, bool blnCloseConnection, Page objCurrentPage)
        {
            try
            {
                if (objDesign.AppDate == string.Empty)
                {
                    objDesign.FirstRenewalDate = false;
                    objDesign.SecondRenewalDate = false;
                    objDesign.ThirdRenewalDate = false;
                }

                System.Text.StringBuilder strQuery;
                SqlParameter[] arrParams;
                SqlParameter objParam;

                strQuery = new System.Text.StringBuilder(
                   " INSERT INTO [dbo].[DesignApplications]  " +
                   "    (                            [@FillingNo@],               [@Year@],               [@TradeMark@],               [@AdditionalGoodsClassesNo@],           [@Picture@], " +
                   "    [@AppNo@],                   [@AppDate@],                 [@RegNo@],              [@RegDate@],             [@FirstRenewalDate@], " +
                   "    [@SecondRenewalDate@],       [@ThirdRenewalDate@],        [@Class@],              [@ApplicantID@],         [@AgentID@],         [@Agent2ID@],         [@Comment@],         [@KCommission@], " +
                   "    [@StatusID@],                [@PowerOfAttorneyNo@],       [@LastDateChecked@]) " +
                   " VALUES " +
                   "    (                             @FillingNo_Value@,          @Year_Value@,          N'@TradeMark_Value@',            N'@AdditionalGoodsClassesNo_Value@',    N'@Picture_Value@', " +
                   "     N'@AppNo_Value@',              '@AppDate_Value@',        N'@RegNo_Value@',          '@RegDate_Value@',       '@FirstRenewalDate_Value@', " +
                   "    '@SecondRenewalDate_Value@', '@ThirdRenewalDate_Value@', '@Class_Value@',          @ApplicantID_Value@,     @AgentID_Value@,     @Agent2ID_Value@,     N'@Comment_Value@',     N'@KCommission_Value@', " +
                   "     @StatusID_Value@,            @PowerOfAttorneyNo_Value@, '@LastDateChecked_Value@')");

                strQuery = strQuery.Replace("@FillingNo@", ClsDBConstants.Design_Col_FillingNo);
                strQuery = strQuery.Replace("@Year@", ClsDBConstants.Design_Col_Year);
                strQuery = strQuery.Replace("@TradeMark@", ClsDBConstants.Design_Col_TradeMark);
                strQuery = strQuery.Replace("@Picture@", ClsDBConstants.Design_Col_Picture);
                strQuery = strQuery.Replace("@AppNo@", ClsDBConstants.Design_Col_AppNo);
                strQuery = strQuery.Replace("@AdditionalGoodsClassesNo@", ClsDBConstants.Design_Col_AdditionalGoodsClassesNo);
                strQuery = strQuery.Replace("@AppDate@", ClsDBConstants.Design_Col_AppDate);
                strQuery = strQuery.Replace("@RegNo@", ClsDBConstants.Design_Col_RegNo);
                strQuery = strQuery.Replace("@RegDate@", ClsDBConstants.Design_Col_RegDate);
                strQuery = strQuery.Replace("@FirstRenewalDate@", ClsDBConstants.Design_Col_FirstRenewalDate);
                strQuery = strQuery.Replace("@SecondRenewalDate@", ClsDBConstants.Design_Col_SecondRenewalDate);
                strQuery = strQuery.Replace("@ThirdRenewalDate@", ClsDBConstants.Design_Col_ThirdRenewalDate);
                strQuery = strQuery.Replace("@Class@", ClsDBConstants.Design_Col_Class);
                strQuery = strQuery.Replace("@ApplicantID@", ClsDBConstants.Design_Col_ApplicantID);
                strQuery = strQuery.Replace("@AgentID@", ClsDBConstants.Design_Col_AgentID);
                strQuery = strQuery.Replace("@Agent2ID@", ClsDBConstants.Design_Col_Agent2ID);
                strQuery = strQuery.Replace("@Comment@", ClsDBConstants.Design_Col_Comment);
                strQuery = strQuery.Replace("@KCommission@", ClsDBConstants.Design_Col_KCommission);
                strQuery = strQuery.Replace("@StatusID@", ClsDBConstants.Design_Col_StatusID);
                strQuery = strQuery.Replace("@PowerOfAttorneyNo@", ClsDBConstants.Design_Col_PowerOfAttorneyNo);
                strQuery = strQuery.Replace("@LastDateChecked@", ClsDBConstants.Design_Col_LastDateChecked);

                strQuery = strQuery.Replace("@FillingNo_Value@",
                    objDesign.FillingNumber.ToString());
                strQuery = strQuery.Replace("@Year_Value@",
                    (objDesign.Year != 0) ? objDesign.Year.ToString() : "NULL");
                strQuery = strQuery.Replace("@TradeMark_Value@",
                    (objDesign.TradeMark != string.Empty) ? objDesign.TradeMark.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@Picture_Value@",
                    (objDesign.Picture != null) ? objDesign.Picture.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@AppNo_Value@",
                    (objDesign.AppNumber != string.Empty) ? objDesign.AppNumber.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@AdditionalGoodsClassesNo_Value@",
                   (objDesign.AdditionalGoodsClassesNumber != string.Empty) ? objDesign.AdditionalGoodsClassesNumber.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@AppDate_Value@",
                    (objDesign.AppDate != String.Empty) ? objDesign.AppDate : "NULL");
                strQuery = strQuery.Replace("@RegNo_Value@",
                    (objDesign.RegNumber != string.Empty) ? objDesign.RegNumber.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@RegDate_Value@",
                    (objDesign.RegDate != string.Empty) ? objDesign.RegDate : "NULL");
                strQuery = strQuery.Replace("@FirstRenewalDate_Value@",
                    objDesign.FirstRenewalDate.ToString());
                strQuery = strQuery.Replace("@SecondRenewalDate_Value@",
                    objDesign.SecondRenewalDate.ToString());
                strQuery = strQuery.Replace("@ThirdRenewalDate_Value@",
                    objDesign.ThirdRenewalDate.ToString());
                strQuery = strQuery.Replace("@Class_Value@",
                    (objDesign.Class != null) ? objDesign.Class.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@ApplicantID_Value@",
                    (objDesign.ApplicantID != 0) ? objDesign.ApplicantID.ToString() : "NULL");
                strQuery = strQuery.Replace("@AgentID_Value@",
                    (objDesign.AgentID != 0) ? objDesign.AgentID.ToString() : "NULL");
                strQuery = strQuery.Replace("@Agent2ID_Value@",
                    (objDesign.Agent2ID != 0) ? objDesign.Agent2ID.ToString() : "NULL");
                strQuery = strQuery.Replace("@Comment_Value@",
                    (objDesign.Comment != string.Empty) ? objDesign.Comment.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@KCommission_Value@",
                    (objDesign.KCommission != string.Empty) ? objDesign.KCommission.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@StatusID_Value@",
                    (objDesign.StatusID != 0) ? objDesign.StatusID.ToString() : "NULL");
                strQuery = strQuery.Replace("@PowerOfAttorneyNo_Value@",
                    (objDesign.PowerOfAttorney != 0) ? objDesign.PowerOfAttorney.ToString() : "NULL");
                strQuery = strQuery.Replace("@LastDateChecked_Value@",
                    (objDesign.LastDateChecked != string.Empty) ? objDesign.LastDateChecked : "NULL");

                strQuery = strQuery.Replace("N'NULL'", "NULL");
                strQuery = strQuery.Replace("'NULL'", "NULL");
                ClsDBController.Instance.ExecuteNoneQuery(strQuery.ToString());

                arrParams = new SqlParameter[2];

                objParam = new SqlParameter();
                objParam.ParameterName = "@TableName";
                objParam.SqlDbType = SqlDbType.NVarChar;
                objParam.Size = 255;
                objParam.Direction = ParameterDirection.Input;
                objParam.SqlValue = ClsDBConstants.Design_TableName;
                arrParams[0] = objParam;

                objParam = new SqlParameter();
                objParam.ParameterName = "@ID";
                objParam.SqlDbType = SqlDbType.BigInt;
                objParam.Direction = ParameterDirection.Output;
                arrParams[1] = objParam;

                ClsDBController.Instance.ExecuteProcedureNonQuery("[dbo].[GetLastTableID]", arrParams);
                ClsLogDataAccessLogic.Insert(ClsLoginManager.GetLoggedOnUser(objCurrentPage).UserID, string.Format("{0:yyyy/MM/dd}", ClsLogDataAccessLogic.GetNowPersianDate()), Convert.ToInt32(ClsLogDataAccessLogic.TransactionType.DesignCreated), true);
                objDesign.ID = (long)arrParams[1].Value;
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

        public void Update(ClsDesign objDesign, bool blnCloseConnection, Page objCurrentPage)
        {
            try
            {
                if (objDesign.AppDate == string.Empty)
                {
                    objDesign.FirstRenewalDate = false;
                    objDesign.SecondRenewalDate = false;
                    objDesign.ThirdRenewalDate = false;
                }

                System.Text.StringBuilder strQuery;
                strQuery = new System.Text.StringBuilder(
                   " Update[dbo].[@TableName@]  " +
                   "    SET    [@FillingNo@] = @FillingNo_Value@                 , [@AdditionalGoodsClassesNo@] = N'@AdditionalGoodsClassesNo_Value@',     [@Year@] = @Year_Value@, " +
                   "           [@TradeMark@] = N'@TradeMark_Value@'              ,     [@Picture@] = N'@Picture_Value@', " +
                   "           [@AppNo@] = N'@AppNo_Value@'                         ,     [@AppDate@] = '@AppDate_Value@', " +
                   "           [@RegNo@] =  N'@RegNo_Value@'                        ,     [@RegDate@] = '@RegDate_Value@',  " +
                   "           [@FirstRenewalDate@] = '@FirstRenewalDate_Value@' ,     [@SecondRenewalDate@] ='@SecondRenewalDate_Value@', " +
                   "           [@ThirdRenewalDate@] ='@ThirdRenewalDate_Value@'  ,     [@Class@] = '@Class_Value@', " +
                   "           [@ApplicantID@] = @ApplicantID_Value@             ,     [@AgentID@] = @AgentID_Value@,     [@Agent2ID@] = @Agent2ID_Value@,     [@Comment@] = N'@Comment_Value@',     [@KCommission@] = N'@KCommission_Value@', " +
                   "           [@StatusID@] = @StatusID_Value@                   ,     [@PowerOfAttorneyNo@] = @PowerOfAttorneyNo_Value@,  " +
                   "           [@LastDateChecked@] = '@LastDateChecked_Value@'  Where [@ID@] = @ID_Value@");


                strQuery = strQuery.Replace("@FillingNo@", ClsDBConstants.Design_Col_FillingNo);
                strQuery = strQuery.Replace("@Year@", ClsDBConstants.Design_Col_Year);
                strQuery = strQuery.Replace("@TradeMark@", ClsDBConstants.Design_Col_TradeMark);
                strQuery = strQuery.Replace("@Picture@", ClsDBConstants.Design_Col_Picture);
                strQuery = strQuery.Replace("@AppNo@", ClsDBConstants.Design_Col_AppNo);
                strQuery = strQuery.Replace("@AppDate@", ClsDBConstants.Design_Col_AppDate);
                strQuery = strQuery.Replace("@RegNo@", ClsDBConstants.Design_Col_RegNo);
                strQuery = strQuery.Replace("@AdditionalGoodsClassesNo@", ClsDBConstants.Design_Col_AdditionalGoodsClassesNo);
                strQuery = strQuery.Replace("@RegDate@", ClsDBConstants.Design_Col_RegDate);
                strQuery = strQuery.Replace("@FirstRenewalDate@", ClsDBConstants.Design_Col_FirstRenewalDate);
                strQuery = strQuery.Replace("@SecondRenewalDate@", ClsDBConstants.Design_Col_SecondRenewalDate);
                strQuery = strQuery.Replace("@ThirdRenewalDate@", ClsDBConstants.Design_Col_ThirdRenewalDate);
                strQuery = strQuery.Replace("@Class@", ClsDBConstants.Design_Col_Class);
                strQuery = strQuery.Replace("@ApplicantID@", ClsDBConstants.Design_Col_ApplicantID);
                strQuery = strQuery.Replace("@AgentID@", ClsDBConstants.Design_Col_AgentID);
                strQuery = strQuery.Replace("@Agent2ID@", ClsDBConstants.Design_Col_Agent2ID);
                strQuery = strQuery.Replace("@Comment@", ClsDBConstants.Design_Col_Comment);
                strQuery = strQuery.Replace("@KCommission@", ClsDBConstants.Design_Col_KCommission);
                strQuery = strQuery.Replace("@StatusID@", ClsDBConstants.Design_Col_StatusID);
                strQuery = strQuery.Replace("@PowerOfAttorneyNo@", ClsDBConstants.Design_Col_PowerOfAttorneyNo);
                strQuery = strQuery.Replace("@LastDateChecked@", ClsDBConstants.Design_Col_LastDateChecked);
                strQuery = strQuery.Replace("@ID@", ClsDBConstants.Design_Col_ID);


                strQuery = strQuery.Replace("@FillingNo_Value@",
                    objDesign.FillingNumber.ToString());
                strQuery = strQuery.Replace("@Year_Value@",
                    (objDesign.Year != 0) ? objDesign.Year.ToString() : "NULL");
                strQuery = strQuery.Replace("@TradeMark_Value@",
                    (objDesign.TradeMark != string.Empty) ? objDesign.TradeMark.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@Picture_Value@",
                    (objDesign.Picture != null) ? objDesign.Picture.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@AppNo_Value@",
                    (objDesign.AppNumber != string.Empty) ? objDesign.AppNumber.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@AppDate_Value@",
                    (objDesign.AppDate != String.Empty) ? objDesign.AppDate : "NULL");
                strQuery = strQuery.Replace("@RegNo_Value@",
                    (objDesign.RegNumber != string.Empty) ? objDesign.RegNumber.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@RegDate_Value@",
                    (objDesign.RegDate != string.Empty) ? objDesign.RegDate : "NULL");
                strQuery = strQuery.Replace("@AdditionalGoodsClassesNo_Value@",
                   (objDesign.AdditionalGoodsClassesNumber != string.Empty) ? objDesign.AdditionalGoodsClassesNumber.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@FirstRenewalDate_Value@",
                    objDesign.FirstRenewalDate.ToString());
                strQuery = strQuery.Replace("@SecondRenewalDate_Value@",
                    objDesign.SecondRenewalDate.ToString());
                strQuery = strQuery.Replace("@ThirdRenewalDate_Value@",
                    objDesign.ThirdRenewalDate.ToString());
                strQuery = strQuery.Replace("@Class_Value@",
                    (objDesign.Class != null) ? objDesign.Class.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@ApplicantID_Value@",
                    (objDesign.ApplicantID != 0) ? objDesign.ApplicantID.ToString() : "NULL");
                strQuery = strQuery.Replace("@AgentID_Value@",
                    (objDesign.AgentID != 0) ? objDesign.AgentID.ToString() : "NULL");
                strQuery = strQuery.Replace("@Agent2ID_Value@",
                   (objDesign.Agent2ID != 0) ? objDesign.Agent2ID.ToString() : "NULL");
                strQuery = strQuery.Replace("@Comment_Value@",
                    (objDesign.Comment != null) ? objDesign.Comment.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@KCommission_Value@",
                   (objDesign.KCommission != null) ? objDesign.KCommission.Replace("'", "''") : "NULL");
                strQuery = strQuery.Replace("@StatusID_Value@",
                    (objDesign.StatusID != 0) ? objDesign.StatusID.ToString() : "NULL");
                strQuery = strQuery.Replace("@PowerOfAttorneyNo_Value@",
                    (objDesign.PowerOfAttorney != 0) ? objDesign.PowerOfAttorney.ToString() : "NULL");
                strQuery = strQuery.Replace("@LastDateChecked_Value@",
                    (objDesign.LastDateChecked != string.Empty) ? objDesign.LastDateChecked : "NULL");
                strQuery = strQuery.Replace("@ID_Value@",
                    objDesign.ID.ToString());

                strQuery = strQuery.Replace("N'NULL'", "NULL");
                strQuery = strQuery.Replace("'NULL'", "NULL");
                strQuery = strQuery.Replace("@TableName@", ClsDBConstants.Design_TableName);

                ClsDBController.Instance.ExecuteNoneQuery(strQuery.ToString());
                ClsLogDataAccessLogic.Insert(ClsLoginManager.GetLoggedOnUser(objCurrentPage).UserID, string.Format("{0:yyyy/MM/dd}", ClsLogDataAccessLogic.GetNowPersianDate()), Convert.ToInt32(ClsLogDataAccessLogic.TransactionType.DesignUpdated), true);

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

        public void Delete(ClsDesign objDesign, bool blnCloseConnection, Page objCurrentPage)
        {
            Delete(objDesign.ID, blnCloseConnection, objCurrentPage);
        }

        public void Delete(long lDesignID, bool blnCloseConnection, Page objCurrentPage)
        {
            try
            {
                string strQuery;
                strQuery = "Delete From {0} Where [{1}] = {2}";

                strQuery = string.Format(strQuery,
                                         ClsDBConstants.Design_TableName,
                                         ClsDBConstants.Design_Col_ID,
                                         lDesignID);
                ClsDBController.Instance.ExecuteNoneQuery(strQuery);
                ClsLogDataAccessLogic.Insert(ClsLoginManager.GetLoggedOnUser(objCurrentPage).UserID, string.Format("{0:yyyy/MM/dd}", ClsLogDataAccessLogic.GetNowPersianDate()), Convert.ToInt32(ClsLogDataAccessLogic.TransactionType.DesignDeleted), true);

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

        public bool IsFillingNoExists(long lFillingNo, long lOriginalDesignID)
        {
            DataTable dtResult = null;
            string strQuery;

            try
            {
                strQuery = " Select * From @TableName@ " +
                           " Where (@FillingNo@=@FillingNoValue@) AND (ID <> @lOriginalID@)";
                strQuery = strQuery.Replace("@TableName@", ClsDBConstants.Design_TableName);
                strQuery = strQuery.Replace("@FillingNo@", ClsDBConstants.Design_Col_FillingNo);
                strQuery = strQuery.Replace("@FillingNoValue@", lFillingNo.ToString());
                strQuery = strQuery.Replace("@lOriginalID@", lOriginalDesignID.ToString());

                dtResult = ClsDBController.Instance.ExecuteQuery(strQuery);

                return (dtResult.Rows.Count > 0);
            }
            finally
            {
                if (dtResult != null)
                    dtResult.Dispose();
            }
        }

        public bool IsRegNoExists(string lRegNo, long lOriginalDesignID)
        {
            DataTable dtResult = null;
            System.Text.StringBuilder strQuery;

            try
            {
                strQuery = new System.Text.StringBuilder(
                    " Select * From @TableName@ " +
                    " Where (@RegNo@=N'@RegNoValue@') AND (ID <> @lOriginalID@)");
                strQuery = strQuery.Replace("@TableName@", ClsDBConstants.Design_TableName);
                strQuery = strQuery.Replace("@RegNo@", ClsDBConstants.Design_Col_RegNo);
                strQuery = strQuery.Replace("@RegNoValue@", lRegNo.ToString());
                strQuery = strQuery.Replace("@lOriginalID@", lOriginalDesignID.ToString());

                dtResult = ClsDBController.Instance.ExecuteQuery(strQuery.ToString());

                return (dtResult.Rows.Count > 0);
            }
            finally
            {
                if (dtResult != null)
                    dtResult.Dispose();
            }
        }

        public bool IsAppNoExists(string lAppNo, long lOriginalDesignID)
        {
            DataTable dtResult = null;
            System.Text.StringBuilder strQuery;

            try
            {
                strQuery = new System.Text.StringBuilder(
                    " Select * From @TableName@ " +
                    " Where (@AppNo@=N'@AppNoValue@') AND (ID <> @lOriginalID@)");

                strQuery = strQuery.Replace("@TableName@", ClsDBConstants.Design_TableName);
                strQuery = strQuery.Replace("@AppNo@", ClsDBConstants.Design_Col_AppNo);
                strQuery = strQuery.Replace("@AppNoValue@", lAppNo.ToString());
                strQuery = strQuery.Replace("@lOriginalID@", lOriginalDesignID.ToString());

                dtResult = ClsDBController.Instance.ExecuteQuery(strQuery.ToString());

                return (dtResult.Rows.Count > 0);
            }
            finally
            {
                if (dtResult != null)
                    dtResult.Dispose();
            }
        }

        public bool IsAdditionalGoodsClassesExists(string lAdditionalGoodsClassesNo, long lOriginalDesignID)
        {
            DataTable dtResult = null;
            string strQuery;

            try
            {
                strQuery = " Select * From @TableName@ " +
                           " Where (@AdditionalGoodsClassesNo@=N'@AdditionalGoodsClassesNoValue@') AND (ID <> @lOriginalID@)";
                strQuery = strQuery.Replace("@TableName@", ClsDBConstants.Design_TableName);
                strQuery = strQuery.Replace("@AdditionalGoodsClassesNo@", ClsDBConstants.Design_Col_AdditionalGoodsClassesNo);
                strQuery = strQuery.Replace("@AdditionalGoodsClassesNoValue@", lAdditionalGoodsClassesNo.ToString());
                strQuery = strQuery.Replace("@lOriginalID@", lOriginalDesignID.ToString());

                dtResult = ClsDBController.Instance.ExecuteQuery(strQuery);

                return (dtResult.Rows.Count > 0);
            }
            finally
            {
                if (dtResult != null)
                    dtResult.Dispose();
            }
        }

        public DataTable GetDesignForPreview(string strSortBy, bool blnSortAscending)
        {
            try
            {
                string strQuery;

                strQuery = "Select * From " + ClsDBConstants.Design_TableName;

                if (strSortBy != string.Empty)
                    strQuery += " Order By " + strSortBy + ((blnSortAscending) ? " Asc" : " Desc") +
                                " , " + ClsDBConstants.Design_Col_FillingNo + " Desc";

                return ClsDBController.Instance.ExecuteQuery(strQuery);
            }
            finally
            {
                ClsDBController.Instance.Close();
            }
        }

        public ClsDesign GetDesign(long lDesignID)
        {
            SqlDataReader objReader = null;
            try
            {
                string strQuery;
                ClsDesign ObjDesign = null;

                strQuery = "Select * From {0} Where {1}={2}";

                strQuery = string.Format(strQuery,
                                         ClsDBConstants.Design_TableName,
                                         ClsDBConstants.Design_Col_ID, lDesignID);

                objReader = ClsDBController.Instance.ExecuteReader(strQuery);

                if (objReader.Read())
                {
                    ObjDesign = FillDesign(objReader);
                }

                return ObjDesign;
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

        public List<ClsDesign> GetAllDesigns(string strSortBy, bool blnSortAscending)
        {
            SqlDataReader objReader = null;
            try
            {
                string strQuery;
                List<ClsDesign> colDesigns;
                ClsDesign objDesign;

                strQuery = "Select * From " + ClsDBConstants.TradeMark_TableName;

                if (strSortBy != string.Empty)
                    strQuery += " Order By " + strSortBy + ((blnSortAscending) ? " Asc" : " Desc") +
                                " , " + ClsDBConstants.Design_Col_FillingNo + " Desc";

                objReader = ClsDBController.Instance.ExecuteReader(strQuery);

                colDesigns = new List<ClsDesign>();

                while (objReader.Read())
                {
                    objDesign = FillDesign(objReader);
                    colDesigns.Add(objDesign);
                }
                return colDesigns;
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

        private ClsDesign FillDesign(SqlDataReader objReader)
        {
            ClsDesign objDesign;
            objDesign = new ClsDesign();

            objDesign.AgentID = (objReader[ClsDBConstants.Design_Col_AgentID] is DBNull) ? 0 :
                (int)objReader[ClsDBConstants.Design_Col_AgentID];
            objDesign.Agent2ID = (objReader[ClsDBConstants.Design_Col_Agent2ID] is DBNull) ? 0 :
                (int)objReader[ClsDBConstants.Design_Col_Agent2ID];
            objDesign.Comment = (objReader[ClsDBConstants.Design_Col_Comment] is DBNull) ? string.Empty :
                (string)objReader[ClsDBConstants.Design_Col_Comment];
            objDesign.AdditionalGoodsClassesNumber = (objReader[ClsDBConstants.Design_Col_AdditionalGoodsClassesNo] is DBNull) ? string.Empty :
                (string)objReader[ClsDBConstants.Design_Col_AdditionalGoodsClassesNo];
            objDesign.KCommission = (objReader[ClsDBConstants.Design_Col_KCommission] is DBNull) ? string.Empty :
                (string)objReader[ClsDBConstants.Design_Col_KCommission];
            objDesign.AppDate = (objReader[ClsDBConstants.Design_Col_AppDate] is DBNull) ? string.Empty :
                (string)objReader[ClsDBConstants.Design_Col_AppDate];
            objDesign.ApplicantID = (objReader[ClsDBConstants.Design_Col_ApplicantID] is DBNull) ? 0 :
                (int)objReader[ClsDBConstants.Design_Col_ApplicantID];
            objDesign.AppNumber = (objReader[ClsDBConstants.Design_Col_AppNo] is DBNull) ? string.Empty :
                (string)objReader[ClsDBConstants.Design_Col_AppNo];
            objDesign.Class = (objReader[ClsDBConstants.Design_Col_Class] is DBNull) ? string.Empty :
                (string)objReader[ClsDBConstants.Design_Col_Class];
            objDesign.FillingNumber =
                (long)objReader[ClsDBConstants.Design_Col_FillingNo];
            objDesign.FirstRenewalDate = ((objReader[ClsDBConstants.Design_Col_FirstRenewalDate]) is DBNull) ? false :
                (bool)(objReader[ClsDBConstants.Design_Col_FirstRenewalDate]);
            objDesign.ID =
                (long)objReader[ClsDBConstants.Design_Col_ID];
            objDesign.LastDateChecked = (objReader[ClsDBConstants.Design_Col_LastDateChecked] is DBNull) ? string.Empty :
                (string)objReader[ClsDBConstants.Design_Col_LastDateChecked];
            objDesign.Picture = (objReader[ClsDBConstants.Design_Col_Picture] is DBNull) ? string.Empty :
                (string)objReader[ClsDBConstants.Design_Col_Picture];
            objDesign.PowerOfAttorney = (objReader[ClsDBConstants.Design_Col_PowerOfAttorneyNo] is DBNull) ? 0 :
                (long)objReader[ClsDBConstants.Design_Col_PowerOfAttorneyNo];
            objDesign.RegDate = (objReader[ClsDBConstants.Design_Col_RegDate] is DBNull) ? string.Empty :
                (string)objReader[ClsDBConstants.Design_Col_RegDate];
            objDesign.RegNumber = (objReader[ClsDBConstants.Design_Col_RegNo] is DBNull) ? string.Empty :
                (string)objReader[ClsDBConstants.Design_Col_RegNo];
            objDesign.SecondRenewalDate = (objReader[ClsDBConstants.Design_Col_SecondRenewalDate] is DBNull) ? false :
                (bool)objReader[ClsDBConstants.Design_Col_SecondRenewalDate];
            objDesign.StatusID = (objReader[ClsDBConstants.Design_Col_StatusID] is DBNull) ? 0 :
                (int)objReader[ClsDBConstants.Design_Col_StatusID];
            objDesign.ThirdRenewalDate = (objReader[ClsDBConstants.Design_Col_ThirdRenewalDate] is DBNull) ? false :
                (bool)objReader[ClsDBConstants.Design_Col_ThirdRenewalDate];
            objDesign.TradeMark = (objReader[ClsDBConstants.Design_Col_TradeMark] is DBNull) ? string.Empty :
                (string)objReader[ClsDBConstants.Design_Col_TradeMark];
            objDesign.Year = (objReader[ClsDBConstants.Design_Col_Year] is DBNull) ? 0 :
                (int)objReader[ClsDBConstants.Design_Col_Year];

            return objDesign;
        }

        public DataTable Search(string lAppNo, string lAdditionalGoodsClassesNo,
                                string lRegNo,
                                string strTrademark,
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
                strWhereClause += ClsDBConstants.Design_Col_AppNo + " = N'" + lAppNo.ToString() + "'";
                blnConditionAdded = true;
            }

            if (!string.IsNullOrEmpty(lAdditionalGoodsClassesNo))
            {
                strWhereClause += ClsDBConstants.Design_Col_AdditionalGoodsClassesNo + " = N'" + lAdditionalGoodsClassesNo.ToString() + "'";
                blnConditionAdded = true;
            }

            if (!string.IsNullOrEmpty(lRegNo))
            {
                if (blnConditionAdded)
                    strWhereClause += ") And (";

                strWhereClause += ClsDBConstants.Design_Col_RegNo + " = N'" + lRegNo.ToString() + "'";
                blnConditionAdded = true;
            }

            if (strTrademark != string.Empty)
            {
                if (blnConditionAdded)
                    strWhereClause += ") And (";

                strWhereClause += ClsDBConstants.TradeMark_Col_TradeMark + " Like '%" + strTrademark.Replace("'", "''") + "%'";
                blnConditionAdded = true;
            }


            if (lApplicantID != 0)
            {
                if (blnConditionAdded)
                    strWhereClause += ") And (";

                strWhereClause += ClsDBConstants.Design_Col_ApplicantID + " = " + lApplicantID.ToString();
                blnConditionAdded = true;
            }

            if (lAgentID != 0)
            {
                if (blnConditionAdded)
                    strWhereClause += ") And (";

                strWhereClause += ClsDBConstants.Design_Col_AgentID + " = " + lAgentID.ToString();
                blnConditionAdded = true;
            }

            if (lAgent2ID != 0)
            {
                if (blnConditionAdded)
                    strWhereClause += ") And (";

                strWhereClause += ClsDBConstants.Design_Col_Agent2ID + " = " + lAgent2ID.ToString();
                blnConditionAdded = true;
            }

            if (lStatusID != 0)
            {
                if (blnConditionAdded)
                    strWhereClause += ") And (";

                strWhereClause += ClsDBConstants.Design_Col_StatusID + " = " + lStatusID.ToString();
                blnConditionAdded = true;
            }

            if (lFillingNo != 0)
            {
                if (blnConditionAdded)
                    strWhereClause += ") And (";

                strWhereClause += ClsDBConstants.Design_Col_FillingNo + " = " + lFillingNo.ToString();
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

            strQuery = string.Format(strQuery, ClsDBConstants.Design_TableName, strWhereClause);

            if (strSortBy != string.Empty)
                strQuery += " Order By " + strSortBy + ((blnSortAscending) ? " Asc" : " Desc") +
                            " , " + ClsDBConstants.Design_Col_FillingNo + " Desc";


            return ClsDBController.Instance.ExecuteQuery(strQuery);
        }
    }
}
