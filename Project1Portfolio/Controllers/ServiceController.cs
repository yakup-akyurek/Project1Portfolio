using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Project1Portfolio.Models;

namespace MyPortfolioProject.Controllers
{
    public class ServiceController : Controller
    {
        MyPortfolioDbEntities1 context = new MyPortfolioDbEntities1();
        public ActionResult ServiceList()
        {
            var values = context.Service.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateService(Service service)
        {
            context.Service.Add(service);
            context.SaveChanges();
            return RedirectToAction(nameof(ServiceList));
        }
        public ActionResult DeleteService(int id)
        {
            var value = context.Service.Find(id);
            context.Service.Remove(value);
            context.SaveChanges();
            return RedirectToAction(nameof(ServiceList));
        }
        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var value = context.Service.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateService(Service service)
        {
            var value = context.Service.Find(service.ServiceId);
            value.Icon = service.Icon;
            value.Title = service.Title;
            value.Description = service.Description;
            value.SubTitleA = service.SubTitleA;
            value.SubTitleB = service.SubTitleB;
            context.SaveChanges();
            return RedirectToAction(nameof(ServiceList));
        }
    }
}