
using PersonalAccounting.Data;
using PersonalAccounting.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.Service
{
    public class IncomeService
    {
        private readonly AccountingEntities _context = new AccountingEntities();
        public List<IncomeViewModel> GetIncomes()
        {
            var model = _context.Incomes
                .Select(i => i)
                .ToList();

            List<IncomeViewModel> viewModel = new List<IncomeViewModel>();
            foreach (var a in model)
            {
                var incomeViewModel = new IncomeViewModel();
                incomeViewModel.Id = a.Id;
                incomeViewModel.Amt = a.Amt;
                incomeViewModel.Date = a.Date;
                incomeViewModel.CategoryName = _context.Categories
                    .Where(i => i.Id == a.CategoryId)
                    .Select(i => i.Name)
                    .FirstOrDefault();
                viewModel.Add(incomeViewModel);
            }
            return viewModel;
        }

        public IncomeViewModel GetIncome(string id)
        {
            IncomeViewModel viewModel = _context.Incomes
                .Where(i => i.Id == id)
                .Select(i => new IncomeViewModel
                {
                    Id = i.Id,
                    Amt = i.Amt,
                    Date = i.Date,
                    CategoryId = i.CategoryId
                })
                .FirstOrDefault();
            return viewModel;
        }

        public void Create(IncomeViewModel viewModel)
        {
            var Entity = new Income();
            Entity.Id = Guid.NewGuid().ToString();
            Entity.Amt = viewModel.Amt;
            Entity.Date = viewModel.Date;
            Entity.CategoryId = viewModel.CategoryId;
            Entity.isDelete = false;
            _context.Incomes.Add(Entity);
            _context.SaveChanges();
        }

        public void Update(IncomeViewModel incomeViewModel)
        {
            var Entity = _context.Incomes
                .Where(b => b.Id == incomeViewModel.Id)
                .FirstOrDefault();

            if (Entity != null)
            {
                Entity.Amt = incomeViewModel.Amt;
                Entity.Date = incomeViewModel.Date;
                Entity.CategoryId = incomeViewModel.CategoryId;
                _context.SaveChanges();
            }

        }

        public void Delete(string id)
        {
            Income income = _context.Incomes
                 .Where(c => c.Id == id)
                 .FirstOrDefault();
            if (income != null)
            {
                _context.Incomes.Remove(income);
                _context.SaveChanges();
            }
        }

        public List<IncomeViewModel> GetIncomeRecords(DateTime start, DateTime end)
        {
            var model = _context.GetIncomeRecords(start, end)
                .Select(i => i)
                .ToList();

            List<IncomeViewModel> viewModel = new List<IncomeViewModel>();
            foreach (var i in model)
            {
                var getIncome = new IncomeViewModel();
                getIncome.Id = i.Id;
                getIncome.Amt = i.Amt;
                getIncome.Date = i.Date;
                getIncome.CategoryName = _context.Categories
                     .Where(c => c.Id == i.CategoryId)
                     .Select(c => c.Name)
                     .FirstOrDefault();
                viewModel.Add(getIncome);
            }
            return viewModel;
        }
    }
}
