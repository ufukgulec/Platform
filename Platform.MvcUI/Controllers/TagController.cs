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
        ITagService tagService;
        public TagController(ITagService tagService)
        {
            this.tagService = tagService;
        }
        public ActionResult Index()
        {

            var tagList = tagService.TagList();
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
            Thread.Sleep(2000);
            return PartialView("MostPopularTags", tagService.GetAll().OrderByDescending(x => x.Entries.Count).Take(5).ToList());
        }

        /// <summary>
        /// Entry Post işleminde konu seçimi için
        /// </summary>
        /// <returns></returns>
        public PartialViewResult TagSelectList()
        {
            return PartialView("TagSelectList", tagService.GetAll());
        }
    }
}