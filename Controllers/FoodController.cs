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


        [NonAction]
        public IEnumerable<SelectListItem> GetAllTypes()
        {
            var selectList = new List<SelectListItem>();

            foreach (var cover in db.Types.ToList())
            {
                selectList.Add(new SelectListItem
                {
                    Value = cover.TypeId.ToString(),
                    Text = cover.Name
                });
            }
            return selectList;
        }

        [HttpGet]
        public ActionResult New()
        {
            Food food = new Food();
            food.Categories = new List<Category>();
            food.TypesList = GetAllTypes();
            return View(food);
        }



        [HttpPost]
        public ActionResult New(Food foodRequest)
        {
            try
            {
                foodRequest.TypesList = GetAllTypes();
                if (ModelState.IsValid)
                {
                    db.Foods.Add(foodRequest);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(foodRequest);
            }
            catch (Exception e)
            {
                return View(foodRequest);
            }
        }

        // GET: /food/edit/{id}
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var food = db.Foods.Find(id);
            

            if (food == null)
            {
                return HttpNotFound();
            }

            return View(food);
        }

        // POST: /food/edit
        [HttpPost]
        public ActionResult Edit(Food food)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var oldFood = db.Foods.Find(food.FoodId);

                    if (oldFood == null)
                    {
                        return HttpNotFound();
                    }

                    oldFood.Denumire = food.Denumire;
                    oldFood.Pret = food.Pret;
                    oldFood.Informatii = food.Informatii;

                    TryUpdateModel(oldFood);

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                return Json(new { error_message = e.Message }, JsonRequestBehavior.AllowGet);
            }

            return View(food);
        }


        // GET: /food/delete/{id}
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var food = db.Foods.Find(id);

            if (food == null)
            {
                return HttpNotFound();
            }

            db.Foods.Remove(food);

            db.SaveChanges();

            return RedirectToAction("Index");
        }





    }
}