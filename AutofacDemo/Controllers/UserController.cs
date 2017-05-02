using AutofacDemo.Core.Data;
using AutofacDemo.Models.Users;
using AutofacDemo.Services.Log;
using AutofacDemo.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutofacDemo.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogService _logService;

        public UserController(IUserService userService, ILogService logService)
        {
            _userService = userService;
            _logService = logService;
        }

        // GET: User
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            var entity = _userService.UserList();
            var model = new List<UserModel>();
            model = entity.Select(x => new UserModel()
            {
                Id = x.Id,
                Name = x.Name,
                Adress = x.Adress,
                Tel=x.Tel,
                Age = x.Age,
                CreateDate = x.CreateDate
            }).ToList();
            return View(model);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var entity = _userService.GetById(id);
            var model = new UserModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Adress = entity.Adress,
                Age = entity.Age,
                Tel = entity.Tel,
                CreateDate = entity.CreateDate
            };
            return View(model);

        }

        // GET: User/Create
        public ActionResult Create()
        {
            var model = new UserModel();
            return View(model);
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserModel model)
        {
            try
            {
                // TODO: Add insert logic here
                var user = new User();
                user.Name = model.Name;
                user.Adress = model.Adress;
                user.Age = model.Age;
                user.Tel = model.Tel;
                user.CreateDate = DateTime.Now;
                _userService.Insert(user);
                _logService.SaveLog(DateTime.Now+":创建用户"+user.Name);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var entity = _userService.GetById(id);
            var model = new UserModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Adress = entity.Adress,
                Age = entity.Age,
                Tel = entity.Tel,
                CreateDate = entity.CreateDate
            };
            return View(model);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(UserModel model)
        {
            try
            {
                // TODO: Add update logic here
                var entity = _userService.GetById(model.Id);
                entity.Adress = model.Adress;
                entity.Age = model.Age;
                entity.Tel = model.Tel;
                entity.Name = model.Name;
                _userService.Update(entity);
                _logService.SaveLog(DateTime.Now + ":编辑用户" + entity.Name);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var entity = _userService.GetById(id);
            var model = new UserModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Adress = entity.Adress,
                Age = entity.Age,
                Tel = entity.Tel,
                CreateDate = entity.CreateDate
            };
            return View(model);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(UserModel model)
        {
            try
            {
                // TODO: Add delete logic here
                var entity = _userService.GetById(model.Id);

                _userService.Delete(entity);
                _logService.SaveLog(DateTime.Now + ":删除用户" + entity.Name);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
