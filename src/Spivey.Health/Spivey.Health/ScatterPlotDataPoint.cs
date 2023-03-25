using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spivey.Health
{
    public class ScatterPlotDataPoint
    {
        public DateTime Date { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }
    }
}
