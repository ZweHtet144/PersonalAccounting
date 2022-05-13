using PersonalAccounting.Data;
using PersonalAccounting.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.Service
{
    public class CategoryServices
    {
        private readonly AccountingEntities _context = new AccountingEntities();
        public List<CategoryViewModel> GetCategories()
        {
            List<CategoryViewModel> categories = new List<CategoryViewModel>();
            categories = _context.Categories
              
               .Select(c => new CategoryViewModel
               {
                   Id = c.Id,
                   Name = c.Name,
                   Type=c.Type
               })
               .ToList();
            return categories;
        }

        public CategoryViewModel GetCategory(string id)
        {
            CategoryViewModel viewModel = _context.Categories
                .Where(b => b.Id == id)
                .Select(b => new CategoryViewModel
                {
                    Id = b.Id,
                    Name = b.Name,
                    Type=b.Type
                })
                .FirstOrDefault();
            return viewModel;
        }

        public void Create(CategoryViewModel viewModel)
        {
            var Entity = new Category();
            Entity.Id = Guid.NewGuid().ToString();
            Entity.Name = viewModel.Name;
            Entity.Type = viewModel.Type;
            Entity.isDelete = false;
            _context.Categories.Add(Entity);
            _context.SaveChanges();
        }

        public void Update(CategoryViewModel categoryViewModel)
        {
            var Entity = _context.Categories
                .Where(b => b.Id == categoryViewModel.Id)
                .FirstOrDefault();

            if (Entity != null)
            {
                Entity.Name = categoryViewModel.Name;
                Entity.Type = categoryViewModel.Type;
                _context.SaveChanges();
            }

        }

        public void Delete(string id)
        {
           Category category = _context.Categories
                .Where(c => c.Id == id)
                .FirstOrDefault();
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }
        public List<CategoryViewModel>IncomeCategories()
        {
            List<CategoryViewModel> categories = new List<CategoryViewModel>();
            categories = _context.Categories
               .Where(c => c.Type!=false)
               .Select(c => new CategoryViewModel
               {
                   Id = c.Id,
                   Name = c.Name
               })
               .ToList();
            return categories;
        }

        public List<CategoryViewModel> ExpenseCategories()
        {
            List<CategoryViewModel> categories = new List<CategoryViewModel>();
            categories = _context.Categories
               .Where(c => c.Type != true)
               .Select(c => new CategoryViewModel
               {
                   Id = c.Id,
                   Name = c.Name
               })
               .ToList();
            return categories;
        }
    }
}
