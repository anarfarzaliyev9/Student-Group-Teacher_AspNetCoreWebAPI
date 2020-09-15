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
    public class GroupController : ControllerBase
    {
        private readonly IGroupRepository repository;

        public GroupController(IGroupRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public List<Group> GetAllGroups()
        {
            return repository.GetAll();
        }
        [HttpPost]
        public IActionResult CreateGroup(Group group)
        {
            if (group != null)
            {
                var result = repository.Create(group);
                if (result != null)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }
        [HttpPost("{id}")]
        public IActionResult EditGroup(int id, Group group)
        {

            if (group != null)
            {
                group.Id = id;
                var result = repository.Edit(group);
                if (result)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }
        [HttpPost("{id}")]
        public IActionResult DeleteGroup(int id)
        {
            
            if (id>0)
            {
                var result = repository.Delete(id);
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult AddTeacherToGroup(int groupId,int teacherId)
        {
            var result = repository.AddTeacherToGroup(groupId, teacherId);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult DeleteTeacherFromGroup(int groupId, int teacherId)
        {
            var result = repository.DeleteTeacherFromGroup(groupId, teacherId);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
        //[HttpPost]
        //public IActionResult CreateGroup(Group group)
        //{
        //    if (group != null)
        //    {
        //        var result = repository.CreateGroup(group);
        //        if (result != null)
        //        {
        //            return Ok();
        //        }
        //    }
        //    return BadRequest();
        //}
        //[HttpPost("{id}")]
        //public IActionResult EditGroup(int id,Group group)
        //{

        //    if (group != null)
        //    {
        //        group.Id = id;
        //        var result = repository.EditGroup(group);
        //        if (result != null)
        //        {
        //            return Ok();
        //        }
        //    }
        //    return BadRequest();
        //}


    }
}