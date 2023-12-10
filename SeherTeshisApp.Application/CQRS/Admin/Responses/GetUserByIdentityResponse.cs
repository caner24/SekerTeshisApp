using SekerTeshis.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshisApp.Application.CQRS.Admin.Responses
{
    public class GetUserByIdentityResponse
    {
        public List<DiabetesDetail> DiabetesDetail { get; set; }
    }
}
