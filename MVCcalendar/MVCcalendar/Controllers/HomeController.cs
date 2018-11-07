using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCcalendar.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEvents()
        {
            using (DatabaseEntities dc = new DatabaseEntities())
            {
                var events = dc.Appointments.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        public ActionResult Contacts()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SaveEvent(Appointment e)
        {
            var status = false;
            using (DatabaseEntities dc = new DatabaseEntities())
            {
                if (e.userId > 0)
                {
                    //Update the event
                    var v = dc.Appointments.Where(a => a.userId == e.userId).FirstOrDefault();
                    if (v != null)
                    {
                        v.Name = e.Name;
                        v.Start = e.Start;
                        v.End = e.End;
                        v.Pname = e.Pname;
                        v.IsFullDay = e.IsFullDay;
                        v.ThemeColor = e.ThemeColor;
                    }
                }
                else
                {
                    dc.Appointments.Add(e);
                }
                dc.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int userID)
        {
            var status = false;
            using (DatabaseEntities dc = new DatabaseEntities())
            {
                var v = dc.Appointments.Where(a => a.userId == userID).FirstOrDefault();
                if (v != null)
                {
                    dc.Appointments.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }


    }
}