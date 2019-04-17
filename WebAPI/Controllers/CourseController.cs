using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Utils;

namespace WebAPI.Controllers
{
    [Route("api/[Controller]")]
    public class CourseController : Controller
    {
        private readonly DatabaseContext _db;

        public CourseController(DatabaseContext db)
        {
            _db = db;
        }

        public IActionResult Get()
        {
            IEnumerable<CourseModel> courses;
            try
            {
                courses = _db.Course.Include(s => s.School).ToList();
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }

            return Ok(courses);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            CourseModel course;
            try
            {
                course = _db.Course.Include(s => s.School).Where(c => c.id == id).FirstOrDefault();
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }

            return Ok(course);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] CourseModel course)
        {
            try
            {
                _db.Course.Add(course);
                _db.SaveChanges();
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }

            return Ok(course);            
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update([FromBody] CourseModel course)
        {
            if (course == null || course.id == 0) return BadRequest();

            try
            {
                _db.Course.Update(course);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok(course);
        }

        [HttpPost]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            CourseModel course = _db.Course.Find(id);

            if (course == null) return NotFound();

            try
            {
                _db.Course.Remove(course);
                _db.SaveChanges();
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }

            return Ok("Deleted");
        }

    }
}