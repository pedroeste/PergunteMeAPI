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
    [Route("api/users")]
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
                return StatusCode(500, "Internal Server Error! Contact API supervisor! => " + e);
            }

            return Ok(teacher);
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserModel user)
        {
            try
            {
                user.password = new EncryptionService().Encrypt(user.password);
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

        [HttpPut]
        public IActionResult Update([FromBody] UserModel user)
        {
            if (user == null || user.id == 0) return BadRequest();

            try
            {
                user.password = new EncryptionService().Encrypt(user.password);
                _db.User.Update(user);
                _db.SaveChanges();

                return Ok(user);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            UserModel user = _db.User.Find(id);

            if (user == null) return NotFound();

            try
            {
                _db.User.Remove(user);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok();
        }
    }
}