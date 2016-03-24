using System;
using System.Data;
using System.Configuration;
using System.Web;
/*using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
*/
/// <summary>
/// Summary description for ClsUser
/// </summary>
public class ClsUser
{
    private string mstrName;
    private string mstrEmailAddress;
    private int mlUserID;
    private bool mblnIsAdmin;
    private string mstrPassword;
    private bool mblnHasLetterAccess;
     private bool mblnHasTradeMarkAccess;
     private bool mblnHasPatentAccess;
     private bool mblnHasAgentAccess;
    private bool mblnHasApplicantAccess;
        private bool mblnHasDesignAccess;
    private string mstrFirstName;
    private string mstrLastName;
    private bool mblnHasAttachmentAccess;



	public ClsUser()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public bool IsAdmin
    {
        get
        {
            return mblnIsAdmin;
        }
        set
        {
            mblnIsAdmin = value;
        }
    }

    public int UserID
    {
        get
        {
            return mlUserID;
        }
        set
        {
            mlUserID = value;
        }
    }

    public string Name
    {
        get
        {
            return mstrName;
        }
        set
        {
            mstrName = value;
        }
    }
    public string FirstName
    {
        get
        {
            return mstrFirstName;
        }
        set
        {
            mstrFirstName = value;
        }
    }
    public string LastName
    {
        get
        {
            return mstrLastName;
        }
        set
        {
            mstrLastName = value;
        }
    }
    public string Password
    {
        get{return mstrPassword;}
        set { mstrPassword = value; }
    }

    public string EmailAddress
    {
        get
        {
            return mstrEmailAddress;
        }
        set
        {
            mstrEmailAddress = value;
        }
    }
        public bool  HasLetterAccess
        {
            get
            {
                return mblnHasLetterAccess;
            }
            set 
            {
                mblnHasLetterAccess = value;
            }
        }
    public bool HasAttachmentAccess
    {
        get
        {
            return mblnHasAttachmentAccess;
        }
        set
        {
            mblnHasAttachmentAccess = value;
        }
    }
    public bool HasTradeMarkAccess
    {
        get
        {
            return mblnHasTradeMarkAccess;
        }
        set
        {
            mblnHasTradeMarkAccess = value;
        }
    }
    public bool HasPatentAccess
    {
        get
        {
            return mblnHasPatentAccess;
        }
        set
        {
            mblnHasPatentAccess = value;
        }
    }
    public bool HasAgentAccess
    {
        get
        {
            return mblnHasAgentAccess;
        }
        set
        {
            mblnHasAgentAccess = value;
        }
    }
    public bool HasApplicantAccess
    {
        get
        {
            return mblnHasApplicantAccess;
        }
        set
        {
            mblnHasApplicantAccess = value;
        }
    }
    public bool HasDesignAccess
    {
        get
        {
            return mblnHasDesignAccess;
        }
        set
        {
            mblnHasDesignAccess = value;
        }
    }
}
