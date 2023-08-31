﻿using Microsoft.EntityFrameworkCore;
using RestauranteAPI.Entity;
using RestauranteAPI.Interface;

namespace RestauranteAPI.Repository
{
    public class EFRepository<T> : IRepository<T> where T : Entidade
    {
        protected ApplicationDbContext _context;
        protected DbSet<T> _dbset;

        public EFRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public void AddNew(T entidade)
        {
            _dbset.Add(entidade);
            _context.SaveChanges();
        }

        public void Update(T entidade)
        {
            _dbset.Update(entidade);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbset.Remove(GetById(id));
            _context.SaveChanges();
        }

        public IList<T> GetAll()
        {
            return _dbset.ToList();
        }

        public T GetById(int id)
        {
            return _dbset.FirstOrDefault(t => t.Id == id);
        }
    }
}
