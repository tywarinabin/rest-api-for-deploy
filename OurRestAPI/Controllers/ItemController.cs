using Microsoft.AspNetCore.Mvc;

namespace OurRestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private static List<Item> items = new List<Item>()
        {
            new Item { Id = 1, Name = "First Item" },
            new Item { Id = 2, Name = "Second Item" }
        };

        // GET: api/items
        [HttpGet]
        public IActionResult GetItems()
        {
            return Ok(new
            {
                message = "Items retrieved successfully",
                data = items
            });
        }

        // GET: api/items/{id}
        [HttpGet("{id}")]
        public IActionResult GetItem(int id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item == null)
                return NotFound(new { message = $"Item with Id = {id} not found" });

            return Ok(new
            {
                message = "Item retrieved successfully",
                data = item
            });
        }

        // POST: api/items
        [HttpPost]
        public IActionResult CreateItem([FromBody] Item newItem)
        {
            if (newItem == null || string.IsNullOrWhiteSpace(newItem.Name))
                return BadRequest(new { message = "Invalid item data" });

            newItem.Id = items.Count > 0 ? items.Max(i => i.Id) + 1 : 1;
            items.Add(newItem);

            return CreatedAtAction(nameof(GetItem), new { id = newItem.Id }, new
            {
                message = "Item created successfully",
                data = newItem
            });
        }

        // PUT: api/items/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateItem(int id, [FromBody] Item updatedItem)
        {
            if (updatedItem == null || id != updatedItem.Id)
                return BadRequest(new { message = "Invalid item data or Id mismatch" });

            var existingItem = items.FirstOrDefault(i => i.Id == id);
            if (existingItem == null)
                return NotFound(new { message = $"Item with Id = {id} not found" });

            existingItem.Name = updatedItem.Name;

            return Ok(new { message = "Item updated successfully" });
        }

        // DELETE: api/items/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item == null)
                return NotFound(new { message = $"Item with Id = {id} not found" });

            items.Remove(item);

            return Ok(new { message = "Item deleted successfully" });
        }
    }
}
public class Item
{
    public int Id { get; set; }
    public string? Name { get; set; } 
    public Item() { }

    public Item(int id, string name)
    {
        Id = id;
        Name = name;
    }

}