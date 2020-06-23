// File:    BlogPollFeedbackService.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:18:25 PM
// Purpose: Definition of Class BlogPollFeedbackService

using Model.Appointments;
using Model.Blognfeedback;
using System;
using System.Collections.Generic;

namespace Service
{
    public class BlogPollFeedbackService : IBlogPollFeedbackCommentService
    {
        public bool AddBlogPost(BlogPost blogPost)
        {
            throw new NotImplementedException();
        }

        public bool AddComment(Appointment appoinment)
        {
            throw new NotImplementedException();
        }

        public bool AddFeedback()
        {
            throw new NotImplementedException();
        }

        public bool CreatePolll(Poll poll)
        {
            throw new NotImplementedException();
        }

        public bool DeleteBlogPost(BlogPost blogPost)
        {
            throw new NotImplementedException();
        }

        public List<BlogPost> GetAllBlogPosts()
        {
            throw new NotImplementedException();
        }

        public List<AppFeedback> GetAllFeedback()
        {
            throw new NotImplementedException();
        }

        public List<Poll> GetAllPoll()
        {
            throw new NotImplementedException();
        }
    }
}