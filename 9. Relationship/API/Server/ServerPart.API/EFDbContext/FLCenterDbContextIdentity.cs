using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerPart.API.EFDbContext
{
    public class FLCenterDbContextIdentity : DbContext
    {
        public FLCenterDbContextIdentity() { }
        public FLCenterDbContextIdentity(DbContextOptions options) : base(options)
        {

        }
    }
}
