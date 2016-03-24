using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Laghaee.Entity;
using Laghaee.DataAccessLayer;
using System.Web.UI.MobileControls;
using System.Collections.Generic;
using Laghaee.Common;
using Laghaee.DataAccess;
using Laghaee.Common.Enumeration;

public partial class TradeMark : System.Web.UI.Page
{
    private const int ID_Index = 0;

    private ClsUserDataAccessLogic mObjUserDataAccessLogic;
    private ClsTradeMarkDataAccessLogic mObjDataAccess;
    private ClsAgentLettersDataAccessLogic mObjAgentLettersDataAccess;
    private ClsCommon mobjCommon;
    static private HttpPostedFile mobjPostedFile;
    static private bool mblnIsSearchMode = false;
    static private string mstrCurrentSortExpression = ClsDBConstants.TradeMark_Col_Year;
    static private bool mblnSortAscending = false;
    static private int miCurrentPageIndex = 1;
    static private int miRenewalCount;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            mObjUserDataAccessLogic = new ClsUserDataAccessLogic();
           // divOperations.Visible = ClsCommon.AuthenticatePage(this, false);
           // divOperations.Visible = ClsLoginManager.GetUserAccessOnPage(this);
            //grdTradeMark.Columns[8].Visible = divOperations.Visible;

            dvCommands.Visible = ClsCommon.AuthenticatePage(this, false);
            dvCommands.Visible = ClsLoginManager.GetUserAccessOnPage(this);

            mobjCommon = new ClsCommon();
            mObjDataAccess = new ClsTradeMarkDataAccessLogic();
            mObjAgentLettersDataAccess = new ClsAgentLettersDataAccessLogic();

