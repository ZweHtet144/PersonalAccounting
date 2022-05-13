using PersonalAccounting.Data;
using PersonalAccounting.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.Service
{
    public class ExpenseService
    {
        private readonly AccountingEntities _context = new AccountingEntities();
        public List<ExpenseViewModel> GetExpenses()
        {
            var model = _context.Expenses
                .Select(e => e)
                .ToList();

            List<ExpenseViewModel> viewModel = new List<ExpenseViewModel>();
            foreach (var a in model)
            {
                var expenseViewModel = new ExpenseViewModel();
                expenseViewModel.Id = a.Id;
                expenseViewModel.Amt = a.Amt;
                expenseViewModel.Date = a.Date;
                expenseViewModel.CategoryName = _context.Categories
                    .Where(i => i.Id == a.CategoryId)
                    .Select(i => i.Name)
                    .FirstOrDefault();
                viewModel.Add(expenseViewModel);
            }
            return viewModel;
        }

        public ExpenseViewModel GetExpense(string id)
        {
            ExpenseViewModel viewModel = _context.Expenses
                .Where(e => e.Id == id)
                .Select(i => new ExpenseViewModel
                {
                    Id = i.Id,
                    Amt = i.Amt,
                    Date = i.Date,
                    CategoryId = i.CategoryId
                })
                .FirstOrDefault();
            return viewModel;
        }

        public void Create(ExpenseViewModel viewModel)
        {
            var Entity = new Expense();
            Entity.Id = Guid.NewGuid().ToString();
            Entity.Amt = viewModel.Amt;
            Entity.Date = viewModel.Date;
            Entity.CategoryId = viewModel.CategoryId;
            Entity.isDelete = false;
            _context.Expenses.Add(Entity);
            _context.SaveChanges();
        }

        public void Update(ExpenseViewModel expenseViewModel)
        {
            var Entity = _context.Expenses
                .Where(e => e.Id == expenseViewModel.Id)
                .FirstOrDefault();

            if (Entity != null)
            {
                Entity.Amt = expenseViewModel.Amt;
                Entity.Date = expenseViewModel.Date;
                Entity.CategoryId = expenseViewModel.CategoryId;
                _context.SaveChanges();
            }

        }

        public void Delete(string id)
        {
            Expense expense = _context.Expenses
                 .Where(e => e.Id == id)
                 .FirstOrDefault();
            if (expense != null)
            {
                _context.Expenses.Remove(expense);
                _context.SaveChanges();
            }
        }

        public List<ExpenseViewModel> GetExpenseRecords(DateTime start, DateTime end)
        {
            var model = _context.GetExpenseRecords(start, end)
                .Select(e => e)
                .ToList();

            List<ExpenseViewModel> viewModel = new List<ExpenseViewModel>();
            foreach (var i in model)
            {
                var getExpense = new ExpenseViewModel();
                getExpense.Id = i.Id;
                getExpense.Amt = i.Amt;
                getExpense.Date = i.Date;
                getExpense.CategoryName = _context.Categories
                     .Where(e => e.Id == i.CategoryId)
                     .Select(e => e.Name)
                     .FirstOrDefault();
                viewModel.Add(getExpense);
            }
            return viewModel;
        }

    }
}
