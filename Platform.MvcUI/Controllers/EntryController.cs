using Platform.Entities.Models;
using Platform.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        public PartialViewResult TodayEntryGetAll()
        {
            return PartialView(entryService.TodayEntryGetAll());
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
        public PartialViewResult MostPopularEntries()
        {
            Thread.Sleep(5000);
            return PartialView("MostPopularEntries", entryService.ActiveEntryGetAll().OrderByDescending(x => x.Likes.Count).Take(5).ToList());
        }
    }
}