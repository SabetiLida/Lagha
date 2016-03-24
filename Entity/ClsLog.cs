using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Laghaee.Entity
{
    public class ClsLog
    {
        #region "Memeber Variables"

        private int miTransactionCode;
        private int miUserID;
        private string mstrDateTime;
        private int miTransactionType;
        private string mstrComment;
        private string mstrMachineName;
       
        #endregion

        public int TransactionCode
        {
            get { return miTransactionCode; }
            set { miTransactionCode = value ; }
        }
        public int UserID
        {
            get { return miUserID; }
            set { miUserID = value; }
        }
        public string DateTime
        {
            get { return mstrDateTime; }
            set { mstrDateTime = value; }
        }
        public int TransactionType
        {
            get { return miTransactionType; }
            set { miTransactionType = value; }
        }
        public string Comment
        {
            get { return mstrComment; }
            set { mstrComment = value; }
        }
        public string MachineName
        {
            get { return mstrMachineName; }
            set { mstrMachineName = value; }
        }
    }
}
