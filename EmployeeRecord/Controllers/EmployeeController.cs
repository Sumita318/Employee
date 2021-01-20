using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeRecord.ViewModel;
using EmployeeRecord.Models;

namespace EmployeeRecord.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeDBEntities _db = new EmployeeDBEntities();
        // GET: Employee
        public ActionResult Index()
        {
            var model = _db.tblEmployeeInfoes.ToList();
            ViewBag.employee = model;
            return View();
        }
        [HttpPost]
        public JsonResult SaveEducationDetails(EmployeeViewModel model)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (EmployeeDBEntities db = new EmployeeDBEntities())
                {
                    tblEmployeeInfo employeeInfo = new tblEmployeeInfo { EmployeeName = model.EmployeeName, EmployeeAddress = model.EmployeeAddress, ContactNo = model.ContactNo, EmployeeId = model.EmployeeId };
                    foreach (var i in model.EducationDetails)
                    {
                        employeeInfo.tblEducations.Add(i);
                    }
                    db.tblEmployeeInfoes.Add(employeeInfo);
                    db.SaveChanges();
                    status = true;
                }
            }
            else
            {
                status = false;
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}