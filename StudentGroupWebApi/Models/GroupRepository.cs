using Microsoft.EntityFrameworkCore;
using StudentGroupWebApi.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentGroupWebApi.Models
{
    public class GroupRepository :GeneralRepo<Group>, IGroupRepository
    {
        private readonly ApplicationContext context;

        public GroupRepository(ApplicationContext context)
            :base(context)
        {
            this.context = context;
        }

        public bool AddTeacherToGroup(int groupId, int teacherId)
        {
            Group group = context.Groups.FirstOrDefault(x => x.Id == groupId);
            Teacher teacher= context.Teachers.FirstOrDefault(x => x.Id == teacherId);
            if (group != null && teacher != null)
            {
                GroupTeacher groupTeacher = context.GroupTeachers.FirstOrDefault(x=>x.GroupID==groupId&&x.TeacherID==teacherId);
                if (groupTeacher != null)
                {
                    return false;
                }   
                GroupTeacher newGroupTeacher = new GroupTeacher() { GroupID = group.Id, TeacherID = teacher.Id };
                context.GroupTeachers.Add(newGroupTeacher);
                var result = context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }

            }
            return false;
        }

        public bool DeleteTeacherFromGroup(int groupId, int teacherId)
        {
           
            GroupTeacher groupTeacher =context.GroupTeachers.FirstOrDefault(x=>x.GroupID== groupId&&x.TeacherID== teacherId);
            if (groupTeacher!=null)
            {

                context.GroupTeachers.Remove(groupTeacher);
                var result = context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }

            }
            return false;
        }

        //public List<Group> GetAllGroups()
        //{
        //    return context.Groups.ToList();
        //}
        //public Group CreateGroup(Group group)
        //{
        //    if (group != null)
        //    {
        //        context.Groups.Add(group);
        //        context.SaveChanges();
        //        return group;
        //    }
        //    return null;
        //}

        //public Group DeleteGroup(Group group)
        //{
        //    if (group != null)
        //    {
        //        context.Groups.Remove(group);
        //        context.SaveChanges();
        //        return group;
        //    }
        //    return null;
        //}

        //public Group EditGroup(Group group)
        //{
        //    Group group_ = context.Groups.FirstOrDefault(x => x.Id == group.Id);
        //    if (group_ != null)
        //    {
        //        context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);
        //        context.Entry(group).State = EntityState.Modified;
        //        context.SaveChanges();
        //        return group;
        //    }
        //    return null;
        //}



        //public Group GetGroupById(int id)
        //{
        //    Group group = context.Groups.FirstOrDefault(x => x.Id == id);
        //    if (group != null)
        //    {
        //        return group;
        //    }
        //    return null;
        //}
    }
}
