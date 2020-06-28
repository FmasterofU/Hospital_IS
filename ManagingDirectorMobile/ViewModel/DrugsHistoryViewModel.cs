using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Medicine;

namespace ManagingDirectorMobile.ViewModel
{
    using System;
    using Controller;
    using ManagingDirectorMobile.Model;

    using OxyPlot;
    using OxyPlot.Series;
    class DrugsHistoryViewModel
    {
        Controller.IDrugController c = new DrugController();
        public DrugsHistoryViewModel(Drug drug)
        {
            this.MyModel = new PlotModel { Title = drug.Name };
            var area = new AreaSeries();
            List<DrugStateChange> dsc = c.GetAllDrugStateChange(drug);
            for(int i=0; i<dsc.Count; i++)
                area.Points.Add(new DataPoint(-DateTime.Now.Subtract(dsc[i].Timestamp).Days, dsc[i].TotalNumber));
            this.MyModel.Series.Add(area);
            //this.MyModel.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "stanje"));
        }

        public PlotModel MyModel { get; private set; }
    }
}
