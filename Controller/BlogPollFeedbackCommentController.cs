// File:    BlogPollFeedbackCommentController.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:35:07 PM
// Purpose: Definition of Class BlogPollFeedbackCommentController

using Model.Appointments;
using Model.Blognfeedback;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class BlogPollFeedbackCommentController : IBlogPollFeedbackCommentController
    {
        public Service.IBlogPollFeedbackCommentService iBlogPollFeedbackCommentService;

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