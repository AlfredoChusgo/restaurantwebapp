using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Persistence;

namespace Infrastructure
{
    class Program
    {
        static void Main(string[] args)
        {
            InsertData();
        }

        private static void InsertData()
        {
            //using (var context = new ApplicationDbContext())
            //{
            //    // Creates the database if not exists
            //    context.Database.EnsureCreated();
            //    // Adds a publisher
            //    // Saves changes
            //    //context.SaveChanges();
            //}
        }
    }
}
