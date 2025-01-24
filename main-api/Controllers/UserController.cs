using Microsoft.AspNetCore.Mvc;

namespace ShopAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            // Products-specific user data
            return Ok(new
            {
                Id = 1,
                Name = "John",
                Preferences = new[] { "Electronics", "Books" },
                RecentlyViewed = new[] { "Laptop", "Phone" }
            });
        }
    }
}
