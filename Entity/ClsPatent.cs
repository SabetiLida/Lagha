using System;
using System.Data;
using System.Configuration;

namespace Laghaee.Entity
{
    /// <summary>
    /// Summary description for ClsPatent
    /// </summary>
    public class ClsPatent
    {
        #region "Member variables"

        private long mlId;
        private long mlFillingNo;
        private int miYear;
        private string mstrTitle;
        private string mlAppNo;
        private string mstrAppDate;
        private string mlRegNo;
        private string mlAdditionalGoodsClassesNumber;
        private string mstrRegDate;
        private string mstrComment;
        private string mstrKCommission;
        private string mstrNextAnnuityDate;
        private int miNextAnnuityYear;
        private int miApplicantId;
        private int miAgentId;
        private int miAgent2Id;
        private int miStatusId;
        private long mlPowerOfAttorneyNo;
        private string mstrLastDateChecked;

        #endregion

        public long ID
        {
            get { return mlId; }
            set { mlId = value; }
        }

        public long FillingNumber
        {
            get { return mlFillingNo; }
            set { mlFillingNo = value; }
        }

        public int Year
        {
            get { return miYear; }
            set { miYear = value; }
        }

        public string Title
        {
            get { return mstrTitle; }
            set { mstrTitle = value; }
        }

        public int NextAnnuityYear
        {
            get { return miNextAnnuityYear; }
            set { miNextAnnuityYear = value; }
        }

        public string NextAnnuityDate
        {
            get { return mstrNextAnnuityDate; }
            set { mstrNextAnnuityDate  = value; }
        }

        public string AppNumber
        {
            get { return mlAppNo; }
            set { mlAppNo = value; }
        }

        public string AdditionalGoodsClassesNumber
        {
            get { return mlAdditionalGoodsClassesNumber; }
            set { mlAdditionalGoodsClassesNumber = value; }
        }


        public string RegNumber
        {
            get { return mlRegNo; }
            set { mlRegNo = value; }
        }

        public string AppDate
        {
            get { return mstrAppDate; }
            set { mstrAppDate = value; }
        }

        public string RegDate
        {
            get { return mstrRegDate; }
            set { mstrRegDate = value; }
        }

        public int ApplicantID
        {
            get { return miApplicantId; }
            set { miApplicantId = value; }
        }

        public int AgentID
        {
            get { return miAgentId; }
            set { miAgentId = value; }
        }

        public int Agent2ID
        {
            get { return miAgent2Id; }
            set { miAgent2Id = value; }
        }

        public string Comment
        {
            get { return mstrComment; }
            set { mstrComment = value; }
        }

        public string KCommission
        {
            get { return mstrKCommission; }
            set { mstrKCommission = value; }
        }

        public int StatusID
        {
            get { return miStatusId; }
            set { miStatusId = value; }
        }

        public long PowerOfAttorney
        {
            get { return mlPowerOfAttorneyNo; }
            set { mlPowerOfAttorneyNo = value; }
        }

        public string LastDateChecked
        {
            get { return mstrLastDateChecked; }
            set { mstrLastDateChecked = value; }
        }


    }
}