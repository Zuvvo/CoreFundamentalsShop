﻿using Microsoft.EntityFrameworkCore;

namespace CoreFundamentalsShop.Models
{
    public class CoreFundamentalsShopDbContext : DbContext
    {
        public CoreFundamentalsShopDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Pie> Pies { get; set; }
    }
}
