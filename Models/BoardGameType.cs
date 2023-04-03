using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BoardGameListApp.Models
{
    public class BoardGameType
    {
        public int ID { get; set; }
        [Display(Name = "Game Type")]
        public string Type { get; set; }
        public virtual ICollection<BoardGame> BoardGames { get; set; }
    }
}