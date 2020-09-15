using StudentGroupWebApi.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentGroupWebApi.Models
{
    public class TeacherRepository:GeneralRepo<Teacher>,ITeacherRepository
    {
        public TeacherRepository(ApplicationContext context)
            :base(context)
        {

        }

    }
}
