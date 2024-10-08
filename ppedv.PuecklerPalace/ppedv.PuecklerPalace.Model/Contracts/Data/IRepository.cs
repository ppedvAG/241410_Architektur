﻿using ppedv.PuecklerPalace.Model.DomainModel;

namespace ppedv.PuecklerPalace.Model.Contracts.Data
{
    public interface IRepository
    {
        IQueryable<T> GetAll<T>() where T : Entity;
        T? Get<T>(int id) where T : Entity;

        void Add<T>(T entity) where T : Entity;
        void Delete<T>(T entity) where T : Entity;
        void Update<T>(T entity) where T : Entity;

        int Save();
    }
}
