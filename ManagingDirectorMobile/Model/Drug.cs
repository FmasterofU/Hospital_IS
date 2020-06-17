using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
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
                var temp = new Drug() { Name = "Hydroxychloroquine", Code = "AXEL", Number = 69, Threshold = 70 };
                temp.drugHistory.AddRange(historydummy());
                foreach (DrugBatch db in drugbatchesdummy())
                    temp.drugBatches.Add(db);
                drugs.Add(temp);
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

        public List<Tuple<DateTime, int>> drugHistory = new List<Tuple<DateTime, int>>();

        public static List<Tuple<DateTime, int>> historydummy()
        {
            var ret = new List<Tuple<DateTime, int>>();
            ret.Insert(0, new Tuple<DateTime, int>(DateTime.Today.AddDays(-5), 32));
            ret.Insert(0, new Tuple<DateTime, int>(DateTime.Today.AddDays(-3), 75));
            ret.Insert(0, new Tuple<DateTime, int>(DateTime.Today.AddDays(-2), 60));
            ret.Insert(0, new Tuple<DateTime, int>(DateTime.Today, 69));
            return ret;
        }

        public ObservableCollection<DrugBatch> drugBatches = new ObservableCollection<DrugBatch>();

        public static ObservableCollection<DrugBatch> drugbatchesdummy()
        {
            var ret = new ObservableCollection<DrugBatch>();
            ret.Add(new DrugBatch() { EXP = DateTime.Today, Quantity = 32, Code = "NES1" });
            ret.Add(new DrugBatch() { EXP = DateTime.Today.AddDays(30), Quantity = 12, Code = "YAS30" });
            ret.Add(new DrugBatch() { EXP = DateTime.Today.AddDays(73), Quantity = 15, Code = "NYAE" });
            ret.Add(new DrugBatch() { EXP = DateTime.Today.AddDays(180), Quantity = 10, Code = "STAGOD" });
            return ret;
        }
    }
}
