using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingDirectorMobile.ViewModel
{
    using System;
    using ManagingDirectorMobile.Model;
    using OxyPlot;
    using OxyPlot.Series;
    class DrugsHistoryViewModel
    {
        public DrugsHistoryViewModel(Drug drug)
        {
            this.MyModel = new PlotModel { Title = drug.Name };
            var area = new AreaSeries();
            for(int i=0; i<drug.drugHistory.Count; i++)
                area.Points.Add(new DataPoint(-DateTime.Now.Subtract(drug.drugHistory[i].Item1).Days, drug.drugHistory[i].Item2));
            this.MyModel.Series.Add(area);
            //this.MyModel.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "stanje"));
        }

        public PlotModel MyModel { get; private set; }
    }
}
