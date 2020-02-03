using Fetch.OrderLunch.Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Fetch.OrderLunch.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity GetById(int id);
        TEntity GetSingleBySpec(ISpecification<TEntity> spec);
        IEnumerable<TEntity> ListAll();
        IEnumerable<TEntity> List(ISpecification<TEntity> spec);
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        IUnitOfWork unitOfWork { get; }
    }
}
