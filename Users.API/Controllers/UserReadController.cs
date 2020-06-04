using Microsoft.AspNetCore.Mvc;
using Users.Domain.Contract;
using Users.Domain.Entity;
using Users.Domain.ValueObject;

namespace Users.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserReadController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserReadController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/UserRead
        [HttpGet]
        public User Get()
        {

            var myUser = _userRepository.GetByEmail(new Email("carlos@closmarfer.com"));

            return myUser;

            // TODO el caso es que ya tengo lista la importación entre proyectos. Ahora a ver cómo serializo esto a JSON (tal vez un metodo)
            //User myUser = new User(
            //        new UserUuid("abc123"),
            //        new Email("carlos@closmarfer.com"),
            //        new Name("Carlos Martín")
            //   );
            //return myUser; //Si lo hago así lo serializa directamente y muestra cada propiedad de las clases
            
            //return new string[] { "value1", "value2" };
        }

        // GET: api/UserRead/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UserRead
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/UserRead/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
