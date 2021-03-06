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
using Laghaee.DataAccess;
using Laghaee.Entity;

namespace Laghaee.WebSite
{
    public partial class Attachment : System.Web.UI.Page
    {
        static private int miCurrentPageIndex = 1;

        private ClsLettersFilesDataAccessLogic mObjDataAccess;
        private ClsUserDataAccessLogic mObjUserDataAccessLogic;
        protected void Page_Load(object sender, EventArgs e)
        {
            mObjUserDataAccessLogic = new ClsUserDataAccessLogic();
            divOperations.Visible = ClsLoginManager.GetUserAccessOnPage(this);
           divUpload.Visible = divOperations.Visible;
            gvAttachments.Columns[1].Visible=divOperations.Visible;
            mObjDataAccess = new ClsLettersFilesDataAccessLogic();
            FillAllFiles(Convert.ToInt32(Request["Id"]) );
            SetAttachControls(Laghaee.Common.Enumeration.AttachOpr.AddNew);
        }
      
        protected void BtnOk_Click(object sender, EventArgs e)
        {
            String savePathInDB;
            String savePath;
            FileUpload f;
            ClsAgentLettersDataAccessLogic objClsAgentLettersDataAccessLogic = new ClsAgentLettersDataAccessLogic();

            for (int i = 1; i <= 5; i++)
            {
                f = (FileUpload)Page.FindControl("FileUpload" + i.ToString());
                if (f.HasFile)
                {
                    String initialPath = ConfigurationManager.AppSettings.Get("PhysicalAgentPath").ToLower();
                    String fileName = f.FileName;
                    String extension = fileName.Substring(fileName.IndexOf('.') + 1, (fileName.Length - fileName.IndexOf('.')) - 1);
                    if ((initialPath.LastIndexOf('\\')==initialPath.Length-1))
                     initialPath = initialPath.Remove(initialPath.Length-1);
                    if (initialPath.Substring(initialPath.LastIndexOf('\\') + 1, (initialPath.Length - initialPath.LastIndexOf('\\')) - 1).Equals("agents"))
                    {
                        savePath = initialPath + "\\" + Request["AgentName"];
                        savePathInDB = "\\" + Request["AgentName"];
                        if (System.IO.Directory.Exists(savePath))
                        {
                            savePath = savePath + "\\" + fileName;
                            savePathInDB = savePathInDB + "\\" + fileName;
                            if (System.IO.File.Exists(savePath))
                            {
                                lblAttachMessage.Text += ".File " + f.FileName + " already exist" + "<br/>";
                                lblAttachMessage.Visible = true;
                            }
                            else
                            {
                                try
                                {
                                    f.SaveAs(savePath);
                                    InsertAgentsFile(Convert.ToInt32(Request["Id"]), extension, savePathInDB, fileName);

                                }
                                catch (Exception ex)
                                {
                                    CheckStatus(savePath);
                                    lblAttachMessage.Text += ex.Message.ToString();
                                    lblAttachMessage.Visible = true;
                                    this.Focus();
                                }
                            }
                        }
                        else
                        {
                            System.IO.Directory.CreateDirectory(savePath);
                            savePath = savePath + "\\" + fileName;
                            savePathInDB = savePathInDB + "\\" + fileName;
                            try
                            {
                                f.SaveAs(savePath);
                                InsertAgentsFile(Convert.ToInt32(Request["Id"]), extension, savePathInDB,fileName);

                            }
                            catch (Exception ex)
                            {
                                CheckStatus(savePath);
                                lblAttachMessage.Text +=ex.Message.ToString();
                                lblAttachMessage.Visible = true;
                                this.Focus();
                            }
                        }
                    }
                    else
                    {
                        savePath = initialPath + "\\Agents\\" + Request["AgentName"];
                        savePathInDB ="\\"+ Request["AgentName"];
                        if (System.IO.Directory.Exists(savePath))
                        {
                            savePath = savePath + "\\" + fileName;
                            savePathInDB = savePathInDB + "\\" + fileName;
                            try
                            {
                                f.SaveAs(savePath);
                                InsertAgentsFile(Convert.ToInt32(Request["Id"]), extension, savePathInDB, fileName);

                            }
                            catch (Exception ex)
                            {
                                CheckStatus(savePath);
                                lblAttachMessage.Text += ex.Message.ToString();
                                lblAttachMessage.Visible = true;
                                this.Focus();
                            }
                        }
                        else
                        {
                            System.IO.Directory.CreateDirectory(savePath);
                            savePath = savePath + "\\" + fileName;
                            savePathInDB = savePathInDB + "\\" + fileName;
                            try
                            {
                                f.SaveAs(savePath);
                                InsertAgentsFile(Convert.ToInt32(Request["Id"]), extension, savePathInDB, fileName);

                            }
                            catch (Exception ex)
                            {
                                CheckStatus(savePath);
                                lblAttachMessage.Text += ex.Message.ToString();
                                lblAttachMessage.Visible = true;
                                this.Focus();
                            }
                        }
                    }
                }
            }

            FillAllFiles(Convert.ToInt32(Request["Id"]));

        }

