using SekerTeshis.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshisApp.Application.CQRS.Home.Responses
{
    public class Last7DiabetesResponse
    {
        public Last7DiabetesResponse()
        {
            DiabetesDetail = new List<DiabetesDetail>();
        }
        public List<DiabetesDetail> DiabetesDetail { get; set; }
    }
}
