using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Lab2
{
    class VisitorContext : DbContext
    {
        public VisitorContext()
            : base("AllDb")
        { }
        public DbSet<Visitor> Visitors { get; set; }
    }
    class Visitor: Person, IAccount
    {
        public ICollection<Concert> Concerts { get; set; }
 

        private int _sum;
        public int CurrentSum { get; }
        public void Put(int sum)
        {
            this._sum += sum;
        }
        public void Withdraw(int sum)
        {
            if (_sum >= sum)
            {
                _sum -= sum;
            }
        }
        public Visitor() { }
        public void BuyTicket(ref Concert c)
        {
            c.Tickets--;
            Withdraw(c.TicketPrice);
            base.sleep();//2.6
        }
        public override void sleep() { }//2.8
        [Key]
        public int Id { get; set; }
    }
}
