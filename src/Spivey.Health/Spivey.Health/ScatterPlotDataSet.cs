using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spivey.Health
{
    public class ScatterPlotDataSet
    {
        public string? Type { get; set; }
        public ScatterPlotDataPoint[] Values { get; set; }

        public ScatterPlotDataSet() 
        {
            Values = new ScatterPlotDataPoint[0];
        }
    }
}
