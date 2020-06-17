using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingDirectorMobile.ViewModel
{
    using OxyPlot;
    using OxyPlot.Series;
    using System.Collections.ObjectModel;

    class WorkStatViewModel
    {
        public ObservableCollection<object> doctors = null;

        public WorkStatViewModel()
        {
            this.MyModel = new PlotModel { /*Title = drug.Name*/ };
            //this.MyModel.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "stanje"));
            var area = new AreaSeries();
            area.Points.Add(new DataPoint(0, 0));
            area.Points.Add(new DataPoint(-1, 0));
            area.Points.Add(new DataPoint(-2, 15));
            area.Points.Add(new DataPoint(-3, 5));
            area.Points.Add(new DataPoint(-4, 21));
            area.Points.Add(new DataPoint(-5, 17));
            area.Points.Add(new DataPoint(-6, 13));
            area.Points.Add(new DataPoint(-7, 0));
            area.Points.Add(new DataPoint(-8, 0));
            area.Points.Add(new DataPoint(-9, 16));
            this.MyModel.Series.Add(area);
        }

        public PlotModel MyModel { get; private set; }
    }
}
