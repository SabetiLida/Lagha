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
using Laghaee.DataAccess;

namespace Laghaee.WebSite
{
    public partial class LetterContent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClsAgentLettersDataAccessLogic mObjDataAccess = new ClsAgentLettersDataAccessLogic();
            Response.Write(mObjDataAccess.GetLetterContent(Convert.ToInt32(Request["Id"])));
        }
    }
}
