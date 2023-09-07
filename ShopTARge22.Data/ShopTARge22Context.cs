using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARge22.Data
{
    public class ShopTARge22Context : DbContext
    {
        public ShopTARge22Context(DbContextOptions<ShopTARge22Context> options) : base(options) { }
    }
}
