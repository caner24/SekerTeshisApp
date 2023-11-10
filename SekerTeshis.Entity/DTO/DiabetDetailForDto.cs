using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshis.Entity.DTO
{
    public record DiabetDetailForDto
    {
        public string DiabetesId { get; init; }
        public string MeasureType { get; init; }
        public int MeasureValue { get; init; }
    }
}
