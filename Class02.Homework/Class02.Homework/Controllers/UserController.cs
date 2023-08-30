using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Class02.Homework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> GetAllUsers()
        {
            return Ok(StaticDb.Users);
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetUser(int id)
        {
            try
            {
                if (id < 0)
                {
                    //return StatusCode(StatusCodes.Status400BadRequest, "The ID can not be negative");
                    return BadRequest("The ID can not be negative");
                }

                if (id >= StaticDb.Users.Count)
                {
                    //return StatusCode(StatusCodes.Status404NotFound, $"There is no user on ID {id}");
                    return NotFound($"There is no user on ID {id}");
                }

                return Ok(StaticDb.Users[id]);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occurred");
            }
        }
    }
}
