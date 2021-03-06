﻿using AutofacDemo.Services.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutofacDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogService _logService;

        public HomeController(ILogService logservice)
        {
            _logService = logservice;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            ViewBag.LogTypeName = _logService.GetType().Name;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}