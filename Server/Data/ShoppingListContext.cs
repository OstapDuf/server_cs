using Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{


    public class ShoppingListContext : DbContext
    {
        public ShoppingListContext(DbContextOptions<ShoppingListContext> options) : base(options)
        {
            
        }
        
        public DbSet<ShoppingList> ShoppingLists { get; set; }

    }
}