using System;
using System.Collections.Generic;
using System.Text;

namespace Laghaee.Entity
{
   public static class ClsStaticAgentLetters
    {
       private static int mID;
       private static string mstrLetterContent;
       private static int mAgentID;
       private static string mLetterDate;
       private static string mRegisterDate;
       private static string mLetterName;

       public static int ID
        {
            get { return mID; }
            set { mID = value; }
        }
       public static string LetterContent
        {
            get { return mstrLetterContent; }
            set { mstrLetterContent = value; }
        }
       public static int AgentID
        {
            get { return mAgentID; }
            set { mAgentID = value; }
        }
       public static string LetterDate
        {
            get { return mLetterDate; }
            set { mLetterDate = value; }
        }
       public static string RegisterDate
        {
            get { return mRegisterDate; }
            set { mRegisterDate = value; }

        }
       public static string LetterName
        {
            get { return mLetterName; }
            set { mLetterName = value; }
        }
    }
}
