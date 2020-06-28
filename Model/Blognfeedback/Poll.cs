// File:    Poll.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class Poll

using Model.Roles;
using System;

namespace Model.Blognfeedback
{
    public class Poll : Repository.IIdentifiable<uint>
    {
        private uint id;
        private Array questions;
        private Array answers;

        public Poll(Array questions, Array answers, Patient patient)
        {
            id = 0;
            this.questions = questions;
            this.answers = answers;
            this.patient = patient;
        }

        public Array Questions
        {
            get => questions;
            set => questions = value;
        }

        public Array Answers
        {
            get => answers;
            set => answers = value;
        }

        public Model.Roles.Patient patient;

        public uint GetId()
        {
            return id;
        }

        public void SetId(uint id)
        {
            this.id = id;
        }
    }
}