using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitCardGeneratorDotNetApi.Entities
{
    public class CardGeneratorContext :DbContext
    {
        public CardGeneratorContext(DbContextOptions<CardGeneratorContext> options) : base(options)
        {

        }
        public DbSet<Rule> Rules { get; set; }
    }
}
