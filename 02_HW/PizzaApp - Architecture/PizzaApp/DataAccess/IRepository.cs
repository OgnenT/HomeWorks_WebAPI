﻿using System.Collections.Generic;

namespace DataAccess
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        int Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
