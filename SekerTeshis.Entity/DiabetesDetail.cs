using SekerTeshis.Core.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshis.Entity
{
    public class DiabetesDetail : IEntity
    {
        public DiabetesDetail()
        {
            Food = new Food();
            Exercises = new Exercises();
        }
        public int Id { get; set; }
        public string Situation { get; set; }
        public string MeasureType { get; set; }
        public DateTime MeasureDate { get; set; }
        public string? DiabetesId { get; set; }
        public int MeasureValue { get; set; }
        public Diabetes? Diabetes { get; set; }
        public Food Food { get; set; }
        public Exercises Exercises { get; set; }
    }
}
