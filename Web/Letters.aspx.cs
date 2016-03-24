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
    public partial class Letters : System.Web.UI.Page
    {
        private ClsAgentLettersDataAccessLogic mObjDataAccess;
        private ClsUserDataAccessLogic mObjUserDataAccessLogic;
        private ClsCommon mobjCommon;
        static private bool mblnSortAscending = false;
        static private bool mblnIsSearchMode = false;
        static private string mstrCurrentSortExpression = ClsDBConstants.AgentLetters_Col_LetterDate;
        static private int miCurrentPageIndex = 1;


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                mObjUserDataAccessLogic = new ClsUserDataAccessLogic();
                //divOperations.Visible = ClsCommon.AuthenticatePage(this, false);
                //divOperations.Visible = ClsLoginManager.GetUserAccessOnPage(this);
                //grdAgentLetter.Columns[10].Visible=divOperations.Visible;

                dvCommands.Visible = ClsCommon.AuthenticatePage(this, false);
                dvCommands.Visible = ClsLoginManager.GetUserAccessOnPage(this);
                

                mobjCommon = new ClsCommon();
                mObjDataAccess = new ClsAgentLettersDataAccessLogic();      
                if (!IsPostBack)
                {
                   
                        divDetail.Visible = false;
                        BtnRemove.CausesValidation = false;
                        divGrid.Visible = true;

                        mobjCommon.FillAgents(drpAgent);
                        mobjCommon.FillAgents(drpSrchAgent);
                        FillAllLetters();
                        SetButtonsActivity();
                   
                }
            }
            catch (Exception ex)
            {
                divDetail.Visible = false;
                divGrid.Visible = false;
                //divOperations.Visible = false;
                dvCommands.Visible = false;
                ClsCommon.ShowMessage(this, MessageType.Error, "An error has been occurred during loading 'Letter' form.", ex);
            }
        }

        protected void BtnNew_Click(object sender, EventArgs e)
        {

            try
            {
                ClsAgentLetters objAgentLetters;

                if (BtnNew.Text == "Add")
                {
                    if (!Page.IsValid)
                        return;
                    objAgentLetters = GetAgentLettersFromUI(true);

                    
                    mObjDataAccess.Insert(objAgentLetters, false,this);
                    FillAllLetters();

                    BtnNew.Text = "New";
                    BtnNew.CausesValidation = false;
                    divDetail.Visible = false;
                }
                else
                {
                    ClearUI();
                    BtnNew.Text = "Add";
                    drpAgent.SelectedIndex = 0;
                    BtnNew.CausesValidation = true;
                    divDetail.Visible = true;

                }

                SetButtonsActivity();

            }
            catch (Exception ex)
            {
                ClsCommon.ShowMessage(this, MessageType.Error, "An error occurred during Adding the specified Letter.", ex);
            }

        }
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsValid)
                    return;
                ClsLettersFilesDataAccessLogic objLetterFilesDataAccessLogic = new ClsLettersFilesDataAccessLogic();
                ClsAgentLetters objAgentLetters = GetAgentLettersFromUI(false);
                //string AgentBeforeUpdate = objLetterFilesDataAccessLogic.GetAllFiles(objAgentLetters.ID).Rows[0]["AgentName"];
                mObjDataAccess.Update(objAgentLetters, false, this);
                //string AgentAfterUpdate = objLetterFilesDataAccessLogic.GetAllFiles(objAgentLetters.ID).Rows[0]["AgentName"];
                //if (AgentBeforeUpdate!=AgentAfterUpdate)
                //{ 
                //  ClsLettersFiles objLetterFiles = new ClsLettersFiles();
                //  objLetterFiles.LetterFilePath = objLetterFilesDataAccessLogic.GetLetterFilePathByLetterId(objAgentLetters.ID);
                //  foreach( DataRow row in objLetterFilesDataAccessLogic.GetAllFiles(objAgentLetters.ID).Rows)
                //  {
                //      objAgentLetters.ID = row["Id"];

                //  }
                //}
                FillAllLetters();
                //grdAgentLetter.SelectedIndex = -1;
                SetButtonsActivity();
                divDetail.Visible = false;

                if (grdAgentLetter.PageCount >= miCurrentPageIndex)
                    grdAgentLetter.PageIndex = miCurrentPageIndex;
            }
            catch (Exception ex)
            {
                ClsCommon.ShowMessage(this, MessageType.Error, "An error occurred during Updating the selected Letter.", ex);
            }
        }

        protected void BtnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                ClsAgentLetters objAgentLetters;

                objAgentLetters = GetAgentLettersFromUI(false);
                mObjDataAccess.Delete(objAgentLetters, false,this);

                // Remove the related picture from server.
                //if (!string.IsNullOrEmpty(objDesign.Picture.Trim()))
                //    RemoveOriginalPicture(objDesign.Picture.Trim());

                //grdAgentLetter.SelectedIndex = -1;

                FillAllLetters();

                SetButtonsActivity();

                divDetail.Visible = false;
            }
            catch (Exception ex)
            {
                ClsCommon.ShowMessage(this, MessageType.Error, "An error occurred during Removing the selected Letter.", ex);
            }


            //try
            //{

            //}
            //catch (Exception ex)
            //{
            //    ClsCommon.ShowMessage(this, MessageType.Error, "An error occurred during Removing the selected Letter.", ex);
            //}

        }
        private void FindFckEditorDatasource()
        {
            ClsUser currentUser;
            currentUser = ClsLoginManager.GetLoggedOnUser(this);


        }
        private ClsAgentLetters GetAgentLettersFromUI(bool blnForInsert)
        {
            ClsAgentLetters objAgentLetters;
            objAgentLetters = new ClsAgentLetters();
            objAgentLetters.RegisterDate = string.Format("{0:yyyy/MM/dd}", ClsCommon.GetNowPersianDate());
            objAgentLetters.AgentID = Convert.ToInt32(Request["AgentId"]);
            objAgentLetters.LetterDate = txtLetterYear.Text + "/" + txtLetterMonth.Text + "/" + txtLetterDay.Text;
            objAgentLetters.LetterName = txtTiltle.Text;
            objAgentLetters.LetterContent = FCKeditor1.Value;
            objAgentLetters.FilingNo = Convert.ToInt64(Request["FillingNo"]);
            objAgentLetters.LetterType = Convert.ToInt32(Request["LetterType"]);
            objAgentLetters.ClientOffice = RedioButtonListClientOfficeLetter.Items.FindByValue("Office").Selected;
            if (!blnForInsert)
                objAgentLetters.ID = int.Parse(txtID.Text);
            return objAgentLetters;

        }
        private void ClearUI()
        {
            drpAgent.SelectedIndex = 0;
            txtTiltle.Text = "";
            txtLetterDay.Text = "";
            txtLetterMonth.Text = "";
            txtLetterYear.Text = "";
            FCKeditor1.Value = "";
            RedioButtonListClientOfficeLetter.Items.FindByValue("Client").Selected = true;
            RedioButtonListClientOfficeLetter.Items.FindByValue("Office").Selected = false;
        }
        private void FillDataInGrid(DataTable dtAgentLetters)
        {
            grdAgentLetter.DataSource = dtAgentLetters;
            grdAgentLetter.DataBind();

            divGrid.Visible = (grdAgentLetter.Rows.Count > 0);
        }
        private void SetButtonsActivity()
        {
            BtnUpdate.Enabled = (grdAgentLetter.SelectedIndex != -1 && BtnNew.Text == "New");
            BtnRemove.Enabled = BtnUpdate.Enabled;
        }
        private void FillAllLetters()
        {
            try
            {
                //FillDataInGrid(mObjDataAccess.GetAllLetters(mstrCurrentSortExpression, mblnSortAscending));
                FillDataInGrid(mObjDataAccess.GetAllLettersBYFillingNo(mstrCurrentSortExpression, mblnSortAscending, Convert.ToInt64(Request["FillingNo"])));
                //mblnIsSearchMode = false;
            }
            catch (Exception ex)
            {
                ClsCommon.ShowMessage(this, MessageType.Error, "Failed to get available letters from database.", ex);
            }
        }

        protected void grdAgentLetter_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ClsAgentLetters objAgentLetters = mObjDataAccess.GetLetter((int)grdAgentLetter.SelectedValue);

                if (objAgentLetters == null) return;

                // This should be filled first because of the further operations are
                // based on it.
                txtID.Text = objAgentLetters.ID.ToString();
                divDetail.Visible = true;

                if (BtnNew.Text == "Add")
                {
                    BtnNew.Text = "New";
                    BtnNew.CausesValidation = false;
                }

                SetButtonsActivity();

                drpAgent.SelectedValue = objAgentLetters.AgentID.ToString();
                txtTiltle.Text =
                   objAgentLetters.LetterName;
                FCKeditor1.Value = objAgentLetters.LetterContent;
                RedioButtonListClientOfficeLetter.Items.FindByValue("Client").Selected = !objAgentLetters.ClientOffice;
                RedioButtonListClientOfficeLetter.Items.FindByValue("Office").Selected = objAgentLetters.ClientOffice;
                ClsCommon.FillDateInControls(objAgentLetters.LetterDate,
                                             txtLetterYear,
                                             txtLetterMonth,
                                             txtLetterDay);


            }
            catch (Exception ex) //ArgumentOutOfRange
            {
                ClsCommon.ShowMessage(this, MessageType.Error, "Failed to load related info to the selected letter.", ex);
            }
        }
        protected void grdAgentLetter_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdAgentLetter.PageIndex = e.NewPageIndex;
                if (mblnIsSearchMode)
                {
                    StartSearch();
                }
                else
                {
                    FillAllLetters();
                }
                miCurrentPageIndex = e.NewPageIndex;
            }
            catch (Exception ex)
            {
                ClsCommon.ShowMessage(this, MessageType.Error, "Failed to change current page.", ex);
            }

        }
        private void StartSearch()
        {
            DataTable dtResult;

            string strLetterDate = (txtSrchLetterYear.Text.Trim() != string.Empty && txtSrchLetterMonth.Text.Trim() != string.Empty && txtSrchLetterDay.Text.Trim() != string.Empty) ? txtSrchLetterYear.Text.Trim() + "/" + txtSrchLetterMonth.Text.Trim() + "/" + txtSrchLetterDay.Text.Trim() : string.Empty;
            string strTitle = txtSrchLetterName.Text.Trim();
            string strAgent = drpSrchAgent.SelectedValue.ToString().Trim();
            dtResult = mObjDataAccess.Search(strLetterDate,
                                             strTitle,
                                             drpAgent.SelectedValue.ToString(),
                                             mstrCurrentSortExpression,
                                             mblnSortAscending);
            FillDataInGrid(dtResult);

            mblnIsSearchMode = true;

            ClsCommon.ShowMessage(this, MessageType.Info, "'" + dtResult.Rows.Count.ToString() + "' Result Found.");
            //ClearSearchKey();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate("Search");
                if (Page.IsValid)
                    StartSearch();
                else
                    // return;
                    ClsCommon.ShowMessage(this.Page, MessageType.Error, "The specified search conditions are not valid.");
            }
            catch (Exception ex)
            {
                ClsCommon.ShowMessage(this, MessageType.Error, "Failed to get search result from database.", ex);
            }
        }
        private void ClearSearchKey()
        {
            txtSrchLetterDay.Text = "";
            txtSrchLetterMonth.Text = "";
            txtSrchLetterYear.Text = "";
            txtSrchLetterName.Text = "";
            drpSrchAgent.SelectedValue = "0";
        }
        protected void ctrlLetterDateValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                string date = txtLetterYear.Text + txtLetterMonth.Text + txtLetterDay.Text;
                if (date == "")
                {
                    ctrlLetterDateValidator.ErrorMessage = "Please enter letter date!";
                    args.IsValid = false;
                }
                else
                    if (RadioButtonListDate.Items.FindByText("Hj").Selected)
                    {
                        ctrlLetterDateValidator.ErrorMessage = "Invalid Date!";
                        args.IsValid = ClsCommon.IsPersianDateValid(txtLetterYear.Text, txtLetterMonth.Text, txtLetterDay.Text);
                    }
                    else
                    {
                        ctrlLetterDateValidator.ErrorMessage = "Invalid Date!";
                        args.IsValid = ClsCommon.IsGregorianDateValid(txtLetterYear.Text, txtLetterMonth.Text, txtLetterDay.Text);
                    }
            }
            catch
            {
                args.IsValid = false;
            }
        }
        protected void CtrlLetterDateSrchControl_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                if (RadioButtonListDate.Items.FindByText("Hj").Selected)
                {
                    ctrlLetterDateValidator.ErrorMessage = "Invalid Date!";
                    args.IsValid = ClsCommon.IsPersianDateValid(txtLetterYear.Text, txtLetterMonth.Text, txtLetterDay.Text);
                }
                else
                {
                    ctrlLetterDateValidator.ErrorMessage = "Invalid Date!";
                    args.IsValid = ClsCommon.IsGregorianDateValid(txtLetterYear.Text, txtLetterMonth.Text, txtLetterDay.Text);
                }

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
                if (drpAgent.SelectedIndex == 0)
                {
                    ctrlLetterDateValidator.ErrorMessage = "Please select specific agent!";
                    args.IsValid = false;
                }
            }
            catch
            {
                args.IsValid = false;
            }
        }

        protected void grdAgentLetter_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                switch (e.SortExpression)
                {
                    case ClsDBConstants.Agent_Col_AgentName:

                        mstrCurrentSortExpression = e.SortExpression;

                        break;
                    case ClsDBConstants.AgentLetters_Col_LetterDate:

                        mstrCurrentSortExpression = e.SortExpression;

                        break;
                    case ClsDBConstants.AgentLetters_Col_LetterName:

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
                    FillAllLetters();
                }
            }
            catch (Exception ex)
            {
                ClsCommon.ShowMessage(this, MessageType.Error,
                                      "An error has been occurred during sorting operaiton.",
                                      ex);
            }
        }
        protected void grdAgentLetter_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // if (grdAgentLetter.SelectedRow != null)
            if (e.CommandName == "ShowLetterContent")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = grdAgentLetter.Rows[index];
                //string k = mObjDataAccess.GetLetterContent(selectedRow.Cells[3].Text, selectedRow.Cells[5].Text, selectedRow.Cells[2].Text);
                //System.Diagnostics.Process.Start(@"C:\Documents and Settings\Ketabati\Desktop\Internet Explorer cannot display the webpage.mht");
               // Server.HtmlEncode(k);
            }

        }
       
        public String  HasAttachment(object Id)
        {
            int letterId =Convert.ToInt32(Id);
            if (mObjDataAccess.GetFileAttachmentByLetterId(letterId).Rows.Count > 0)
                return "~/Images/UI/attachment2.png";
            else
                return "~/Images/UI/add.png";
        }
        public Boolean HasContent(object letterContent)
        {
            
            if (letterContent.ToString() != "")
                return true;
            else
                return false;
        }
        public string GetAgentId()
        { return Request["AgentId"]; }
        public string GetAgentName()
        {return  mObjDataAccess.GetAgentNameByAgentId(Convert.ToInt32(Request["AgentId"])); }

        public String IsClientorOffice(object ClientorOffice)
        {
            
            if ((bool) ClientorOffice)
                return "O";
            else
                return "C";
        }
    }
}