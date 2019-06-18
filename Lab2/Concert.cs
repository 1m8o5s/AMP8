using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Lab2
{
    class ConcertContext : DbContext
    {
        public ConcertContext()
            : base("AllDb")
        { }
        public DbSet<Concert> Concerts { get; set; }
    }
    class Concert
    {
        public Concert()
        {
            Visitors = new List<Visitor>();
        }
        [Key]
        public int Id { get; set; }
        public string Place { get; set; }
        public int Tickets { get; set; } = 100;
        public int TicketPrice { get; set; } = 199;
        public string Date { get; set; }
        public string Name { get; set; }
        public Singer Singers { get; set; }
        public ICollection<Visitor> Visitors { get; set; }
        public Manager Manager { get; set; }
        public string WallPaper { get; set; }
        delegate int Tax(int price);
        Tax pdv = (price) => Convert.ToInt32(price * 1.25);
        Tax pd = delegate (int price)
        {
            return Convert.ToInt32(price / 1.25);
        };
    }
}
