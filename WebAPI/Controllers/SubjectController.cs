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
    public class SubjectController : Controller
    {
        private readonly DatabaseContext _db;

        public SubjectController(DatabaseContext db)
        {
            _db = db;
        }

        [HttpGet]
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

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] SubjectModel subject)
        {
            try
            {
                _db.Subject.Add(subject);
                _db.SaveChanges();
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }

            return Ok(subject);
        }

        [HttpPost("{id}")]
        public IActionResult Update(int id, [FromBody] SubjectModel subject)
        {
            if (subject == null || subject.id != id) return BadRequest();

            var subjectDb = _db.Subject.Find(id);

            if (subjectDb == null) return NotFound();

            subjectDb.name = subject.name;
            _db.Subject.Update(subjectDb);

            return new NoContentResult();
        }

        [HttpPost]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var subject = _db.Subject.Find(id);

            if (subject == null) return NotFound();

            _db.Subject.Remove(subject);

            return new NoContentResult();
        }

        [HttpPost]
        [Route("vincularDisciplina")]
        public IActionResult UserSubject([FromBody] UserSubjectViewModel userSubject)
        {
            UserSubjectModel userSubjectModel = new UserSubjectModel();
            try
            {
                var user = _db.User.Find(userSubject.userId);

                foreach (var id in userSubject.subjectsId)
                {
                    userSubjectModel.userId = user.id;

                    userSubjectModel.subjectId = _db.Subject.Find(id).id;

                    _db.UserSubject.Add(userSubjectModel);
                    _db.SaveChanges();
                }
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }

            return Ok(userSubjectModel);
        }
    }
}