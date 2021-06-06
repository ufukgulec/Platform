using Platform.Business;
using Platform.Dal.Abstract;
using Platform.Dal.Concrete.EntityFramework.Repository;
using Platform.Entities.Models;
using Platform.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Platform.MvcUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        readonly IEntryService entryService;

        public HomeController(IEntryService entryService)
        {
            this.entryService = entryService;
        }
        public ActionResult Index()
        {
            return View(entryService.List());
        }
    }
}