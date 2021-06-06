﻿using Platform.Entities.Models;
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
            Thread.Sleep(2000);
            return PartialView("MostPopularEntries", entryService.PopularEntries(5));
        }
        public PartialViewResult Post()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Post(Entry entry)
        {
            entry.EntryDate = DateTime.Now.Date;
            entry.IsValid = true;
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
            Like like = new Like
            {
                LikeDate = DateTime.Now.Date,
                EntryID = id,
                PersonID = 1//Authroize ile 
            };
            likeService.Add(like);

            return PartialView(entryService.Get(id));
        }
    }
}