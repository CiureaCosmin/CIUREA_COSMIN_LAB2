using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CIUREA_COSMIN_LAB2.Models;

namespace CIUREA_COSMIN_LAB2.Data
{
    public class CIUREA_COSMIN_LAB2Context : DbContext
    {
        public CIUREA_COSMIN_LAB2Context (DbContextOptions<CIUREA_COSMIN_LAB2Context> options)
            : base(options)
        {
        }

        public DbSet<CIUREA_COSMIN_LAB2.Models.Book> Book { get; set; } = default!;

        public DbSet<CIUREA_COSMIN_LAB2.Models.Publisher> Publisher { get; set; }

        public DbSet<CIUREA_COSMIN_LAB2.Models.Author> Author { get; set; }
    }
}
