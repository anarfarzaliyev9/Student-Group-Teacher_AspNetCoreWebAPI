using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentGroupWebApi.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentGroupWebApi.Models
{
    public class StudentRepository : GeneralRepo<Student>, IStudentRepository
    {
        private readonly ApplicationContext context;

        public StudentRepository(ApplicationContext context)
            : base(context)
        {
            this.context = context;
        }

        public bool AddStudentToGroup(int studentId, int groupId)
        {
            Student student = context.Students.FirstOrDefault(x => x.Id == studentId);
            Group group = context.Groups.FirstOrDefault(x => x.Id == groupId);
            if (group != null && student != null)
            {
                student.GroupId = group.Id;

                var result = context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }

            }
            return false;
        }

        public object GetStudentsWithGroups()
        {
            var studentGroups = (from s in context.Students
                                 join g in context.Groups on s.GroupId equals g.Id
                                 select new
                                 {
                                     Student = s,
                                     Group = g.Students.FirstOrDefault()
                                 }).ToList();
            var students = context.Students.Include("Group").ToList();
            //var studentGroup = context.Students.Include("Group").ToList();
            return studentGroups;
        }

       


        //public List<Student> GetAllStudents()
        //{
        //    return context.Students.ToList();
        //}
        //[HttpPost]
        //public Student CreateStudent(Student student)
        //{
        //    if (student != null)
        //    {
        //        context.Students.Add(student);
        //        context.SaveChanges();
        //        return student;
        //    }
        //    return null;
        //}

        //public Student EditStudent(Student student)
        //{
        //    Student student_ = context.Students.FirstOrDefault(x => x.Id == student.Id);
        //    if (student_ != null)
        //    {
        //        context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);
        //        context.Entry(student).State = EntityState.Modified;
        //        context.SaveChanges();
        //        return student;
        //    }
        //    return null;
        //}


    }
}
