using AutofacDemo.Models.Log;
using AutofacDemo.Services.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutofacDemo.Controllers
{
    public class LogController : Controller
    {
        private readonly ILogService _logService;
        public LogController(ILogService logService)
        {
            _logService = logService;
        }

        // GET: Log
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            var entitys = _logService.logList();
            var modelList = entitys.Select(t => new LogModel()
            {
                Id = t.Id,
                Message = t.Message,
                CreateDate = t.CreateDate
            });
            return View(modelList);
        }
    }
}