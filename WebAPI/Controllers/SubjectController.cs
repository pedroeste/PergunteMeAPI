using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Utils;
using WebAPI.ViewModel;

namespace WebAPI.Controllers
{
    [Route("api/subjects")]
    public class SubjectController : Controller
    {
        private readonly DatabaseContext _db;

        public SubjectController(DatabaseContext db)
        {
            _db = db;
        }

        public IActionResult Get()
        {
            IEnumerable<SubjectModel> subjects;
            try
            {
                subjects = _db.Subject.ToList();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok(subjects);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            SubjectModel user = new SubjectModel();
            try
            {
                user = _db.Subject.Find(id);
            }
            catch(Exception e)
            {
                return StatusCode(500, e);
            }

            return Ok(user);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] SubjectModel subject)
        {
            try
            {
                subject.isActive = true;
                _db.Subject.Add(subject);
                _db.SaveChanges();
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }

            return Ok(subject);
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] SubjectModel subject)
        {
            if (subject == null || subject.id != subject.id) return BadRequest();

            try
            {
                subject.name = subject.name;
                _db.Subject.Update(subject);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }

            return Ok("Updated");
        }

        [HttpPost]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var subject = _db.Subject.Find(id);

            if (subject == null) return NotFound();

            try
            {
                _db.Subject.Remove(subject);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok(subject);
        }

        [HttpPost]
        [Route("vincularDisciplina")]
        public IActionResult UserSubject([FromBody] UserSubjectViewModel userSubject)
        {
            
            try
            {
                
                foreach(var subjectId in userSubject.subjectsId)
                {
                    SubjectModel subject = _db.Subject.Find(subjectId);

                    foreach (var userId in userSubject.usersId)
                    {
                        UserSubjectModel userSubjectModel = new UserSubjectModel();

                        userSubjectModel.subjectId = subject.id;

                        var userDb = _db.User.Find(userId);

                        userSubjectModel.userId = userDb.id;

                        _db.UserSubject.Add(userSubjectModel);
                        _db.SaveChanges();
                    }
                }

                

                return StatusCode(201);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }            
        }

        [HttpPost]
        [Route("vincularCourseSubject")]
        public IActionResult CourseSubject([FromBody] CourseSubjectViewModel courseSubject)
        {
            try
            {
                foreach(var subjecId in courseSubject.subjectsId)
                {
                    SubjectModel subject = _db.Subject.Find(subjecId);

                    foreach (var courseId in courseSubject.coursesId)
                    {
                        CourseSubjectModel courseSubjectModel = new CourseSubjectModel();

                        courseSubjectModel.subjectId = subject.id;
                        var courseDb = _db.Course.Include(s => s.School).Where(c => c.id == courseId).FirstOrDefault();

                        courseSubjectModel.courseId = courseDb.id;

                        _db.CourseSubject.Add(courseSubjectModel);
                        _db.SaveChanges();
                    }
                }

                

                return StatusCode(201);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}