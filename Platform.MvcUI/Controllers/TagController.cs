using Platform.Business;
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
    public class TagController : Controller
    {
        readonly IGenericService<Tag> tagService = new GenericManager<Tag>(new EfGenericRepository<Tag>());
        //CacheFonksiyon cacheFonksiyon = new CacheFonksiyon();
        public ActionResult Index()
        {
            var tagList = tagService.GetAll().OrderByDescending(x=>x.Entries.Count).ToList();
            return View(tagList);
        }
        [HttpPost]
        public ActionResult TagAdd(Tag tag)
        {
            tag.IsValid = true;
            tagService.Add(tag);

            return RedirectToAction("Index");
        }
        public PartialViewResult MostPopularTags()
        {
            Thread.Sleep(5000);
            return PartialView("MostPopularTags", tagService.GetAll().OrderByDescending(x => x.Entries.Count).Take(5).ToList());
        }

        public PartialViewResult TagSelectList()
        {
            return PartialView("TagSelectList", tagService.GetAll());
        }
    }
}