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
    public class TestController : Controller
    {
        private readonly DatabaseContext _db;

        public TestController(DatabaseContext db)
        {
            _db = db;
        }

        public IActionResult Get()
        {
            IEnumerable<TestModel> tests;

            try
            {
                tests = _db.Test.ToList();
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }

            return Ok(tests);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            TestModel test;
            try
            {
                test = _db.Test.Find(id);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }

            return Ok(test);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] TestModel test)
        {
            try
            {
                _db.Test.Add(test);
                _db.SaveChanges();

                List<QuestionModel> questionsDb = _db.Question.ToList();
                List<QuestionModel> questions = new List<QuestionModel>();

                for (int i = 0; i < 30; i++)
                {
                    Random random = new Random();
                    int num = random.Next(questionsDb.Count());
                    questions.Add(questionsDb.Where(p => p == questionsDb[num]).FirstOrDefault());

                    questionsDb.RemoveAt(num);
                }

                foreach(var question in questions)
                {
                    TestQuestionModel testQuestion = new TestQuestionModel();
                    testQuestion.questionId = question.id;
                    testQuestion.testId = test.id;

                    _db.TestQuestion.Add(testQuestion);
                    _db.SaveChanges();
                }


                //while(questions.Count < 30)
                //{
                //    Random random = new Random();
                //    int num = random.Next(questionsDb.Count());

                //    if (questions.FindIndex(c => c.id == num) == -1) { questions.Add(questionsDb.First(c => c.id == num); }
                //}                
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }

            return StatusCode(201, test);
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update([FromBody] TestModel test)
        {
            if (test == null || test.id == 0) return BadRequest();

            try
            {
                _db.Test.Update(test);
                _db.SaveChanges();
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }

            return Ok(test);
        }

        [HttpPost]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            TestModel test = _db.Test.Find(id);

            if (test == null) return NotFound();

            try
            {
                _db.Test.Remove(test);
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