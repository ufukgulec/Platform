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

            var tagList = tagService.List();
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
            return PartialView("MostPopularTags", tagService.PopularTags());
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