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
            //this.MyModel = new PlotModel { Title = drug.Name };
            //this.MyModel.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "stanje"));
        }
        public PlotModel MyModel { get; private set; }
    }
}
