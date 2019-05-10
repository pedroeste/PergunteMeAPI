﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Utils;
using WebAPI.ViewModel;

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
                    QuestionModel quest = _db.Question.Find(question.questionId);
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
        public IActionResult Generate([FromBody] TestViewModel testParam)
        {
            try
            {
                testParam.test.isActive = true;
                _db.Test.Add(testParam.test);
                _db.SaveChanges();

                // Para cada disciplina selecionada
                List<QuestionModel> questions = new List<QuestionModel>();
                foreach (var subject in testParam.testTopics)
                {
                    List<QuestionModel> questionsDb = new List<QuestionModel>();

                    // Pega todas as perguntas daquela disciplina e coloca em uma lista
                    var questionDb = _db.Question.Where(q => q.subjectId == subject.subject.id).ToList();
                    questionsDb.Concat(questionDb);

                    // Para cada disciplina, uma pergunta é selecionada aleatoriamente de acordo com o total de perguntas pré-definido para aquela disciplina
                    for (int i = 0; i < subject.questionsNumber; i++)
                    {
                        Random random = new Random();
                        int num = random.Next(questionsDb.Count());
                        questions.Add(questionsDb.Where(p => p == questionsDb[num]).FirstOrDefault());
                        questionsDb.RemoveAt(num);
                    }

                }

                // Adiciona as perguntas do Exame na model de json final
                foreach (var question in questions)
                {
                    TestQuestionModel testQuestion = new TestQuestionModel();
                    testQuestion.questionId = question.id;
                    testQuestion.testId = testParam.test.id;

                    _db.TestQuestion.Add(testQuestion);
                    _db.SaveChanges();
                }

                return Ok(testParam.test);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] TestViewModel testOptions)
        {
            try
            {
                testOptions.test.isActive = true;
                _db.Test.Add(testOptions.test);
                _db.SaveChanges();

                List<QuestionModel> questionsDb = _db.Question.ToList();
                List<QuestionModel> questions = new List<QuestionModel>();

                for (int i = 0; i < testOptions.totalQuestions; i++)
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
                    testQuestion.testId = testOptions.test.id;

                    _db.TestQuestion.Add(testQuestion);
                    _db.SaveChanges();
                }
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }

            return StatusCode(201, testOptions.test);
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