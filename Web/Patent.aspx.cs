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
using System.Collections.Generic;
using Laghaee.Common;
using Laghaee.DataAccess;
using Laghaee.Common.Enumeration;

public partial class Patent : System.Web.UI.Page
{
    private const int ID_Index = 0;
    private ClsUserDataAccessLogic mObjUserDataAccessLogic;
    private ClsPatentDataAccessLogic mObjDataAccess;
    private ClsAgentLettersDataAccessLogic mObjAgentLettersDataAccess;
    private ClsCommon mobjCommon;
    static private bool mblnIsSearchMode = false;
    static private string mstrCurrentSortExpression = ClsDBConstants.Patent_Col_Year;
    static private bool mblnSortAscending = false;
    static private int miCurrentPageIndex = 1;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            mObjUserDataAccessLogic = new ClsUserDataAccessLogic();
            //divOperations.Visible = ClsCommon.AuthenticatePage(this, false);
            //divOperations.Visible = ClsLoginManager.GetUserAccessOnPage(this);
            //grdPatent.Columns[8].Visible=divOperations.Visible;

            dvCommands.Visible = ClsCommon.AuthenticatePage(this, false);
            dvCommands.Visible = ClsLoginManager.GetUserAccessOnPage(this);

            mobjCommon = new ClsCommon();
            mObjDataAccess = new ClsPatentDataAccessLogic();
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

