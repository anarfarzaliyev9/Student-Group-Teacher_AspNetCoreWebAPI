using Microsoft.EntityFrameworkCore;
using StudentGroupWebApi.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentGroupWebApi.Models
{
    public class GeneralRepo<T> : IGeneralRepo<T> where T : class
    {
        private readonly ApplicationContext context;
        private readonly DbSet<T> db;
        public GeneralRepo(ApplicationContext context)
        {
            this.context = context;
            db = context.Set<T>();
        }
        public List<T> GetAll()
        {
            return db.ToList();
        }
        public T Create(T data)
        {
            if (data != null)
            {
                db.Add(data);
                context.SaveChanges();
                return data;
            }
            return null;
        }

        public bool Delete(int id)
        {
            var data = db.Find(id);
            if (context.Entry(data).State == EntityState.Detached)
            {
                db.Attach(data);
            }  
            db.Remove(data);
            var result=context.SaveChanges();
            if (result>0)
            {
                return true;
            }
            return false;
        }

        public bool Edit(T data)
        {

            db.Attach(data);
            context.Entry(data).State = EntityState.Modified;
            var result = context.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            return false;

        }

        public T GetById(int id)
        {
            var data = db.Find(id);
            return data;
        }



        
    }
}
