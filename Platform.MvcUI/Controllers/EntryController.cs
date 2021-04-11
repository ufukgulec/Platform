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

        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return View(entryService.EntryList());
            }
            else
            {
                return View(entryService.EntryList(x => x.TagID == id));
            }
        }
        public PartialViewResult TodayEntryGetAll()
        {
            return PartialView(entryService.TodayEntries());
        }

        public PartialViewResult Post()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Post(Entry entry)
        {
            entryService.Post(entry);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            entryService.Delete(id);
            return RedirectToAction("Index");
        }
        public PartialViewResult MostPopularEntries()
        {
            return PartialView("MostPopularEntries", entryService.EntryList().OrderByDescending(x => x.Likes.Count).Take(5).ToList());
        }
    }
}