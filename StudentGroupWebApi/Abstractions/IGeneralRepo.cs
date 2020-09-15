using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentGroupWebApi.Abstractions
{
    public interface IGeneralRepo<T>
    {
        List<T> GetAll();
        T Create(T data);
        bool Edit(T data);
        bool Delete(int id);
        T GetById(int id);
    }
}
