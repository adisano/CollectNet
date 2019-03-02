using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CollectNet.Models;

namespace CollectNet.Models
{
    public class CollectionContext : DbContext
    {
        public CollectionContext (DbContextOptions<CollectionContext> options)
            : base(options)
        {
        }

        public DbSet<CollectNet.Models.List> List { get; set; }

        public DbSet<CollectNet.Models.Item> Item { get; set; }
    }
}
