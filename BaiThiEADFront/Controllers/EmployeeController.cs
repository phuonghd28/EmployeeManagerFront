using BaiThiEADFront.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaiThiEADFront.Controllers
{
    public class EmployeeController : Controller
    {
        private Service1Client service = new Service1Client();
        // GET: Employee
        public ActionResult Index()
        {
            var data = service.GetList(null);
            return View(data);
        }

        public ActionResult IndexAjax()
        {
            var searchString = this.Request.QueryString["searchString"];
            var result = service.GetList(searchString != null ? searchString : null);
            return PartialView("IndexAjax", result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(Employee employee)
        {
            var result = service.CreateEmployee(employee);
            if(!result)
            {
                return View("Error");
            }
            return RedirectToAction("Index");
        }
    }
}