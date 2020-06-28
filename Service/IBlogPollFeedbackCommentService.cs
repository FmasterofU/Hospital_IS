// File:    IBlogPollFeedbackCommentService.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:18:25 PM
// Purpose: Definition of Interface IBlogPollFeedbackCommentService

using Model.Blognfeedback;
using System.Collections.Generic;

namespace Service
{
    public interface IBlogPollFeedbackCommentService
    {
        List<BlogPost> GetAllBlogPosts();

        bool AddBlogPost(Model.Blognfeedback.BlogPost blogPost);

        bool DeleteBlogPost(Model.Blognfeedback.BlogPost blogPost);

        bool CreatePolll(Model.Blognfeedback.Poll poll);

        List<Poll> GetAllPoll();

        bool AddFeedback();

        List<AppFeedback> GetAllFeedback();

        bool AddComment(Model.Appointments.Appointment appoinment);

    }
}