using Platform.Business;
using Platform.Dal.Concrete.EntityFramework.Repository;
using Platform.Entities.Models;
using Platform.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Platform.MvcUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            IEntryService service = new EntryManager(new EfEntryRepository());
            var list = service.ActiveEntryGetAll(x=>x.PersonID==1);
            int a = 10;
            return View();
        }
    }
}