            if (!IsPostBack)
            {
                divDetail.Visible = false;
                btnRemove.CausesValidation = false;

                mobjCommon.FillAgents(drpAgent);
                mobjCommon.FillAgents(drpAgent2);
                mobjCommon.FillApplicants(drpApplicant);
                mobjCommon.FillStatus(drpStatus);

                mobjCommon.FillAgents(drpSrchAgent);
                mobjCommon.FillAgents(drpSrchAgent2);
                mobjCommon.FillApplicants(drpSrchApplicant);
                mobjCommon.FillStatus(drpSrchStatus);

                FillAllTradeMarks();
                SetButtonsActivity();
            }
            AddClassesCheckMarks();
        }
        catch (Exception ex)
        {
            divDetail.Visible = false;
            divGrid.Visible = false;
            //divOperations.Visible = false;
            dvCommands.Visible = false;
            ClsCommon.ShowMessage(this, MessageType.Error,
                                  "An error has been occurred during loading 'TradeMark' form.",
                                  ex);
        }
    }

    protected void grdTradeMark_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            switch (e.SortExpression)
            {
                case ClsDBConstants.TradeMark_Col_Year:

                    mstrCurrentSortExpression = e.SortExpression;

                    break;
                default:
                    e.Cancel = true;
                    break;
            }

            if (!e.Cancel)
                mblnSortAscending = !mblnSortAscending;

            if (mblnIsSearchMode)
            {
                StartSearch();
            }
            else
            {
                FillAllTradeMarks();
            }
        }
        catch (Exception ex)
        {
            ClsCommon.ShowMessage(this, MessageType.Error,
                                  "An error has been occurred during sorting operaiton.",
                                  ex);
        }
    }

    protected void grdTradeMark_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdTradeMark.PageIndex = e.NewPageIndex;
            if (mblnIsSearchMode)
            {
                StartSearch();
            }
            else
            {
                FillAllTradeMarks();
            }
            miCurrentPageIndex = e.NewPageIndex;
        }
        catch (Exception ex)
        {
            ClsCommon.ShowMessage(this, MessageType.Error,
                                  "Failed to change current page.",
                                  ex);
        }
    }

    protected void grdTradeMark_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ClsTradeMark objTradeMark = mObjDataAccess.GetTradeMark((long)grdTradeMark.SelectedValue);

            if (objTradeMark == null) return;

            miRenewalCount = objTradeMark.RenewalCount;

            // This should be filled first because of the further operations are
            // based on it.
            txtID.Text = objTradeMark.ID.ToString();
            divDetail.Visible = true;

            if (btnAdd.Text == "Add")
            {
                btnAdd.Text = "New";
                btnAdd.CausesValidation = false;
            }

            SetButtonsActivity();

            chkRenewalDate.Checked = false;
            drpAgent.SelectedValue = objTradeMark.AgentID.ToString();
            drpAgent2.SelectedValue = objTradeMark.Agent2ID.ToString();
            drpApplicant.SelectedValue = objTradeMark.ApplicantID.ToString();
            txtAppNo.Text = objTradeMark.AppNumber;
            txtComment.Text = objTradeMark.Comment;
            txtKCommission.Text = objTradeMark.KCommission;
            txtExtractNumber.Text = objTradeMark.ExtractNumber;
            txtOppositionAgainst.Text = objTradeMark.OppositionAganistNumber;
            txtAdditionalGoodsClasses.Text = objTradeMark.AdditionalGoodsClassesNumber;
            txtFillingNo.Text = objTradeMark.FillingNumber.ToString();
            imgPicture.ImageUrl = objTradeMark.Picture;
            txtPowerOfAttorney.Text =
                (objTradeMark.PowerOfAttorney == 0) ? string.Empty : objTradeMark.PowerOfAttorney.ToString();
            txtRegNo.Text = objTradeMark.RegNumber;
            drpStatus.SelectedValue = objTradeMark.StatusID.ToString();
            txtTradeMark.Text = objTradeMark.TradeMarkName;
            txtYear.Text =
                (objTradeMark.Year == 0) ? string.Empty : objTradeMark.Year.ToString();

            // Fill Classes check boxes.
            SetClasses(objTradeMark.Classes);

            ClsCommon.FillDateInControls(objTradeMark.AppDate,
                                         txtAppDateYear,
                                         txtAppDateMonth,
                                         txtAppDateDay);
            ClsCommon.FillDateInControls(objTradeMark.RegDate,
                                         txtRegDateYear,
                                         txtRegDateMonth,
                                         txtRegDateDay);

            lblRenewalDate.Text =
                (objTradeMark.RenewalCount != 0) ?
                objTradeMark.RenewalDate :
                "'None'";
            lblRenewalDateShamsi.Text =
                (objTradeMark.RenewalCount != 0) ?
                ClsCommon.GetPersianDate(objTradeMark.RenewalDate, objTradeMark.AppDate) :
                "'None'";

            ////lblRenewalDate.Text = 
            ////    (objTradeMark.RenewalDate != string.Empty)? 
            ////    ClsCommon.GetGregorianDate(objTradeMark.RenewalDate):
            ////    "'None'";
            ////lblRenewalDateShamsi.Text =
            ////    (objTradeMark.RenewalDate != string.Empty) ?
            ////    objTradeMark.RenewalDate:
            ////    "'None'"; 
            ////lblRenewalDate.Text = (objTradeMark.RenewalDate) ?
            ////    ClsCommon.AddYearToPersianDate(objTradeMark.AppDate, 10) :
            ////    string.Empty;

            lblRegDateG.Text =
                (objTradeMark.RegDate == string.Empty) ? "'None'" :
                DateConverter.GetGregorianDate(objTradeMark.RegDate);
            //FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(objTradeMark.RegDate).ToWritten();

            lblAppDateG.Text =
                (objTradeMark.AppDate == string.Empty) ? "'None'" :
                DateConverter.GetGregorianDate(objTradeMark.AppDate);
            //FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(objTradeMark.AppDate).ToWritten();

            lblLastCheckedDateValue.Text =
                (objTradeMark.LastDateChecked != string.Empty) ?
                objTradeMark.LastDateChecked :
                "'None'";
        }
        catch (Exception ex)//ArgumentOutOfRange
        {
            ClsCommon.ShowMessage(this, MessageType.Error,
                                  "Failed to get related information to the selected trademark.",
                                  ex);
        }
    }

    protected void btnStartSearch_Click(object sender, EventArgs e)
    {
        try
        {
            Page.Validate("Search");

            if (Page.IsValid)
                StartSearch();
            else
                ClsCommon.ShowMessage(this.Page, MessageType.Error, "The specified search conditions are not valid.");
        }
        catch (Exception ex)
        {
            ClsCommon.ShowMessage(this, MessageType.Error,
                                  "Failed to get search result from database.",
                                  ex);
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsValid)
                return;

            ClsTradeMark objTradeMark = GetTradeMarkFromUI(false);

            mObjDataAccess.Update(objTradeMark, false, this);
            FillAllTradeMarks();
            grdTradeMark.SelectedIndex = -1;
            SetButtonsActivity();
            divDetail.Visible = false;

            if (grdTradeMark.PageCount >= miCurrentPageIndex)
                grdTradeMark.PageIndex = miCurrentPageIndex;
        }
        catch (Exception ex)
        {
            ClsCommon.ShowMessage(this, MessageType.Error,
                                  "An error has been occurred during updating the selected trademark.",
                                  ex);
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            ClsTradeMark objTradeMark;

            if (btnAdd.Text == "Add")
            {
                if (!Page.IsValid)
                    return;
                objTradeMark = GetTradeMarkFromUI(true);

                mObjDataAccess.Insert(objTradeMark, false, this);

                FillAllTradeMarks();

                btnAdd.Text = "New";
                btnAdd.CausesValidation = false;

                divDetail.Visible = false;
            }
            else
            {
                ClearUI();
                btnAdd.Text = "Add";
                btnAdd.CausesValidation = true;

                divDetail.Visible = true;
            }

            SetButtonsActivity();
        }
        catch (Exception ex)
        {
            ClsCommon.ShowMessage(this, MessageType.Error,
                                  "An error has been occurred during adding the specifieds trademark.:",
                                  ex);
        }
    }

    protected void btnRemove_Click(object sender, EventArgs e)
    {
        try
        {
            ClsTradeMark objTradeMark;

            objTradeMark = GetTradeMarkFromUI(false);
            mObjDataAccess.Delete(objTradeMark, false, this);

            // Remove the related picture from server.
            if (objTradeMark.Picture.Trim() != string.Empty)
                RemoveOriginalPicture(objTradeMark.Picture.Trim());

            grdTradeMark.SelectedIndex = -1;

            FillAllTradeMarks();

            SetButtonsActivity();

            divDetail.Visible = false;
        }
        catch (Exception ex)
        {
            ClsCommon.ShowMessage(this, MessageType.Error,
                                  "An error has been occurred during removing selected trademark.",
                                  ex);
        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            mobjPostedFile = ctrlUpload.PostedFile;

            if (mobjPostedFile.ContentLength == 0)
                mobjPostedFile = null;
        }
        catch (Exception ex)
        {
            ClsCommon.ShowMessage(this, MessageType.Error,
                                  "Failed to upload the specified image.",
                                  ex);
        }

    }

    protected void ctrlRegDateValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            args.IsValid = ClsCommon.IsPersianDateValid(txtRegDateYear.Text, txtRegDateMonth.Text, txtRegDateDay.Text);
        }
        catch
        {
            args.IsValid = false;
        }
    }

    protected void ctrlAppDateValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            ctrlAppDateValidator.ErrorMessage = "Invalid Date!";
            args.IsValid = ClsCommon.IsPersianDateValid(txtAppDateYear.Text, txtAppDateMonth.Text, txtAppDateDay.Text);

            if (args.IsValid)
            {
                if (txtRegDateYear.Text.Trim() != string.Empty &&
                    string.Compare(ClsCommon.GetDateFromControls(txtAppDateYear, txtAppDateMonth, txtAppDateDay),
                                   ClsCommon.GetDateFromControls(txtRegDateYear, txtRegDateMonth, txtRegDateDay),
                                   true, System.Globalization.CultureInfo.InvariantCulture) > 0)
                {
                    args.IsValid = false;
                    ctrlAppDateValidator.ErrorMessage = "Above RegDate!";
                }
            }
        }
        catch
        {
            args.IsValid = false;
        }
    }

    protected void ctrlFillingNoExistanceValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            long lCurrentTradeMarkID = 0;

            if (txtID.Text != string.Empty)
            {
                lCurrentTradeMarkID = long.Parse(txtID.Text);
            }

            args.IsValid = !mObjDataAccess.IsFillingNoExists(long.Parse(args.Value), lCurrentTradeMarkID);
        }
        catch
        {
            args.IsValid = false;
        }
    }

    protected void ctrlRegNoExistanceValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            long lCurrentTrademarkID = 0;

            if (txtID.Text != string.Empty)
            {
                lCurrentTrademarkID = long.Parse(txtID.Text);
            }

            args.IsValid = !mObjDataAccess.IsRegNoExists(args.Value, lCurrentTrademarkID);
        }
        catch
        {
            args.IsValid = false;
        }
    }

    protected void ctrlAppNoExistanceValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            long lCurrentTrademarkID = 0;

            if (txtID.Text != string.Empty)
            {
                lCurrentTrademarkID = long.Parse(txtID.Text);
            }

            args.IsValid = !mObjDataAccess.IsAppNoExists(args.Value, lCurrentTrademarkID);
        }
        catch
        {
            args.IsValid = false;
        }
    }

    protected void ctrlOppositionAgainstExistanceValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            long lCurrentTrademarkID = 0;

            if (txtID.Text != string.Empty)
            {
                lCurrentTrademarkID = long.Parse(txtID.Text);
            }

            args.IsValid = !mObjDataAccess.IsOppositionAganistExists(args.Value, lCurrentTrademarkID);
        }
        catch
        {
            args.IsValid = false;
        }
    }

    protected void ctrlAdditionalGoodsClassesExistanceValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            long lCurrentTrademarkID = 0;

            if (txtID.Text != string.Empty)
            {
                lCurrentTrademarkID = long.Parse(txtID.Text);
            }

            args.IsValid = !mObjDataAccess.IsAdditionalGoodsClassesExists(args.Value, lCurrentTrademarkID);
        }
        catch
        {
            args.IsValid = false;
        }
    }

    protected void ctrlStatusValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            args.IsValid = (drpStatus.SelectedIndex != -1);
        }
        catch
        {
            args.IsValid = false;
        }
    }

    protected void ctrlAgentValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            args.IsValid = (drpAgent.SelectedIndex != -1);
        }
        catch
        {
            args.IsValid = false;
        }
    }

    protected void ctrlAgent2Validator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            args.IsValid = (drpAgent2.SelectedIndex != -1);
        }
        catch
        {
            args.IsValid = false;
        }
    }

    protected void ctrlApplicantValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            args.IsValid = (drpApplicant.SelectedIndex != -1);
        }
        catch
        {
            args.IsValid = false;
        }
    }

    #region "Private methods"

    private void StartSearch()
    {
        DataTable dtResult;
        string strRenewalDateFrom;
        string strRenewalDateTo;

        string lAppNo = txtSrchAppNo.Text.Trim();
        string lRegNo = txtSrchRegNo.Text.Trim();
        string lOppositionAgainst = txtSrchOppositionAganist.Text.Trim();
        string lAdditionalGoodsClassesNo = txtSrchAdditionalGoodsClassesNo.Text.Trim();


        strRenewalDateFrom = ClsCommon.GetDateFromControls(txtRenewalDateYearFrom,
                                                           txtRenewalDateMonthFrom,
                                                           txtRenewalDateDayFrom);

        strRenewalDateTo = ClsCommon.GetDateFromControls(txtRenewalDateYearTo,
                                                        txtRenewalDateMonthTo,
                                                        txtRenewalDateDayTo);

        if (strRenewalDateFrom != string.Empty && strRenewalDateTo != string.Empty)
        {
            dtResult = mObjDataAccess.Search(lAppNo, lOppositionAgainst,lAdditionalGoodsClassesNo,
                                         lRegNo,
                                         txtsrchTrademark.Text.Trim(),
                                         long.Parse(drpSrchApplicant.SelectedValue),
                                         long.Parse(drpSrchAgent.SelectedValue),
                                         long.Parse(drpSrchAgent2.SelectedValue),
                                         (txtsrchFillingNo.Text.Trim() != string.Empty) ? long.Parse(txtsrchFillingNo.Text.Trim()) : 0, long.Parse(drpSrchStatus.SelectedValue),
                                         strRenewalDateFrom,
                                         strRenewalDateTo,
                                         ClsCommon.GetNowPersianDate(),
                                         mstrCurrentSortExpression,
                                         mblnSortAscending);
        }
        else
        {
            dtResult = mObjDataAccess.Search(lAppNo, lOppositionAgainst,lAdditionalGoodsClassesNo,
                                             lRegNo,
                                             txtsrchTrademark.Text.Trim(),
                                             long.Parse(drpSrchApplicant.SelectedValue),
                                             long.Parse(drpSrchAgent.SelectedValue),
                                             long.Parse(drpSrchAgent2.SelectedValue),
                                             (txtsrchFillingNo.Text.Trim() != string.Empty) ? long.Parse(txtsrchFillingNo.Text.Trim()) : 0, long.Parse(drpSrchStatus.SelectedValue),
                                             mstrCurrentSortExpression,
                                             mblnSortAscending);
        }
        FillDataInGrid(dtResult);

        mblnIsSearchMode = true;

        ClsCommon.ShowMessage(this, MessageType.Info, "'" + dtResult.Rows.Count.ToString() + "' Result Found.");
    }

    private void FillDataInGrid(DataTable dtTradeMarks)
    {
        grdTradeMark.DataSource = dtTradeMarks;
        grdTradeMark.DataBind();

        divGrid.Visible = (grdTradeMark.Rows.Count > 0);
    }

    private void FillAllTradeMarks()
    {
        try
        {
            FillDataInGrid(mObjDataAccess.GetTradeMarkForPreview(mstrCurrentSortExpression, mblnSortAscending));
            mblnIsSearchMode = false;
        }
        catch (Exception ex)
        {
            ClsCommon.ShowMessage(this, MessageType.Error,
                                  "Failed to get available trademark from database.",
                                  ex);
        }
    }

    private void SetButtonsActivity()
    {
        btnUpdate.Enabled = (grdTradeMark.SelectedIndex != -1 && btnAdd.Text == "New");
        btnRemove.Enabled = btnUpdate.Enabled;

        //btnUpload.Visible = (divOperations.Visible && grdTradeMark.SelectedIndex != -1 || btnAdd.Text == "Add");
        //ctrlUpload.Visible = (divOperations.Visible && grdTradeMark.SelectedIndex != -1 || btnAdd.Text == "Add");
        btnUpload.Visible = (dvCommands.Visible && grdTradeMark.SelectedIndex != -1 || btnAdd.Text == "Add");
        ctrlUpload.Visible = (dvCommands.Visible && grdTradeMark.SelectedIndex != -1 || btnAdd.Text == "Add");
    }

    private void ClearUI()
    {
        chkRenewalDate.Checked = false;
        lblRenewalDate.Text = string.Empty;
        miRenewalCount = 0;
        lblRenewalDateShamsi.Text = string.Empty;

        drpAgent.SelectedIndex = -1;
        drpAgent2.SelectedIndex = -1;
        ClsCommon.FillDateInControls(string.Empty,
                                     txtAppDateYear,
                                     txtAppDateMonth,
                                     txtAppDateDay);
        lblAppDateG.Text = string.Empty;
        drpApplicant.SelectedIndex = -1;
        txtAppNo.Text = string.Empty;
        txtOppositionAgainst.Text = string.Empty;
        txtAdditionalGoodsClasses.Text = string.Empty;
        txtExtractNumber.Text = string.Empty;
        txtFillingNo.Text = string.Empty;

        txtID.Text = string.Empty;
        lblLastCheckedDateValue.Text = string.Empty;
        imgPicture.ImageUrl = string.Empty;
        txtPowerOfAttorney.Text = string.Empty;
        ClsCommon.FillDateInControls(string.Empty,
                                     txtRegDateYear,
                                     txtRegDateMonth,
                                     txtRegDateDay);
        lblRegDateG.Text = string.Empty;
        txtRegNo.Text = string.Empty;
        drpStatus.SelectedIndex = -1;
        txtTradeMark.Text = string.Empty;
        txtYear.Text = string.Empty;
        txtComment.Text = string.Empty;
        txtKCommission.Text = string.Empty;
        ClearClasses();
    }

    private ClsTradeMark GetTradeMarkFromUI(bool blnForInsert)
    {
        ClsTradeMark objTradeMark;

        objTradeMark = new ClsTradeMark();

        objTradeMark.AgentID = int.Parse(drpAgent.SelectedValue);
        objTradeMark.Agent2ID = int.Parse(drpAgent2.SelectedValue);
        objTradeMark.AppDate =
            ClsCommon.GetDateFromControls(txtAppDateYear, txtAppDateMonth, txtAppDateDay);
        objTradeMark.ApplicantID = int.Parse(drpApplicant.SelectedValue);
        objTradeMark.AppNumber = txtAppNo.Text.Trim();
        objTradeMark.KCommission = txtKCommission.Text.Trim();
        objTradeMark.Comment = txtComment.Text.Trim();
        objTradeMark.ExtractNumber = txtExtractNumber.Text.Trim();
        objTradeMark.OppositionAganistNumber = txtOppositionAgainst.Text.Trim();
        objTradeMark.AdditionalGoodsClassesNumber = txtAdditionalGoodsClasses.Text.Trim();
        objTradeMark.FillingNumber = long.Parse(txtFillingNo.Text);

        if (objTradeMark.AppDate != string.Empty)
        {
            if (chkRenewalDate.Checked)
            {
                miRenewalCount += 1;
            }

            //objTradeMark.RenewalDate =
            //        ClsCommon.AddYearToPersianDate(objTradeMark.AppDate,
            //                                       miRenewalCount * 10,
            //                                       true);
            objTradeMark.RenewalDate = DateConverter.GetGregorianDate(ClsCommon.AddYearToMyPersianDate(DateConverter.GetGregorianDate(objTradeMark.AppDate), miRenewalCount * 10));
        }
        else
        {
            miRenewalCount = 0;
            objTradeMark.RenewalDate = string.Empty;
        }

        objTradeMark.RenewalCount = miRenewalCount;

        if (!blnForInsert)
            objTradeMark.ID = long.Parse(txtID.Text);

        objTradeMark.LastDateChecked = string.Format("{0:yyyy/MM/dd}", DateTime.Now);

        if (blnForInsert || mobjPostedFile != null)
        {
            // Remove the original image file if exists.
            if (!blnForInsert && imgPicture.ImageUrl.Trim() != string.Empty)
            {
                RemoveOriginalPicture(imgPicture.ImageUrl);
            }
            if (mobjPostedFile != null)
                objTradeMark.Picture = mobjCommon.UploadPicture(ref mobjPostedFile, Server);
            else
                objTradeMark.Picture = string.Empty;
        }
        else
            objTradeMark.Picture = imgPicture.ImageUrl;

        objTradeMark.PowerOfAttorney =
            (txtPowerOfAttorney.Text.Trim() != string.Empty) ? long.Parse(txtPowerOfAttorney.Text) : 0;

        objTradeMark.RegDate =
            ClsCommon.GetDateFromControls(txtRegDateYear, txtRegDateMonth, txtRegDateDay);

        objTradeMark.RegNumber = txtRegNo.Text.Trim();
        objTradeMark.StatusID = int.Parse(drpStatus.SelectedValue);
        objTradeMark.TradeMarkName = txtTradeMark.Text.Trim();
        objTradeMark.Comment = txtComment.Text.Trim();
        objTradeMark.KCommission = txtKCommission.Text.Trim();
        objTradeMark.Year =
            (txtYear.Text != string.Empty) ? int.Parse(txtYear.Text) : 0;

        string strClassess = string.Empty;
        CheckBox chk;
        foreach (object objControl in pnlClasses.Controls)
        {
            if (objControl is CheckBox)
            {
                chk = objControl as CheckBox;
                strClassess += (chk.Checked) ? "1" : "0";
            }
        }

        objTradeMark.Classes = strClassess;

        mobjPostedFile = null;

        return objTradeMark;
    }

    private void RemoveOriginalPicture(string strRelativePicturePath)
    {
        try
        {
            string strImageDir = ConfigurationManager.AppSettings.Get("DatabaseImagesPath");

            string strImagePath = strRelativePicturePath.Replace(@"~", Server.MapPath(string.Empty));

            if (System.IO.File.Exists(strImagePath))
                System.IO.File.Delete(strImagePath);
        }
        catch (Exception ex)
        {
            ClsCommon.ShowMessage(this, MessageType.Error,
                                  "An error has been occurred during removing the related picture to original trademark.",
                                  ex);
        }
    }

    private void AddClassesCheckMarks()
    {
        string strChildHtml = string.Empty;
        for (int iIndex = 1; iIndex <= 45; iIndex++)
        {
            //strChildHtml += @"<asp:CheckBox ID=""chkClass" + iIndex.ToString() + 
            //                @""" Text=""" + iIndex.ToString() + @""" runat=""server"" />";
            CheckBox chk = new CheckBox();

            chk.ID = "chkClass" + iIndex.ToString();
            chk.Text = iIndex.ToString();
            chk.EnableViewState = true;
            chk.Visible = true;

            pnlClasses.Controls.Add(chk);
        }
        pnlClasses.Visible = true;
    }

    private void ClearClasses()
    {
        foreach (object objControl in pnlClasses.Controls)
        {
            if (objControl is CheckBox)
            {
                ((CheckBox)objControl).Checked = false;
            }
        }
    }
    public string HasLetter(object lFilingNo)
    {
        DataTable objLetterDataTable = mObjAgentLettersDataAccess.GetAllLetterByFilingNoLetterType((long)lFilingNo, Convert.ToInt32(LetterType.TradeMarkLetter));
        if (objLetterDataTable.Rows.Count > 0)
            return "~/Images/UI/mail.png";
        else
            return "~/Images/UI/add.png";
    }

    public string StatusName(object statusId)
    {
        ListItemCollection columnStatus = drpStatus.Items;
        string statusName=string.Empty;
        foreach (ListItem item in columnStatus)
        {
            if (item.Value == statusId.ToString())
            {
                statusName = item.Text;
                break;
            }
        }
        return statusName;
    }

    private void SetClasses(string strClasses)
    {
        // Fill Classes check boxes.
        if (strClasses != string.Empty)
        {
            char[] arrClasses = strClasses.ToCharArray();
            int iControlIndex = 0;

            foreach (object objControl in pnlClasses.Controls)
            {
                if (objControl is CheckBox)
                {
                    ((CheckBox)objControl).Checked = (arrClasses[iControlIndex] == char.Parse("1"));
                    iControlIndex++;
                }
            }
        }
        else
        {
            ClearClasses();
        }
    }

    # endregion

    protected void ctrlSrchAppDateValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = ClsCommon.IsGregorianDateValid(txtRenewalDateYearFrom.Text.Trim(),
                                                     txtRenewalDateMonthFrom.Text.Trim(),
                                                     txtRenewalDateDayFrom.Text.Trim()) &
                        ClsCommon.IsGregorianDateValid(txtRenewalDateYearTo.Text.Trim(),
                                                      txtRenewalDateMonthTo.Text.Trim(),
                                                      txtRenewalDateDayTo.Text.Trim());
    }
}
