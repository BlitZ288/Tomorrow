
using System;
using System.Data.Entity;

namespace WpfApp1
{
    class MyDbContex:DbContext
    {

        public MyDbContex() : base("DbConnectionString")
        {


        }
        public DbSet<User>Users { get; set; }
        public DbSet<Zodiac> Zodiacs { get; set; }
    }
}
