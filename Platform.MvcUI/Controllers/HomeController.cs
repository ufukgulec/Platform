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

namespace Platform.MvcUI.Controllers
{
    public class HomeController : Controller
    {
        readonly IGenericService<Tag> tagService = new GenericManager<Tag>(new EfGenericRepository<Tag>());
        readonly IEntryService entryService = new EntryManager(new EfEntryRepository());
        public ActionResult Index()
        {
            return View(entryService.TodayEntryGetAll());
        }
        public PartialViewResult MostPopularTags()
        {
            return PartialView("MostPopularTags", tagService.GetAll().OrderByDescending(x => x.Entries.Count).Take(5).ToList());
        }
        public PartialViewResult MostPopularEntries()
        {
            return PartialView("MostPopularEntries", entryService.ActiveEntryGetAll().OrderByDescending(x => x.Likes.Count).Take(5).ToList());
        }
        public PartialViewResult Tags()
        {
            CacheFonksiyon cacheFonksiyon = new CacheFonksiyon();

            return PartialView("Index", cacheFonksiyon.TagsGet());
        }
    }
}