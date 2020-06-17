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
    class RoomOccupancyHistoryViewModel
    {
        public RoomOccupancyHistoryViewModel(Drug drug)
        {
            this.MyModel = new PlotModel { Title = "Intenzivna njega 1" };
            //this.MyModel.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "stanje"));
            var area = new AreaSeries();
            area.Points.Add(new DataPoint(0, 2));
            area.Points.Add(new DataPoint(-1, 2));
            area.Points.Add(new DataPoint(-2, 2));
            area.Points.Add(new DataPoint(-3, 3));
            area.Points.Add(new DataPoint(-4, 4));
            area.Points.Add(new DataPoint(-5, 4));
            area.Points.Add(new DataPoint(-6, 3));
            area.Points.Add(new DataPoint(-7, 4));
            area.Points.Add(new DataPoint(-8, 4));
            area.Points.Add(new DataPoint(-9, 2));
            this.MyModel.Series.Add(area);
        }
        public PlotModel MyModel { get; private set; }
    }
}
