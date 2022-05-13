using PersonalAccounting.Service;
using PersonalAccounting.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalAccounting.Web.Controllers
{
    public class ExpenseController : Controller
    {
        // GET: Expense
        private readonly  ExpenseService _expenseservices = new ExpenseService();
        private readonly CategoryServices _categoriesservices = new CategoryServices();
        public ActionResult Index()
        {
            List<ExpenseViewModel> model = _expenseservices.GetExpenses();
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new ExpenseViewModel();
            model.Categories = _categoriesservices.ExpenseCategories();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(ExpenseViewModel viewModel)
        {
            _expenseservices.Create(viewModel);
            return RedirectToAction("index");
        }

        public ActionResult Edit(string id)
        {
            var expense = _expenseservices.GetExpense(id);
            expense.Categories = _categoriesservices.ExpenseCategories();
            return View(expense);
        }
        [HttpPost]
        public ActionResult Edit(ExpenseViewModel viewModel)
        {
            _expenseservices.Update(viewModel);
            return RedirectToAction("index");
        }
        public ActionResult Delete(string id)
        {
            _expenseservices.Delete(id);
            return RedirectToAction("index");
        }

        public ActionResult GetExpenseRecords()
        {
            ExpenseViewModel viewModel = new ExpenseViewModel();
            return View("viewModel");
        }
        [HttpPost]
        public ActionResult GetExpenseRecords(DateTime start, DateTime end)
        {
            List<ExpenseViewModel> model = _expenseservices.GetExpenseRecords(start, end);
            return View(model);
        }
    }
}