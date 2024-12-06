using Data;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.EntityFrameworkCore;


namespace Controller
{
    [ApiController]
    [Route("/[controller]")]
    public class ShoppingListController : ControllerBase
    {
        private readonly ShoppingListContext _context;

        public ShoppingListController(ShoppingListContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingList>>> GetShoppingLists()
        {
            return await _context.ShoppingLists.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingList>> GetShoppingList(int id)
        {
            var shoppinglist = await _context.ShoppingLists.FindAsync(id);
            if (shoppinglist == null)
            {
                return NotFound();
                
            }

            return shoppinglist;
        }

        [HttpPost]
        public async Task<ActionResult<ShoppingList>> PostShoppingList(ShoppingList shoppingList)
        {
            _context.ShoppingLists.Add(shoppingList);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetShoppingList), new { id = shoppingList.Id }, shoppingList);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ShoppingList>> PutShoppingList(int id, ShoppingList shoppingList)
        {
            var existingShoppingList  = await _context.ShoppingLists.FindAsync(id);
            if (existingShoppingList  == null)
            {
                return BadRequest();
            }
            
            existingShoppingList.Name = shoppingList.Name;
            existingShoppingList.Quality = shoppingList.Quality;
            existingShoppingList.Price = shoppingList.Price;
            await _context.SaveChangesAsync();

            return NoContent();



        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ShoppingList>> DeleteShoppingList(int id)
        {
            var shoppinglist = await _context.ShoppingLists.FindAsync(id);
            if (shoppinglist == null)
            {
                return NotFound();
                
            }

            _context.ShoppingLists.Remove(shoppinglist);
            await _context.SaveChangesAsync();

            return NoContent();
        }
       
        
    }
    

}