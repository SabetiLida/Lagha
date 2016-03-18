using System;
using System.Data;
using System.Configuration;


/// <summary>
/// Summary description for ClsAgent
/// </summary>
/// 

namespace Laghaee.Entity
{
    public class ClsAgent
    {
        private long mlID;
        private string mstrAgentName;

        public long ID
        {
            get { return mlID; }
            set { mlID = value; }
        }

        public string AgentName
        {
            get { return mstrAgentName; }
            set { mstrAgentName = value; }
        }
    }
}
