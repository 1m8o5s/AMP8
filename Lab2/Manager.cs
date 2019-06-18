using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Lab2
{
    class ManagerContext : DbContext
    {
        public ManagerContext()
            : base("AllDb")
        { }
        public DbSet<Manager> Managers { get; set; }
    }
    class Manager: Person
    {

        public Manager() { Concerts = new List<Concert>(); }
        public void MakeConcert(Singer s, string date, string place = "Arena") {
            Concert concert = new Concert();
            concert.Singers = s;
            concert.Date = date;
            InformSinger(s, ref concert);
            ConcertContext db = new ConcertContext();
            db.Concerts.Add(concert);
            db.SaveChanges();
        }
        public void InformSinger(Singer s, ref Concert c)
        {
            s.NextConcert = c.Date;
        }
        public ICollection<Concert> Concerts { get; set; } = null;
        new public void sleep() {//2.5
            string s = "Is sleeping";
        }
        [Key]
        public int Id { get; set; }
    }
}
