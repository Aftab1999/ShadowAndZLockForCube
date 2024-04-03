

using Microsoft.AspNetCore.Mvc;
using MvcDemo.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MvcDemo.Controllers
{
    [ApiController] // Indicates that this controller responds to web API requests
    [Route("[controller]")] // Sets the route as the controller name without "Controller" suffix
    public class CubesController : ControllerBase // Inherit from ControllerBase for API controllers
    {
        private readonly MvcDemoContext _context;

        public CubesController(MvcDemoContext context)
        {
            _context = context;
        }

        // Existing actions...

        // Adjusted Create for API
        [HttpPost("Create")] // Specifies this is a POST method with route "/Cubes/Create"
        public async Task<IActionResult> CreateApi([FromBody] Cube cube) // [FromBody] to bind from request body
        {
            if (ModelState.IsValid)
            {
                _context.Add(cube);
                await _context.SaveChangesAsync();
                return Ok(cube); // Return the created cube as JSON
            }
            return BadRequest(ModelState); // Return bad request if model validation fails
        }

        // Add other actions...
    }
}
