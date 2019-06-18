using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Lab2
{
    class Person
    {
        public string Login { get; set; }
        public string phoneNumber { get; set; }
        public string cardNumber { get; set; }
        public int rank { get; set; }
        public Person() { }
        public string profileImage { get; set; }
        public string Password { get; set; }
        virtual public void sleep() { }
    }
}
