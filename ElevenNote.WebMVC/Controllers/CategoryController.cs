﻿//using ElevenNote.Data;
//using ElevenNote.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace ElevenNote.WebMVC.Controllers
//{
//    [Authorize]
//    public class CategoryController : Controller
//    {
//        // GET: Category
//        public ActionResult Index()
//        {
//            var categoryId = Guid.Parse(Category.Identity.GetCategoryId());
//            var service = new CategoryService(categoryId);
//            var model = service.GetCategories();

//            return View(model);
//        }

//        // GET
//        public ActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(CategoryCreate model)
//        {
//            if (!ModelState.IsValid) return View(model);

//            var service = CreateCategoryService();

//            if (service.CreateCategory(model))
//            {
//                TempData["SaveResult"] = "Your category was created.";
//                return RedirectToAction("index");
//            };

//            ModelState.AddModelError("", "Category could not be created.");

//            return View(model);
//        }

//        public ActionResult Details(int id)
//        {
//            var svc = CreateCategoryService();
//            var model = svc.GetCategoryById(id);

//            return View(model);
//        }

//        public ActionResult Edit(int id)
//        {
//            var service = CreateCategoryService();
//            var detail = service.GetCategoryById(id);
//            var model =
//                new CategoryEdit
//                {
//                    CategoryId = detail.CategoryId,
//                    CategoryName = detail.CategoryName
//                };
//            return View(model);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(int id, CategoryEdit model)
//        {
//            if (!ModelState.IsValid) return View(model);

//            if(model.CategoryId != id)
//            {
//                ModelState.AddModelError("", "Id Mismatch");
//                return View(model);
//            }

//            var service = CreateCategoryService();

//            if (service.UpdateCategory(model))
//            {
//                TempData["SaveResult"] = "Your category was updated.";
//                return RedirectToAction("Index");
//            }

//            ModelState.AddModelError("", "Your category could not be updated.");
//            return View(model);
//        }

//        [ActionName("Delete")]
//        public ActionResult Delete(int id)
//        {
//            var svc = CreateCategoryService();
//            var model = svc.GetCategoryById(id);

//            return View(model);
//        }

//        [HttpPost]
//        [ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteCategory(int id)
//        {
//            var service = CreateCategoryService();

//            service.DeleteCategory(id);

//            TempData["SaveResult"] = "Your category was deleted.";

//            return RedirectToAction("Index");
//        }

//        private CategoryService CreateCategoryService()
//        {
//            var categoryId = Guid.Parse(Category.Identity.GetCategoryId());
//            var service = new CategoryService(categoryId);
//            return service;
//        }

//    }
//}