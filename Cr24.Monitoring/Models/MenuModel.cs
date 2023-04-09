using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cr24.Monitoring.Models
{
    public class MenuModel
    {

        public MenuModel()
        {
            ChildList = new List<MenuModel>();
        }
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string ActionName { get; set; }
        public string ControlName { get; set; }
        public int? ParentId { get; set; }
        public List<MenuModel> ChildList { get; set; }
    }
}