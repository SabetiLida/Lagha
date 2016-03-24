using System;
using System.Collections.Generic;
using System.Text;

namespace Laghaee.Entity
{
    public class ClsTradeMark
    {
        #region "Memeber Variables"

        private long mlID;
        private int miApplicantID;
        private int miAgentID;
        private int miAgent2ID;
        private int miStatusID;
        private long mlFillingNumber;
        private int miYear;
        private string mlAppNo;
        private string mlOppositionAgainstNo;
        private string mlAdditionalGoodsClassesNumber;
        private string mlExtractNumber;
        private string mlRegNo;
        private long mlPowerOfAttorneyNo;
        private string mstrClasses;
        private string mstrTrademark;
        private string mstrKCommission;
        private string mstrComment;
        private string mstrAppDate;
        private string mstrRegDate;
        private string mstrRenewalDate;
        private int  miRenewalCount;
        private string mstrLastDateChecked;
        private string mstrPicture ;

        #endregion

        public long  ID
        {
            get { return mlID; }
            set { mlID = value; }
        }

        public int ApplicantID
        {
            get { return miApplicantID; }
            set { miApplicantID = value; }
        }

        public int AgentID
        {
            get { return miAgentID; }
            set { miAgentID = value; }
        }

        public int Agent2ID
        {
            get { return miAgent2ID; }
            set { miAgent2ID = value; }
        }

        public int StatusID
        {
            get { return miStatusID; }
            set { miStatusID = value; }
        }

        public long FillingNumber
        {
            get { return mlFillingNumber; }
            set { mlFillingNumber = value; }
        }

        public int Year
        {
            get { return miYear; }
            set { miYear = value; }
        }

        public string AppNumber
        {
            get { return mlAppNo; }
            set { mlAppNo = value; }
        }

        public string OppositionAganistNumber
        {
            get { return mlOppositionAgainstNo; }
            set { mlOppositionAgainstNo = value; }
        }

        public string AdditionalGoodsClassesNumber
        {
            get { return mlAdditionalGoodsClassesNumber; }
            set { mlAdditionalGoodsClassesNumber = value; }
        }

        public string ExtractNumber
        {
            get { return mlExtractNumber; }
            set { mlExtractNumber = value; }
        }

        public string RegNumber
        {
            get { return mlRegNo; }
            set { mlRegNo = value; }
        }

        public long PowerOfAttorney
        {
            get { return mlPowerOfAttorneyNo; }
            set { mlPowerOfAttorneyNo = value; }
        }

        public string TradeMarkName
        {
            get { return mstrTrademark; }
            set { mstrTrademark = value; }
        }

        public string KCommission
        {
            get { return mstrKCommission; }
            set { mstrKCommission = value; }
        }

        public string Comment
        {
            get { return mstrComment; }
            set { mstrComment = value; }
        }

        public string Classes
        {
            get { return mstrClasses; }
            set { mstrClasses = value; }
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

        public int RenewalCount
        {
            get { return miRenewalCount; }
            set { miRenewalCount = value; }
        }

        public string RenewalDate
        {
            get { return mstrRenewalDate; }
            set { mstrRenewalDate = value; }
        }

        public string LastDateChecked
        {
            get { return mstrLastDateChecked; }
            set { mstrLastDateChecked = value; }
        }

        public string Picture
        {
            get { return mstrPicture ; }
            set { mstrPicture = value; }
        }
    }
}
