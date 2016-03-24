using System;
using System.Data;
using System.Configuration;

namespace Laghaee.Entity
{
    /// <summary>
    /// Summary description for ClsApplicant
    /// </summary>
    public class ClsApplicants
    {
        private long mlID;
        private string mstrApplicantName;

        public long ID
        {
            get { return mlID; }
            set { mlID = value; }
        }

        public string ApplicantName
        {
            get { return mstrApplicantName; }
            set { mstrApplicantName = value; }
        }
    }
}
