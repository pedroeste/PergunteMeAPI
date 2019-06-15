using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Utils;
using WebAPI.ViewModel;
using Xceed.Words.NET;

namespace WebAPI.Controllers
{
    [Route("api/tests")]
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
            FinalTestViewModel finalTest = new FinalTestViewModel();
            try
            {
                var test = _db.Test.Find(id);
                finalTest.test = test;

                List<TestQuestionModel> testQuestions = _db.TestQuestion.Where(t => t.testId == id).ToList();

                List<QuestionModel> questions = new List<QuestionModel>();
                foreach (var question in testQuestions)
                {
                    QuestionModel quest = _db.Question.Include(q => q.Subject).Where(q => q.id == question.questionId).FirstOrDefault();
                    questions.Add(quest);
                }

                finalTest.questions = questions;
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }

            return Ok(finalTest);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TestViewModel testParam)
        {
            try
            {
                // Lista com todas as perguntas de todas as disciplinas demandadas
                List<QuestionModel> questionsDb = new List<QuestionModel>();

                // Lista de perguntas aleatórias selecionadas
                List<QuestionModel> questions = new List<QuestionModel>();

                foreach (var subject in testParam.subjectsList)
                {
                    // Lista de perguntas de cada disciplina
                    List<QuestionModel> questionSubject = _db.Question.Where(q => q.subjectId == subject.subjectId).ToList();
                    questionsDb.AddRange(questionSubject);
                }
                foreach (var subject in testParam.subjectsList)
                {
                    // Lista de perguntas de cada disciplina
                    List<QuestionModel> questionSubject = questionsDb.Where(q => q.subjectId == subject.subjectId).ToList();
                    
                    for (int i = 0; i < subject.questionsNumber; i++)
                    {
                        Random random = new Random();
                        int num = random.Next(questionSubject.Count);

                        var randomSubjectQuestion = questionSubject[num];

                        // Adiciona pergunta na lista de perguntas aleatorias selecionadas
                        questions.Add(randomSubjectQuestion);

                        // Remove a pergunta selecionada da lista de perguntas
                        questionsDb.Remove(questionSubject[num]);

                        // Remove a pergunta selecionada da lista de perguntas por disciplina
                        questionSubject.RemoveAt(num);
                    }

                }

                testParam.test.isActive = true;
                _db.Test.Add(testParam.test);
                _db.SaveChanges();

                // Cria relacionamento entre pergunta e teste
                foreach (var question in questions)
                {
                    TestQuestionModel testQuestion = new TestQuestionModel();
                    testQuestion.questionId = question.id;
                    testQuestion.testId = testParam.test.id;

                    _db.TestQuestion.Add(testQuestion);
                    _db.SaveChanges();
                }

                // Adiciona as perguntas do Exame na model de json final
                FinalTestViewModel ft = new FinalTestViewModel();
                ft.questions = questions;
                ft.test = testParam.test;

                return Ok(ft);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("{id}")]
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

        [HttpDelete("{id}")]
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

            return Ok();
        }
    }
}