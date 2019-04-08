using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Utils;
using WebAPI.ViewModel;

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

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            TeacherModel teacher = new TeacherModel();

            try
            {
                UserModel user = new UserModel();
                user = _db.User.Find(id);
                teacher.user = user;

                List<UserSubjectModel> subjectList = _db.UserSubject.Where(s => s.userId == user.id).ToList();

                List<SubjectModel> subjects = new List<SubjectModel>();

                foreach(var subjectId in subjectList)
                {
                    SubjectModel subject = _db.Subject.Find(subjectId.subjectId);
                    subjects.Add(subject);
                }

                teacher.subjects = subjects;
            }
            catch(Exception e)
            {
                return StatusCode(500, "Internal Server Error! Contact API supervisor!");
            }

            return Ok(teacher);
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

            try
            {
                var userDb = _db.User.Find(id);

                if (userDb == null) return NotFound();

                userDb = user;
                _db.User.Update(userDb);
                _db.SaveChanges();

                return Ok(userDb);
            }
            catch(Exception e)
            {
                return StatusCode(500, e);
            }            
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