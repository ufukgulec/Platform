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
        ILikeService likeService;
        public EntryController(IEntryService entryService, ILikeService likeService)
        {
            this.entryService = entryService;
            this.likeService = likeService;
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
            Thread.Sleep(5000);
            return PartialView("MostPopularEntries", entryService.PopularEntries(5));
        }
        public ActionResult Like(int id)
        {
            Like like = new Like
            {
                LikeDate = DateTime.Now.Date,
                EntryID = id,
                PersonID = 1
            };
            likeService.Add(like);
            return RedirectToAction("Index");
        }
    }
}