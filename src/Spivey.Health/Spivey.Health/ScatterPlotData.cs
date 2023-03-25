using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spivey.Health
{
    public class ScatterPlotData
    {
        public string[] Labels { get; set; }
        public double[] Values { get; set; }
        public ScatterPlotDataSet[] DataSets { get; set; }
        
        public ScatterPlotData() 
        {
            Labels = new string[0];
            Values = new double[0];
            DataSets = new ScatterPlotDataSet[0];
        }
    }
}
