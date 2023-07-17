using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_Hunger.Db;
using Zero_Hunger.Models;

namespace Zero_Hunger.Controllers
{
    public class RestaurentController : Controller
    {
        // GET: Restaurent
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CollectRequest()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CollectRequest(RequestDTO req)
        {
            if (ModelState.IsValid)
            {
                var db = new Zero_HungerEntities();
                db.newRequests.Add(Convert(req));
                db.SaveChanges();


            }
            return View(req);
        }

        newRequest Convert(RequestDTO req)
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
        RequestDTO Convert(newRequest req)
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
        List<RequestDTO> Convert(List<newRequest> requests)
        {
            var rst = new List<RequestDTO>();
            foreach (var item in requests)
            {
                rst.Add(Convert(item));
            }
            return rst;
        }
    }
}