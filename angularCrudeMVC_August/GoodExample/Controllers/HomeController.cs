using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoodExample.Models;

namespace GoodExample.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }


        public JsonResult getAll()
        {
            using (SampleDBEntities2 dataContext = new SampleDBEntities2())
            {
                var employeeList = dataContext.Employees.ToList();
                return Json(employeeList, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult getEmployeeByNo(string EmpNo)
        {
            using (SampleDBEntities2 dataContext = new SampleDBEntities2())
            {
                int no = Convert.ToInt32(EmpNo);
                var employeeList = dataContext.Employees.Find(no);
                return Json(employeeList, JsonRequestBehavior.AllowGet);
            }
        }
        public string UpdateEmployee(Employee Emp)
        {
            if (Emp != null)
            {
                using (SampleDBEntities2 dataContext = new SampleDBEntities2())
                {
                    int no = Convert.ToInt32(Emp.Id);
                    var employeeList = dataContext.Employees.Where(x => x.Id == no).FirstOrDefault();
                    employeeList.name = Emp.name;
                   // employeeList.Age = Emp.Age;
                    employeeList.email = Emp.email;
                    dataContext.SaveChanges();
                    return "Employee Updated";
                }
            }
            else
            {
                return "Invalid Employee";
            }
        }
        public string AddEmployee(Employee Emp)
        {
            if (Emp != null)
            {
                using (SampleDBEntities2 dataContext = new SampleDBEntities2())
                {
                    dataContext.Employees.Add(Emp);
                    dataContext.SaveChanges();
                    return "Employee Updated";
                }
            }
            else
            {
                return "Invalid Employee";
            }
        }


        public string DeleteEmployee(Employee Emp)
        {
            if (Emp != null)
            {
                using (SampleDBEntities2 dataContext = new SampleDBEntities2())
                {
                    int no = Convert.ToInt32(Emp.Id);
                    var employeeList = dataContext.Employees.Where(x => x.Id == no).FirstOrDefault();
                    dataContext.Employees.Remove(employeeList);
                    dataContext.SaveChanges();
                    return "Employee Deleted";
                }
            }
            else
            {
                return "Invalid Employee";
            }
        }
    }
}
