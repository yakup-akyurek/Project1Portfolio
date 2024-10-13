using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Project1Portfolio.Models;

namespace MyPortfolioProject.Controllers
{
    public class PortfolioController : Controller
    {
        // GET: Portfolio
        MyPortfolioDbEntities1 context = new MyPortfolioDbEntities1();
        public ActionResult PortfolioList()
        {
            var values = context.Portfolio.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreatePortfolio()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatePortfolio(Portfolio portfolio)
        {
            context.Portfolio.Add(portfolio);
            context.SaveChanges();
            return RedirectToAction(nameof(PortfolioList));
        }
        public ActionResult DeletePortfolio(int id)
        {
            var value = context.Portfolio.Find(id);
            context.Portfolio.Remove(value);
            context.SaveChanges();
            return RedirectToAction(nameof(PortfolioList));
        }
        [HttpGet]
        public ActionResult UpdatePortfolio(int id)
        {
            var value = context.Portfolio.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdatePortfolio(Portfolio portfolio)
        {
            var value = context.Portfolio.Find(portfolio.PortfolioID);
            value.SubTitle = portfolio.SubTitle;
            value.Title = portfolio.Title;
            value.ImageUrl = portfolio.ImageUrl;
            context.SaveChanges();
            return RedirectToAction(nameof(PortfolioList));
        }
    }
}