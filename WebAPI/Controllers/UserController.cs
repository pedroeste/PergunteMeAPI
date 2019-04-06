using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Utils;

namespace WebAPI.Controllers
{
    [Route("api/[Controller]")]
    public class UserController : Controller
    {
        private readonly DatabaseContext _db;

        public UserController(DatabaseContext db)
        {
            _db = db;
        }

        public IActionResult Get()
        {
            IEnumerable<UserModel> users;
            try
            {
                users = _db.User.ToList();                
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok(users);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] UserModel user)
        {
            try
            {
                user.isActive = true;
                _db.User.Add(user);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok(user);
        }

        [HttpPost("{id}")]
        public IActionResult Update(int id, [FromBody] UserModel user)
        {
            if (user == null || user.id != id) return BadRequest();

            var userDb = _db.User.Find(id);

            if (userDb == null) return NotFound();

            userDb = user;
            _db.User.Update(userDb);

            return new NoContentResult();
        }

        [HttpPost("id)")]
        public IActionResult Delete(int id)
        {
            var user = _db.User.Find(id);

            if (user == null) return NotFound();

            _db.User.Remove(user);

            return new NoContentResult();
        }
    }
}