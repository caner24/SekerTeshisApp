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
        public DateOnly MinCreatedDate { get; set; }
        public DateOnly MaxCreatedDate { get; set; }

        public bool ValidateYearRange => MaxCreatedDate > MinCreatedDate;
        public string? DiabetesName { get; set; }
    }
}