        public void InsertAgentsFile(int agentLetterID,string extension,string letterPath,string fileName)
        {
            ClsLettersFiles objLettersFiles = new ClsLettersFiles(agentLetterID,letterPath,extension,fileName);
            ClsLettersFilesDataAccessLogic RequestAttachs = new ClsLettersFilesDataAccessLogic();
            RequestAttachs.Insert(objLettersFiles, true,this);

        }
        public void CheckStatus(string savepath)
        {
            if (System.IO.Directory.Exists(savepath))
            {
                System.IO.Directory.Delete(savepath);
            }
        }
        private void FillAllFiles(int  LettersAttachId)
        {
            try
            {
                FillDataInGrid(mObjDataAccess.GetAllFiles(LettersAttachId));
            }
            catch (Exception ex)
            {
                lblAttachMessage.Text += ex.Message.ToString();
                lblAttachMessage.Visible = true;
                this.Focus();
            }
        }
        private void FillDataInGrid(DataTable dtAgentFiles)
        {
            gvAttachments.DataSource = dtAgentFiles;
            gvAttachments.DataBind();
            gvAttachments.Visible = (dtAgentFiles.Rows.Count > 0);
        }
        
        protected void gvAttachments_RowCommand(object sender, GridViewCommandEventArgs e)
        {



            if (gvAttachments.SelectedValue != null)
            {
                lblAttachMessage.Visible = false;

                if (e.CommandName == "Del")
                {
                    SetAttachControls(Laghaee.Common.Enumeration.AttachOpr.DeleteSelected);

                }  
                
            }
            //else
            //{
            //    //lblAttachMessage.Text = ".First you must select a row"+"<br/>";
            //    //lblAttachMessage.Visible = true;
            //    //this.Focus();
            //}


        }
        public void SetAttachControls(Laghaee.Common.Enumeration.AttachOpr DelStatus)
        {
            switch (DelStatus)
            {
                case Laghaee.Common.Enumeration.AttachOpr.DeleteAll:
                    break;
                case Laghaee.Common.Enumeration.AttachOpr.DeleteSelected:
                    lblAttachMessage.Text = "If you confirm,selected file will be deleted" + "<br/>";
                    lblAttachMessage.Visible = true;
                    btnOkDelAttach.Visible = true;
                    btnCancelAttach.Visible = true;
                    break;
                case Laghaee.Common.Enumeration.AttachOpr.AddNew:
                    lblAttachMessage.Visible = false;
                    btnOkDelAttach.Visible = false;
                    btnCancelAttach.Visible = false;
                    break;
                default:
                    break;
            }
        }

        protected void btnOkDelAttach_Click(object sender, EventArgs e)
        {
            try
            {
                String initialPath = ConfigurationManager.AppSettings.Get("PhysicalAgentPath").ToLower();
                if (initialPath.Substring(initialPath.LastIndexOf('\\') + 1, (initialPath.Length - initialPath.LastIndexOf('\\')) - 1).Equals("agents"))
                    System.IO.File.Delete(initialPath + mObjDataAccess.GetLetterFilePathByLetterId(Convert.ToInt32(Request["Id"])));

                else
                { System.IO.File.Delete(initialPath + "\\Agents" + mObjDataAccess.GetLetterFilePathByLetterId(Convert.ToInt32(Request["Id"]))); }

                    mObjDataAccess.Delete(Convert.ToInt32(gvAttachments.SelectedValue), true,this);
                    lblAttachMessage.Visible = false;
                    FillAllFiles(Convert.ToInt32(Request["Id"]));

            }
            catch (Exception ex)
            {
                lblAttachMessage.Text = ex.Message.ToString();
            }

        
        }
       
        protected void btnCancelAttach_Click(object sender, EventArgs e)
        {
            SetAttachControls(Laghaee.Common.Enumeration.AttachOpr.AddNew);
        }

        protected void gvAttachments_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvAttachments.PageIndex = e.NewPageIndex;

                FillAllFiles(Convert.ToInt32(Request["Id"]));

                miCurrentPageIndex = e.NewPageIndex;
            }
            catch (Exception ex)
            {

            }
        }
        public object  GetFilePath(object attachmentid)
        {
            //return ConfigurationManager.AppSettings.Get("NavigateAttachment");
            return ConfigurationManager.AppSettings.Get("NavigateAttachment")+mObjDataAccess.GetLetterFilePathByAttachmentId(Convert.ToInt32(attachmentid));
        }
        public string GetAgentName()
        { return Request["AgentName"]; }

        protected void gvAttachments_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        
      
    }
}
