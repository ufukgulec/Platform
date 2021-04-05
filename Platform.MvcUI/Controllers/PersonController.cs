using Platform.Business;
using Platform.Dal.Concrete.EntityFramework.Repository;
using Platform.Entities.Models;
using Platform.Interfaces;
using Platform.MvcUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Platform.MvcUI.Controllers
{
    public class PersonController : Controller
    {
        IPersonService personService = new PersonManager(new EfPersonRepository());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(ViewPersonLogin person)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = personService.Login(person.Username, person.Password);
                    if (user != null)
                    {
                        Session["User"] = user;
                        return RedirectToAction("Index", "Home");
                    }

                }
                else
                {
                    return View(person);
                }
            }
            catch (Exception error)
            {
                ModelState.AddModelError("", error.Message);
                return View(person);
            }
            return View(person);

        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Person person)
        {
            return View();
        }
    }
}