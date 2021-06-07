using Platform.Business;
using Platform.Dal.Concrete.EntityFramework.Repository;
using Platform.Entities.Models;
using Platform.Interfaces;
using Platform.MvcUI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Platform.MvcUI.Controllers
{
    public class PersonController : Controller
    {
        IPersonService personService = new PersonManager(new EfPersonRepository());
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
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
                        FormsAuthentication.SetAuthCookie(user.Username, false);
                        Session["user-photo"] = user.PersonImgUrl;
                        Session["PersonID"] = user.PersonID;
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
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(Person person)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Request.Files.Count > 0)
                    {
                        string FileName = Path.GetFileName(person.Username);
                        string FileTypeName = Path.GetExtension(Request.Files[0].FileName);
                        string path = "/Content/ProfileImages/" + FileName + FileTypeName;
                        Request.Files[0].SaveAs(Server.MapPath(path));
                        person.PersonImgUrl = path;
                    }
                    personService.Register(person);
                    return RedirectToAction("Login");
                }
            }
            catch (Exception)
            {

                return View(person);
            }
            return View(person);
        }
    }
}