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

public partial class Design : System.Web.UI.Page
{
    private const int ID_Index = 0;

    private ClsDesignDataAccessLogic mObjDataAccess;
    private ClsUserDataAccessLogic mObjUserDataAccessLogic;
    private ClsAgentLettersDataAccessLogic mObjAgentLettersDataAccess;
    private ClsCommon mobjCommon;
    static private HttpPostedFile mobjPostedFile;
    static private bool mblnIsSearchMode = false;
    static private string mstrCurrentSortExpression = ClsDBConstants.Design_Col_Year;
    static private bool mblnSortAscending = false;
    static private int miCurrentPageIndex = 1;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            mObjUserDataAccessLogic = new ClsUserDataAccessLogic();
            //divOperations.Visible = ClsCommon.AuthenticatePage(this, false);
            //divOperations.Visible = ClsLoginManager.GetUserAccessOnPage(this);
            //grdDesign.Columns[7].Visible=divOperations.Visible ;

            dvCommands.Visible = ClsCommon.AuthenticatePage(this, false);
            dvCommands.Visible = ClsLoginManager.GetUserAccessOnPage(this);

            mobjCommon = new ClsCommon();
            mObjDataAccess = new ClsDesignDataAccessLogic();
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

                FillAllDesigns();
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
                                  "An error has been occurred during loading 'Design' form.",
                                  ex);
        }
    }

    protected void grdDesign_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdDesign.PageIndex = e.NewPageIndex;
            if (mblnIsSearchMode)
            {
                StartSearch();
            }
            else
            {
                FillAllDesigns();
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

    protected void grdDesign_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            switch (e.SortExpression)
            {
                case ClsDBConstants.Design_Col_Year:

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
                FillAllDesigns();
            }
        }
        catch (Exception ex)
        {
            ClsCommon.ShowMessage(this, MessageType.Error,
                                  "An error has been occurred during sorting operaiton.",
                                  ex);
        }
    }

    protected void grdDesign_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ClsDesign objDesign = mObjDataAccess.GetDesign((long)grdDesign.SelectedValue);

            if (objDesign == null) return;

            // This should be filled first because of the further operations are
            // based on it.
            txtID.Text = objDesign.ID.ToString();
            divDetail.Visible = true;

            if (btnAdd.Text == "Add")
            {
                btnAdd.Text = "New";
                btnAdd.CausesValidation = false;
            }

            SetButtonsActivity();

            drpAgent.SelectedValue = objDesign.AgentID.ToString();
            drpAgent2.SelectedValue = objDesign.Agent2ID.ToString();
            drpApplicant.SelectedValue = objDesign.ApplicantID.ToString();
            txtAppNo.Text = objDesign.AppNumber.ToString();
            txtClass.Text = objDesign.Class;
            txtComment.Text = objDesign.Comment;
            txtKCommission.Text = objDesign.KCommission;
            txtFillingNo.Text = objDesign.FillingNumber.ToString();
            txtAdditionalGoodsClasses.Text = objDesign.AdditionalGoodsClassesNumber.ToString();
            imgPicture.ImageUrl = objDesign.Picture;
            txtPowerOfAttorney.Text =
                (objDesign.PowerOfAttorney == 0) ? string.Empty : objDesign.PowerOfAttorney.ToString();
            txtRegNo.Text = objDesign.RegNumber.ToString();
            drpStatus.SelectedValue = objDesign.StatusID.ToString();
            txtYear.Text =
                (objDesign.Year == 0) ? string.Empty : objDesign.Year.ToString();

            chkFirstRenewalDate.Checked = objDesign.FirstRenewalDate;
            chkSecondRenewalDate.Checked = objDesign.SecondRenewalDate;
            chkThirdRenewalDate.Checked = objDesign.ThirdRenewalDate;

            ClsCommon.FillDateInControls(objDesign.AppDate,
                                         txtAppDateYear,
                                         txtAppDateMonth,
                                         txtAppDateDay);
            ClsCommon.FillDateInControls(objDesign.RegDate,
                                         txtRegDateYear,
                                         txtRegDateMonth,
                                         txtRegDateDay);

            lblFirstRenewalDate.Text =
                objDesign.FirstRenewalDate ?
                ClsCommon.AddYearToPersianDate(objDesign.AppDate, 5) :
                "'None'";
            lblFirstRenewalDateShamsi.Text =
                objDesign.FirstRenewalDate ?
                ClsCommon.AddYearToMyPersianDate(lblFirstRenewalDate.Text, 0) :
                "'None'";

            lblSecondRenewalDate.Text =
                objDesign.SecondRenewalDate ?
                ClsCommon.AddYearToPersianDate(objDesign.AppDate, 10) :
                "'None'";
            lblSecondRenewalDateShamsi.Text =
                objDesign.SecondRenewalDate ?
                ClsCommon.AddYearToMyPersianDate(lblFirstRenewalDate.Text, 5) :
                "'None'";

            lblThirdRenewalDate.Text =
                objDesign.ThirdRenewalDate ?
                ClsCommon.AddYearToPersianDate(objDesign.AppDate, 15) :
                "'None'";
            lblThirdRenewalDateShamsi.Text =
                objDesign.ThirdRenewalDate ?
                ClsCommon.AddYearToMyPersianDate(lblFirstRenewalDate.Text, 10) :
                "'None'";

            lblRegDateG.Text =
                (string.IsNullOrEmpty(objDesign.RegDate)) ? "'None'" :
                DateConverter.GetGregorianDate(objDesign.RegDate);
            //FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(objDesign.RegDate).ToWritten();
            lblAppDateG.Text =
                (string.IsNullOrEmpty(objDesign.AppDate)) ? "'None'" :
                DateConverter.GetGregorianDate(objDesign.AppDate);
            //FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(objDesign.AppDate).ToWritten();

            lblLastCheckedDateValue.Text =
                (!string.IsNullOrEmpty(objDesign.LastDateChecked)) ?
                objDesign.LastDateChecked :
                "'None'";

        }
        catch (Exception ex) //ArgumentOutOfRange
        {
            ClsCommon.ShowMessage(this,
                                  MessageType.Error,
                                  "Failed to load related info to the selected design.",
                                  ex);
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsValid)
                return;

            ClsDesign objDesign = GetDesignFromUI(false);

            mObjDataAccess.Update(objDesign, false, this);
            FillAllDesigns();
            grdDesign.SelectedIndex = -1;
            SetButtonsActivity();
            divDetail.Visible = false;

            if (grdDesign.PageCount >= miCurrentPageIndex)
                grdDesign.PageIndex = miCurrentPageIndex;
        }
        catch (Exception ex)
        {
            ClsCommon.ShowMessage(this, MessageType.Error,
                                  "An error has been occurred during updating the selected design.",
                                  ex);
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            ClsDesign objDesign;

            if (btnAdd.Text == "Add")
            {
                if (!Page.IsValid)
                    return;
                objDesign = GetDesignFromUI(true);

                mObjDataAccess.Insert(objDesign, false, this);

                FillAllDesigns();

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

                //divGrid.Style[HtmlTextWriterStyle.Top] = "270px";
            }

            SetButtonsActivity();

        }
        catch (Exception ex)
        {
            ClsCommon.ShowMessage(this, MessageType.Error,
                                  "An error has been occurred during adding the specified design.",
                                  ex);
        }
    }

    protected void btnRemove_Click(object sender, EventArgs e)
    {
        try
        {
            ClsDesign objDesign;

            objDesign = GetDesignFromUI(false);
            mObjDataAccess.Delete(objDesign, false, this);

            // Remove the related picture from server.
            if (!string.IsNullOrEmpty(objDesign.Picture.Trim()))
                RemoveOriginalPicture(objDesign.Picture.Trim());

            grdDesign.SelectedIndex = -1;

            FillAllDesigns();

            SetButtonsActivity();

            divDetail.Visible = false;
        }
        catch (Exception ex)
        {
            ClsCommon.ShowMessage(this, MessageType.Error,
                                  "An error has been occurred during removing the selected design.",
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
                                  "Failed to upload the selected image.",
                                  ex);
        }
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
        DataTable objLetterDataTable = mObjAgentLettersDataAccess.GetAllLetterByFilingNoLetterType((long)lFilingNo, Convert.ToInt32(LetterType.DesignLetter));
        if (objLetterDataTable.Rows.Count > 0)
            return "~/Images/UI/mail.png";
        else
            return "~/Images/UI/add.png";
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
                if (!string.IsNullOrEmpty(txtRegDateYear.Text.Trim()) &&
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
            long lCurrentDesignID = 0;

            if (!string.IsNullOrEmpty(txtID.Text))
            {
                lCurrentDesignID = long.Parse(txtID.Text);
            }

            args.IsValid = !mObjDataAccess.IsFillingNoExists(long.Parse(args.Value), lCurrentDesignID);
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
            long lCurrentDesignID = 0;

            if (!string.IsNullOrEmpty(txtID.Text))
            {
                lCurrentDesignID = long.Parse(txtID.Text);
            }

            args.IsValid = !mObjDataAccess.IsRegNoExists(args.Value, lCurrentDesignID);
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

            if (!string.IsNullOrEmpty(txtID.Text))
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
            long lCurrentDesignID = 0;

            if (txtID.Text != string.Empty)
            {
                lCurrentDesignID = long.Parse(txtID.Text);
            }

            args.IsValid = !mObjDataAccess.IsAdditionalGoodsClassesExists(args.Value, lCurrentDesignID);
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
        string lAdditionalGoodsClassesNo = txtSrchAdditionalGoodsClassesNo.Text.Trim();

        dtResult = mObjDataAccess.Search(lAppNo, lAdditionalGoodsClassesNo,
                                         lRegNo,
                                         txtsrchTrademark.Text.Trim(),
                                         long.Parse(drpSrchApplicant.SelectedValue),
                                         long.Parse(drpSrchAgent.SelectedValue),
                                         long.Parse(drpSrchAgent2.SelectedValue),
                                         (!string.IsNullOrEmpty(txtsrchFillingNo.Text.Trim())) ? long.Parse(txtsrchFillingNo.Text.Trim()) : 0,
                                         long.Parse(drpSrchStatus.SelectedValue),
                                         mstrCurrentSortExpression,
                                         mblnSortAscending);
        FillDataInGrid(dtResult);

        mblnIsSearchMode = true;

        ClsCommon.ShowMessage(this, MessageType.Info, "'" + dtResult.Rows.Count.ToString() + "' Result Found.");
    }

    private void FillDataInGrid(DataTable dtDesigns)
    {
        grdDesign.DataSource = dtDesigns;
        grdDesign.DataBind();

        divGrid.Visible = (grdDesign.Rows.Count > 0);
    }

    private void FillAllDesigns()
    {
        try
        {
            FillDataInGrid(mObjDataAccess.GetDesignForPreview(mstrCurrentSortExpression, mblnSortAscending));
            mblnIsSearchMode = false;
        }
        catch (Exception ex)
        {
            ClsCommon.ShowMessage(this, MessageType.Error,
                                  "Failed to get available designs from database.",
                                  ex);
        }
    }

    private void SetButtonsActivity()
    {
        btnUpdate.Enabled = (grdDesign.SelectedIndex != -1 && btnAdd.Text == "New");
        btnRemove.Enabled = btnUpdate.Enabled;

        //btnUpload.Visible = (divOperations.Visible && grdDesign.SelectedIndex != -1 || btnAdd.Text == "Add");
        //ctrlUpload.Visible = (divOperations.Visible && grdDesign.SelectedIndex != -1 || btnAdd.Text == "Add");
        btnUpload.Visible = (dvCommands.Visible && grdDesign.SelectedIndex != -1 || btnAdd.Text == "Add");
        ctrlUpload.Visible = (dvCommands.Visible && grdDesign.SelectedIndex != -1 || btnAdd.Text == "Add");
    }

    private void ClearUI()
    {
        chkFirstRenewalDate.Checked = false;
        chkSecondRenewalDate.Checked = false;
        chkThirdRenewalDate.Checked = false;
        lblFirstRenewalDateShamsi.Text = string.Empty;
        lblSecondRenewalDateShamsi.Text = string.Empty;
        lblThirdRenewalDateShamsi.Text = string.Empty;

        drpAgent.SelectedIndex = -1;
        drpAgent2.SelectedIndex = -1;
        ClsCommon.FillDateInControls(string.Empty, txtAppDateYear, txtAppDateMonth, txtAppDateDay);
        lblAppDateG.Text = string.Empty;
        drpApplicant.SelectedIndex = -1;
        txtAppNo.Text = string.Empty;
        txtClass.Text = string.Empty;
        txtFillingNo.Text = string.Empty;
        lblFirstRenewalDate.Text = string.Empty;
        txtID.Text = string.Empty;
        txtAdditionalGoodsClasses.Text = string.Empty;
        lblLastCheckedDateValue.Text = string.Empty;
        imgPicture.ImageUrl = string.Empty;
        txtPowerOfAttorney.Text = string.Empty;
        ClsCommon.FillDateInControls(string.Empty, txtRegDateYear, txtRegDateMonth, txtRegDateDay);
        lblRegDateG.Text = string.Empty;
        txtRegNo.Text = string.Empty;
        lblSecondRenewalDate.Text = string.Empty;
        drpStatus.SelectedIndex = -1;
        lblThirdRenewalDate.Text = string.Empty;
        txtYear.Text = string.Empty;
        txtComment.Text = string.Empty;
        txtKCommission.Text = string.Empty;
    }

    private ClsDesign GetDesignFromUI(bool blnForInsert)
    {
        ClsDesign objDesign;

        objDesign = new ClsDesign();

        objDesign.AgentID = int.Parse(drpAgent.SelectedValue);
        objDesign.Agent2ID = int.Parse(drpAgent2.SelectedValue);
        objDesign.AppDate =
            ClsCommon.GetDateFromControls(txtAppDateYear, txtAppDateMonth, txtAppDateDay);
        objDesign.ApplicantID = int.Parse(drpApplicant.SelectedValue);
        objDesign.AppNumber = txtAppNo.Text.Trim();
        objDesign.AdditionalGoodsClassesNumber = txtAdditionalGoodsClasses.Text.Trim();
        objDesign.Comment = txtComment.Text.Trim();
        objDesign.KCommission = txtKCommission.Text.Trim();
        objDesign.Class = txtClass.Text.Trim();
        objDesign.FillingNumber = long.Parse(txtFillingNo.Text);
        objDesign.FirstRenewalDate = chkFirstRenewalDate.Checked;
        if (!blnForInsert)
            objDesign.ID = long.Parse(txtID.Text);
        objDesign.LastDateChecked = string.Format("{0:yyyy/MM/dd}", DateTime.Now);

        if (blnForInsert || mobjPostedFile != null)
        {
            // Remove the original image file if exists.
            if (!blnForInsert && !string.IsNullOrEmpty(imgPicture.ImageUrl.Trim()))
            {
                RemoveOriginalPicture(imgPicture.ImageUrl);
            }

            if (mobjPostedFile != null)
                objDesign.Picture = mobjCommon.UploadPicture(ref mobjPostedFile, Server);
            else
                objDesign.Picture = string.Empty;
        }
        else
            objDesign.Picture = imgPicture.ImageUrl;

        objDesign.PowerOfAttorney =
            (!string.IsNullOrEmpty(txtPowerOfAttorney.Text.Trim())) ? long.Parse(txtPowerOfAttorney.Text) : 0;

        objDesign.RegDate =
            ClsCommon.GetDateFromControls(txtRegDateYear, txtRegDateMonth, txtRegDateDay);
        objDesign.RegNumber = txtRegNo.Text.Trim();
        objDesign.SecondRenewalDate = chkSecondRenewalDate.Checked;
        objDesign.StatusID = int.Parse(drpStatus.SelectedValue);
        objDesign.ThirdRenewalDate = chkThirdRenewalDate.Checked;
        objDesign.TradeMark = string.Empty;
        objDesign.Year =
            (!string.IsNullOrEmpty(txtYear.Text)) ? int.Parse(txtYear.Text) : 0;

        mobjPostedFile = null;

        return objDesign;
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
                                  "An error has been occurred during removing the related picture to original design.",
                                  ex);
        }
    }

    #endregion

}
