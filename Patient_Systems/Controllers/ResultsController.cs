using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Patient_Systems.Models;
using Rotativa;
using Rotativa.MVC;

namespace Patient_Systems.Controllers

{
    //[Authorize(Roles = "employee")]

    public class ResultsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Results
        public ActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                var data = db.results.SqlQuery("[dbo].[Get_ALL_Results]").ToList();
                return View(data);
            }

        }
        public ActionResult Print()
        {
            var p = new ActionAsPdf("Index");
            return p;
        }
    }



    }