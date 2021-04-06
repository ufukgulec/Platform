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
        CacheFonksiyon cacheFonksiyon = new CacheFonksiyon();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult MostPopularTags()
        {
            Thread.Sleep(2000);
            return PartialView("MostPopularTags", tagService.GetAll().OrderByDescending(x => x.Entries.Count).Take(5).ToList());
        }

        public PartialViewResult TagSelectList()
        {
            return PartialView("TagSelectList", cacheFonksiyon.TagsGet());
        }
    }
}