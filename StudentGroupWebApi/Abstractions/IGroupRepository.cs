using StudentGroupWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentGroupWebApi.Abstractions
{
    public interface IGroupRepository:IGeneralRepo<Group>
    {
        bool AddTeacherToGroup(int groupId,int teacherId);
        bool DeleteTeacherFromGroup(int groupId, int teacherId);
    }
}
