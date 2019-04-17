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
    public class SchoolController : Controller
    {
        private readonly DatabaseContext _db;

        public SchoolController(DatabaseContext db)
        {
            _db = db;
        }

        public IActionResult Get()
        {
            IEnumerable<SchoolModel> schools;
            try
            {
                schools = _db.School.ToList();
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }

            return Ok(schools);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            SchoolModel school;
            try
            {
                school = _db.School.Find(id);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }

            return Ok(school);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] SchoolModel school)
        {
            try
            {
                _db.School.Add(school);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok(school);
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update([FromBody] SchoolModel school)
        {
            if (school == null || school.id == 0) return BadRequest();

            try
            {
                _db.School.Update(school);
                _db.SaveChanges();
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }

            return Ok(school);
        }

        [HttpPost]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            SchoolModel school = _db.School.Find(id);

            if (school == null) return NotFound();

            try
            {
                _db.School.Remove(school);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok("Deleted");
        }

    }
}