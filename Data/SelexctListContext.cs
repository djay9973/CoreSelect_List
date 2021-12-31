using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreSelect_List.Models;

namespace CoreSelect_List.Data
{
    public class SelexctListContext:DbContext
    {
        public SelexctListContext(DbContextOptions<SelexctListContext> options) : base(options)
        {

        }
        public virtual DbSet<Customer> Customers_dj { get; set; }
        public virtual DbSet<Country_dj> Country_Djs { get; set; }
        public virtual DbSet<City_dj> City_Djs { get; set; }
    }
}
