using Microsoft.AspNetCore.Mvc;

namespace CartApp.Server.Controllers
{

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
        [ApiController]
        [Route("api/[controller]")]
        public class CartController : ControllerBase
        {
            private readonly HttpClient _httpClient;

            public CartController(HttpClient httpClient)
            {
                _httpClient = httpClient;
            }

            [HttpGet]
            public async Task<IActionResult> GetCart()
            {
                var cart = await _httpClient.GetFromJsonAsync<List<Product>>("http://main-api/api/shop/cart");
              
                // Enrich with cart-specific calculations and data
                var enrichedCart = new {
                    Items = cart.Select(item => new {
                        Id = item.Id,
                        Name = item.Name,
                        Price = item.Price,
                        PriceFormatted = $"${item.Price:N2}",
                        EstimatedDelivery = GetEstimatedDelivery(),
                        GiftWrappingAvailable = IsGiftWrappingAvailable(item.Id)
                    }),
                    Summary = new {
                        SubTotal = cart.Sum(i => i.Price),
                        Tax = cart.Sum(i => i.Price) * 0.1m,
                        Total = cart.Sum(i => i.Price) * 1.1m,
                        ItemCount = cart.Count,
                        QualifiesForFreeShipping = cart.Sum(i => i.Price) > 50
                    }
                };

                return Ok(enrichedCart);
            }

            private DateTime GetEstimatedDelivery() => 
                DateTime.Now.AddDays(3);

            private bool IsGiftWrappingAvailable(int productId) =>
                // Simulated gift wrapping eligibility
                new[] { 2, 3 }.Contains(productId);

            [HttpPost]
            public async Task<IActionResult> AddToCart([FromBody] Product product)
            {                
                product.Id = new Random().Next(1, 1000);
                var response = await _httpClient.PostAsJsonAsync("http://main-api/api/shop/cart", product);
                var updatedCart = await response.Content.ReadFromJsonAsync<List<Product>>();
                return Ok(updatedCart);
            }
        }
    }