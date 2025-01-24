using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CartApp.Server.Controllers
{

    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<string> Preferences { get; set; }

        public List<string> RecentlyViewed {get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly HttpClient _client;
        private readonly ILogger<UserController> _logger;

        public UserController(HttpClient client, ILogger<UserController> logger)
        {
            _client = client;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            // Get user data from main API
            var userData = await _client.GetFromJsonAsync<User>("http://main-api/api/user");

            // Transform and enrich with cart-specific data
            var enrichedUserData = new
            {
                userData.Id,
                userData.Name,
                Purchases = await _client.GetFromJsonAsync<List<dynamic>>(
                    $"http://main-api/api/user/{userData.Id}/purchases"
                )
            };

            return Ok(enrichedUserData);
        }
    }
}