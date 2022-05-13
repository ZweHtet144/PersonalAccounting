using PersonalAccounting.Data;
using PersonalAccounting.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.Service
{
    public class ProfitService
    {
        private readonly AccountingEntities _context = new AccountingEntities();
        public List<ProfitViewModel> ShowProfits()
        {
            var model = _context.NetProfit()
                 .Select(p => p)
                 .ToList();

            List<ProfitViewModel> viewModel = new List<ProfitViewModel>();
            foreach (var i in model)
            {
                var profitViewModel = new ProfitViewModel();
                profitViewModel.TotalIncome = i.totalincome;
                profitViewModel.TotalExpense = i.totalexpense;
                profitViewModel.Net = i.Net;
                profitViewModel.Date = i.TotalDate;
                viewModel.Add(profitViewModel);
            }
            return viewModel;
        }

        public ProfitViewModel Show(DateTime date)
        {
            ProfitViewModel viewModel = _context.NetProfit()
                .Where(i => i.TotalDate == date.ToString())
                .Select(i => new ProfitViewModel
                {
                    TotalIncome = i.totalincome,
                    TotalExpense = i.totalexpense,
                    Net = i.Net
                })
                .FirstOrDefault();
               
            return viewModel;
        }
    }
}
