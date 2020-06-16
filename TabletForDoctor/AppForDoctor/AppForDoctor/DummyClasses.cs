using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;  
using System.Runtime.Serialization;  
using System.Runtime.Serialization.Formatters.Binary;

namespace AppForDoctor
{
    public class SerialTest
    {
        public SerialTest()
        {
            SerializeNow();
            DeSerializeNow();
        }
        public void SerializeNow()
        {
            Drug c = new Drug("sasa", 5);

            try
            {
                using (FileStream fs = File.Create("temp.dat"))
                {
                    //byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                    //fs.Write(info, 0, info.Length);

                    BinaryFormatter b = new BinaryFormatter();
                    b.Serialize(fs, c);
                    fs.Close();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            /*File f = new File("temp.dat");
            Stream s = f.Open(FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(s, c);
            s.Close();*/
        }
        public void DeSerializeNow()
        {
            Drug c = new Drug("sas", 4);

            try
            {
                using (FileStream fs = File.OpenRead("temp.dat"))
                {

                    BinaryFormatter b = new BinaryFormatter();
                    c = (Drug)b.Deserialize(fs);
                    Console.WriteLine("Name :" + c.Name);
                    Console.WriteLine("Amount :" + c.Amount);
                    fs.Close();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            //string path = @"c:\temp\MyTest.txt";
            /*File f = new File("temp.dat");
            Stream s = f.Open(FileMode.Open);
            BinaryFormatter b = new BinaryFormatter();
            c = (Drug)b.Deserialize(s);
            Console.WriteLine("Name :" + c.Name);
            Console.WriteLine("Amount :" + c.Amount);
            s.Close();*/
        }
    }
    [Serializable]
    public class Examination
    {
        private string anamnesis;
        private List<Prescription> prescriptions = new List<Prescription>();
        private List<Referral> referrals = new List<Referral>();
        public Examination(string anamnesis, List<Prescription> drugs, List<Referral> referrals)
        {
            this.anamnesis = anamnesis;
            this.prescriptions = new List<Prescription>();
            this.referrals = new List<Referral>();
            foreach (Prescription p in drugs) this.prescriptions.Add(p);
            foreach (Referral r in referrals) this.referrals.Add(r);
        }

        public string Anamnesis
        {
            get { return anamnesis; }
            set { anamnesis = value; }
        }
        public List<Prescription> Prescriptions
        {
            get { return prescriptions; }
            set { prescriptions = value; }
        }

        public List<Referral> Referrals
        {
            get { return referrals; }
            set { referrals = value; }
        }
    }

    [Serializable]
    public class Drug
    {
        private string name;
        private int amount;
        public Drug(string name, int amount)
        {
            this.name = name;
            this.amount = amount;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
    }

    [Serializable]
    public class Prescription
    {
        private Drug drug;
        private string usage;

        public Prescription(Drug drug, string usage)
        {
            this.drug = drug;
            this.usage = usage;
        }

        public Drug Drug
        {
            get { return drug; }
            set { drug = value; }
        }
        public string Usage
        {
            get { return usage; }
            set { usage = value; }
        }
    }

    [Serializable]
    public class Referral
    {
        private string refType;
        private string note;

        public Referral(string type, string note)
        {
            this.refType = type;
            this.note = note;
        }

        public string RefType
        {
            get { return refType; }
            set { refType = value; }
        }
        public string Note
        {
            get { return note; }
            set { note = value; }
        }
    }

    [Serializable]
    public class Article
    {
        private string title;
        private string content;

        public Article(string title, string content)
        {
            this.title = title;
            this.content = content;
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Content
        {
            get { return content; }
            set { content = value; }
        }
    }

    [Serializable]
    public class User
    {
        private string username;
        private string password;
        private string name;
        private string surname;
        private string adress;
        private string mail;
        private int userType;
        private string patientID;
        private int age;

        public User(string username, string password, string name, string surname, string adress, string mail, int type, int age, string patientID = "0")
        {
            // 1 - doctor
            // 2 - patient
            // 3 - secretary
            // 4 - director
            // 5 - specialist
            this.username = username;
            this.password = password;
            this.name = name;
            this.surname = surname;
            this.adress = adress;
            this.mail = mail;
            this.userType = type;
            this.patientID = patientID;
            this.age = age;
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public string Adress
        {
            get { return adress; }
            set { adress = value; }
        }
        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }
        public int UserType
        {
            get { return userType; }
            set { userType = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string PatientID
        {
            get { return patientID; }
            set { patientID = value; }
        }
    }

    [Serializable]
    public class MedRecord
    {
        private string patientID;
        private List<Examination> examinations = new List<Examination>();

        public MedRecord(string patientID, List<Examination> examinations)
        {
            this.examinations = new List<Examination>();
            this.patientID = patientID;
            foreach (Examination e in examinations) this.examinations.Add(e);
        }

        public string PatientID
        {
            get { return patientID; }
            set { patientID = value; }
        }

        public List<Examination> Examinations
        {
            get { return examinations; }
            set { examinations = value; }
        }
    }

    [Serializable]
    public class ArticleList
    {
        private List<Article> articles = new List<Article>();

        public ArticleList()
        {
            this.articles = new List<Article>();
            this.articles.Add(new Article("Nove prostorije", "Prošle nedelje naša klinika je dobila 4 nove spavaće sobe!"));
            this.articles.Add(new Article("Doniranje krvi", "Svake srede od 7 do 11 prepodne zainteresovani građani mogu donirati krv\nna našoj klinici."));
            //DeSerializeNow();
        }

        public List<Article> Articles
        {
            get { return articles; }
            set { articles = value; }
        }

        /*public void SerializeNow()
        {
            try
            {
                using (FileStream fs = File.Create("articles.data"))
                {
                    BinaryFormatter b = new BinaryFormatter();
                    b.Serialize(fs, articles);
                    fs.Close();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void DeSerializeNow()
        {
            try
            {
                using (FileStream fs = File.OpenRead("articles.data"))
                {

                    BinaryFormatter b = new BinaryFormatter();
                    articles = (List<Article>)b.Deserialize(fs);
                    fs.Close();
                }
            }

            catch (Exception ex)
            {
            }
        }*/
    }

    [Serializable]
    public class DrugList
    {
        private List<string> allDrugNames = new List<string>();

        public DrugList()
        {
            this.allDrugNames = new List<string>();
            this.allDrugNames.Add("Brufen");
            this.allDrugNames.Add("Paracetamol");
            this.allDrugNames.Add("Cefalexin");
            this.allDrugNames.Add("Caffetin");
            this.allDrugNames.Add("Ranisan");
            this.allDrugNames.Add("Andol");
            this.allDrugNames.Add("Bensedin");
            this.allDrugNames.Add("Bromazepam");
            this.allDrugNames.Add("Dilacor");
        }

        public List<string> AllDrugNames
        {
            get { return allDrugNames; }
            set { allDrugNames = value; }
        }

        public static HashSet<string> ContainsInName(string input)
        {
            HashSet<string> ret = new HashSet<string>();
            DrugList list = new DrugList();
            foreach(string s in list.allDrugNames)
            {
                if (s.Contains(input)) ret.Add(s);
            }
            return ret;
        }
    }

    [Serializable]
    public class UserList
    {
        private List<User> allUsers = new List<User>();

        public UserList()
        {
            this.allUsers = new List<User>();
            this.allUsers.Add(new User("pera", "pera", "Pera", "Peric", "Ulica 1", "pera@mail.com", 1, 54));
            this.allUsers.Add(new User("mika", "mika", "Mika", "Mikic", "Ulica 2", "mika@mail.com", 2, 21, "111111"));
            this.allUsers.Add(new User("mara", "mara", "Mara", "Maric", "Ulica 3", "mara@mail.com", 1, 45));
            this.allUsers.Add(new User("steva", "steva", "Steva", "Stevic", "Ulica 4", "steva@mail.com", 3, 39));
            this.allUsers.Add(new User("ivan", "ivan", "Ivan", "Ivic", "Ulica 5", "ivan@mail.com", 1, 65));
            this.allUsers.Add(new User("eva", "eva", "Eva", "Ras", "Ulica 6", "eva@mail.com", 2, 69, "222222"));
            this.allUsers.Add(new User("jan", "jan", "Jan", "Janic", "Ulica 7", "jan@mail.com", 4, 58));
            this.allUsers.Add(new User("aca", "aca", "Aca", "Lukas", "Ulica 8", "aca@mail.com", 5, 34));
            this.allUsers.Add(new User("jova", "jova", "Jova", "Jovic", "Ulica 9", "jova@mail.com", 2, 10, "333333"));
        }

        public List<User> AllUsers
        {
            get { return allUsers; }
            set { allUsers = value; }
        }

        public static User IsDoctor(string mail, string password)
        {
            UserList list = new UserList();
            foreach(User u in list.AllUsers)
            {
                if (u.Mail.Equals(mail) && u.Password.Equals(password) && (u.UserType == 1 || u.UserType == 5)) return u;
            }
            return null;
        }

        public static User getByID(string id)
        {
            UserList list = new UserList();
            foreach(User u in list.AllUsers)
            {
                if (u.PatientID.Equals(id)) return u;
            }
            return null;
        }

        public static List<User> getPatientByName(string name)
        {
            UserList list = new UserList();
            List<User> ret = new List<User>();
            foreach(User u in list.AllUsers)
            {
                if (u.Name.Contains(name) && u.UserType == 2) ret.Add(u);
            }
            return ret;
        }
    }

    [Serializable]
    public class MedRecordList
    {
        private List<MedRecord> medRecords = new List<MedRecord>();

        public MedRecordList()
        {
            Drug d1 = new Drug("Brufen", 1);
            Drug d2 = new Drug("Ranisan", 5);
            Drug d3 = new Drug("Bromazepam", 4);
            Drug d4 = new Drug("Dilacor", 2);
            Drug d5 = new Drug("Bensedin", 1);
            Drug d6 = new Drug("Cefalexin", 1);
            Drug d7 = new Drug("Brufen", 3);
            Drug d8 = new Drug("Paracetamol", 1);
            Drug d9 = new Drug("Cefalexin", 4);

            Prescription p1 = new Prescription(d1, "2 tablete dnevno");
            Prescription p2 = new Prescription(d2, "4 tablete dnevno");
            Prescription p3 = new Prescription(d3, "2 tablete dnevno");
            Prescription p4 = new Prescription(d4, "3 tablete dnevno");
            Prescription p5 = new Prescription(d5, "7 tableta dnevno");
            Prescription p6 = new Prescription(d6, "1 tableta dnevno");
            Prescription p7 = new Prescription(d7, "po potrebi");
            Prescription p8 = new Prescription(d8, "8 tableta dnevno");
            Prescription p9 = new Prescription(d9, "2 tablete dnevno");

            List<Prescription> l1 = new List<Prescription>();
            l1.Add(p1);
            l1.Add(p3);
            l1.Add(p8);

            List<Prescription> l2 = new List<Prescription>();
            l2.Add(p9);

            Referral r1 = new Referral("accessory", "potrebna kolica");
            Referral r2 = new Referral("specialist", "potreban pregled dermatologa");
            Referral r3 = new Referral("lab", "potrebna krvna slika");

            List<Referral> lr1 = new List<Referral>();
            lr1.Add(r1);
            lr1.Add(r3);

            List<Referral> lr2 = new List<Referral>();
            lr2.Add(r2);

            Examination e1 = new Examination("dobro zdravlje", l2, lr1);
            Examination e2 = new Examination("tumor", l1, lr1);
            Examination e3 = new Examination("vrtoglavica izrazena", l1, lr2);

            List<Examination> le1 = new List<Examination>();
            le1.Add(e2);
            le1.Add(e1);

            List<Examination> le2 = new List<Examination>();
            le2.Add(e1);

            List<Examination> le3 = new List<Examination>();
            le3.Add(e1);
            le3.Add(e3);
            le3.Add(e2);

            this.medRecords.Add(new MedRecord("333333", le3));
            this.medRecords.Add(new MedRecord("222222", le1));
            this.medRecords.Add(new MedRecord("111111", le2));
        }

        public List<MedRecord> MedRecords
        {
            get { return medRecords; }
            set { medRecords = value; }
        }

        public static MedRecord getMedHistory(string id)
        {
            MedRecordList list = new MedRecordList();
            foreach(MedRecord m in list.MedRecords)
            {
                if (m.PatientID.Equals(id)) return m;
            }
            return null;
        }
    }
}
