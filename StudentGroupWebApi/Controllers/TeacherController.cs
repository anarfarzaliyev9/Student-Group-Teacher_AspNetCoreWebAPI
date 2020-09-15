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
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository repository;

        public TeacherController(ITeacherRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public List<Teacher> GetAllTeachers()
        {
            return repository.GetAll();
        }
        [HttpPost]
        public IActionResult CreateTeacher(Teacher teacher)
        {
            if (teacher != null)
            {
                var result = repository.Create(teacher);
                if (result != null)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }
        [HttpPost("{id}")]
        public IActionResult EditTeacher(int id, Teacher teacher)
        {

            if (teacher != null)
            {
                teacher.Id = id;
                var result = repository.Edit(teacher);
                if (result)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }
        [HttpPost("{id}")]
        public IActionResult DeleteTeacher(int id)
        {

            if (id > 0)
            {
                var result = repository.Delete(id);
                return Ok();
            }
            return BadRequest();
        }
    }
}