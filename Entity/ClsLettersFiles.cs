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
    public class ClsLettersFiles
    {
        private int mlID;
        private int mAgentLettersId;
        private string mLetterFilePath;
        private string mFileType;
        private string mFileName;
        public ClsLettersFiles(int AgentLetterId,string LetterFilePath,string FileType,string FileName)
        {
            
            this.AgentLettersId = AgentLetterId;
            this.LetterFilePath = LetterFilePath;
            this.FileType = FileType;
            this.FileName = FileName;
        }
        public ClsLettersFiles()
        { }
        public int ID
        {
            get { return mlID; }
            set { mlID = value; }
        }

        public int AgentLettersId
        {
            get { return mAgentLettersId; }
            set { mAgentLettersId = value; }
        }
        public string LetterFilePath
        {
            get { return mLetterFilePath; }
            set { mLetterFilePath = value; }
        }
        public string FileType
        {
            get { return mFileType; }
            set { mFileType = value; }
        }
        public string FileName
        {
            get { return mFileName; }
            set { mFileName = value; }
        }
    }
}
