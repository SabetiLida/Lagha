using System;
using System.Collections.Generic;
using System.Text;

namespace Laghaee.Entity
{
  public  class ClsAgentLetters
    {
        private  int mID;
      private  string mstrLetterContent;
      private  int mAgentID;
      private  string mLetterDate;
      private  string mRegisterDate;
      private long mFilingNo;
      private  string mLetterName;
      private int mLetterType;
      private bool  mClientOffice;

      public  int ID
        {
            get { return mID; }
            set { mID = value;}
        }
      public  string LetterContent
        {
            get { return mstrLetterContent;}
            set { mstrLetterContent = value;}
        }
      public long FilingNo
      {
          get { return mFilingNo; }
          set { mFilingNo = value; }
      }
      public  int AgentID
        {
            get { return mAgentID;}
            set { mAgentID = value;}
        }
      public int LetterType
      {
          get { return mLetterType; }
          set { mLetterType = value; }
      }
      public  string LetterDate
        {
            get { return mLetterDate;}
            set { mLetterDate = value;}
        }
        public  string RegisterDate
        {
            get { return mRegisterDate;}
            set { mRegisterDate = value; }

        }
        public  string  LetterName
        {
            get { return mLetterName; }
            set { mLetterName = value; }
        }
      public bool ClientOffice
      {
          get { return mClientOffice; }
          set { mClientOffice = value; }
      }
    }
}
