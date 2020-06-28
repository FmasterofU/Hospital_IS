// File:    IRepositoryCRUD.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 4:25:54 PM
// Purpose: Definition of Interface IRepositoryCRUD

using System.Collections.Generic;

namespace Repository
{
    public interface IRepositoryCRUD<T, E>
    {
        bool Delete(E id);

        T Create(T item);

        T Read(E id);

        T Update(T item);

        List<T> GetAll();

    }
}