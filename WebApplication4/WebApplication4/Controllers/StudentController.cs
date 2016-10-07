using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class StudentController : Controller
    {
      public ActionResult index()
      {
      new Student();
        return View();
      }
    }
}
