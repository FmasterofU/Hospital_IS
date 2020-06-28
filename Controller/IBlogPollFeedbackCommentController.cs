// File:    IBlogPollFeedbackCommentController.cs
// Author:  fmaster
// Created: Monday, June 22, 2020 7:30:59 PM
// Purpose: Definition of Interface IBlogPollFeedbackCommentController

using Model.Blognfeedback;
using System.Collections.Generic;

namespace Controller
{
    public interface IBlogPollFeedbackCommentController
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