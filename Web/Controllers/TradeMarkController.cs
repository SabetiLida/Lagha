using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laghaee.WebSite.Controllers
{
    public class TradeMarkController : Controller
    {
        // GET: TradeMark
        public PartialViewResult TradeMarkTemplate()
        {
            return PartialView();
        }
    }
}