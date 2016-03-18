using System;
using System.Data;
using System.Configuration;
using System.Web;

namespace Laghaee.Common.Enumeration
{
    public enum AttachOpr
    {
        DeleteAll,
        DeleteSelected,
        AddNew
    }
    public enum LetterType
    {
        DesignLetter=1,
        PatentLetter=2,
        TradeMarkLetter=3
    }
    public enum LetterClientOfficce
    {
        Client=0,
        Office=1
    }

}
