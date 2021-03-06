﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebAPI.Models;
using WebAPI.Utils;
using WebAPI.ViewModel;

namespace WebAPI.Controllers
{
    [Route("api/questions")]
    public class QuestionController : Controller
    {
        private IConfiguration _configuration;
        private readonly DatabaseContext _db;

        public QuestionController(DatabaseContext db, IConfiguration configuration)
        {
            _configuration = configuration;
            _db = db;
        }

        public IActionResult Get()
        {
            IEnumerable<QuestionModel> questions;
            try
            {
                questions = _db.Question.Include(s => s.Subject).ToList();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok(questions);
        }

        [HttpPost]
        [Route("bysubjectid")]
        public IActionResult GetBySubjectId([FromBody] SubjectIdParamViewModel param)
        {
            List<QuestionSubjectIdViewModel> questionBySubjectId = new List<QuestionSubjectIdViewModel>();

            foreach(var id in param.ids)
            {
                int questionsNumber = _db.Question.Where(q => q.subjectId == id).Count();

                QuestionSubjectIdViewModel qst = new QuestionSubjectIdViewModel();
                qst.subjectId = id;
                qst.questionCount = questionsNumber;

                questionBySubjectId.Add(qst);
            }
            return Ok(questionBySubjectId);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            QuestionModel question;
            try
            {
                question = _db.Question.Include(s => s.Subject).Where(q => q.id == id).FirstOrDefault();
                if (question == null) return NotFound($"Question with id ${id} not found!");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Ok(question);
        }

        [HttpPost]
        public IActionResult Create([FromBody] QuestionModel createQuestion, IFormFile document)
        {
            try
            {
                if (document != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        document.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        BlobStorageService bs = new BlobStorageService(_configuration);
                        var uploadSuccess = bs.CreateBlob(document.FileName, document.ContentType, fileBytes);
                        string blob = uploadSuccess.Result;

                        createQuestion.imgUrl = blob;
                    }
                }

                createQuestion.isActive = true;

                createQuestion.Subject = _db.Subject.Find(createQuestion.subjectId);

                _db.Question.Add(createQuestion);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return StatusCode(201, createQuestion);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] QuestionModel question, IFormFile document)
        {
            if (question == null || question.id == 0) return BadRequest();

            try
            {
                if (document != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        document.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        BlobStorageService bs = new BlobStorageService(_configuration);
                        var uploadSuccess = bs.CreateBlob(document.FileName, document.ContentType, fileBytes);
                        string blob = uploadSuccess.Result;

                        question.imgUrl = blob;
                    }
                }

                _db.Question.Update(question);
                _db.SaveChanges();
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }

            return Ok(question);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            QuestionModel question = _db.Question.Find(id);

            if (question == null) return NotFound($"Question with id ${id} not found!");

            try
            {
                _db.Question.Remove(question);
                _db.SaveChanges();
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }

            return Ok();
        }

        [HttpGet]
        [Route("subjects")]
        public IActionResult BySubject()
        {
            IEnumerable<SubjectModel> subjects = _db.Subject.ToList();
            IEnumerable<QuestionsBySubjectViewModel> questionsBySubjects = Enumerable.Empty<QuestionsBySubjectViewModel>();

            foreach(var subject in subjects)
            {
                IEnumerable<QuestionModel> questions = _db.Question.Where(q => q.subjectId == subject.id).ToList();
                QuestionsBySubjectViewModel qbs = new QuestionsBySubjectViewModel();
                qbs.count = questions.Count();
                qbs.subject = subject.name;

                questionsBySubjects.Append(qbs);
            }

            return Ok(questionsBySubjects);
        }
    }
}