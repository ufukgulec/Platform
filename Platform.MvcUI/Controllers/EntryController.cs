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
        IPersonService personService;
        public EntryController(IEntryService entryService, ILikeService likeService, IPersonService personService)
        {
            this.entryService = entryService;
            this.likeService = likeService;
            this.personService = personService;
        }

        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                var list = entryService.List();
                return View(list);
            }
            else
            {
                var list = entryService.List(x => x.TagID == id);
                return View(list);
            }
        }
        public ActionResult Detail(int id)
        {
            return View(entryService.Get(id));
        }
        public PartialViewResult GetEntries(int? id)
        {
            if (id == null)
            {
                var list = entryService.List();
                return PartialView(list);
            }
            else
            {
                var list = entryService.List(x => x.TagID == id);
                return PartialView(list);
            }
        }
        public PartialViewResult TodayEntryGetAll()
        {
            return PartialView(entryService.TodayEntries());
        }
        public PartialViewResult MostPopularEntries()
        {
            return PartialView("MostPopularEntries", entryService.PopularEntries(5));
        }
        public PartialViewResult Post()
        {
            ViewBag.username = personService.Get(Convert.ToInt32(HttpContext.User.Identity.Name)).Username;
            ViewBag.personID = personService.Get(Convert.ToInt32(HttpContext.User.Identity.Name)).PersonID;
            ViewBag.personImg = personService.Get(Convert.ToInt32(HttpContext.User.Identity.Name)).PersonImgUrl;
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
        public PartialViewResult Like(int id)
        {
            likeService.LikeOrDislike(id, Convert.ToInt32(HttpContext.User.Identity.Name));
            return PartialView(entryService.Get(id));
        }
    }
}