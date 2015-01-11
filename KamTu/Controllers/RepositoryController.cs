using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KamTu.Models;
using System.Collections;
using System.Diagnostics;

namespace KamTu.Controllers
{
    public class RepositoryController : Controller
    {
        //
        // GET: /Repository/
        IKamtu kamtuRepository = new KamtuRepository();

        public ActionResult DisplayDriversParaOrigen(string Origen)
        {
            Debug.WriteLine("en repocontroller");
           List<Driver> drivers = kamtuRepository.dameDriversDeUnOrigen(Origen);

           return View("indexdrivers",drivers);
        }

    }
}
