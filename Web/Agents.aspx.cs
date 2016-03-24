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
using Laghaee.DataAccess;

public partial class Agents : System.Web.UI.Page
{
    private const int ID_Index = 0;
    private const int Name_Index = 1;

    ClsAgentDataAccessLogic mObjDataAccess;
    static private int miCurrentPageIndex = 1;
    private ClsUserDataAccessLogic mObjUserDataAccessLogic;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            mObjUserDataAccessLogic = new ClsUserDataAccessLogic();
            //divOperations.Visible = ClsCommon.AuthenticatePage(this, false);
            //divOperations.Visible = ClsLoginManager.GetUserAccessOnPage(this);
            //grdAgentList.Columns[2].Visible=divOperations.Visible;

            dvCommands.Visible = ClsCommon.AuthenticatePage(this, false);
            dvCommands.Visible = ClsLoginManager.GetUserAccessOnPage(this);
            

            mObjDataAccess = new ClsAgentDataAccessLogic();
            if (!IsPostBack)
            {
                divDetail.Visible = false;
                btnRemove.CausesValidation = false;

                FillAgents();
                SetButtonsActivity();
            }
            
        }
        catch(Exception ex)
        {
            divDetail.Visible = false;
            divGrid.Visible = false;
            //divOperations.Visible = false;
            dvCommands.Visible = false;
            ClsCommon.ShowMessage(this, MessageType.Error,
                                  "An error has been occurred during loading 'Agent' form.", 
                                  ex);
        }
    }

    protected void grdAgentList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdAgentList.PageIndex = e.NewPageIndex;
            FillAgents();
            miCurrentPageIndex = e.NewPageIndex;
        }
        catch (Exception ex)
        {
            ClsCommon.ShowMessage(this, MessageType.Error, 
                                  "Failed to change current page.",
                                  ex);
        }
    }

    protected void grdAgentList_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ClsAgent objAgent = mObjDataAccess.GetAgent((int)grdAgentList.SelectedValue );

            if (objAgent == null) return;
            // This should be filled first because of the further operations are
            // based on it.
            txtID.Text = objAgent.ID.ToString();

            txtAgentName.Text = objAgent.AgentName;
            
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
                                  "Failed to load related info to the selected agent.",
                                  ex);
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsValid)
                return;

            ClsAgent objAgent = GetAgentFromUI(false);

            mObjDataAccess.Update(objAgent, false,this);
            FillAgents();
            grdAgentList.SelectedIndex = -1;
            SetButtonsActivity();
            divDetail.Visible = false;

            if (grdAgentList.PageCount >= miCurrentPageIndex)
                grdAgentList.PageIndex = miCurrentPageIndex;
        }
        catch (Exception ex)
        {
            ClsCommon.ShowMessage(this, MessageType.Error, 
                                  "An error has been occurred during updating the specified agent.",
                                  ex);
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            ClsAgent objAgent;

            if (btnAdd.Text == "Add")
            {
                if (!Page.IsValid)
                    return;

                objAgent = GetAgentFromUI(true);

                mObjDataAccess.Insert(objAgent, false,this);

                FillAgents();

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
                                  "an error has been occurred during adding the specified agent.",
                                  ex);
        }
    }

    protected void btnRemove_Click(object sender, EventArgs e)
    {
        try
        {
            ClsAgent objAgent;

            objAgent = GetAgentFromUI(false);
            mObjDataAccess.Delete(objAgent, false,this);

            grdAgentList.SelectedIndex = -1;

            FillAgents();

            SetButtonsActivity();

            divDetail.Visible = false;
        }
        catch (Exception ex)
        {
            ClsCommon.ShowMessage(this, MessageType.Error, 
                                  "An error occurred during removing the selected agent.",
                                  ex);
        }
    }

    protected void ctrlAgentNameExistanceValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            long lCurrentAgentID = 0;

            if (txtID.Text != string.Empty)
            {
                lCurrentAgentID = long.Parse(txtID.Text);
            }

            args.IsValid = !mObjDataAccess.IsAgentNameExists(args.Value, lCurrentAgentID);
        }
        catch 
        {
            args.IsValid = false;
        }
    }

    private void ClearUI()
    {
        txtID.Text = string.Empty;
        txtAgentName.Text = string.Empty;
    }

    private void FillAgents()
    {
     try
        {
            grdAgentList.DataSource = mObjDataAccess.GetAgentsForPreview();
            grdAgentList.DataBind();

            divGrid.Visible = (grdAgentList.Rows.Count > 0);

        }
        catch (Exception ex)
        {
            ClsCommon.ShowMessage(this, MessageType.Error, 
                                  "Failed to get list of available agents from datebase.",
                                  ex);
        }
    }
    
    private ClsAgent GetAgentFromUI(bool blnForInsert)
    {
        ClsAgent objAgent;

        objAgent = new ClsAgent();

        objAgent.AgentName = txtAgentName.Text;
        if (!blnForInsert)
            objAgent.ID = long.Parse(txtID.Text);

        return objAgent;
    }

    private void SetButtonsActivity()
    {
        btnUpdate.Enabled = (grdAgentList.SelectedIndex != -1 && btnAdd.Text == "New");
        btnRemove.Enabled = btnUpdate.Enabled;
    }
}

