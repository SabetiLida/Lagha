using System;
using System.Data;
using System.Configuration;

namespace Laghaee.Entity
{
    /// <summary>
    /// Summary description for ClsDesignApplications
    /// </summary>
    public class ClsDesign
    {
#region "Member variables"
    
        private long mlId;
        private long mlFillingNo;
        private string mlAdditionalGoodsClassesNumber;
        private int miYear;
        private string mstrTrademark;
        private string mstrComment;
        private string mstrKCommission;
        private string mstrPicture;
        private string  mlAppNo;
        private string mstrAppDate;
        private string mlRegNo;
        private string mstrRegDate;
        private bool mblnFirstRenewalDate;
        private bool mblnSecondRenewalDate;
        private bool mblnThirdRenewalDate;
        private string mstrClass;
        private int miApplicantId;
        private int miAgentId;
        private int miAgent2Id;
        private int miStatusId;
        private long mlPowerOfAttorneyNo;
        private string mstrLastDateChecked;
           
#endregion 

        public long ID
        {
            get {return mlId;}
            set {mlId =value ;}
        }

        public long FillingNumber
        {
            get {return mlFillingNo ;}
            set {mlFillingNo =value ;}
        }

        public string AdditionalGoodsClassesNumber
        {
            get { return mlAdditionalGoodsClassesNumber; }
            set { mlAdditionalGoodsClassesNumber = value; }
        }
        public int Year
        {
            get {return miYear  ;}
            set {miYear=value  ;}
        }

        public string TradeMark
        {
            get {return mstrTrademark  ;}
            set {mstrTrademark =value  ;}
        }

        public string Picture
        {
            get {return mstrPicture;}
            set {mstrPicture =value ;}
        }

        public string AppNumber
        {
            get {return mlAppNo  ;}
            set {mlAppNo = value  ;}
        }

        public string RegNumber
        {
            get {return mlRegNo  ;}
            set {mlRegNo = value  ;}
        }

        public string AppDate
        {
            get {return mstrAppDate  ;}
            set {mstrAppDate = value  ;}
        }

        public string RegDate
        {
            get {return mstrRegDate  ;}
            set {mstrRegDate=value  ;}
        }

        public bool FirstRenewalDate
        {
            get {return mblnFirstRenewalDate  ;}
            set {mblnFirstRenewalDate= value ;}
        }

        public bool  SecondRenewalDate
        {
            get {return mblnSecondRenewalDate  ;}
            set {mblnSecondRenewalDate=value  ;}
        }

        public bool ThirdRenewalDate
        {
            get {return mblnThirdRenewalDate  ;}
            set {mblnThirdRenewalDate =value  ;}
        }

        public string Class
        {
            get {return mstrClass  ;}
            set {mstrClass=value  ;}
        }

        public int ApplicantID
        {
            get {return miApplicantId  ;}
            set {miApplicantId = value  ;}
        }

        public int AgentID
        {
            get {return miAgentId  ;}
            set {miAgentId =value  ;}
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
            get {return miStatusId  ;}
            set {miStatusId = value  ;}
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
