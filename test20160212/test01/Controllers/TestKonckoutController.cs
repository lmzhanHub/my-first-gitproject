using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace test01.Controllers
{
    public class TestKonckoutController : Controller
    {
        //
        // GET: /TestKonckout/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetDatas() 
        {
            
            return Json();
        }

    }
}
