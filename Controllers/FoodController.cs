using Amada_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amada_Management.Controllers
{
    public class FoodController : Controller
    {
        private DbCtx db = new DbCtx();

        // GET: Food
        [HttpGet]
        public ActionResult Index()
        {
            List<Food> foods = db.Foods.ToList();
            ViewBag.Foods = foods;

            return View();
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Food food = db.Foods.Find(id);

                if (food != null)
                {
                    return View(food);
                }
                return HttpNotFound("Couldn't find the food id " + id.ToString());
            }
            return HttpNotFound("Missing food id!");
        }
    }
}