using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.ViewModel
{
    public class ProfitViewModel
    {
        [DisplayFormat(DataFormatString = "{0:n0}")]
        public Nullable<decimal> TotalIncome { get; set; }

        [DisplayFormat(DataFormatString = "{0:n0}")]
        public Nullable<decimal> TotalExpense { get; set; }
        public Nullable<decimal> Net { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public string Date { get; set; }

    }
}


