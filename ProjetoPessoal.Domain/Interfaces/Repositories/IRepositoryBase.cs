using System.Collections.Generic;

namespace ProjetoPessoal.Domain.Interfaces.Repositories
{
    /* 
        Informando que o repositório é genérico através do TEntity e que sempre será uma classe
    */
    public interface IRepositoryBase<TEntity> where TEntity : class 
    {
        //Adicionando os métodos genéricos

        //Método Adicionar
        void Add(TEntity obj);

        //Método Buscar por um Id
        TEntity GetById(int id);

        //Método para recuperar uma lista com todas as entidades
        IEnumerable<TEntity> GetAll();

        //Método Atualizar
        void Update(TEntity obj);

        //Método Remover
        void Remove(TEntity obj);

        void Dispose();
    }
}
