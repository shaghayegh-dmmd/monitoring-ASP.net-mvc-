using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cr24.Monitoring.Models;
using System.Timers;
using System.Data;

namespace Cr24.Monitoring.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            var mdl = new List<ServiceStatusData>()
            {

                new ServiceStatusData() { Name = "ثبت احوال", Total = 10 , Error = 1,Percent = 40 ,LeadingToError = true},
                new ServiceStatusData() { Name = "شاهکار", Total = 20, Error = 2, Percent = 60, LeadingToError = false },
                new ServiceStatusData() { Name = "پست", Total = 30, Error = 0, Percent = 80, LeadingToError = true },
                new ServiceStatusData() { Name = "تسهیلات", Total = 40, Error = 3, Percent = 100, LeadingToError = false },
                new ServiceStatusData() { Name = "چک برگشتی", Total = 5, Error = 0, Percent = 90, LeadingToError = true },
                 new ServiceStatusData() { Name = "سما چک", Total = 20, Error = 2, Percent = 60, LeadingToError = false },
                new ServiceStatusData() { Name = "سمارفع سو", Total = 30, Error = 0, Percent = 80, LeadingToError = true },
                new ServiceStatusData() { Name = "سمات اصلی", Total = 40, Error = 3, Percent = 100, LeadingToError = false },
                new ServiceStatusData() { Name = "سمات ضامن", Total = 30, Error = 0, Percent = 80, LeadingToError = true },
                new ServiceStatusData() { Name = "سمات تسویه", Total = 40, Error = 3, Percent = 100, LeadingToError = false }
            };


            Random rnd = new Random();
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromSeconds(30);

            var timer = new System.Threading.Timer((e) =>
            {
               
                mdl.Find(o => o.Name == "ثبت احوال").Percent = rnd.Next(0, 100);
                mdl.Find(o => o.Name == "شاهکار").Percent = rnd.Next(0, 100);
                mdl.Find(o => o.Name == "پست").Percent = rnd.Next(0, 100);
                mdl.Find(o => o.Name == "تسهیلات").Percent = rnd.Next(0, 100);
                mdl.Find(o => o.Name == "چک برگشتی").Percent = rnd.Next(0, 100);
                mdl.Find(o => o.Name == "سما چک").Percent = rnd.Next(0, 100);
                mdl.Find(o => o.Name == "سمارفع سو").Percent = rnd.Next(0, 100);
                mdl.Find(o => o.Name == "سمات اصلی").Percent = rnd.Next(0, 100);
                mdl.Find(o => o.Name == "سمات ضامن").Percent = rnd.Next(0, 100);
                mdl.Find(o => o.Name == "سمات تسویه").Percent = rnd.Next(0, 100);


            }, null, startTimeSpan, periodTimeSpan);


            return View(mdl);
            
        }


        public ActionResult LoadMenu()
        {


            MenuModel menuModel = CreateActionMenu();


            return PartialView("_PartialMenu", menuModel);
        }

        private MenuModel CreateActionMenu()
        {

            MenuModel menuModel = new MenuModel()
            {
                Id = 1,
                ChildList = new List<MenuModel>()
            };


                menuModel.ChildList.Add(new MenuModel()
                {
                    Id = 2,
                    ParentId = 1,
                    DisplayName = "مانیتورینگ",
                    ControlName = "Home",
                    ActionName = "Index",

                });
          


            
                menuModel.ChildList.Add(new MenuModel()
                {
                    Id = 3,
                    ParentId = 1,
                    DisplayName = "آموزش",
                    ControlName = "OfficialFile",
                    ActionName = "GetAllFileContentLearnIndex",

                });

            
                menuModel.ChildList.Add(new MenuModel()
                {
                    Id = 4,
                    ParentId = 1,
                    DisplayName = "فنی",
                    ControlName = "OfficialFile",
                    ActionName = "GetAllFileContentTechIndex",

                });
           
            return menuModel;
        }

    }
}