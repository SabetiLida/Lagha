using System;
using System.Data;
using System.Configuration;


/// <summary>
/// Summary description for ClsStatus
/// </summary>
/// 

namespace Laghaee.Entity
{
    public class ClsStatus
    {
        private long mlID;
        private string mstrStatusName;

        public long ID
        {
            get { return mlID; }
            set { mlID = value; }
        }

        public string StatusName
        {
            get { return mstrStatusName; }
            set { mstrStatusName = value; }
        }
    }
}
