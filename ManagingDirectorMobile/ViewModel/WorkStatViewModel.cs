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
            this.MyModel.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "stanje"));
        }

        public PlotModel MyModel { get; private set; }
    }
}
