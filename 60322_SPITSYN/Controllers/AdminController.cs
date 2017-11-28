using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.DAL.Entities;
using Shop.DAL.Repositories;
using Shop.DAL.Interfaces;

namespace _60322_SPITSYN.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        IRepository<SportInv> repository;

        public AdminController(IRepository<SportInv> repos)
        {
            repository = repos;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View(repository.GetAllSportInvs());
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View(new SportInv());
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(SportInv ap, HttpPostedFileBase imageUpload = null)
        {
            if (ModelState.IsValid)
            {
                if (imageUpload != null)
                {
                    var count = imageUpload.ContentLength;
                    ap.Image = new byte[count];
                    imageUpload.InputStream.Read(ap.Image, 0, (int)count);
                    ap.MimeType = imageUpload.ContentType;
                }
                try
                {
                    repository.CreateSportInv(ap);

                    return RedirectToAction("Index");
                }
                catch
                {
                    //return View(ap);
                    return View();
                }
            }
            else return View(ap);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repository.GetSportInv(id));
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(SportInv ap, HttpPostedFileBase imageUpload = null)
        {
            if (imageUpload != null)
            {
                var count = imageUpload.ContentLength;
                ap.Image = new byte[count];
                imageUpload.InputStream.Read(ap.Image, 0, (int)count);
                ap.MimeType = imageUpload.ContentType;
            }
            try
            {
                repository.UpdateSportInv(ap);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(ap);
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            repository.DeleteSportInv(id);
            return RedirectToAction("Index");
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
