using Platform.Entities.Models;
using Platform.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Platform.MvcUI.Controllers
{
    public class EntryController : Controller
    {
        IEntryService entryService;

        public EntryController(IEntryService entryService)
        {
            this.entryService = entryService;
        }

        public ActionResult Index()
        {
            return View(entryService.ActiveEntryGetAll());
        }
        public ActionResult Post()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Post(Entry entry)
        {
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            entryService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}