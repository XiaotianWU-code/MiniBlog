using MiniBlog.Model;
using MiniBlog.Stores;
using Microsoft.AspNetCore.Mvc;
using MiniBlog.Service;

namespace MiniBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private IUserService _userService;

        public UserController( IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult<User> Register(User user)
        {
            _userService.Register(user);

            return new CreatedResult($"create new user: {user}",user);
        }

        [HttpGet]
        public List<User> GetAll()
        {
            return _userService.GetAll();
        }

        [HttpPut]
        public User Update(User user)
        {
            return _userService.Update(user);
        }

        [HttpDelete]
        public User Delete(string name)
        {
            return _userService.Delete(name);
        }

        [HttpGet("{name}")]
        public User GetByName(string name)
        {
            return _userService.GetByName(name);
        }
    }
}