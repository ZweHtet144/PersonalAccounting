using PersonalAccounting.Service;
using PersonalAccounting.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalAccounting.Web.Controllers
{
    public class ProfitController : Controller
    {
        private readonly ProfitService _services = new ProfitService();
        // GET: Profit
        public ActionResult Index()
        {
            List<ProfitViewModel> model = _services.ShowProfits();
            return View(model);
        }
        public ActionResult Detalis(DateTime date)
        {
            var model = new ProfitViewModel();
            model = _services.Show(date);
            return View(model);
        }
    }
}