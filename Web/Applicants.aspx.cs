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
using Laghaee.Common;
using Laghaee.Entity;
using Laghaee.DataAccess;
using Laghaee.DataAccessLayer;

public partial class Applicants : System.Web.UI.Page
{
    private const int ID_Index = 0;
    private const int Name_Index = 1;
    private ClsUserDataAccessLogic mObjUserDataAccessLogic;
    ClsApplicantDataAccessLogic mObjDataAccess;
    static private int miCurrentPageIndex = 1;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            mObjUserDataAccessLogic = new ClsUserDataAccessLogic();
            //divOperations.Visible = ClsCommon.AuthenticatePage(this, false);
            //divOperations.Visible = ClsLoginManager.GetUserAccessOnPage(this);
            //grdApplicantList.Columns[2].Visible=divOperations.Visible;

            dvCommands.Visible = ClsCommon.AuthenticatePage(this, false);
            dvCommands.Visible = ClsLoginManager.GetUserAccessOnPage(this);

            mObjDataAccess = new ClsApplicantDataAccessLogic();
            if (!IsPostBack)
            {
                divDetail.Visible = false;
                btnRemove.CausesValidation = false;

                FillApplicants();
                SetButtonsActivity();
            }
        }
        catch (Exception ex)
        {
            divDetail.Visible = false;
            divGrid.Visible = false;
            //divOperations.Visible = false;
            dvCommands.Visible = false;
            ClsCommon.ShowMessage(this,  MessageType.Error, 
                                  "An error occurred during loading 'Applicant' form.",
                                  ex);
        }
    }

    protected void grdApplicantList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdApplicantList.PageIndex = e.NewPageIndex;
            FillApplicants();
            miCurrentPageIndex = e.NewPageIndex;
        }
        catch (Exception ex)
        {
            ClsCommon.ShowMessage(this, MessageType.Error, 
                                  "Failed to change current page.",
                                  ex);
        }
    }

    protected void grdApplicantList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ClsApplicants objApplicants = 
                mObjDataAccess.GetApplicant((int)grdApplicantList.SelectedValue);

            if (objApplicants == null) return;

            // This should be filled first because of the further operations are
            // based on it.
            txtID.Text = objApplicants.ID.ToString();

            txtApplicantName.Text = objApplicants.ApplicantName;
            

            if (btnAdd.Text == "Add")
            {
                btnAdd.Text = "New";
                btnAdd.CausesValidation = false;
            }
            divDetail.Visible = true;

            SetButtonsActivity();
        }
        catch (Exception ex)
        {
            ClsCommon.ShowMessage(this, MessageType.Error, 
                "Failed to show related info to the selected applicant.",
                ex);
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsValid)
                return;

            ClsApplicants objApplicants = GetApplicantsFromUI(false);

            mObjDataAccess.Update(objApplicants, false,this);
            FillApplicants();
            grdApplicantList.SelectedIndex = -1;
            SetButtonsActivity();
            divDetail.Visible = false;

            if (grdApplicantList.PageCount >= miCurrentPageIndex)
                grdApplicantList.PageIndex = miCurrentPageIndex;
        }
        catch (Exception ex)
        {
            ClsCommon.ShowMessage(this, MessageType.Error, 
                                  "An error has been occurred during updating selected applicant",
                                  ex);
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            ClsApplicants objApplicants;

            if (btnAdd.Text == "Add")
            {
                if (!Page.IsValid)
                    return;

                objApplicants = GetApplicantsFromUI(true);

                mObjDataAccess.Insert(objApplicants, false,this);

                FillApplicants();

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
                                  "An error occurred during adding the specified applicant.",
                                  ex);
        }
    }

    protected void btnRemove_Click(object sender, EventArgs e)
    {
        try
        {
            ClsApplicants objApplicants;

            objApplicants = GetApplicantsFromUI(false);
            mObjDataAccess.Delete(objApplicants, false,this);

            grdApplicantList.SelectedIndex = -1;

            FillApplicants();

            SetButtonsActivity();

            divDetail.Visible = false;
        }
        catch (Exception ex)
        {
            ClsCommon.ShowMessage(this, MessageType.Error, 
                                  "An error has been occurred during removing the selected applicant.",
                                  ex);
        }
    }

    protected void ctrlApplicantNameExistanceValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            long lCurrentAgentID = 0;

            if (txtID.Text != string.Empty)
            {
                lCurrentAgentID = long.Parse(txtID.Text);
            }

            args.IsValid = !mObjDataAccess.IsApplicantNameExists(args.Value, lCurrentAgentID);
        }
        catch
        {
            args.IsValid = false;
        }
    }

    private void ClearUI()
    {
        txtID.Text = string.Empty;
        txtApplicantName.Text = string.Empty;
    }

    private void FillApplicants()
    {
        try
        {
            grdApplicantList.DataSource = mObjDataAccess.GetApplicantsForPreview();
            grdApplicantList.DataBind();

            divGrid.Visible = (grdApplicantList.Rows.Count > 0);

        }
        catch (Exception ex)
        {
            ClsCommon.ShowMessage(this, MessageType.Error, 
                                  "Failed to get the available applicants from datebase.",
                                  ex);
        }
    }

    private ClsApplicants GetApplicantsFromUI(bool blnForInsert)
    {
        ClsApplicants objApplicants;

        objApplicants = new ClsApplicants();

        objApplicants.ApplicantName = txtApplicantName.Text;
        if (!blnForInsert)
            objApplicants.ID = long.Parse(txtID.Text);

        return objApplicants;
    }

    private void SetButtonsActivity()
    {
        btnUpdate.Enabled = (grdApplicantList.SelectedIndex != -1 && btnAdd.Text == "New");
        btnRemove.Enabled = btnUpdate.Enabled;
    }    
}

