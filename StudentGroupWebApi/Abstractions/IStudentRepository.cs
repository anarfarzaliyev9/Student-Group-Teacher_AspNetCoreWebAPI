using StudentGroupWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentGroupWebApi.Abstractions
{
    public interface IStudentRepository:IGeneralRepo<Student>
    {
        bool AddStudentToGroup(int studentId,int groupId);

        object GetStudentsWithGroups();
    }
}
