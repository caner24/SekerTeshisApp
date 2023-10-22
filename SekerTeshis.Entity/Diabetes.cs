using SekerTeshis.Core.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshis.Entity
{
    public class Diabetes : IEntity
    {
        public string Id { get; set; }
        public bool IsDiabetUser { get; set; }
        public User? User { get; set; }
        public List<DiabetesDetail>? DiabetesDetail { get; set; }
    }
}
