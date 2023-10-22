using SekerTeshis.Core.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshis.Entity
{
    public class Diabetes:IEntity
    {
        public int Id { get; set; }
        public bool IsDiabetUser { get; set; }
        public enum DiabetesType
        {
            Tip1,
            Tip2
        }
        public User? User { get; set; }
        public List<DiabetesDetail>? DiabetesDetail { get; set; }
    }
}
