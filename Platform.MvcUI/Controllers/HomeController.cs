using Platform.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Platform.Entities.Models;
using Platform.Business;
using Platform.Dal.Concrete.EntityFramework.Repository;

namespace Platform.MvcUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            IGenericService<Entry> parentService = new GenericManager<Entry>(new EfGenericRepository<Entry>());
            return View();
        }
    }
}