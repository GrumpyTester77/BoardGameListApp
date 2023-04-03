using BoardGameListApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BoardGameListApp.DAL
{
    public class GamesContext
    {
        public DbSet<BoardGame> BoardGames { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<BoardGameType> BoardGameTypes { get; set; }
    }
}