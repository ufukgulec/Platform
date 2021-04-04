using Platform.Business;
using Platform.Dal.Abstract;
using Platform.Dal.Concrete.EntityFramework.Repository;
using Platform.Entities.Models;
using Platform.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Platform.MvcUI.Controllers
{
    public class HomeController : Controller
    {
        readonly IGenericService<Tag> tagService = new GenericManager<Tag>(new EfGenericRepository<Tag>());
        public ActionResult Index()
        {
            return View();
        }
    }
}