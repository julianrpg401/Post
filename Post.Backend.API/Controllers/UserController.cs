using Backend.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly PostDbContext _postDbContext;

        public UserController(PostDbContext postDbContext)
        {
            _postDbContext = postDbContext;
        }

        [HttpPost]
        [Route("CreateUser")]
        public IActionResult CreateUser(User user)
        {
            _postDbContext.Users.Add(user);
            _postDbContext.SaveChanges();
            
            return Ok(user);
        }
    }
}
