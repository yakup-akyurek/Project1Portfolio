﻿using Project1Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1Portfolio.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public ActionResult Inbox()
        {
            var values = context.Message.ToList();

            return View(values);
        }
        public ActionResult MessageDetails(int id)
        {

            var value = context.Message.Where(x=>x.MessageId==id).FirstOrDefault();
            return View(value);
        }

    }
}