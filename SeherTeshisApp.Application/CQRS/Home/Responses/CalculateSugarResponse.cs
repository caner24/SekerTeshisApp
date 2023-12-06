using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshisApp.Application.CQRS.Home.Responses
{
    public class CalculateSugarResponse
    {
        public DateTime DateTime { get; set; }
        public string Type { get; set; }

        public string MailAdress { get; set; }

        public string Morning { get; set; }

        public string Afternoon { get; set; }

        public string Evening { get; set; }

        public string AfternoonExercises { get; set; }

        public string EveningExercises { get; set; }
    }
}
