using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_Hunger.Db;
using Zero_Hunger.Models;

namespace Zero_Hunger.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CheckDistribution()
        {
            var db = new Zero_HungerEntities();
            var data = db.Distribution2.ToList();
            return View(Convert(data));
        }

        Distribution2 Convert(DistributionDTO emp)
        {
            var r = new Distribution2()
            {
                Did = emp.Did,
                Employee_Id = emp.Employee_Id,
                Restaurent_Id = emp.Restaurent_Id,
                Food_Item = emp.Food_Item,
                Max_Preservation_Time = emp.Max_Preservation_Time





            };
            return r;
        }
        DistributionDTO Convert(Distribution2 emp)
        {
            var r = new DistributionDTO()
            {
                Did = emp.Did,
                Employee_Id = emp.Employee_Id,
                Restaurent_Id = emp.Restaurent_Id,
                Food_Item = emp.Food_Item,
                Max_Preservation_Time = emp.Max_Preservation_Time
            };
            return r;
        }
        List<DistributionDTO> Convert(List<Distribution2> emps)
        {
            var em = new List<DistributionDTO>();
            foreach (var item in emps)
            {
                em.Add(Convert(item));
            }
            return em;
        }

        public ActionResult doneDelivery()
        {
            return View();
        }
    }
}