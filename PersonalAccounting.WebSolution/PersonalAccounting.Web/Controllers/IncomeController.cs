
using PersonalAccounting.Service;
using PersonalAccounting.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalAccounting.Web.Controllers
{
    public class IncomeController : Controller
    {
        // GET: Income
        private readonly IncomeService _incomeservices = new IncomeService();
        private readonly ExpenseService _expenseservices = new ExpenseService();
        private readonly CategoryServices _categoriesservices = new CategoryServices();
        
        public ActionResult Index()
        {
            List<IncomeViewModel> model = _incomeservices.GetIncomes();
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new IncomeViewModel();
            model.Categories = _categoriesservices.IncomeCategories();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(IncomeViewModel viewModel)
        {
            _incomeservices.Create(viewModel);
            return RedirectToAction("index");
        }

        public ActionResult Edit(string id)
        {
            var income= _incomeservices.GetIncome(id);
            income.Categories = _categoriesservices.IncomeCategories();
            return View(income);
        }
        [HttpPost]
        public ActionResult Edit(IncomeViewModel viewModel)
        {
            _incomeservices.Update(viewModel);
            return RedirectToAction("index");
        }
        public ActionResult Delete(string id)
        {
            _incomeservices.Delete(id);
            return RedirectToAction("index");
        }
        public ActionResult GetIncomeRecords()
        {
            IncomeViewModel viewModel = new IncomeViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult GetIncomeRecords(DateTime start, DateTime end)
        {
            List<IncomeViewModel> model = _incomeservices.GetIncomeRecords(start,end);
            return View(model);
        }
    }
}