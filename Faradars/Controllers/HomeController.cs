using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Faradars.Models;
using Faradars.Models.ViewModel;
using System.Globalization;
using Faradars.Data;
using Faradars.Models.Rep;
using Faradars.Models.DB;

namespace Faradars.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = null;
        public HomeController()
        {
            db = new ApplicationDbContext();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Jostejo(int ostan, DateTime tarikhvorod, DateTime tarikhkhoroj)
        {
            PersianCalendar pc = new PersianCalendar();
            DateTime dtv = new DateTime(tarikhvorod.Year, tarikhvorod.Month, tarikhvorod.Day, pc);
            DateTime dtkh = new DateTime(tarikhkhoroj.Year, tarikhkhoroj.Month, tarikhkhoroj.Day, pc);

            var qhotels = db.hotels
            .Where(a => a.ZamanShoroa <= dtv && a.ZamanPayan >= dtkh && a.Faal == true && dtkh > DateTime.Now && dtv >= DateTime.Today)
            .ToList();

            if (qhotels == null)
                return RedirectToAction(nameof(Index));

            List<int> lstidhotel = new List<int>();
            foreach (var o in qhotels)
            {
                var qjozeyat = db.jozeyatHotels
               .Where(a => a.Jozeyat_OstanID == ostan && a.Jozeyat_HotelID == o.Hotel_ID)
               .FirstOrDefault();

                if (qjozeyat != null)
                    lstidhotel.Add(o.Hotel_ID);
                else
                    lstidhotel.Add(0);

            }

            if (lstidhotel.Count() > 0)
            {
                List<Jostejo> lstjostejo = new List<Jostejo>();
                foreach (var item in lstidhotel)
                {
                    if (item > 0)
                    {
                        var qhotel = db.hotels
                        .Where(a => a.Hotel_ID.Equals(item) && a.ZamanShoroa <= dtv && a.ZamanPayan >= dtkh && a.Faal == true && dtkh > DateTime.Now && dtv >= DateTime.Today)
                        .FirstOrDefault();

                        var qimg = db.tasavirHotels
                            .Where(a => a.Tasavir_IDHotel.Equals(item) && a.Tasavir_Asli.Equals(true))
                            .FirstOrDefault();


                        var qjozyat = db.jozeyatHotels
                            .Where(a => a.Jozeyat_HotelID.Equals(item))
                            .FirstOrDefault();

                        if (qjozyat == null)
                            return RedirectToAction(nameof(Index));

                        var qnameostan = db.ostanHotels.Where(a => a.Ostan_ID.Equals(qjozyat.Jozeyat_OstanID)).FirstOrDefault().Ostan_Name;
                        var qstareh = db.tedadStarehs.Where(a => a.TedadStareh_ID.Equals(qjozyat.Jozeyat_TedadStareID)).FirstOrDefault().TedadStareh_Name;

                        if (qstareh == null || qnameostan == null || qimg == null || qhotel == null)
                            return RedirectToAction(nameof(Index));

                        Jostejo j = new Jostejo();
                        j.GheymatYekShab = qhotel.Jozeyat_Gheymat;
                        j.HotelID = qhotel.Hotel_ID;
                        j.imgUrl = "/img/img/" + qimg.Tasavir_Name + "";
                        j.Nameostan = qnameostan;
                        j.Stareh = qstareh;
                        j.NameHotel = qhotel.Name_Hotel;
                        lstjostejo.Add(j);
                    }

                }

                string khroj = string.Format("{0}/{1}/{2}", pc.GetYear(dtkh), pc.GetMonth(dtkh), pc.GetDayOfMonth(dtkh));
                string vorod = string.Format("{0}/{1}/{2}", pc.GetYear(dtv), pc.GetMonth(dtv), pc.GetDayOfMonth(dtv));

                ViewData["khoroj"] = khroj;
                ViewData["vorod"] = vorod;
                return View(lstjostejo);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

        }

        public IActionResult Details(int id, DateTime vorod, DateTime khoroj)
        {
            Page_Rep page_Rep = new Page_Rep();
            var qpage = page_Rep.GetPage(id);


            PersianCalendar pc = new PersianCalendar();
            DateTime dtv = new DateTime(vorod.Year, vorod.Month, vorod.Day, pc);
            DateTime dtkh = new DateTime(khoroj.Year, khoroj.Month, khoroj.Day, pc);

            string dtk1 = string.Format("{0}/{1}/{2}", pc.GetYear(dtkh), pc.GetMonth(dtkh), pc.GetDayOfMonth(dtkh));
            string dtv1 = string.Format("{0}/{1}/{2}", pc.GetYear(dtv), pc.GetMonth(dtv), pc.GetDayOfMonth(dtv));


            if (dtk1 == "1/1/1")
            {
                DateTime dt1 = DateTime.Today;
                DateTime dt2 = DateTime.Today.AddDays(1);
                string dtk2 = string.Format("{0}/{1}/{2}", pc.GetYear(dt2), pc.GetMonth(dt2), pc.GetDayOfMonth(dt2));
                string dtv2 = string.Format("{0}/{1}/{2}", pc.GetYear(dt1), pc.GetMonth(dt1), pc.GetDayOfMonth(dt1));

                ViewData["khoroj"] = dtk2;
                ViewData["vorod"] = dtv2;
            }
            else
            {
                ViewData["khoroj"] = dtk1;
                ViewData["vorod"] = dtv1;
            }


            return View(qpage);
        }

        public IActionResult Sabtnazar(int idhotel, string email, string name, string mozoa, string matn, int emtyaz)
        {

            if (idhotel == 0 && email == null && matn == null)
                return RedirectToAction("Details", "Home", new { id = idhotel });

            Nazarat n = new Nazarat();
            n.Nazarat_Email = email;
            n.Nazarat_Emtyaz = emtyaz;
            n.Nazarat_HotelID = idhotel;
            n.Nazarat_Matn = matn;
            n.Nazarat_Name = name;
            n.Nazarat_Zaman = Convert.ToString(DateTime.Now);
            db.nazarats.Add(n);
            db.SaveChanges();
            return RedirectToAction("Details", "Home", new { id = idhotel });

        }

        public IActionResult Entekhab(DateTime tarikhvorod, DateTime tarikhkhoroj, string tedadtakht, string zarfeyat, int id)
        {

            Page_Rep r = new Page_Rep();
            var qpage = r.GetNemayeshHotel(tarikhvorod, tarikhkhoroj, tedadtakht, zarfeyat, id);
            ViewData["vorod"] = tarikhvorod;
            ViewData["khoroj"] = tarikhkhoroj;
            ViewData["id"] = id;
            return View(qpage);
        }



    }
}

