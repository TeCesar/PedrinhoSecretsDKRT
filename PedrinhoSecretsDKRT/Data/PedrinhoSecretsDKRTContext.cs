using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PedrinhoSecretsDKRT.Models
{
    public class PedrinhoSecretsDKRTContext : DbContext
    {
        public PedrinhoSecretsDKRTContext (DbContextOptions<PedrinhoSecretsDKRTContext> options)
            : base(options)
        {
        }

        public DbSet<PedrinhoSecretsDKRT.Models.enigmas> enigmas { get; set; }
    }
}
