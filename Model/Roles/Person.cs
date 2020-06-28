// File:    Person.cs
// Author:  fmaster
// Created: Thursday, May 21, 2020 10:21:32 PM
// Purpose: Definition of Class Person

namespace Model.Roles
{
    public abstract class Person : Repository.IIdentifiable<uint>
    {
        private uint id;
        private string name;
        private string surname;
        private string phone;
        private string email;
        private Sex sex;
        private string jmbg;
        private string username;
        private string password;
        private UserType userType = UserType.None;

        protected Person(string name, string surname, string phone, string email, Sex sex, string jmbg, string username, string password, UserType userType)
        {
            id = 0;
            this.name = name;
            this.surname = surname;
            this.phone = phone;
            this.email = email;
            this.sex = sex;
            this.jmbg = jmbg;
            this.username = username;
            this.password = password;
            this.userType = userType;
        }

        protected Person(uint id, string name, string surname, string phone, string email, Sex sex, string jmbg, string username, string password, UserType userType)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.phone = phone;
            this.email = email;
            this.sex = sex;
            this.jmbg = jmbg;
            this.username = username;
            this.password = password;
            this.userType = userType;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Surname
        {
            get => surname;
            set => surname = value;
        }

        public string Phone
        {
            get => phone;
            set => phone = value;
        }

        public string Email
        {
            get => email;
            set => email = value;
        }

        public Sex Sex
        {
            get => sex;
            set => sex = value;
        }

        public string Jmbg => jmbg;

        public UserType UserType
        {
            get => userType;
            set => userType = value;
        }

        public string Username
        {
            get => username;
            set => username = value;
        }

        public string Password
        {
            get => password;
            set => password = value;
        }

        public uint GetId()
        {
            return id;
        }

        public void SetId(uint id)
        {
            this.id = id;
        }

        public string getPersonCommaSeparatedData()
        {
            return id + "," + (int)UserType + "," + Jmbg + "," + Name + "," + Surname + "," + Phone + "," + Email + "," + (int)Sex + "," + Username + "," + Password;
        }

        public bool IsStaff()
        {
            return UserType.Equals(UserType.Doctor) || UserType.Equals(UserType.Manager) || UserType.Equals(UserType.Secretary) || UserType.Equals(UserType.Specialist);
        }
    }
}