using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Project1Portfolio.Models;

namespace MyPortfolioProject.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        MyPortfolioDbEntities1 context = new MyPortfolioDbEntities1();
        public ActionResult GetSkills()
        {
            var values = context.Skill.ToList();
            return PartialView(values);
        }
    }
}