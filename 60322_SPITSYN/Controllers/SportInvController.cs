using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;
using _60322_SPITSYN.Models;
using System.Drawing;
using System.Threading.Tasks;

namespace _60322_SPITSYN.Controllers
{
    public class SportInvController : Controller
    {
        IRepository<SportInv> repository;
        int pageSize = 3;

        //хочу, для объектов, не имеющих фото, возвращать  imageToView (для метода GetImage)
        Type type;
        byte[] imageToView;


        public SportInvController(IRepository<SportInv> repos)
        {
            repository = repos;

            //заполняю type и imageToView
            Image image = Image.FromFile(@"E:\учёба\60322_SPITSYN_LB7\60322_SPITSYN\Images\photo.png");
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            imageToView = memoryStream.ToArray();
            type = image.GetType();
        }

        // GET: SportInv
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult List()
        //{
        //    return View(repsitory.GetAllSportInvs());
        //}

        //ЛБ4
        //public ActionResult List(int page = 1)
        //{
        //    var lst = repsitory.GetAllSportInvs().OrderBy(ap => ap.Weight);
        //    return View(PageListViewModel<SportInv>.CreatePage(lst, page,pageSize));
        //}

        //ЛБ5
        public ActionResult List(string category, int page = 1)
        {
            var itemsList = repository.GetAllSportInvs()
                                        .Where(d => category == null || d.GroupName.Equals(category))
                                        .OrderBy(d => d.Weight);
            var model = PageListViewModel<SportInv>.CreatePage(itemsList, page, pageSize);
            if (Request.IsAjaxRequest())
            {
                return PartialView("ListViewPatial", model);
            }
            return View(model);
        }

        //public FileContentResult GetImage(int SportInvId)
        //{
        //    SportInv ap = repository.GetSportInv(SportInvId);

        //    if (ap != null && ap.Image != null)
        //        return File(ap.Image, ap.MimeType);
        //    else
        //    {
        //        return File(imageToView, type.ToString()); ;
        //    }
        //}

        public async Task<FileContentResult> GetImage(int SportInvId)
        {
            SportInv ap = await repository.GetSportInvAsync(SportInvId);

            if (ap != null && ap.Image != null)
                return File(ap.Image, ap.MimeType);
            else
            {
                return File(imageToView, type.ToString()); ;
            }
        }
    }
}