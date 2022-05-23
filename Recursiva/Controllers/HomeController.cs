using Recursiva.Logic;
using System;
using System.Web;
using System.Web.Mvc;

namespace Recursiva.Controllers
{
    public class HomeController : Controller
    {
        Process logic = new Process();

        public ActionResult Index()
        {
            ViewBag.Title = "Challenge Superliga - Recursiva";
            ViewBag.ImagePath = "~favicon.ico";
            return View();
        }
        public ActionResult ProcessFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProcessFile(HttpPostedFileBase file)
        {
            try
            {
                return View("ProcessFile", logic.ProcessFile(file));
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View("Index");
            }
        }
    }
}