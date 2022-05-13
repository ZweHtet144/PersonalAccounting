using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.ViewModel
{
    public class IncomeViewModel
    {

        public string Id { get; set; }

        [Required]
        [DisplayFormat(DataFormatString ="{0:dd MMM yyyy}")]
        public Nullable<System.DateTime> Date { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        [Display(Name = "Amount")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Enter only numeric number")]
        public Nullable<decimal> Amt { get; set; }
        public string CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }
        public Nullable<bool> isDelete { get; set; }
        public string ExpenseId { get; set; }
        public List<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
