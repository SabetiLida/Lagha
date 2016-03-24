using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using Laghaee.Entity;
using Laghaee.DataAccessLayer;
using System.Text.RegularExpressions;
using System.Globalization;
using Laghaee.DataAccess;

/// <summary>
/// Summary description for ClsCommon
/// </summary>
/// 

    public class ClsCommon
    {

        private const string LogoutQueryString = "logout";

        public static void ShowMessage(Page currentPage,
                                       MessageType eMessageType,
                                       string strMessage,
                                       Exception ex)
        {
            System.IO.StreamWriter writer = null;
            try
            {
                ShowMessage(currentPage, eMessageType, strMessage);

                // Create exception log if required.
                if (ex != null)
                {
                    //writer = new System.IO.StreamWriter(currentPage.MapPath("Log")+ @"\Log.txt",false);

                    //writer.Write(ex.ToString());
                    //writer.Flush();
                }
            }
            catch (UnauthorizedAccessException)
            { }
            catch (System.Security.SecurityException)
            { }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        public static void ShowMessage(Page currentPage,
                                       MessageType eMessageType,
                                       string strMessage)
        {
            MessageControl msgControl = (MessageControl)currentPage.Page.Master.FindControl("MessageControl");

            switch (eMessageType)
            {
                case MessageType.Info:
                    msgControl.ShowInfoMessage(strMessage);
                    break;

                case MessageType.Error:
                    msgControl.ShowErrorMessage(strMessage);
                    break;
                case MessageType.Question:
                    msgControl.ShowQuestionMessage(strMessage);
                    break;
            }
        }

        public static bool AuthenticatePage(System.Web.UI.Page currentPage, bool blnIsLoginPage)
        {
            Control masterHeaderControl;
            string strRedirectUri = string.Empty;

            if (currentPage.Request.QueryString.Count > 0 && currentPage.Request.QueryString.Get(LogoutQueryString) != null)
            {

                ClsLoginManager.Logout(currentPage);
                //currentPage.Response.Redirect(currentPage.Request.UrlReferrer.ToString());
                strRedirectUri = currentPage.Request.Url.AbsoluteUri;
                strRedirectUri = strRedirectUri.Substring(0, strRedirectUri.IndexOf("?", 0));
                currentPage.Response.Redirect(strRedirectUri);
            }
            else
            {
                // Indicates if any user is logged on or not.
                ClsUser currentUser = ClsLoginManager.GetLoggedOnUser(currentPage);
                if (currentUser != null)
                {
                    masterHeaderControl = currentPage.Master.FindControl("PageHeaderContentPlaceHolder");

                    LinkButton logoutLink = new LinkButton();

                    logoutLink.Text = "Logout";
                    logoutLink.CausesValidation = false;

                    if (currentPage.Request.QueryString.Count > 0)
                        logoutLink.PostBackUrl = currentPage.Request.Url.AbsoluteUri + "&" + LogoutQueryString + "=1";
                    else
                        logoutLink.PostBackUrl = currentPage.Request.Url.AbsoluteUri + "?" + LogoutQueryString + "=1";

                    masterHeaderControl.Controls.Add(logoutLink);

                    // Add change password link to if its the login page.
                    if (blnIsLoginPage)
                    {
                        return true;
                    }
                    else
                    {
                        return currentUser.IsAdmin;
                    }
                }
                else
                {
                    if (!blnIsLoginPage)
                    {
                        ClsLoginManager.RedirectAddress = currentPage.Page.Request.Url.AbsoluteUri;
                        currentPage.Response.Redirect("Logins.aspx");
                    }
                }
            }
            return false;
        }

        public static bool IsGregorianDateValid(string txtYear, string txtMonth, string txtDay)
        {
            try
            {
                if (txtYear.Length == 0 && txtMonth.Length == 0 && txtDay.Length == 0)
                {
                    return true;
                }
                else if (txtYear.Length != 4 || txtMonth.Length != 2 || txtDay.Length != 2)
                    return false;

                DateTime.Parse(txtYear + "/" + txtMonth + "/" + txtDay);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsPersianDateValid(string txtYear, string txtMonth, string txtDay)
        {
            try
            {
                string strDate = "{0}/{1}/{2}";
                strDate = String.Format(strDate,
                                        txtYear.Trim(),
                                        txtMonth.Trim(),
                                        txtDay.Trim());
                if (strDate == "//")
                    return true;
                if (txtYear.Length < 4)
                    return false;

                FarsiLibrary.Utils.PersianDate.Parse(strDate, false);
                ////DateTime.Parse(strDate,
                ////               System.Globalization.CultureInfo.CurrentCulture,
                ////               System.Globalization.DateTimeStyles.AdjustToUniversal);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string GetDateFromControls(TextBox txtYear, TextBox txtMonth, TextBox txtDay)
        {
            if (txtYear.Text.Trim() != string.Empty)
                return
                    txtYear.Text.Trim() + "/" + txtMonth.Text.Trim() + "/" + txtDay.Text.Trim();
            else
                return string.Empty;
        }

        public static void FillDateInControls(string strDate, TextBox txtYear, TextBox txtMonth, TextBox txtDay)
        {
            if (strDate.Trim() == string.Empty)
            {
                txtYear.Text = string.Empty;
                txtMonth.Text = string.Empty;
                txtDay.Text = string.Empty;
            }
            else
            {
                ////DateTime date = DateTime.Parse(strDate,
                ////                               System.Globalization.CultureInfo.CurrentCulture,
                ////                               System.Globalization.DateTimeStyles.AdjustToUniversal);
                ////txtYear.Text = date.Year.ToString();
                ////txtMonth.Text = date.Month.ToString();
                ////txtDay.Text = date.Day.ToString();

                Match objMatch = Regex.Match(
                    strDate,
                    @"(?<Year>([0-9]){4})/(?<Month>\d\d?)/(?<Day>\d\d?)");

                if (objMatch.Success)
                {
                    txtYear.Text = objMatch.Groups["Year"].Value;
                    txtMonth.Text = objMatch.Groups["Month"].Value;
                    txtDay.Text = objMatch.Groups["Day"].Value;
                }
            }
        }

        public static string AddYearToPersianDate(string strOriginalPersianDate,
                                                  int iValue,
                                                  string strIgnoreLeapWith)
        {
            string result;
            result = AddYearToPersianDate(strOriginalPersianDate, iValue, false);

            if (strIgnoreLeapWith != string.Empty)
            {
                result = result.Remove(result.Length - 2) +
                         strIgnoreLeapWith.Substring(strIgnoreLeapWith.Length - 2);
            }
            return result;
        }

        public static string AddYearToPersianDate(string strOriginalPersianDate,
                                                  int iValue,
                                                  bool blnReturnGregorianDate)
        {
            string strTempDate;
            strTempDate = AddYearToPersianDate(strOriginalPersianDate, iValue);

            if (blnReturnGregorianDate)
            {
                return strTempDate;
            }
            else
            {
                return FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(
                    strTempDate).ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);
            }
        }
        public static string AddYearToMyPersianDate(string strOriginalPersianDate,
                                                  int iValue)
        {
            string strAddedYearDate;
            char zero;
            zero = Char.Parse("0");
            FarsiLibrary.Utils.PersianDate _PersianDate =
            FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(strOriginalPersianDate.Trim());
            int i = _PersianDate.Year + iValue;

            strAddedYearDate = i.ToString() + "/" +
                _PersianDate.Month.ToString().PadLeft(2, zero) +
                "/" + _PersianDate.Day.ToString().PadLeft(2, zero);
            return string.Format(CultureInfo.InvariantCulture, "{0:yyyy/MM/dd}", strAddedYearDate);


        }
        public static string AddYearToPersianDate(string strOriginalPersianDate,
                                                  int iValue)
        {
            DateTime dOriginalDateG;

            dOriginalDateG =
                FarsiLibrary.Utils.PersianDateConverter.ToGregorianDateTime(strOriginalPersianDate);

            return string.Format("{0:yyyy/MM/dd}",
                                 dOriginalDateG.AddYears(iValue));
        }

        public static string GetPersianDate(string strGregorianDate,
                                            string ignoreLeapWith)
        {
            string result;

            if (strGregorianDate.Trim() == string.Empty)
                return string.Empty;

            result = FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(
                strGregorianDate.Trim()).ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);

            if (ignoreLeapWith != string.Empty)
                result = result.Remove(result.Length - 2) +
                    ignoreLeapWith.Substring(ignoreLeapWith.Length - 2);

            return result;
        }

        public static string GetNowPersianDate()
        {
            return FarsiLibrary.Utils.PersianDate.Now.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);
        }

       

        public void FillAgents(DropDownList drpAgent)
        {
            ClsAgentDataAccessLogic objDataAccess = new ClsAgentDataAccessLogic();
            List<ClsAgent> colAgents;

            colAgents = objDataAccess.GetAllAgents();

            drpAgent.Items.Clear();

            ListItem newItem = new ListItem("'None'", "0");
            drpAgent.Items.Add(newItem);

            foreach (ClsAgent objAgent in colAgents)
            {
                newItem = new ListItem(objAgent.AgentName);
                newItem.Value = objAgent.ID.ToString();

                drpAgent.Items.Add(newItem);
            }
        }

        public void FillStatus(DropDownList drpStatus)
        {
            ClsStatusDataAccessLogic objDataAccess = new ClsStatusDataAccessLogic();
            List<ClsStatus> colStatuss;

            colStatuss = objDataAccess.GetAllStatuss();

            drpStatus.Items.Clear();
            ListItem newItem = new ListItem("'None'", "0");
            drpStatus.Items.Add(newItem);

            foreach (ClsStatus objStatus in colStatuss)
            {
                newItem = new ListItem(objStatus.StatusName);
                newItem.Value = objStatus.ID.ToString();

                drpStatus.Items.Add(newItem);
            }
        }

        public void FillApplicants(DropDownList drpApplicant)
        {
            ClsApplicantDataAccessLogic objDataAccess = new ClsApplicantDataAccessLogic();
            List<ClsApplicants> colApplicants;

            colApplicants = objDataAccess.GetAllApplicants();

            drpApplicant.Items.Clear();
            ListItem newItem = new ListItem("'None'", "0");
            drpApplicant.Items.Add(newItem);

            foreach (ClsApplicants objApplicant in colApplicants)
            {
                newItem = new ListItem(objApplicant.ApplicantName);
                newItem.Value = objApplicant.ID.ToString();

                drpApplicant.Items.Add(newItem);
            }
        }

        //public void UpdatePicture(HttpPostedFile objPostedFile, string strOriginPictureFile)
        //{
        //    objPostedFile.SaveAs(strOriginPictureFile);
        //}

        public string UploadPicture(ref HttpPostedFile objPostedFile, HttpServerUtility objHttpUtil)
        {
            try
            {
                string strFileName = new System.IO.FileInfo(objPostedFile.FileName).Name;
                string strImageDir = ConfigurationManager.AppSettings.Get("DatabaseImagesPath");

                string strFilePath = objHttpUtil.MapPath(strImageDir) + strFileName;

                while (System.IO.File.Exists(strFilePath))
                {
                    strFileName = "CopyOf_" + strFileName;
                    strFilePath = objHttpUtil.MapPath(strImageDir) + strFileName;
                }

                objPostedFile.SaveAs(strFilePath);

                return @"~\" + strImageDir + strFileName;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update the specified image.", ex);
            }
            finally
            {
                objPostedFile = null;
            }
        }

    }

