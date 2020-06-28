// File:    IIdentifiable.cs
// Author:  fmaster
// Created: Sunday, May 31, 2020 8:27:07 AM
// Purpose: Definition of Interface IIdentifiable

namespace Repository
{
    public interface IIdentifiable<T>
    {
        T GetId();

        void SetId(T id);

    }
}