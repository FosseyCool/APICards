using APICards.Models;
using Microsoft.EntityFrameworkCore;

namespace APICards.Data
{
    public class CardContext : DbContext
    {


        public CardContext(DbContextOptions<CardContext> options) : base(options)
        {
            
        }

        public DbSet<Card> Cards { get; set; }
    }
}