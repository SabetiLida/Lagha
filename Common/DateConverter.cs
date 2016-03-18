using System;
using System.Collections.Generic;
using System.Text;

namespace Laghaee.Common
{
    public class DateConverter
    {
        public static string GetGregorianDate(string strPersianDate)
        {
            if (strPersianDate.Trim() == string.Empty)
                return string.Empty;

            DateTime dConvertedDate;
            FarsiLibrary.Utils.PersianDate objPersianDate;

            objPersianDate =
                FarsiLibrary.Utils.PersianDate.Parse(strPersianDate, false);
            dConvertedDate =
                FarsiLibrary.Utils.PersianDateConverter.ToGregorianDateTime(objPersianDate);

            return string.Format("{0:yyyy/MM/dd}", dConvertedDate);
        }
    }
}
