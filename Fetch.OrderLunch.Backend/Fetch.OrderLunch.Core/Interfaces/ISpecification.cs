using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Fetch.OrderLunch.Core.Interfaces
{
    public interface ISpecification<TEntity>
    {
        Expression<Func<TEntity, bool>> Criteria { get; }
        List<Expression<Func<TEntity, object>>> Includes { get; }
        List<string> IncludeStrings { get; }
    }
}
