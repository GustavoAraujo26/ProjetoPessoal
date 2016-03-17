using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ProjetoPessoal.Domain.Interfaces;
using ProjetoPessoal.Domain.Interfaces.Repositories;
using ProjetoPessoal.Infra.DataContext;

namespace ProjetoPessoal.Infra.Repositories
{
    /*
        Utilizando o TEntity para tornar a classe genérica
        Implementa o IRepositoryBase
    */
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected Contexto Db;

        public RepositoryBase(Contexto db)
        {
            this.Db = db;
        }

        public void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }

    }
}
