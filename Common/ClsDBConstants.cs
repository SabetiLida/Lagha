using System;

namespace Laghaee.Common
{

    /// <summary>
    /// Summary description for ClsDBConstants
    /// </summary>
    /// 
    public class ClsDBConstants
    {
        // User Table Fields.
        public const string User_TableName = "User";
        public const string User_Col_ID = "ID";
        public const string User_Col_UserName = "UserName";
        public const string User_Col_Password = "Password";
        public const string User_Col_EmailAddress = "EmailAddress";
        public const string User_Col_Is_Admin = "IsAdmin";
        public const string User_Col_HasLetterAccess = "HasLettersAccess";
        public const string User_Col_HasTradeMarkAccess = "HasTradeMarkAccess";
        public const string User_Col_HasPatentAccess = "HasPatentAccess";
        public const string User_Col_HasAgentAccess = "HasAgentsAccess";
        public const string User_Col_HasApplicantAccess = "HasApplicantsAccess";
        public const string User_Col_HasDesignAccess = "HasDesignAccess";
        public const string User_Col_FirstName = "FirstName";
        public const string User_Col_LastName = "LastName";
        public const string User_Col_HasAttachmentAccess = "HasAttachmentAccess";


        // 'Applicant Table Fields.
        public const string Applicant_TableName = "Applicants";
        public const string Applicant_Col_ID = "ID";
        public const string Applicant_Col_ApplicantName = "ApplicantName";

        // 'Status' Table Fields.
        public const string Status_TableName = "ApplicationStatuses";
        public const string Status_Col_ID = "ApplicationStatusID";
        public const string Status_Col_StatusName = "ApplicationStatusName";

        // 'Agent' Table Fields.
        public const string Agent_TableName = "Agents";
        public const string Agent_Col_ID = "ID";
        public const string Agent_Col_AgentName = "AgentName";

        // 'Desing' Table Fields.
        public const string Design_TableName = "DesignApplications";
        public const string Design_Col_ID = "ID";
        public const string Design_Col_FillingNo = "FillingNo";
        public const string Design_Col_Year = "Year";
        public const string Design_Col_TradeMark = "TradeMark";
        public const string Design_Col_Picture = "PictureFile";
        public const string Design_Col_AppNo = "AppNo";
        public const string Design_Col_AdditionalGoodsClassesNo = "AdditionalGoodsClassesNo";
        public const string Design_Col_AppDate = "AppDate";
        public const string Design_Col_RegNo = "RegNo";
        public const string Design_Col_RegDate = "RegDate";
        public const string Design_Col_FirstRenewalDate = "FirstRenewalDate";
        public const string Design_Col_SecondRenewalDate = "SecondRenewalDate";
        public const string Design_Col_ThirdRenewalDate = "ThirdRenewalDate";
        public const string Design_Col_Class = "Class";
        public const string Design_Col_ApplicantID = "ApplicantID";
        public const string Design_Col_AgentID = "AgentID";
        public const string Design_Col_Agent2ID = "Agent2ID";
        public const string Design_Col_Comment = "Comment";
        public const string Design_Col_KCommission = "KCommission";
        public const string Design_Col_StatusID = "StatusID";
        public const string Design_Col_PowerOfAttorneyNo = "PoweralAtTorneyNo";
        public const string Design_Col_LastDateChecked = "LastDateChecked";

