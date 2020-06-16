using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingDirectorMobile.Model
{
    public class Drug
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public int Number { get; set; }

        public int Threshold { get; set; }

        public string Details { get { return String.Format("šifra: {0}\nminimum: {1}\nbroj: {2}", Code, Threshold, Number); } }

        public static ObservableCollection<Drug> drugs = new ObservableCollection<Drug>();

        public static ObservableCollection<Drug> GetDrugList()
        {
            if (drugs.Count == 0)
            {
                drugs.Add(new Drug() { Name = "Hydroxychloroquine", Code = "AXEL", Number = 69, Threshold = 70 });
                drugs.Add(new Drug() { Name = "Antiretroviral", Code = "FROG", Number = 70, Threshold = 69 });
                drugs.Add(new Drug() { Name = "Amoksicilin", Code = "MAX", Number = 70, Threshold = 69 });
                drugs.Add(new Drug() { Name = "Sumamaed", Code = "RETARD", Number = 70, Threshold = 69 });
                drugs.Add(new Drug() { Name = "Paracetamol", Code = "NESTO", Number = 70, Threshold = 69 });
                drugs.Add(new Drug() { Name = "Drugo", Code = "FROG1", Number = 70, Threshold = 100 });
                drugs.Add(new Drug() { Name = "Penicilin", Code = "FROG12", Number = 200, Threshold = 1000 });
                drugs.Add(new Drug() { Name = "Cefaleksin", Code = "CEFF", Number = 90, Threshold = 10 });
                drugs.Add(new Drug() { Name = "Naturoplex", Code = "NAT", Number = 20, Threshold = 3 });
                drugs.Add(new Drug() { Name = "Lamital", Code = "SMASHY", Number = 20, Threshold = 15 });
                drugs.Add(new Drug() { Name = "Nemam vise ideja", Code = "NA", Number = 20, Threshold = 3 });
                drugs.Add(new Drug() { Name = "Aspirin", Code = "ASP", Number = 130, Threshold = 1410 });
            }
            return drugs;
        }
    }
}
