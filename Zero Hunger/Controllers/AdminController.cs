using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_Hunger.Db;
using Zero_Hunger.Models;

namespace Zero_Hunger.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Username)
        {
            ViewBag.Uname = Username;
            return View();
        }
       public ActionResult Submit(string Username,string Password)
        {
            if (Username == "admin" && Password == "Admin")
            {
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddRestaurent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddRestaurent(RestaurentDTO res)
        {
             if (ModelState.IsValid)
            {
                var db = new Zero_HungerEntities();
                db.Restaurents.Add(Convert(res));
                db.SaveChanges();
                return RedirectToAction("Dashboard");
                //return RedirectToAction("Login");   

            }
            return View(res);
        }

        Restaurent Convert(RestaurentDTO res)
        {
            var r = new Restaurent()
            {
                Id = res.Id,
                Name = res.Name,
                Username = res.Username,
                Password = res.Password
               
            };
            return r;
        }
        RestaurentDTO Convert(Restaurent res)
        {
            var r = new RestaurentDTO()
            {

                Id = res.Id,
                Name = res.Name,
                Username = res.Username,
                Password = res.Password
            };
            return r;
        }
        List<RestaurentDTO> Convert(List<Restaurent> restaurents)
        {
            var rst = new List<RestaurentDTO>();
            foreach (var item in restaurents)
            {
                rst.Add(Convert(item));
            }
            return rst;
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(EmployeeDTO emp)
        {
            if (ModelState.IsValid)
            {
                var db2 = new Zero_HungerEntities();
                db2.Employees2.Add(Convert(emp));
                db2.SaveChanges();
                return RedirectToAction("Dashboard");
                //return RedirectToAction("Login");   

            }
            return View(emp);
        }

        Employees2 Convert(EmployeeDTO emp)
        {
            var r = new Employees2()
            {
                Id = emp.Id,
                Name = emp.Name,
                Username = emp.Username,
                Password = emp.Password

            };
            return r;
        }
        EmployeeDTO Convert(Employees2 emp)
        {
            var r = new EmployeeDTO()
            {

                Id = emp.Id,
                Name = emp.Name,
                Username = emp.Username,
                Password = emp.Password
            };
            return r;
        }
        List<EmployeeDTO> Convert(List<Employees2> emps)
        {
            var em = new List<EmployeeDTO>();
            foreach (var item in emps)
            {
                em.Add(Convert(item));
            }
            return em;
        }

        public ActionResult CheckRequest()
        {
            var db = new Zero_HungerEntities();
            var data = db.newRequests.ToList();
            return View(Convert(data));
        }

        public RequestDTO Convert(newRequest req)
        {
            var r = new RequestDTO()
            {

                Cid = req.Cid,
                Restaurent_Id = req.Restaurent_Id,
                Food_Item = req.Food_Item,
                Max_Preservation_Time = req.Max_Preservation_Time
            };
            return r;
        }

        public newRequest Convert(RequestDTO req)
        {
            var r = new newRequest()
            {
                Cid = req.Cid,
                Restaurent_Id = req.Restaurent_Id,
                Food_Item = req.Food_Item,
                Max_Preservation_Time = req.Max_Preservation_Time

            };
            return r;
        }

        List<RequestDTO> Convert(List<newRequest> requests)
        {
            var rst = new List<RequestDTO>();
            foreach (var item in requests)
            {
                rst.Add(Convert(item));
            }
            return rst;
        }
        
        [HttpGet]
        public ActionResult AcceptRequest(int id)
        {
            var db = new Zero_HungerEntities();
            var data = db.newRequests.Find(id);
            return View(Convert(data));
        }

        [HttpPost]
        public ActionResult Submit2(DistributionDTO dis)
        {
            if (ModelState.IsValid)
            {
                var db2 = new Zero_HungerEntities();
                db2.Distribution2.Add(Convert(dis));
                db2.SaveChanges();
                
                //return RedirectToAction("Login");   

            }
            return View(dis);
        }

        Distribution2 Convert(DistributionDTO emp)
        {
            var r = new Distribution2()
            {
                Did = emp.Did,
                Employee_Id=emp.Employee_Id,
                Restaurent_Id=emp.Restaurent_Id,
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
        public ActionResult Logout()
        {
            Session["Login"] = null;
            return RedirectToAction("Index");
        }
      



    }
}