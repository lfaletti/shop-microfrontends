using Microsoft.AspNetCore.Mvc;

namespace ShopAPI.Controllers
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class ShopController : ControllerBase
    {
        private static readonly List<Product> _products = new()
        {
            new Product { Id = 1, Name = "Laptop", Price = 999 },
            new Product { Id = 2, Name = "Smartphone", Price = 699 },
            new Product { Id = 3, Name = "Headphones", Price = 199 }
        };

        private static List<Product> _cart = new();

        [HttpGet("products")]
        public IActionResult GetProducts()
        {
            return Ok(_products);
        }

        [HttpGet("cart")]
        public IActionResult GetCart()
        {
            return Ok(_cart);
        }

        [HttpPost("cart")]
        public IActionResult AddToCart([FromBody] Product product)
        {
            _cart.Add(product);
            return Ok(_cart);
        }
    }
}