                FillAllPatents();
                SetButtonsActivity();
            }
        }
        catch (Exception ex)
        {
            divDetail.Visible = false;
            divGrid.Visible = false;
            //divOperations.Visible = false;
            dvCommands.Visible = false;
            ClsCommon.ShowMessage(this, MessageType.Error,
                                  "An error occurred during loading 'Patent' form.",
                                  ex);
        }
    }

    protected void grdPatent_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            switch (e.SortExpression)
            {
                case ClsDBConstants.Patent_Col_Year:

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
                FillAllPatents();
            }
        }
        catch (Exception ex)
        {
            ClsCommon.ShowMessage(this, MessageType.Error,
                                  "An error has been occurred during sorting operaiton.",
                                  ex);
        }
    }

    protected void grdPatent_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdPatent.PageIndex = e.NewPageIndex;
            if (mblnIsSearchMode)
            {
                StartSearch();
            }
            else
            {
                FillAllPatents();
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

    protected void grdPatent_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ClsPatent objPatent = mObjDataAccess.GetPatent((long)grdPatent.SelectedValue);

            if (objPatent == null) return;

            // This should be filled first because of the further operations are
            // based on it.
            txtID.Text = objPatent.ID.ToString();
            divDetail.Visible = true;

            if (btnAdd.Text == "Add")
            {
                btnAdd.Text = "New";
                btnAdd.CausesValidation = false;
            }

            SetButtonsActivity();

            drpAgent.SelectedValue = objPatent.AgentID.ToString();
            drpAgent2.SelectedValue = objPatent.Agent2ID.ToString();
            drpApplicant.SelectedValue = objPatent.ApplicantID.ToString();
            txtAppNo.Text = objPatent.AppNumber.ToString();
            txtComment.Text = objPatent.Comment;
            txtAdditionalGoodsClasses.Text = objPatent.AdditionalGoodsClassesNumber;
            txtKCommission.Text = objPatent.KCommission;
            txtFillingNo.Text = objPatent.FillingNumber.ToString();
            txtPowerOfAttorney.Text =
                (objPatent.PowerOfAttorney == 0) ? string.Empty : objPatent.PowerOfAttorney.ToString();
            txtRegNo.Text = objPatent.RegNumber.ToString();
            drpStatus.SelectedValue = objPatent.StatusID.ToString();
            drpNextAnnuityYear.SelectedValue = objPatent.NextAnnuityYear.ToString();
            txtTradeMark.Text = objPatent.Title;
            txtYear.Text =
                (objPatent.Year == 0) ? string.Empty : objPatent.Year.ToString();

            ClsCommon.FillDateInControls(objPatent.AppDate,
                                         txtAppDateYear,
                                         txtAppDateMonth,
                                         txtAppDateDay);
            ClsCommon.FillDateInControls(objPatent.NextAnnuityDate,
                                         txtNextAnnuYear,
                                         txtNextAnnuMonth,
                                         txtNextAnnuDay);
            ClsCommon.FillDateInControls(objPatent.RegDate,
                                         txtRegDateYear,
                                         txtRegDateMonth,
                                         txtRegDateDay);
            lblRegDateG.Text =
                (objPatent.RegDate == string.Empty) ? "'None'" :
                DateConverter.GetGregorianDate(objPatent.RegDate);
            //FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(objPatent.RegDate).ToWritten();
            lblAppDateG.Text =
                (objPatent.AppDate == string.Empty) ? "'None'" :
                DateConverter.GetGregorianDate(objPatent.AppDate);
            //FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(objPatent.AppDate).ToWritten();
            lblNextAnnuityDateG.Text =
                (objPatent.NextAnnuityDate == string.Empty) ? string.Empty :
                DateConverter.GetGregorianDate(objPatent.NextAnnuityDate);
            //FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(objPatent.NextAnnuityDate).ToWritten();

            lblLastCheckedDateValue.Text =
                (objPatent.LastDateChecked != string.Empty) ?
                objPatent.LastDateChecked :
                "'None'";
        }
        catch (Exception ex) //ArgumentOutOfRange
        {
            ClsCommon.ShowMessage(this, MessageType.Error,
                                  "Failed to get related information to the selected patent.",
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

            ClsPatent objPatent = GetPatentFromUI(false);

            mObjDataAccess.Update(objPatent, false, this);
            FillAllPatents();
            grdPatent.SelectedIndex = -1;
            SetButtonsActivity();
            divDetail.Visible = false;

            if (grdPatent.PageCount >= miCurrentPageIndex)
                grdPatent.PageIndex = miCurrentPageIndex;
        }
        catch (Exception ex)
        {
            ClsCommon.ShowMessage(this, MessageType.Error,
                                  "An error has been occurred during updating the selected patent.",
                                  ex);
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            ClsPatent objPatent;

            if (btnAdd.Text == "Add")
            {
                if (!Page.IsValid)
                    return;

                objPatent = GetPatentFromUI(true);

                mObjDataAccess.Insert(objPatent, false, this);

                FillAllPatents();

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
                                  "An error has been occurred during adding the specified patent.",
                                  ex);
        }
    }

    protected void btnRemove_Click(object sender, EventArgs e)
    {
        try
        {

            ClsPatent objPatent;

            objPatent = GetPatentFromUI(false);
            mObjDataAccess.Delete(objPatent, false, this);

            grdPatent.SelectedIndex = -1;

            FillAllPatents();

            SetButtonsActivity();

            divDetail.Visible = false;
        }
        catch (Exception ex)
        {
            ClsCommon.ShowMessage(this, MessageType.Error,
                                  "An error has been occurred during removing the selected patent.",
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

    protected void ctrlNextAnnuityDateValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            args.IsValid = ClsCommon.IsPersianDateValid(txtNextAnnuYear.Text, txtNextAnnuMonth.Text, txtNextAnnuDay.Text);
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
            long lCurrentPatentID = 0;

            if (txtID.Text != string.Empty)
            {
                lCurrentPatentID = long.Parse(txtID.Text);
            }

            args.IsValid = !mObjDataAccess.IsFillingNoExists(long.Parse(args.Value), lCurrentPatentID);
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
            long lCurrentPatentID = 0;

            if (txtID.Text != string.Empty)
            {
                lCurrentPatentID = long.Parse(txtID.Text);
            }

            args.IsValid = !mObjDataAccess.IsRegNoExists(args.Value, lCurrentPatentID);
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
            long lCurrentDesignID = 0;

            if (txtID.Text != string.Empty)
            {
                lCurrentDesignID = long.Parse(txtID.Text);
            }

            args.IsValid = !mObjDataAccess.IsAppNoExists(args.Value, lCurrentDesignID);
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

    protected void ctrlAdditionalGoodsClassesExistanceValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            long lCurrentPatentID = 0;

            if (txtID.Text != string.Empty)
            {
                lCurrentPatentID = long.Parse(txtID.Text);
            }

            args.IsValid = !mObjDataAccess.IsAdditionalGoodsClassesExists(args.Value, lCurrentPatentID);
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

        string lAppNo = txtSrchAppNo.Text.Trim();
        string lRegNo = txtSrchRegNo.Text.Trim();
        string lAdditionalGoodsClasses = txtSrchAdditionalGoodsClassesNo.Text.Trim();

        dtResult = mObjDataAccess.Search(lAppNo,
                                         lRegNo, lAdditionalGoodsClasses,
                                         txtsrchTitle.Text.Trim(),
                                         long.Parse(drpSrchApplicant.SelectedValue),
                                         long.Parse(drpSrchAgent.SelectedValue),
                                         long.Parse(drpSrchAgent2.SelectedValue),
                                         (txtsrchFillingNo.Text.Trim() != string.Empty) ? long.Parse(txtsrchFillingNo.Text.Trim()) : 0, long.Parse(drpSrchStatus.SelectedValue),
                                         mstrCurrentSortExpression,
                                         mblnSortAscending);
        FillDataInGrid(dtResult);

        mblnIsSearchMode = true;

        ClsCommon.ShowMessage(this, MessageType.Info, "'" + dtResult.Rows.Count.ToString() + "' Result Found.");
    }

    private void FillDataInGrid(DataTable dtPatents)
    {
        grdPatent.DataSource = dtPatents;
        grdPatent.DataBind();

        divGrid.Visible = (grdPatent.Rows.Count > 0);
    }

    private void FillAllPatents()
    {
        try
        {
            FillDataInGrid(mObjDataAccess.GetPatentForPreview(mstrCurrentSortExpression, mblnSortAscending));
            mblnIsSearchMode = false;
        }
        catch (Exception ex)
        {
            ClsCommon.ShowMessage(this, MessageType.Error,
                                  "Failed to get available patents from database.",
                                  ex);
        }
    }

    private void SetButtonsActivity()
    {
        btnUpdate.Enabled = (grdPatent.SelectedIndex != -1 && btnAdd.Text == "New");
        btnRemove.Enabled = btnUpdate.Enabled;
    }

    private void ClearUI()
    {
        drpAgent.SelectedIndex = -1;
        drpAgent2.SelectedIndex = -1;
        ClsCommon.FillDateInControls(string.Empty,
                                     txtAppDateYear,
                                     txtAppDateMonth,
                                     txtAppDateDay);
        lblAppDateG.Text = string.Empty;
        drpApplicant.SelectedIndex = -1;
        txtAppNo.Text = string.Empty;
        txtComment.Text = string.Empty;
        txtKCommission.Text = string.Empty;
        txtFillingNo.Text = string.Empty;
        ClsCommon.FillDateInControls(string.Empty,
                                     txtNextAnnuYear,
                                     txtNextAnnuMonth,
                                     txtNextAnnuDay);
        txtID.Text = string.Empty;
        lblLastCheckedDateValue.Text = string.Empty;
        txtPowerOfAttorney.Text = string.Empty;
        ClsCommon.FillDateInControls(string.Empty,
                                     txtRegDateYear,
                                     txtRegDateMonth,
                                     txtRegDateDay);
        lblRegDateG.Text = string.Empty;
        lblNextAnnuityDate.Text = string.Empty;
        lblNextAnnuityDateG.Text = string.Empty;
        txtRegNo.Text = string.Empty;
        txtAdditionalGoodsClasses.Text = string.Empty;
        drpStatus.SelectedIndex = -1;
        drpNextAnnuityYear.SelectedValue = "0";
        txtTradeMark.Text = string.Empty;
        txtYear.Text = string.Empty;
    }

    private ClsPatent GetPatentFromUI(bool blnForInsert)
    {
        ClsPatent objPatent;

        objPatent = new ClsPatent();

        objPatent.AgentID = int.Parse(drpAgent.SelectedValue);
        objPatent.Agent2ID = int.Parse(drpAgent2.SelectedValue);
        objPatent.AppDate =
            ClsCommon.GetDateFromControls(txtAppDateYear, txtAppDateMonth, txtAppDateDay);
        objPatent.ApplicantID = int.Parse(drpApplicant.SelectedValue);
        objPatent.AppNumber = txtAppNo.Text.Trim();
        objPatent.Comment = txtComment.Text.Trim();
        objPatent.AdditionalGoodsClassesNumber = txtAdditionalGoodsClasses.Text.Trim();
        objPatent.KCommission = txtKCommission.Text.Trim();
        objPatent.FillingNumber = long.Parse(txtFillingNo.Text);
        objPatent.NextAnnuityDate =
            ClsCommon.GetDateFromControls(txtNextAnnuYear, txtNextAnnuMonth, txtNextAnnuDay);
        if (!blnForInsert)
            objPatent.ID = long.Parse(txtID.Text);
        objPatent.LastDateChecked = string.Format("{0:yyyy/MM/dd}", DateTime.Now);
        objPatent.PowerOfAttorney =
            (txtPowerOfAttorney.Text.Trim() != string.Empty) ? long.Parse(txtPowerOfAttorney.Text) : 0;

        objPatent.RegDate =
            ClsCommon.GetDateFromControls(txtRegDateYear, txtRegDateMonth, txtRegDateDay);
        objPatent.RegNumber = txtRegNo.Text.Trim();
        objPatent.StatusID = int.Parse(drpStatus.SelectedValue);
        objPatent.NextAnnuityYear = int.Parse(drpNextAnnuityYear.SelectedValue);
        objPatent.Title = txtTradeMark.Text.Trim();
        objPatent.Year =
            (txtYear.Text != string.Empty) ? int.Parse(txtYear.Text) : 0;

        return objPatent;
    }

    public string StatusName(object statusId)
    {
        ListItemCollection columnStatus = drpStatus.Items;
        string statusName = string.Empty;
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
    public string HasLetter(object lFilingNo)
    {
        DataTable objLetterDataTable = mObjAgentLettersDataAccess.GetAllLetterByFilingNoLetterType((long)lFilingNo, Convert.ToInt32(LetterType.PatentLetter));
        if (objLetterDataTable.Rows.Count > 0)
            return "~/Images/UI/mail.png";
        else
            return "~/Images/UI/add.png";
    }
    #endregion
}
