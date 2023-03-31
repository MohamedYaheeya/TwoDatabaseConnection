using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using TwoDatabaseConnection.Models;

namespace TwoDatabaseConnection.Controllers
{
    public class HomeController : Controller
    {
        DataBaseConnection db = new DataBaseConnection();

        public List<FinalModel> dataList()
        {
            var query = from EmployeModel in db.DBConnection1()
                        join HrModel in db.DBConnection2() on EmployeModel.Emp_id equals HrModel.Department_Id
                        select new FinalModel { Name = EmployeModel.Name, Email = EmployeModel.Email, Department = HrModel.Department, Manager = HrModel.Manager, Salary = HrModel.Salary };
            IEnumerable<FinalModel> resultList = query.ToList();          
            return (List<FinalModel>)resultList;      
        }
            
        public ActionResult GetEmployeeDetails(string name)
        {
            var query = from EmployeModel in db.DBConnection1()
                        join HrModel in db.DBConnection2() on EmployeModel.Emp_id equals HrModel.Department_Id
                        where EmployeModel.Name.Contains(name ?? "")
                        select new FinalModel { Name = EmployeModel.Name, Email = EmployeModel.Email, Department = HrModel.Department, Manager = HrModel.Manager, Salary = HrModel.Salary };
            var resultList = query.FirstOrDefault();
            return PartialView("EmployeDetail", resultList);
        }
        public ActionResult Index()
        {          
            var results = dataList();
            ViewBag.msg = results;             
            return View(results);
        }

    }
}