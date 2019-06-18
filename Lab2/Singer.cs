using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Lab2
{
    //class SingerContext : DbContext
    //{
    //    public SingerContext()
    //        : base("DbSingers")
    //    { }
    //    public DbSet<Singer> Singers { get; set; }
    //}
    class SingerContext : DbContext
    {
        public SingerContext()
            : base("AllDb")
        { }
        public DbSet<Singer> Singers { get; set; }
    }
    sealed class Singer: Person//2.7
    {
        public ICollection<Concert> Concerts { get; set; }
        delegate string SetNextConcert(string concert);
        public string NextConcert { get; set; }
        public Singer() { }
        [Key]
        public int Id { get; set; }
        SetNextConcert cs = delegate (string concert)
        {
            return concert;
        };
    }
}
