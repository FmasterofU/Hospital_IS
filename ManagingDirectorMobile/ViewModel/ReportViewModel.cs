using ManagingDirectorMobile.Model;
using RandomSolutions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingDirectorMobile.ViewModel
{
    class ReportViewModel
    {
        public static void DrugsReport()
        {
            var items = Enumerable.Range(0, Drug.drugs.Count - 1).Select(x => new
            {
                Prop1 = Drug.drugs[x].Name,
                Prop2 = Drug.drugs[x].Code,
                Prop3 = Drug.drugs[x].Number,
                Prop4 = Drug.drugs[x].Threshold
            }) ;

            var pdf = items.ToPdf(scheme =>
            {
                scheme.Title = "Izvještaj o trenutnom stanju lijekova";
                scheme.PageOrientation = ArrayToPdfOrientations.Portrait;
                scheme.PageMarginLeft = 15;
                scheme.AddColumn("Naziv lijeka", x => x.Prop1);
                scheme.AddColumn("Šifra lijeka", x => x.Prop2);
                scheme.AddColumn("Trenutno Stanje", x => x.Prop3);
                scheme.AddColumn("Minimalno potrebno stanje", x => x.Prop4);
            });

            File.WriteAllBytes(@"..\..\Reports\DrugsReport.pdf", pdf);
        }
    }
}
