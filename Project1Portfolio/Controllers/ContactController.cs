using Project1Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1Portfolio.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        MyPortfolioDbEntities1 context = new MyPortfolioDbEntities1();
        public PartialViewResult PartialContactSideBar()
        {
            return PartialView();
        }
        public ActionResult PartialContactAdress() 
        {   /*TEK BİR BİLGİYİ GETİRMEK İÇİN FİRSTORDEFAULT KULLANILIR*/
            ViewBag.description=context.Profile.Select(x => x.Description).FirstOrDefault();
            ViewBag.address=context.Profile.Select(x => x.Address).FirstOrDefault();
            ViewBag.email=context.Profile.Select(x => x.Email).FirstOrDefault();
            ViewBag.phone=context.Profile.Select(x => x.PhoneNumber).FirstOrDefault();

            return PartialView();
        }
        public ActionResult PartialContactLocation() 
        {
            ViewBag.mapLocation=context.Profile.Select(x=>x.MapLocation).FirstOrDefault();
            return PartialView();
        }
    }    
        
}