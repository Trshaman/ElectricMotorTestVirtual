﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace ElectricMotorTestVirtual.Entity
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private Context _context = null;
        private DbSet<T> table = null;

        public GenericRepository()
        {
            this._context = new Context(Program.ConnectionString);
            table = _context.Set<T>();
        }

        public GenericRepository(Context context)
        {
            this._context=context;
            table = _context.Set<T>();  
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public T GetLastRow()
        {
            return table.ToArray().Last();
        }
    }
}
