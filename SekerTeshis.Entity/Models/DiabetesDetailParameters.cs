using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshis.Entity.Models
{
    public class DiabetesDetailParameters:QueryStringParameters
    {
        public DiabetesDetailParameters()
        {
            OrderBy = "MeasureValue";
        }
        public string? DiabetesName { get; set; }
    }
}
