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


namespace Laghaee.WebSite
{
    public partial class User : System.Web.UI.Page
    {
        private ClsUserDataAccessLogic mObjDataAccess;

        private ClsCommon mobjCommon;
        static private bool mblnSortAscending = false;
        static private int miCurrentPageIndex = 1;
        static private string mstrCurrentSortExpression = ClsDBConstants.User_Col_FirstName;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                divOperations.Visible = ClsCommon.AuthenticatePage(this, false);
               if (ClsLoginManager.GetUserType(this)!=ClsLoginManager.UserType.Admin)
               {
                   divDetail.Visible = false;
                   divGrid.Visible = false;
                   divOperations.Visible = false;
                   ClsCommon.ShowMessage(this, MessageType.Error, "You have not access to 'User' form.",null);
                   return;
               }
                mobjCommon = new ClsCommon();
                mObjDataAccess = new ClsUserDataAccessLogic();
                if (!IsPostBack)
                {
                    
                    divDetail.Visible = false;
                    BtnRemove.CausesValidation = false;
                    divGrid.Visible = true;
                    FillAllUsersInGrid();
                    SetButtonsActivity();
                    
                }
            }
            catch (Exception ex)
            {
                divDetail.Visible = false;
                divGrid.Visible = false;
                divOperations.Visible = false;
                ClsCommon.ShowMessage(this, MessageType.Error, "An error has been occurred during loading 'User' form.", ex);
            }
        }
        private void SetButtonsActivity()
        {
            BtnUpdate.Enabled = (grdUser.SelectedIndex != -1 && BtnNew.Text == "New");
            BtnRemove.Enabled = BtnUpdate.Enabled;
        }
        private void FillAllUsersInGrid()
        {
            try
            {
                FillDataInGrid(mObjDataAccess.GetAllUsers(mstrCurrentSortExpression, mblnSortAscending));
            }
            catch (Exception ex)
            {
                ClsCommon.ShowMessage(this, MessageType.Error, "Failed to get available User from database.", ex);
            }
        }
        private void FillDataInGrid(DataTable dtUsers)
        {
            grdUser.DataSource = dtUsers;
            grdUser.DataBind();

            divGrid.Visible = (grdUser.Rows.Count > 0);
        }
        protected void BtnNew_Click(object sender, EventArgs e)
        {

            try
            {
                ClsUser objUsers;

                if (BtnNew.Text == "Add")
                {
                    if (!Page.IsValid)
                        return;
                    objUsers = GetUsersFromUI(true);


                    mObjDataAccess.Insert(objUsers, false,this);
                    FillAllUsersInGrid();

                    BtnNew.Text = "New";
                    BtnNew.CausesValidation = false;
                    divDetail.Visible = false;
                }
                else
                {
                    ClearUI();
                    BtnNew.Text = "Add";
                    BtnNew.CausesValidation = true;
                    divDetail.Visible = true;

                }

                SetButtonsActivity();

            }
            catch (Exception ex)
            {
                ClsCommon.ShowMessage(this, MessageType.Error, "An error occurred during Adding the specified User.", ex);
            }

        }
        private ClsUser GetUsersFromUI(bool blnForInsert)
        {
            ClsUser objUsers;
            objUsers = new ClsUser();
            objUsers.Name  = txtUserName.Text;
            objUsers.Password = txtPassword.Text;
            objUsers.FirstName = txtFirstName.Text;
            objUsers.LastName = txtLastName.Text;
            objUsers.EmailAddress = txtEmailAddress.Text;
            objUsers.HasAgentAccess = AccessPageCheckBoxList.Items.FindByValue("HasAgentAccess").Selected ;
            objUsers.HasPatentAccess = AccessPageCheckBoxList.Items.FindByValue("HasPatentAccess").Selected ;
            objUsers.HasDesignAccess  = AccessPageCheckBoxList.Items.FindByValue("HasDesignAccess").Selected ;
            objUsers.HasApplicantAccess = AccessPageCheckBoxList.Items.FindByValue("HasApplicantAccess").Selected ;
            objUsers.HasTradeMarkAccess = AccessPageCheckBoxList.Items.FindByValue("HasTradeMarkAccess").Selected ;
            objUsers.HasLetterAccess = AccessPageCheckBoxList.Items.FindByValue("HasLetterAccess").Selected;
            objUsers.HasAttachmentAccess = AccessPageCheckBoxList.Items.FindByValue("HasAttachmentAccess").Selected;
            objUsers.IsAdmin = AccessPageCheckBoxList.Items.FindByValue("IsAdmin").Selected ;
           if (!blnForInsert)
               objUsers.UserID = int.Parse(txtID.Text);
            return objUsers;

        }
        private void ClearUI()
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmailAddress.Text = "";
            AccessPageCheckBoxList.Items.FindByValue("HasAgentAccess").Selected = false;
            AccessPageCheckBoxList.Items.FindByValue("HasPatentAccess").Selected=false ;
            AccessPageCheckBoxList.Items.FindByValue("HasDesignAccess").Selected=false ;
            AccessPageCheckBoxList.Items.FindByValue("HasApplicantAccess").Selected = false;
            AccessPageCheckBoxList.Items.FindByValue("HasTradeMarkAccess").Selected = false;
            AccessPageCheckBoxList.Items.FindByValue("HasLetterAccess").Selected = false;
            AccessPageCheckBoxList.Items.FindByValue("HasAttachmentAccess").Selected = false;
            AccessPageCheckBoxList.Items.FindByValue("IsAdmin").Selected = false;
        }
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsValid)
                    return;

                ClsUser objUsers = GetUsersFromUI(false);

                mObjDataAccess.Update(objUsers, false,this);
                FillAllUsersInGrid();
                grdUser.SelectedIndex = -1;
                SetButtonsActivity();
                divDetail.Visible = false;

                if (grdUser.PageCount >= miCurrentPageIndex)
                    grdUser.PageIndex = miCurrentPageIndex;
            }
            catch (Exception ex)
            {
                ClsCommon.ShowMessage(this, MessageType.Error, "An error occurred during Updating the selected User.", ex);
            }
        }
        protected void BtnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                ClsUser objUsers;

                objUsers = GetUsersFromUI(false);
                mObjDataAccess.Delete(objUsers, false,this);

                grdUser.SelectedIndex = -1;

                FillAllUsersInGrid();

                SetButtonsActivity();

                divDetail.Visible = false;
            }
            catch (Exception ex)
            {
                ClsCommon.ShowMessage(this, MessageType.Error, "An error occurred during Removing the selected User.", ex);
            }

        }
        protected void grdUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ClsUser objUsers = mObjDataAccess.GetUserByUserID((int)grdUser.SelectedValue);

                if (objUsers == null) return;

                // This should be filled first because of the further operations are
                // based on it.
                txtID.Text = objUsers.UserID.ToString();
                divDetail.Visible = true;

                if (BtnNew.Text == "Add")
                {
                    BtnNew.Text = "New";
                    BtnNew.CausesValidation = false;
                }

                SetButtonsActivity();

                txtUserName.Text =objUsers.Name;
                txtPassword.Text = objUsers.Password;
                txtFirstName.Text = objUsers.FirstName;
                txtLastName.Text = objUsers.LastName;
                txtID.Text = objUsers.UserID.ToString();
                txtEmailAddress.Text = objUsers.EmailAddress;
                AccessPageCheckBoxList.Items.FindByValue("HasAgentAccess").Selected = objUsers.HasAgentAccess;
                AccessPageCheckBoxList.Items.FindByValue("HasApplicantAccess").Selected = objUsers.HasApplicantAccess;
                AccessPageCheckBoxList.Items.FindByValue("HasDesignAccess").Selected = objUsers.HasDesignAccess;
                AccessPageCheckBoxList.Items.FindByValue("HasPatentAccess").Selected = objUsers.HasPatentAccess;
                AccessPageCheckBoxList.Items.FindByValue("HasTradeMarkAccess").Selected = objUsers.HasTradeMarkAccess;
                AccessPageCheckBoxList.Items.FindByValue("HasLetterAccess").Selected = objUsers.HasLetterAccess;
                AccessPageCheckBoxList.Items.FindByValue("HasAttachmentAccess").Selected = objUsers.HasAttachmentAccess;
                AccessPageCheckBoxList.Items.FindByValue("IsAdmin").Selected = objUsers.IsAdmin;
            }
            catch (Exception ex) //ArgumentOutOfRange
            {
                ClsCommon.ShowMessage(this, MessageType.Error, "Failed to load related info to the selected user.", ex);
            }
        }
        protected void grdUser_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                switch (e.SortExpression)
                {
                    case ClsDBConstants.User_Col_FirstName:

                        mstrCurrentSortExpression = e.SortExpression;

                        break;
                    case ClsDBConstants.User_Col_LastName:

                        mstrCurrentSortExpression = e.SortExpression;

                        break;
                    default:
                        e.Cancel = true;
                        break;
                }

                if (!e.Cancel)
                    mblnSortAscending = !mblnSortAscending;

               
                    FillAllUsersInGrid();
               
            }
            catch (Exception ex)
            {
                ClsCommon.ShowMessage(this, MessageType.Error,
                                      "An error has been occurred during sorting operation.",
                                      ex);
            }
        }

        protected void grdUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdUser.PageIndex = e.NewPageIndex;
                FillAllUsersInGrid();
                miCurrentPageIndex = e.NewPageIndex;
            }
            catch (Exception ex)
            {
                ClsCommon.ShowMessage(this, MessageType.Error, "Failed to change current page.", ex);
            }

        }
        
    }
}
