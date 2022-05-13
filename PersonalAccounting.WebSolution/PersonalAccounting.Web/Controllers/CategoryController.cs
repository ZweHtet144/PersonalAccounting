using PersonalAccounting.Service;
using PersonalAccounting.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalAccounting.Web.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        private readonly CategoryServices _service = new CategoryServices();
        public ActionResult Index()
        {
            List<CategoryViewModel> viewModel = _service.GetCategories();
            return View(viewModel);
        }

        public ActionResult Create()
        {
            var model = new CategoryViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(CategoryViewModel viewModel)
        {
            _service.Create(viewModel);
            return RedirectToAction("index");
        }

        public ActionResult Edit(string id)
        {
            CategoryViewModel category = _service.GetCategory(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(CategoryViewModel viewModel)
        {
           _service.Update(viewModel);
            return RedirectToAction("index");
        }
        public ActionResult Delete(string id)
        {
            _service.Delete(id);
            return RedirectToAction("index");
        }
    }
}