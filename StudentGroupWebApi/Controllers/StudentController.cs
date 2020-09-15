using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentGroupWebApi.Abstractions;
using StudentGroupWebApi.Models;

namespace StudentGroupWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository repository;
            
        public StudentController(IStudentRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public List<Student> GetAllStudents()
        {
            return repository.GetAll();
        }
        [HttpGet]
        public object GetStudentsWithGroups()
        {
            var studentGroups = repository.GetStudentsWithGroups();
            return studentGroups;
        }
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            if (student != null)
            {
                var result = repository.Create(student);
                if (result != null)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }
        [HttpPost("{id}")]
        public IActionResult EditStudent(int id, Student student)
        {

            if (student != null)
            {
                student.Id = id;
                var result = repository.Edit(student);
                if (result)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }
        [HttpPost("{id}")]
        public IActionResult DeleteStudent(int id)
        {

            if (id > 0)
            {
                var result = repository.Delete(id);
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult AddStudentToGroup(int studentId,int groupId)
        {
            var result = repository.AddStudentToGroup(studentId, groupId);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet("{id}")]
        public Student GetStudentById(int id)
        {
            var student = repository.GetById(id);
            if (student != null)
            {
                return student;
            }
            return null;
        }
        //[HttpPost]
        //public IActionResult CreateStudent(Student student)
        //{
        //    if (student != null)
        //    {
        //       var result= repository.CreateStudent(student);
        //        if (result != null)
        //        {
        //            return Ok();
        //        }
        //    }
        //    return BadRequest();
        //}
        //[HttpPost("{id}")]
        //public IActionResult EditStudent(int id, Student student)
        //{

        //    if (student != null)
        //    {
        //        student.Id = id;
        //        var result = repository.EditStudent(student);
        //        if (result != null)
        //        {
        //            return Ok();
        //        }
        //    }
        //    return BadRequest();
        //}


    }
}