using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BoardGameListApp.Models
{
    public class Company
    {
        public int ID { get; set; }
        [Display(Name = "Games Company")]
        public string Name { get; set; }
        public virtual ICollection<BoardGame> BoardGames { get; set; }
    }
}