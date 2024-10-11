using Project1Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1Portfolio.Controllers
{
    public class DefaultController : Controller
    {
        MyPortfolioDbEntities1 context = new MyPortfolioDbEntities1();
        // GET: Default
        public ActionResult Index()
        {   //kullanıcının hangi kategoride gönderim yapabileceğini seçtirdik. kullanıcıya isim gitti biz ıd üzerinden çektik
            List<SelectListItem> values =(from x in context.Category.ToList()
                                          select new SelectListItem
                                          {
                                              Text=x.CategoryName,
                                              Value=x.CategoryId.ToString(),
                                          }).ToList();
            ViewBag.v=values;
            return View();
        }
        [HttpPost]
        public ActionResult Index(Message message) 
        {
            //günümüz tarihinde gönderi yapmasını sağladık
            message.SendDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            message.IsRead = false;
            context.Message.Add(message);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavBar() 
        {
            return PartialView();        
        }
        public PartialViewResult PartialHeader() 
        {
            ViewBag.title=context.About.Select(a => a.Title).FirstOrDefault();
            ViewBag.detail=context.About.Select(a => a.Detail).FirstOrDefault();
            ViewBag.imageUrl=context.About.Select(a => a.ImageUrl).FirstOrDefault();

            ViewBag.address=context.Profile.Select(a => a.Address).FirstOrDefault();
            ViewBag.email=context.Profile.Select(a => a.Email).FirstOrDefault();
            ViewBag.phone=context.Profile.Select(a => a.PhoneNumber).FirstOrDefault();
            ViewBag.github=context.Profile.Select(a => a.Github).FirstOrDefault();

            return PartialView();
        }
        public PartialViewResult PartialAbout() 
        {
            ViewBag.title=context.Profile.Select(x=>x.Title).FirstOrDefault();
            ViewBag.description=context.Profile.Select(x=>x.Description).FirstOrDefault();
            ViewBag.phone=context.Profile.Select(x=>x.PhoneNumber).FirstOrDefault();
            ViewBag.email=context.Profile.Select(x=>x.Email).FirstOrDefault();
            ViewBag.imageUrl=context.Profile.Select(x=>x.ImageUrl).FirstOrDefault();
            return PartialView();
        }

        public PartialViewResult PartialEducation() 
        {
            var values = context.Education.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialExperience() 
        {
            var values = context.Experience.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialSkills() 
        {
            var values = context.Skill.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialScript() 

        {
            return PartialView();
        }

        public PartialViewResult PartialSocialMedia() 
        {
            var values = context.SocialMedia.Where(x=>x.Status==true).ToList();
            return PartialView(values);

        }
        public PartialViewResult PartialTestimonial() 
        {
            var values = context.Testimonial.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialPortfolio() 
        {
            var values = context.Portfolio.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialService() 
        {
            var values = context.Service.ToList();
            return PartialView(values);
        }
    }
    
    
}