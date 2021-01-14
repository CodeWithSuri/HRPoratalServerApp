using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace HRPoratalServerApp.Models
{
    public class RepositryPattrenContext: DbContext
    {


        public RepositryPattrenContext(DbContextOptions options) :base(options)
        {

        }

        DbSet<Employee> employees { get; set; }
    }
}
