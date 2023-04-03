using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BoardGameListApp.Models
{
    public class BoardGame
    {
        public int ID { get; set; }
        [Display(Name = "Board Game Title")]
        public string Title { get; set; }
        public int? CompanyID { get; set; }
        public virtual Company Company { get; set; }
        public int? BoardGameTypeId { get; set; }
        public virtual BoardGameType BoardGameType { get; set; }


    }
}