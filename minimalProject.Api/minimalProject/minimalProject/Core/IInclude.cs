﻿namespace minimalProject.Core
{

    public interface IInclude<TEntity> where TEntity : class
    {
        T Execute<T>(T query) where T : IQueryable<TEntity>;
    }
}
