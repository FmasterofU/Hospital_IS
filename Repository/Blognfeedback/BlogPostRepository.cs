// File:    BlogPostRepository.cs
// Author:  fmaster
// Created: Saturday, May 30, 2020 9:17:12 PM
// Purpose: Definition of Class BlogPostRepository

using Model.Blognfeedback;
using System;
using System.Collections.Generic;

namespace Repository.Blognfeedback
{
   public class BlogPostRepository : Repository.IRepositoryCRUD<BlogPost, uint>
   {
      private string path;
      private static BlogPostRepository instance = null;

        private BlogPostRepository() {}
      
      public static BlogPostRepository GetInstance()
      {
            if (instance == null) instance = new BlogPostRepository();
            return instance;
      }

        public bool Delete(uint id)
        {
            throw new NotImplementedException();
        }

        public BlogPost Create(BlogPost item)
        {
            throw new NotImplementedException();
        }

        public BlogPost Read(uint id)
        {
            throw new NotImplementedException();
        }

        public BlogPost Update(BlogPost item)
        {
            throw new NotImplementedException();
        }

        public List<BlogPost> GetAll()
        {
            throw new NotImplementedException();
        }
   }
}