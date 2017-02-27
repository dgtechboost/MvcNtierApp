using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcNtierApp.Core;

namespace MvcNtierApp.Controllers
{
    public class TicketsController : Controller
    {
        // GET: Tickets
        public ActionResult Index()
        {
            TicketManager ticketManager  = new TicketManager();

            var listOfItems = ticketManager.Get();
            if (listOfItems != null)
            {
                return View(listOfItems.ToList());
            }
            return RedirectToAction("Home", "Tickets");
        }

        public ActionResult Home()
        {
                return View();
        }
    }
}