        // 'Patent' Table Fields.
        public const string Patent_TableName = "PatentApplications";
        public const string Patent_Col_ID = "ID";
        public const string Patent_Col_FillingNo = "FillingNo";
        public const string Patent_Col_Year = "Year";
        public const string Patent_Col_Title = "Title";
        public const string Patent_Col_AppNo = "AppNo";
        public const string Patent_Col_AppDate = "AppDate";
        public const string Patent_Col_RegNo = "RegNo";
        public const string Patent_Col_AdditionalGoodsClassesNo = "AdditionalGoodsClassesNo";
        public const string Patent_Col_RegDate = "RegDate";
        public const string Patent_Col_NextAnnuityDate = "NextAnnuityDate";
        public const string Patent_Col_NextAnnuityYear = "NextAnnuityYear";
        public const string Patent_Col_ApplicantID = "ApplicantID";
        public const string Patent_Col_AgentID = "AgentID";
        public const string Patent_Col_Agent2ID = "Agent2ID";
        public const string Patent_Col_Comment = "Comment";
        public const string Patent_Col_KCommission = "KCommission";
        public const string Patent_Col_StatusID = "StatusID";
        public const string Patent_Col_PowerOfAttorneyNo = "PoweralAtTorneyNo";
        public const string Patent_Col_LastDateChecked = "LastDateChecked";

        // 'TradeMark' Table Fields.
        public const string TradeMark_TableName = "TradeMarkApplications";
        public const string TradeMark_Col_ID = "ID";
        public const string TradeMark_Col_FillingNo = "FillingNo";
        public const string TradeMark_Col_Year = "Year";
        public const string TradeMark_Col_TradeMark = "TradeMark";
        public const string TradeMark_Col_Picture = "PictureFile";
        public const string TradeMark_Col_AppNo = "AppNo";
        public const string TradeMark_Col_OppositionAgainstNo = "OppositionAgainstNo";
        public const string TradeMark_Col_AdditionalGoodsClassesNo = "AdditionalGoodsClassesNo";
        public const string TradeMark_Col_ExtractNumber = "ExtractNumber";
        public const string TradeMark_Col_AppDate = "AppDate";
        public const string TradeMark_Col_RegNo = "RegNo";
        public const string TradeMark_Col_RegDate = "RegDate";
        public const string TradeMark_Col_RenewalDate = "RenewalDate";
        public const string TradeMark_Col_RenewalCount = "RenewalCount";
        public const string TradeMark_Col_Class = "Classes";
        public const string TradeMark_Col_ApplicantID = "ApplicantID";
        public const string TradeMark_Col_AgentID = "AgentID";
        public const string TradeMark_Col_Agent2ID = "Agent2ID";
        public const string TradeMark_Col_Comment = "Comment";
        public const string TradeMark_Col_KCommission = "KCommission";
        public const string TradeMark_Col_StatusID = "StatusID";
        public const string TradeMark_Col_PowerOfAttorneyNo = "PoweralAtTorneyNo";
        public const string TradeMark_Col_LastDateChecked = "LastDateChecked";

        //'AgentLetters' Table Fields.
        public const string AgentLetters_TableName = "AgentLetters";
        public const string AgentLetters_Col_Id = "Id";
        public const string AgentLetters_Col_LetterContent = "LetterContent";
        public const string AgentLetters_Col_AgentId = "AgentId";
        public const string AgentLetters_Col_LetterDate = "LetterDate";
        public const string AgentLetters_Col_RegisterDate = "RegisterDate";
        public const string AgentLetters_Col_LetterName = "LetterName";
        public const string AgentLetters_Col_FilingNo = "FilingNo";
        public const string AgentLetters_Col_LetterType = "LetterType";
        public const string AgentLetters_Col_ClientorOffice = "ClientorOffice";

        //'LettersFiles' Table Fields.
        public const string LettersFiles_TableName = "LettersFiles";
        public const string LettersFiles_Col_Id = "Id";
        public const string LettersFiles_Col_AgentLettersId = "AgentLettersId";
        public const string LettersFiles_Col_LetterFilePath = "LetterFilePath";
        public const string LettersFiles_Col_FileType = "FileType";
        public const string LettersFiles_Col_FileName = "FileName";
       
        //'LogTable' Table Fields
        public const string Log_TableName = "Log";
        public const string Log_Col_TransactionCode = "TransactionCode";
        public const string Log_Col_UserID = "UserID";
        public const string Log_Col_DateTime = "DateTime";
        public const string Log_Col_TransactionType = "TransactionType";
        public const string Log_Col_Comment = "Comment";
        public const string Log_Col_MachineName = "MachineName";
    }
}